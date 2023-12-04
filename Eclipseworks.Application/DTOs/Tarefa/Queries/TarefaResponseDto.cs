using Eclipseworks.Domain.Entities.Enums;

namespace Eclipseworks.Application.DTOs.Tarefa.Queries
{
    public class TarefaResponseDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTimeOffset DataVencimento { get; set; }

        public StatusTarefaEnum Status { get; set; }

        public PrioridadeTarefaEnum Prioridade { get; set; }

        public DateTimeOffset DataCriacao { get; set; }

        public DateTimeOffset? DataAtualizacao { get; set; }
    }

    public class TarefaResponseDtoList
    {
        public TarefaResponseDtoList()
        {
            TarefaResponseDtos = new List<TarefaResponseDto>();
        }

        public ICollection<TarefaResponseDto>? TarefaResponseDtos { get; set; }
    }
}
