using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eclipseworks.Persistence.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly IGenericRepository<Projeto> _repository;

        public ProjetoRepository(IGenericRepository<Projeto> repository)
        {
            _repository = repository;
        }

        public async Task<bool> VerificaNomeProjeto(string nome)
        {
            return await _repository.Entities.AnyAsync(x => x.Nome.Equals(nome.Trim()));
        }
    }
}
