using Eclipseworks.Domain.Entities.Enums;

namespace Eclipseworks.Application.DTOs.TarefaHistorico.Commands
{
    public class CreateTarefaComentarioDto
    {
        public string Comentario { get; set; }
        public int ModificadoPor { get; set; }
        public int TarefaId { get; set; }
    }
}
