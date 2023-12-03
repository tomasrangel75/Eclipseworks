namespace Eclipseworks.Application.DTOs.Projeto.Queries
{
    public class ProjetoResponseDto
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public string Status { get; set; }

        public DateTimeOffset DataCriacao { get; set; }

        public DateTimeOffset? DataAtualizacao { get; set; }
    }

    public class ProjetoResponseDtoList
    {
        public ProjetoResponseDtoList()
        {
            ProjetoResponseDtos = new List<ProjetoResponseDto>();
        }

        public ICollection<ProjetoResponseDto>? ProjetoResponseDtos { get; set; }
    }
}
