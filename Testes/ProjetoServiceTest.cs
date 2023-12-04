using AutoMapper;
using Eclipseworks.Application.DTOs.Projeto.Commands;
using Eclipseworks.Application.DTOs.Projeto.Queries;
using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Application.Interfaces.Services;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Entities.Enums;
using Eclipseworks.Services.Services;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace Testes
{
    [TestFixture]
    public class ProjetoServiceTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjetoRepository _projetoRepository;
        private readonly IMapper _mapper;
        private IProjetoService _projetoService;

        public ProjetoServiceTest()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _projetoRepository = Substitute.For<IProjetoRepository>();
            _mapper = Substitute.For<IMapper>();

        }


        [SetUp]
        public void Setup()
        {
            _projetoService = new ProjetoService(_unitOfWork, _projetoRepository, _mapper);
        }

        [Test]
        public void CadastroSucesso()
        {
            var createProjetoDto = GetCreateProjetoDto();

            _projetoRepository.VerificaNomeProjeto(createProjetoDto.Nome).ReturnsForAnyArgs(false);

            var result = _projetoService.CriarProjeto(createProjetoDto);

            Assert.That(result.Result.Succeeded, Is.True);
        }

        [Test]
        public void CadastroFalhaProjetoNomeNulo()
        {
            var createProjetoDto = GetCreateProjetoDto();

            createProjetoDto.Nome = null;
          
            var result = _projetoService.CriarProjeto(createProjetoDto);

            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Succeeded, Is.False);
                Assert.That(result.Result.Messages[0], Is.EqualTo("O nome do projeto não pode ser nulo."));
            });
        }

        [Test]
        public void CadastroFalhaProjetoNomeVazio()
        {
            var createProjetoDto = GetCreateProjetoDto();

            createProjetoDto.Nome = String.Empty;

            var result = _projetoService.CriarProjeto(createProjetoDto);
            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Succeeded, Is.False);
                Assert.That(result.Result.Messages[0], Is.EqualTo("O nome do projeto deve ser preenchido."));
            });
        }

        [Test]
        public void CadastroFalhaProjetoNomeComCaracterIncorreto()
        {
            var createProjetoDto = GetCreateProjetoDto();

            createProjetoDto.Nome = "ab";

            var result = _projetoService.CriarProjeto(createProjetoDto);
            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Succeeded, Is.False);
                Assert.That(result.Result.Messages[0].Equals("O nome deve ter entre 3 e 50 caracteres."), Is.True);
            });
        }

        [Test]
        public void CadastroFalhaNomeJaCadastrado()
        {
            var createProjetoDto = GetCreateProjetoDto();

            _projetoRepository.VerificaNomeProjeto(createProjetoDto.Nome).ReturnsForAnyArgs(true);

            var result = _projetoService.CriarProjeto(createProjetoDto);

            Assert.That(result.Result.Succeeded, Is.False);
            Assert.That(result.Result.Messages[0], Is.EqualTo("Nome já utilizado."));
        }

        [Test]
        public void CadastroFalhaProjetoDescricaoNula()
        {
            var createProjetoDto = GetCreateProjetoDto();

            createProjetoDto.Descricao = null;


            var result = _projetoService.CriarProjeto(createProjetoDto);
            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Succeeded, Is.False);
                Assert.That(result.Result.Messages[0], Is.EqualTo("A descrição não pode ser nula."));
            });
        }

        [Test]
        public void CadastroFalhaProjetoDescricaoVazia()
        {
            var createProjetoDto = GetCreateProjetoDto();

            createProjetoDto.Descricao = String.Empty;

            var result = _projetoService.CriarProjeto(createProjetoDto);

            Assert.That(result.Result.Succeeded, Is.False);
            Assert.That(result.Result.Messages[0], Is.EqualTo("A descrição do projeto deve ser preenchida."));
        }

        [Test]
        public void CadastroFalhaProjetoDescricaoComCaracterIncorreto()
        {
            var createProjetoDto = GetCreateProjetoDto();

            createProjetoDto.Descricao = "w";

            var result = _projetoService.CriarProjeto(createProjetoDto);

            Assert.That(result.Result.Succeeded, Is.False);
            Assert.That(result.Result.Messages[0].Equals("A descrição deve ter entre 3 e 100 caracteres."), Is.True);
        }
        
        [Test]
        public void ExclusaoSucesso()
        {
            var deleteProjetoDto = GetDeleteProjetoDto();

            var projeto = new Projeto
            {
                Tarefas = new List<Tarefa>()
            {
                   new Tarefa()
                   {
                        Titulo = "Titulo Tarefa",
                        Descricao = "Descricao Tarefa",
                        DataVencimento = DateTimeOffset.Now.AddDays(10),
                        Prioridade = 0,
                        Status = (StatusTarefaEnum)2,
                        CriadoPor = 1,
                        DataCriacao = DateTimeOffset.Now,
                        Id = 1,
                        ProjetoId = 1
                   }
            }
            };

            _unitOfWork.Repository<Projeto>().GetByIdAsync(deleteProjetoDto.Id).ReturnsForAnyArgs(projeto);

            var result = _projetoService.ExcluirProjeto(deleteProjetoDto);
            
            Assert.That(result.Result.Succeeded, Is.True);
            Assert.That(result.Result.Messages[0].Equals("Projeto excluído com sucesso."), Is.True);
        }

        [Test]
        public void ExclusaoFalhaTarefaPendente()
        {
            var deleteProjetoDto = GetDeleteProjetoDto();

            var projeto = new Projeto
            {
                Tarefas = new List<Tarefa>()
            {
                   new Tarefa()
                   {
                        Titulo = "Titulo Tarefa",
                        Descricao = "Descricao Tarefa",
                        DataVencimento = DateTimeOffset.Now.AddDays(10),
                        Prioridade = 0,
                        Status = (StatusTarefaEnum)0,
                        CriadoPor = 1,
                        DataCriacao = DateTimeOffset.Now,
                        Id = 1,
                        ProjetoId = 1
                   }
            }
            };

            _unitOfWork.Repository<Projeto>().GetByIdAsync(deleteProjetoDto.Id).ReturnsForAnyArgs(projeto);

            var result = _projetoService.ExcluirProjeto(deleteProjetoDto);
            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Succeeded, Is.False);
                Assert.That(result.Result.Messages[0].Equals("A tarefa de ID 1 está pendente. Conclua ou remova a tarefa primeiro."), Is.True);
            });
        }

        [Test]
        public void ExclusaoFalhaProjetoInexistente()
        {
            var deleteProjetoDto = GetDeleteProjetoDto();

            var result = _projetoService.ExcluirProjeto(deleteProjetoDto);

            Assert.That(result.Result.Succeeded, Is.False);
            Assert.That(result.Result.Messages[0], Is.EqualTo("Projeto não encontrado."));
        }

        #region private methods

        private static CreateProjetoDto GetCreateProjetoDto()
        {
            return new CreateProjetoDto()
            {
                Nome = "Nome Teste 1",
                Descricao = "Descricao Teste",
                UserId = 1
            };
        }

        private static DeleteProjetoDto GetDeleteProjetoDto()
        {
            return new DeleteProjetoDto()
            {
                Id = 1
            };
        }

        private static ProjetoFilterRequestDto GetProjetoFilterRequestDto()
        {
            return new ProjetoFilterRequestDto() { UserId = 1 };
        }
        #endregion
    }
}