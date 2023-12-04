using Eclipseworks.Application.DTOs.TarefaHistorico.Commands;
using Eclipseworks.Shared;

namespace Eclipseworks.Application.Interfaces.Services
{
    public interface ITarefaHistoricoService
    {
        Task<Result<int>> CriarTarefaHistorico(CreateTarefaHistoricoDto command, CancellationToken cancellationToken);

        Task<Result<int>> CriarTarefaComentario(CreateTarefaComentarioDto command, CancellationToken cancellationToken);
    }
}
