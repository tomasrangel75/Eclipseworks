using Eclipseworks.Domain.Entities.Enums;

namespace Eclipseworks.Application.DTOs.Tarefa.Commands
{
    public class CreateTarefaDto
    {
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public StatusProjetoEnum Status { get; set; }
    }
}
