using System.ComponentModel.DataAnnotations.Schema;

namespace Eclipseworks.Domain.Entities.Common.Interfaces
{
    public interface IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
