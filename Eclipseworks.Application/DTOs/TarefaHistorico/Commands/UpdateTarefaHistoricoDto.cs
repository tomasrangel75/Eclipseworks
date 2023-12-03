using Eclipseworks.Domain.Entities.Enums;

namespace Eclipseworks.Application.DTOs.TarefaHistorico.Commands
{
    public class UpdateTarefaHistoricoDto
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public StatusProjetoEnum Status { get; set; }
    }
}
