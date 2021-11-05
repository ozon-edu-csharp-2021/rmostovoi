using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchInquiryAggregate
{
    public interface IMerchInquiryRepository : IRepository<MerchInquiry>
    {
        IAsyncEnumerable<MerchInquiry> FindAllAsync(Sku sku, CancellationToken cancellationToken);
    }
}