using AutoMapper;
using Eclipseworks.Application.DTOs.Projeto.Commands;
using Eclipseworks.Application.DTOs.Projeto.Queries;
using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Application.Interfaces.Services;
using Eclipseworks.Application.Interfaces.Validacao;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Entities.Enums;
using Eclipseworks.Shared;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.ComponentModel.DataAnnotations;

namespace Eclipseworks.Services.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjetoRepository _projetoRepository;
        private readonly IMapper _mapper;

        public ProjetoService(IUnitOfWork unitOfWork, IProjetoRepository projetoRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _projetoRepository = projetoRepository;
            _mapper = mapper;
        }

        #region commands

        public async Task<Result<int>> CriarProjeto(CreateProjetoDto command)
        {
            try
            {
                #region validacao

                List<string>? errorMessages = new();
                var validador = new ValidaProjeto();
                var result = validador.Validate(command);
                if (!result.IsValid)
                {
                    errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                    return await Result<int>.FailureAsync(errorMessages);
                }

                var validaNome = await _projetoRepository.VerificaNomeProjeto(command.Nome);

                if (validaNome)
                {
                    errorMessages.Add("Nome já utilizado.") ;
                    return await Result<int>.FailureAsync(errorMessages);
                }

                #endregion

                var projeto = new Projeto {
                    Nome = command.Nome?.Trim(), 
                    Descricao = command.Descricao, 
                    Status =  StatusProjetoEnum.ativo,
                    CriadoPor = command.UserId,
                    DataCriacao = DateTimeOffset.Now};

                projeto = await _unitOfWork.Repository<Projeto>().AddAsync(projeto);

                await _unitOfWork.Save();

                return await Result<int>.SuccessAsync("Projeto criado com sucesso.");
            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync(ex);
            }
        }
                
        public async Task<Result<int>> ExcluirProjeto(DeleteProjetoDto command)
        {
            try
            {
                var projeto = await _unitOfWork.Repository<Projeto>().GetByIdAsync(command.Id);

                if (projeto != null)
                {
                    var tarefasPendentes = projeto.Tarefas?.Where(x => x.Status == StatusTarefaEnum.pendente)?.OrderBy(p => p.Id);

                    if (tarefasPendentes != null && tarefasPendentes.Any())
                    {
                        var mensagemTarefasPendentes =
                            tarefasPendentes.Select(item => $"A tarefa de ID {item.Id} está pendente. Conclua ou remova a tarefa primeiro.").ToList();

                        return await Result<int>.FailureAsync(mensagemTarefasPendentes);
                    }

                    await _unitOfWork.Repository<Projeto>().DeleteAsync(projeto);

                    await _unitOfWork.Save();

                    return await Result<int>.SuccessAsync(projeto.Id, "Projeto excluído com sucesso.");
                }
                else
                {
                    return await Result<int>.FailureAsync("Projeto não encontrado.");
                }

            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync(ex);
            }

        }

        #endregion

        #region queries

        public async Task<Result<ProjetoResponseDtoList>> ConsultarProjeto(ProjetoFilterRequestDto query)
        {
            var projetos = 
                await _unitOfWork.Repository<Projeto>().Entities
                .Where(p => p.CriadoPor == query.UserId).OrderBy(p => p.Id)
                .ToListAsync();

            var result = new ProjetoResponseDtoList { 
                ProjetoResponseDtos = _mapper.Map<ICollection<ProjetoResponseDto>>(projetos)?.ToList()};
            
            return await Result<ProjetoResponseDtoList>.SuccessAsync(result);
        }

        #endregion
    }
}
