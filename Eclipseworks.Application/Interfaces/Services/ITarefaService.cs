using Eclipseworks.Application.DTOs.Projeto.Queries;
using Eclipseworks.Application.DTOs.Tarefa.Commands;
using Eclipseworks.Application.DTOs.Tarefa.Queries;
using Eclipseworks.Shared;

namespace Eclipseworks.Application.Interfaces.Services
{
    public interface ITarefaService
    {
        Task<Result<int>> CriarTarefa(CreateTarefaDto request, CancellationToken cancellationToken);
        Task<Result<int>> AtualizarTarefa(UpdateTarefaDto command, CancellationToken cancellationToken);
        Task<Result<int>> ExcluirTarefa(DeleteTarefaDto command, CancellationToken cancellationToken);
        Task<Result<TarefaResponseDto>> ConsultarTarefa(TarefaFilterRequestDto query, CancellationToken cancellationToken);
    }
}
