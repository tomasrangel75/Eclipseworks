using AutoMapper;
using Eclipseworks.Application.DTOs.Tarefa.Commands;
using Eclipseworks.Application.DTOs.Tarefa.Queries;
using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Services.Services;
using NSubstitute;

namespace Testes
{
    [TestFixture]
    public class TarefaServiceTests
    {
        private TarefaService _tarefaService;
        private IUnitOfWork _unitOfWork;
        private ITarefaRepository _tarefaRepository;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _tarefaRepository = Substitute.For<ITarefaRepository>();
            _mapper = Substitute.For<IMapper>();
            _tarefaService = new TarefaService(_unitOfWork, _tarefaRepository, _mapper);
        }

        [Test]
        public async Task CadastroTarefaSucesso()
        {
            var command = GetCreateTarefaDto();

            _tarefaRepository.VerificaTituloTarefa(command.Titulo).ReturnsForAnyArgs(false);

            var result = await _tarefaService.CriarTarefa(command);

            Assert.Multiple(() =>
            {
                Assert.That(result.Succeeded, Is.True);
                Assert.That(result.Messages[0], Is.EqualTo("Tarefa criada com sucesso."));
            });
        }

        [Test]
        public async Task CadastroFalhaTarefaTituloNulo()
        {
            var command = GetCreateTarefaDto();
            command.Titulo = null;

            var result = await _tarefaService.CriarTarefa(command);

            Assert.Multiple(() =>
            {
                Assert.That(result.Succeeded, Is.False);
                Assert.That(result.Messages[0].Equals("O título da tarefa não pode ser nulo."), Is.True);
            });
        }

        [Test]
        public async Task CadastroFalhaTarefaTituloVazio()
        {
            var command = GetCreateTarefaDto();
            command.Titulo = String.Empty;

            var result = await _tarefaService.CriarTarefa(command);

            Assert.Multiple(() =>
            {
                Assert.That(result.Succeeded, Is.False);
                Assert.That(result.Messages[0].Equals("O título da tarefa deve ser preenchido."), Is.True);
            });
        }

        [Test]
        public async Task CadastroFalhaTarefaTituloCaracteresIncorretos()
        {
            var command = GetCreateTarefaDto();
            command.Titulo = "ab";

            var result = await _tarefaService.CriarTarefa(command);

            Assert.Multiple(() =>
            {
                Assert.That(result.Succeeded, Is.False);
                Assert.That(result.Messages[0].Equals("O título deve ter entre 3 e 50 caracteres."), Is.True);
            });
        }

        [Test]
        public async Task CadastroFalhaTarefaDescricaoNula()
        {
            var command = GetCreateTarefaDto();
            command.Descricao = null;

            var result = await _tarefaService.CriarTarefa(command);

            Assert.Multiple(() =>
            {
                Assert.That(result.Succeeded, Is.False);
                Assert.That(result.Messages[0], Is.EqualTo("A descrição da tarefa não pode ser nula."));
            });
        }

        [Test]
        public async Task CadastroFalhaTarefaDescricaoVazia()
        {
            var command = GetCreateTarefaDto();
            command.Descricao = String.Empty;

            var result = await _tarefaService.CriarTarefa(command);

            Assert.Multiple(() =>
            {
                Assert.That(result.Succeeded, Is.False);
                Assert.That(result.Messages[0], Is.EqualTo("A descrição da tarefa deve ser preenchida."));
            });
        }

        [Test]
        public async Task CadastroFalhaTarefaPrioridade()
        {
            var command = GetCreateTarefaDto();
            command.Prioridade = 4;

            var result = await _tarefaService.CriarTarefa(command);

            Assert.Multiple(() =>
            {
                Assert.That(result.Succeeded, Is.False);
                Assert.That(result.Messages[0], Is.EqualTo("A prioridade deve ser 0 = baixa, 1 = média ou 2 = alta"));
            });
        }

        [Test]
        public async Task CadastroFalhaTarefaDataVencimento()
        {
            var command = GetCreateTarefaDto();
            command.DataVencimento = DateTimeOffset.Now.AddDays(-10);

            var result = await _tarefaService.CriarTarefa(command);

            Assert.Multiple(() =>
            {
                Assert.That(result.Succeeded, Is.False);
                Assert.That(result.Messages[0], Is.EqualTo("A data de vencimento deve ser válida."));
            });
        }
        

        [Test]
        public async Task CadastroFalhaTarefaTituloJaCadastrado()
        {
            var command = GetCreateTarefaDto();

            _tarefaRepository.VerificaTituloTarefa(command.Titulo).ReturnsForAnyArgs(true);

            var result = await _tarefaService.CriarTarefa(command);

            Assert.Multiple(() =>
            {
                Assert.That(result.Succeeded, Is.False);
                Assert.That(result.Messages[0], Is.EqualTo("Título já utilizado."));
            });
        }

        [Test]
        public async Task CadastroFalhaNumeroTarefasExcedido()
        {
            var command = GetCreateTarefaDto();

            _tarefaRepository.VerificaNumeroDeTarefasPorProjeto(command.ProjetoId).ReturnsForAnyArgs(21);

            var result = await _tarefaService.CriarTarefa(command);

            Assert.Multiple(() =>
            {
                Assert.That(result.Succeeded, Is.False);
                Assert.That(result.Messages[0], Is.EqualTo("Número de tarefas excedido."));
            });
        }

        #region private

        private static CreateTarefaDto GetCreateTarefaDto()
        {
            return new CreateTarefaDto
            {
                Titulo = "Titulo",
                Descricao = "Descricao Titulo",
                DataVencimento = DateTimeOffset.Now,
                Prioridade = 0,
                ProjetoId = 1,
                UserId = 1
            };
        }

        #endregion
    }
}