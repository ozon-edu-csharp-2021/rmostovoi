using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Domain.Contracts
{
    public interface IRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }

        Task AddAsync(T entity, CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}