using Eclipseworks.Domain.Entities.Common;
using System.Numerics;

namespace Eclipseworks.Domain.Entities
{
    public sealed class Projeto : BaseEntity
    {
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public int Status { get; set; }

        public IList<Tarefa>? Tarefas { get; set; }
    }
}
