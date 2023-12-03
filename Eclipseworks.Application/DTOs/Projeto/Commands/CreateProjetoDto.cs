using Eclipseworks.Domain.Entities.Enums;

namespace Eclipseworks.Application.DTOs.Projeto.Commands
{
    public class CreateProjetoDto
    {
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public int UserId { get; set; }
    }
}
