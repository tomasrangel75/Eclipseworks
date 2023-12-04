using Eclipseworks.Domain.Entities.Enums;
using System;

namespace Eclipseworks.Application.DTOs.Tarefa.Commands
{
    public class CreateTarefaDto
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTimeOffset DataVencimento { get; set; }

        public int Prioridade { get; set; }

        public int ProjetoId { get; set; }

        public int UserId { get; set; }
    }
}
