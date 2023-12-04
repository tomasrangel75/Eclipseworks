using System.Numerics;

namespace Eclipseworks.Application.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        Task<bool> VerificaNomeProjeto(string nome);
    }
}
