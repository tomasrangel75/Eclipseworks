using Eclipseworks.Domain.Entities.Common;

namespace Eclipseworks.Domain.Entities
{
    public sealed class TarefaComentario : BaseEntity
    {
        public int IdTarefa { get; set; }
        public string? Comentario { get; set; }
        public int? TarefaId { get; set; }

        public Tarefa? Tarefa { get; set; }
    }
}
