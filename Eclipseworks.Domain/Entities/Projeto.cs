using Eclipseworks.Domain.Entities.Common;
using Eclipseworks.Domain.Entities.Enums;
using System.Numerics;

namespace Eclipseworks.Domain.Entities
{
    public sealed class Projeto : BaseEntity
    {
        public Projeto()
        {
            Tarefas = new List<Tarefa>();
        }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public StatusProjetoEnum Status { get; set; }

        public IList<Tarefa>? Tarefas { get; set; }
    }
}
