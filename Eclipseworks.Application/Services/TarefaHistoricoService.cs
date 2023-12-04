using Eclipseworks.Application.DTOs.TarefaHistorico.Commands;
using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Application.Interfaces.Services;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Entities.Enums;
using Eclipseworks.Shared;

namespace Eclipseworks.Services.Services
{
    public class TarefaHistoricoService : ITarefaHistoricoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TarefaHistoricoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region commands

        public async Task<Result<int>> CriarTarefaHistorico(CreateTarefaHistoricoDto command, CancellationToken cancellationToken)
        {
            try
            {
                var tarefaHistorico = new TarefaHistorico
                {
                     TarefaId = command.TarefaId,
                     ColunaModificada  = command.ColunaModificada,
                     TipoModificacao =  TipoModificacaoEnum.alteracao,
                     ValorAnterior = command.ValorAnterior,
                     ValorAtual = command.ValorAtual,
                     CriadoPor = command.ModificadoPor,
                     DataCriacao = DateTimeOffset.Now
                };

                tarefaHistorico = await _unitOfWork.Repository<TarefaHistorico>().AddAsync(tarefaHistorico);

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(tarefaHistorico.Id, "Histórico registrado com sucesso.");
            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync(ex);
            }
        }


        public async Task<Result<int>> CriarTarefaComentario(CreateTarefaComentarioDto command, CancellationToken cancellationToken)
        {
            try
            {
                var tarefaHistorico = new TarefaHistorico
                {
                    TarefaId = command.TarefaId,
                    TipoModificacao = TipoModificacaoEnum.adicao,
                    Comentario = command.Comentario,
                    CriadoPor = command.ModificadoPor,
                    DataCriacao = DateTimeOffset.Now
                };

                tarefaHistorico = await _unitOfWork.Repository<TarefaHistorico>().AddAsync(tarefaHistorico);

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(tarefaHistorico.Id, "Comentário registrado com sucesso.");
            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync(ex);
            }
        }

        #endregion
    }
}
