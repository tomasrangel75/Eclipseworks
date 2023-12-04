using Eclipseworks.Domain.Entities.Common;
using Eclipseworks.Domain.Entities.Enums;

namespace Eclipseworks.Domain.Entities
{
    public sealed class TarefaHistorico : BaseEntity
    {
        public string? ColunaModificada { get; set; }
        public TipoModificacaoEnum TipoModificacao { get; set; }
        public string? ValorAnterior { get; set; }
        public string? ValorAtual { get; set; }
        public string? Comentario { get; set; }
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}
