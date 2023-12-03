﻿using Eclipseworks.Domain.Entities.Enums;

namespace Eclipseworks.Application.DTOs.TarefaHistorico.Commands
{
    public class CreateTarefaHistoricoDto
    {
        public string ColunaModificada { get; set; }
        public int ModificadoPor { get; set; }
        public string Modificacao { get; set; }
        public int TarefaId { get; set; }
    }
}
