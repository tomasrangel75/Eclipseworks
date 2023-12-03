using Eclipseworks.Domain.Entities.Enums;

namespace Eclipseworks.Application.DTOs.Tarefa.Commands
{
    public class UpdateTarefaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTimeOffset DataVencimento { get; set; }

        public StatusTarefaEnum Status { get; set; }

        public int UserId { get; set; }
    }
}
