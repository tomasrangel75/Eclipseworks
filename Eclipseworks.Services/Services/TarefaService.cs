using AutoMapper;
using Eclipseworks.Application.DTOs.Tarefa.Commands;
using Eclipseworks.Application.DTOs.Tarefa.Queries;
using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Application.Interfaces.Services;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Entities.Enums;
using Eclipseworks.Shared;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Eclipseworks.Services.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TarefaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region commands

        public async Task<Result<int>> CriarTarefa(CreateTarefaDto command, CancellationToken cancellationToken)
        {
            try
            {
                var numeroTarefas =
                    _unitOfWork.Repository<Tarefa>().Entities
                   .Where(t => t.ProjetoId == command.ProjetoId).Count();
                if(numeroTarefas == 20) return await Result<int>.FailureAsync("Número de tarefas excedido.");

                var tarefa = new Tarefa
                {
                    Titulo = command.Titulo?.Trim(),
                    Descricao = command.Descricao,
                    Status = StatusTarefaEnum.emAndamento,
                    Prioridade = (PrioridadeTarefaEnum)command.Prioridade,
                    CriadoPor = command.UserId,
                    DataCriacao = DateTimeOffset.Now,
                    ProjetoId = command.ProjetoId
                };

                tarefa = await _unitOfWork.Repository<Tarefa>().AddAsync(tarefa);

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(tarefa.Id, "Tarefa criada com sucesso.");
            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync(ex);
            }
        }

        public async Task<Result<int>> AtualizarTarefa(UpdateTarefaDto command, CancellationToken cancellationToken)
        {
            try
            {
                var tarefa = await _unitOfWork.Repository<Tarefa>().GetByIdAsync(command.Id);
                if (tarefa != null)
                {
                    if(tarefa.Status == StatusTarefaEnum.concluida) return await Result<int>.FailureAsync("Tarefa já concluída não pode ser alterada.");

                    tarefa.Titulo = command.Titulo;
                    tarefa.Descricao = command.Descricao;
                    tarefa.Status = command.Status;
                    tarefa.DataVencimento = command.DataVencimento;
                    tarefa.AtualizadoPor = command.UserId;
                    tarefa.DataAtualizacao = DateTimeOffset.Now;

                    await _unitOfWork.Repository<Tarefa>().UpdateAsync(tarefa);

                    await _unitOfWork.Save(cancellationToken);

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

        public async Task<Result<int>> ExcluirTarefa(DeleteTarefaDto command, CancellationToken cancellationToken)
        {
            try
            {
                var tarefa = await _unitOfWork.Repository<Tarefa>().GetByIdAsync(command.Id);

                if (tarefa != null)
                {
                    await _unitOfWork.Repository<Tarefa>().DeleteAsync(tarefa);

                    await _unitOfWork.Save(cancellationToken);

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

        public async Task<Result<TarefaResponseDtoList>> ConsultarTarefa(TarefaFilterRequestDto query, CancellationToken cancellationToken)
        {
            var tarefas = 
                await _unitOfWork.Repository<Tarefa>().Entities
                .Where(t => t.ProjetoId == query.ProjetoId).OrderBy(t => t.Id)
                .ToListAsync(cancellationToken: cancellationToken);

            var result = new TarefaResponseDtoList
            {
                TarefaResponseDtos = _mapper.Map<ICollection<TarefaResponseDto>>(tarefas)?.ToList()
            };

            return await Result<TarefaResponseDtoList>.SuccessAsync(result);

        }

        #endregion

    }
}
