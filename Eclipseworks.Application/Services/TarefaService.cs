using AutoMapper;
using Eclipseworks.Application.DTOs.Tarefa.Commands;
using Eclipseworks.Application.DTOs.Tarefa.Queries;
using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Application.Interfaces.Services;
using Eclipseworks.Application.Interfaces.Validacao;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Entities.Enums;

using Eclipseworks.Shared;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Eclipseworks.Services.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;

        public TarefaService(IUnitOfWork unitOfWork, ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        #region commands

        public async Task<Result<int>> CriarTarefa(CreateTarefaDto command)
        {
            try
            {
                #region validacao

                var numeroTarefas =
                    _unitOfWork.Repository<Tarefa>().Entities
                   .Where(t => t.ProjetoId == command.ProjetoId).Count();
                if(numeroTarefas == 20) return await Result<int>.FailureAsync("Número de tarefas excedido.");


                List<string>? errorMessages = new();
                var validador = new ValidaCriacaoDeTarefa();
                var result = validador.Validate(command);
                if (!result.IsValid)
                {
                    errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                    return await Result<int>.FailureAsync(errorMessages);
                }

                var validaTitulo = await _tarefaRepository.VerificaTituloTarefa(command.Titulo);

                if (validaTitulo)
                {
                    errorMessages.Add("Título já utilizado.");
                    return await Result<int>.FailureAsync(errorMessages);
                }

                #endregion

                var tarefa = new Tarefa
                {
                    Titulo = command.Titulo?.Trim(),
                    Descricao = command.Descricao,
                    Status = StatusTarefaEnum.emAndamento,
                    Prioridade = (PrioridadeTarefaEnum)command.Prioridade,
                    CriadoPor = command.UserId,
                    DataCriacao = DateTimeOffset.Now,
                    DataVencimento = command.DataVencimento,
                    ProjetoId = command.ProjetoId
                };

                tarefa = await _unitOfWork.Repository<Tarefa>().AddAsync(tarefa);

                await _unitOfWork.Save();

                return await Result<int>.SuccessAsync(tarefa.Id, "Tarefa criada com sucesso.");
            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync(ex);
            }
        }

        public async Task<Result<int>> AtualizarTarefa(UpdateTarefaDto command)
        {
            try
            {
                var tarefa = await _unitOfWork.Repository<Tarefa>().GetByIdAsync(command.Id);
                if (tarefa != null)
                {
                    #region validacao

                    if (tarefa.Status == StatusTarefaEnum.concluida) return await Result<int>.FailureAsync("Tarefa já concluída não pode ser alterada.");

                    List<string>? errorMessages = new();
                    var validador = new ValidaAtualizacaoDeTarefa();
                    var result = validador.Validate(command);
                    if (!result.IsValid)
                    {
                        errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                        return await Result<int>.FailureAsync(errorMessages);
                    }

                    var validaTitulo = await _tarefaRepository.VerificaTituloAtualizacaoTarefa(command.Titulo, tarefa.Id);

                    if (validaTitulo)
                    {
                        errorMessages.Add("Título já utilizado.");
                        return await Result<int>.FailureAsync(errorMessages);
                    }

                    #endregion

                    var objOriginal = Clone.CreateNonReferencedObject(tarefa);
                    tarefa.Titulo = command.Titulo;
                    tarefa.Descricao = command.Descricao;
                    tarefa.Status = (StatusTarefaEnum)command.Status;
                    tarefa.DataVencimento = command.DataVencimento;
                    tarefa.AtualizadoPor = command.UserId;
                    tarefa.DataAtualizacao = DateTimeOffset.Now;

                    await _unitOfWork.Repository<Tarefa>().UpdateAsync(tarefa);

                    await RegistrarAlteracoes(objOriginal, command);

                    await _unitOfWork.Save();

                    return await Result<int>.SuccessAsync(tarefa.Id, "Tarefa atualizada com sucesso.");
                }
                else
                {
                    return await Result<int>.FailureAsync("Tarefa não encontrada.");
                }
            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync(ex);
            }

        }
       
      
        public async Task<Result<int>> ExcluirTarefa(DeleteTarefaDto command)
        {
            try
            {
                var tarefa = await _unitOfWork.Repository<Tarefa>().GetByIdAsync(command.Id);

                if (tarefa != null)
                {
                    await _unitOfWork.Repository<Tarefa>().DeleteAsync(tarefa);

                    await _unitOfWork.Save();
                    
                    return await Result<int>.SuccessAsync(tarefa.Id, "Tarefa excluída com sucesso.");
                }
                else
                {
                    return await Result<int>.FailureAsync("Tarefa não encontrada.");
                }

            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync(ex);
            }
        }

        #endregion

        #region queries

        public async Task<Result<TarefaResponseDtoList>> ConsultarTarefa(TarefaFilterRequestDto query)
        {
            var tarefas = 
                await _unitOfWork.Repository<Tarefa>().Entities
                .Where(t => t.ProjetoId == query.ProjetoId).OrderBy(t => t.Id)
                .ToListAsync();

            var result = new TarefaResponseDtoList
            {
                TarefaResponseDtos = _mapper.Map<ICollection<TarefaResponseDto>>(tarefas)?.ToList()
            };

            return await Result<TarefaResponseDtoList>.SuccessAsync(result);

        }

        #endregion

        #region private

        private async Task RegistrarAlteracoes(Tarefa tarefa, UpdateTarefaDto command)
        {
            if (!tarefa.Titulo.Equals(command.Titulo)) await RegistrarAlteracoes(command.UserId, command.Id, "Título", command.Titulo, tarefa.Titulo);
            if (!tarefa.Descricao.Equals(command.Descricao)) await RegistrarAlteracoes(command.UserId, command.Id, "Descrição", command.Descricao, tarefa.Descricao);
            if (tarefa.DataVencimento != command.DataVencimento) await RegistrarAlteracoes(command.UserId, command.Id, "DataVencimento", command.DataVencimento.ToString(), tarefa.DataVencimento.ToString());
            if ((int)tarefa.Status != command.Status) await RegistrarAlteracoes(command.UserId, command.Id, "Status", command.Status.ToString(), tarefa.Status.ToString());
        }

        private async Task RegistrarAlteracoes(int userId, int tarefaId, string? coluna, string? valorAtual, string? valorAnterior)
        {
                var tarefaHistorico = new TarefaHistorico
                {
                    TarefaId = tarefaId,
                    ColunaModificada = coluna,
                    TipoModificacao = TipoModificacaoEnum.alteracao,
                    ValorAnterior = valorAnterior,
                    ValorAtual = valorAtual,
                    CriadoPor = userId,
                    DataCriacao = DateTimeOffset.Now
                };

                tarefaHistorico = await _unitOfWork.Repository<TarefaHistorico>().AddAsync(tarefaHistorico);
              
        }

        

        #endregion

    }
}
