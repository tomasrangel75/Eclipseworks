using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eclipseworks.Persistence.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly IGenericRepository<Tarefa> _repository;

        public TarefaRepository(IGenericRepository<Tarefa> repository)
        {
            _repository = repository;
        }

        public async Task<bool> VerificaTituloTarefa(string titulo)
        {
            return await _repository.Entities.AnyAsync(x => x.Titulo.Equals(titulo.Trim()));
        }

        public async Task<bool> VerificaTituloAtualizacaoTarefa(string titulo, int tarefaId)
        {
            return await _repository.Entities.AnyAsync(x => x.Id != tarefaId && x.Titulo.Equals(titulo.Trim()));
        }
    }
}
