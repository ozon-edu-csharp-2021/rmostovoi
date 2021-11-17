using System;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchInquiryAggregate
{
    public record MerchInquiry(
        Guid Id,
        Sku Sku,
        Quantity Quantity,
        EmployeeId EmployeeId,
        DateTime RequestedAt
    ) : Entity;
}