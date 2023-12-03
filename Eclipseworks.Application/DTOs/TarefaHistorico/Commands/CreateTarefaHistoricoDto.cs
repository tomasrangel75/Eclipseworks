using Eclipseworks.Domain.Entities.Enums;

namespace Eclipseworks.Application.DTOs.TarefaHistorico.Commands
{
    public class CreateTarefaHistoricoDto
    {
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public StatusProjetoEnum Status { get; set; }
    }
}
