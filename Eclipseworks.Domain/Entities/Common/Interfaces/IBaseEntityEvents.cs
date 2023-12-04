namespace Eclipseworks.Domain.Entities.Common.Interfaces
{
    public interface IBaseEntityEvents
    {
        int CriadoPor { get; set; }
        DateTimeOffset DataCriacao { get; set; }
        int? AtualizadoPor { get; set; }
        DateTimeOffset? DataAtualizacao { get; set; }
    }
}
