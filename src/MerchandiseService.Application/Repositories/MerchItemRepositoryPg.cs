using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Application.Repositories
{
    public class MerchItemRepositoryPg : IMerchItemRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task AddAsync(MerchItem itemToCreate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MerchItem itemToUpdate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<MerchItem?> FindAsync(MerchItemId id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<MerchItem?> FindAsync(Sku sku, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<MerchItem> GetManyBySkus(IEnumerable<Sku> skus, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}