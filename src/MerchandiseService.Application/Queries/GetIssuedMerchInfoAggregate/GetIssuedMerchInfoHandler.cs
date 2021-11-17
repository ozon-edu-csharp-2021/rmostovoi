using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Application.Models;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using MerchandiseService.Domain.AggregationModels.MerchItemAggregate;

namespace MerchandiseService.Application.Queries.GetIssuedMerchInfoAggregate
{
    // NOTE: Должен быть типа ответа IAsyncEnumerable, но MediatR пока не поддерживает его: https://github.com/jbogard/MediatR/pull/659#issuecomment-961485271
    public class GetIssuedMerchInfoHandler : IRequestHandler<GetIssuedMerchInfoQuery, GetIssuedMerchInfoResponse>
    {
        private readonly IIssuedMerchRepository _issuedMerchRepository;
        private readonly IMerchItemRepository _merchItemRepository;

        public GetIssuedMerchInfoHandler(IIssuedMerchRepository issuedMerchRepository,
            IMerchItemRepository merchItemRepository)
        {
            _issuedMerchRepository = issuedMerchRepository;
            _merchItemRepository = merchItemRepository;
        }

        public async Task<GetIssuedMerchInfoResponse> Handle(
            GetIssuedMerchInfoQuery request,
            CancellationToken cancellationToken)
        {
            var employeeId = new EmployeeId(new Guid(request.EmployeeId));
            var issuedMerch = await _issuedMerchRepository.FindAllAsync(employeeId, cancellationToken)
                .ToListAsync(cancellationToken);
            var skus = issuedMerch.Select(it => it.Sku).Distinct();
            var items = await _merchItemRepository.GetManyBySkus(skus, cancellationToken)
                .ToDictionaryAsync(it => it.Sku, cancellationToken);
            var models = issuedMerch.Select(it => new IssuedMerchModel(it, items[it.Sku]))
                .ToImmutableList();
            return new GetIssuedMerchInfoResponse(models);
        }
    }
}