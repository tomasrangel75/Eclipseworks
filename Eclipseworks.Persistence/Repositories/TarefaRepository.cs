using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Domain.Entities;

namespace Eclipseworks.Persistence.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly IGenericRepository<Tarefa> _repository;

        public TarefaRepository(IGenericRepository<Tarefa> repository)
        {
            _repository = repository;
        }
    }
}
