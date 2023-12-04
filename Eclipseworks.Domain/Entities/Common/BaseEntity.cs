using Eclipseworks.Domain.Entities.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eclipseworks.Domain.Entities.Common
{
    public abstract class BaseEntity : IEntity, IBaseEntityEvents
    {
        public int Id { get; set; }
        public int CriadoPor { get; set; }
        public DateTimeOffset DataCriacao { get; set; }
        public int? AtualizadoPor { get; set; }
        public DateTimeOffset? DataAtualizacao { get; set; }
        
    }
}
