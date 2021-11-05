using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public interface IMerchPackRepository : IRepository<MerchPack>
    {
        Task<MerchPack?> FindAsync(MerchPackId id, CancellationToken cancellationToken);
    }
}