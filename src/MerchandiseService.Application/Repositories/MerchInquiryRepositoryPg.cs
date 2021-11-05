using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.MerchInquiryAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Application.Repositories
{
    public class MerchInquiryRepositoryPg : IMerchInquiryRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task AddAsync(MerchInquiry entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MerchInquiry entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<MerchInquiry> FindAllAsync(Sku sku, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(MerchInquiry merchInquiry)
        {
            throw new NotImplementedException();
        }
    }
}