using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public interface IMerchItemRepository : IRepository<MerchItem>
    {
        Task<MerchItem?> FindAsync(MerchItemId id, CancellationToken cancellationToken);
        Task<MerchItem?> FindAsync(Sku sku, CancellationToken cancellationToken);
        IAsyncEnumerable<MerchItem> GetManyBySkus(IEnumerable<Sku> skus, CancellationToken cancellationToken);
    }
}