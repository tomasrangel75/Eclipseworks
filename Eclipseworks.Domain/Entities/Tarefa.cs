using Eclipseworks.Domain.Entities.Common;

namespace Eclipseworks.Domain.Entities
{
    public sealed class Tarefa : BaseEntity
    {
        public string? Titulo { get; set; }

        public string? Descricao { get; set; }

        public DateTime? DataVencimento { get; set; }

        public int Status { get; set; }

        public int Prioridade { get; set; }

        public int? ProjetoId { get; set; }

        public Projeto? Projeto { get; set; }

        public IList<TarefaComentario>? Comentarios { get; set; }

        public IList<TarefaHistorico>? Historicos { get; set; }
    }
}
