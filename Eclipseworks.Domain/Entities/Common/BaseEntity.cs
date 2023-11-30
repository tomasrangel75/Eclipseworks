using Eclipseworks.Domain.Entities.Common.Interfaces;

namespace Eclipseworks.Domain.Entities.Common
{
    public class BaseEntity : IEntity, IBaseEntityEvents
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
