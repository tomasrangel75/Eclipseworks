namespace Eclipseworks.Application.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        Task<bool> VerificaTituloTarefa(string titulo);

        Task<bool> VerificaTituloAtualizacaoTarefa(string titulo, int tarefaId);

        Task<int> VerificaNumeroDeTarefasPorProjeto(int projetoId);
    }
}
