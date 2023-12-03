using Eclipseworks.Application.DTOs.Tarefa.Commands;
using Eclipseworks.Application.DTOs.Tarefa.Queries;
using Eclipseworks.Shared;

namespace Eclipseworks.Application.Interfaces.Services
{
    public interface ITarefaService
    {
        Task<Result<int>> CriarTarefa(CreateTarefaDto command, CancellationToken cancellationToken);
        Task<Result<int>> AtualizarTarefa(UpdateTarefaDto command, CancellationToken cancellationToken);
        Task<Result<int>> ExcluirTarefa(DeleteTarefaDto command, CancellationToken cancellationToken);
        Task<Result<TarefaResponseDtoList>> ConsultarTarefa(TarefaFilterRequestDto query, CancellationToken cancellationToken);
    }
}
