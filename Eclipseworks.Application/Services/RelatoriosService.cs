using Eclipseworks.Application.DTOs.Relatorio.Queries;
using Eclipseworks.Application.DTOs.Tarefa.Queries;
using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Application.Interfaces.Services;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Entities.Enums;
using Eclipseworks.Shared;

namespace Eclipseworks.Services.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RelatorioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region queries

        public async Task<Result<RelatorioResponseDto>> RelatorioNumeroMedioTarefas(RelatorioFilterRequestDto query, CancellationToken cancellationToken)
        {
                var result = new RelatorioResponseDto();

                if (VerificarPermissao(query))
                {

                    var numeroTarefas = _unitOfWork.Repository<Tarefa>().Entities
                                .Where(t => t.CriadoPor == query.UserId
                                    && t.Status == StatusTarefaEnum.concluida
                                    && (t.DataAtualizacao >= DateTimeOffset.Now.AddDays(-30))).Count();

                    result.NumeroMedioTarefas = numeroTarefas > 0 ? numeroTarefas / 30 : 0;

                    return await Result<RelatorioResponseDto>.SuccessAsync(result);
                }
                else
                {
                    result.PermissaoUsuario = false;

                    return await Result<RelatorioResponseDto>.FailureAsync(result);
                }
        }

        private bool VerificarPermissao(RelatorioFilterRequestDto query)
        {
            return _unitOfWork.Repository<UserRole>().Entities.Any(x => x.UserId == query.UserId && x.RoleId == 3);
        }

        #endregion
    }
}
