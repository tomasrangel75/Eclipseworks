using Eclipseworks.Application.DTOs.Relatorio.Queries;
using Eclipseworks.Application.DTOs.Tarefa.Queries;
using Eclipseworks.Shared;

namespace Eclipseworks.Application.Interfaces.Services
{
    public interface IRelatorioService
    {
        Task<Result<RelatorioResponseDto>> RelatorioNumeroMedioTarefas(RelatorioFilterRequestDto query, CancellationToken cancellationToken);
    }
}
