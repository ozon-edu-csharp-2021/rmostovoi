using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate
{
    public interface IIssuedMerchRepository : IRepository<IssuedMerch>
    {
        Task<IssuedMerch?> FindAsync(Sku sku, EmployeeId employeeId, CancellationToken cancellationToken);
        IAsyncEnumerable<IssuedMerch> FindAllAsync(EmployeeId employeeId, CancellationToken cancellationToken);
    }
}