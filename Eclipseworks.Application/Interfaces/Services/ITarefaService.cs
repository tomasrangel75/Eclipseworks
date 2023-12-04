using Eclipseworks.Application.DTOs.Tarefa.Commands;
using Eclipseworks.Application.DTOs.Tarefa.Queries;
using Eclipseworks.Shared;

namespace Eclipseworks.Application.Interfaces.Services
{
    public interface ITarefaService
    {
        Task<Result<int>> CriarTarefa(CreateTarefaDto command);
        Task<Result<int>> AtualizarTarefa(UpdateTarefaDto command);
        Task<Result<int>> ExcluirTarefa(DeleteTarefaDto command);
        Task<Result<TarefaResponseDtoList>> ConsultarTarefa(TarefaFilterRequestDto query);
    }
}
