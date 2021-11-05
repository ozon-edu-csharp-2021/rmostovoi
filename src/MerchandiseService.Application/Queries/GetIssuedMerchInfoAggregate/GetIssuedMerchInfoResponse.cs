using System.Collections.Generic;
using MerchandiseService.Application.Models;

namespace MerchandiseService.Application.Queries.GetIssuedMerchInfoAggregate
{
    public record GetIssuedMerchInfoResponse(IReadOnlyCollection<IssuedMerchModel> Items);
}