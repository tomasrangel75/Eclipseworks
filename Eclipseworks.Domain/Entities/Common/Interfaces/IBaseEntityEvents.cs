namespace Eclipseworks.Domain.Entities.Common.Interfaces
{
    public interface IBaseEntityEvents
    {
        int? CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        int? UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
