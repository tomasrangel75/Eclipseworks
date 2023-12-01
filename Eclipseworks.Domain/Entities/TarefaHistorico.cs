using Eclipseworks.Domain.Entities.Common;
using Eclipseworks.Domain.Entities.Common.Interfaces;
using Eclipseworks.Domain.Entities.Enums;

namespace Eclipseworks.Domain.Entities
{
    public sealed class TarefaHistorico : BaseEntity
    {
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
        public string ColunaModificada { get; set; }
        public int ModificadoPor { get; set; }
        public DateTime DataModificacao { get; set; }
        public TipoModificacaoEnum TipoModificacao { get; set; }
        public string Modificacao { get; set; }
    }
}
