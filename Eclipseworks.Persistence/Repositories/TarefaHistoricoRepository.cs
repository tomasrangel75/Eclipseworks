using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Domain.Entities;

namespace Eclipseworks.Persistence.Repositories
{
    public class TarefaHistoricoRepository : ITarefaHistoricoRepository
    {
        private readonly IGenericRepository<TarefaHistorico> _repository;

        public TarefaHistoricoRepository(IGenericRepository<TarefaHistorico> repository)
        {
            _repository = repository;
        }
    }
}
