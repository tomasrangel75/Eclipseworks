using Eclipseworks.Domain.Entities.Common;
using Eclipseworks.Domain.Entities.Enums;

namespace Eclipseworks.Domain.Entities
{
    public sealed class Tarefa : BaseEntity
    {
        public Tarefa()
        {
            TarefaHistoricos = new List<TarefaHistorico>();
        }
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTimeOffset DataVencimento { get; set; }

        public StatusTarefaEnum Status { get; set; }

        public PrioridadeTarefaEnum Prioridade { get; set; }

        public int ProjetoId { get; set; }

        public Projeto Projeto { get; set; }

        public IList<TarefaHistorico>? TarefaHistoricos { get; set; }
    }
}
