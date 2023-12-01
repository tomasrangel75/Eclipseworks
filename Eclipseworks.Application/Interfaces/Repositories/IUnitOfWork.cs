using Eclipseworks.Domain.Entities.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class, IEntity, IBaseEntityEvents;

        Task<int> Save(CancellationToken cancellationToken);

        Task Rollback();
    }
}
