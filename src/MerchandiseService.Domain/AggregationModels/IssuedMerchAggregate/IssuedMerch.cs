using System;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate
{
    public record IssuedMerch(
        Guid Id,
        Sku Sku,
        Quantity Quantity,
        EmployeeId EmployeeId,
        DateTime IssuedAt
    ) : Entity;
}