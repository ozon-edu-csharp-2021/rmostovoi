using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Application.Repositories
{
    public class IssuedMerchRepositoryPg : IIssuedMerchRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task AddAsync(IssuedMerch itemToCreate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IssuedMerch itemToUpdate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IssuedMerch?> FindAsync(Sku sku, EmployeeId employeeId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<IssuedMerch> FindAllAsync(EmployeeId employeeId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(IssuedMerch issuedMerch)
        {
            throw new NotImplementedException();
        }
    }
}