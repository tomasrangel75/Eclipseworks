namespace Eclipseworks.Application.DTOs.Tarefa.Queries
{
    public class RelatorioResponseDto
    {
        public RelatorioResponseDto()
        {
            NumeroMedioTarefas = 0;
            PermissaoUsuario = true;
        }
        public decimal NumeroMedioTarefas { get; set; }
        public bool PermissaoUsuario { get; set; }
    }
}
