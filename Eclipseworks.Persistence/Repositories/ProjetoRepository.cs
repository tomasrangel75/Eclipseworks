using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Domain.Entities;

namespace Eclipseworks.Persistence.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly IGenericRepository<Projeto> _repository;

        public ProjetoRepository(IGenericRepository<Projeto> repository)
        {
            _repository = repository;
        }
    }
}
