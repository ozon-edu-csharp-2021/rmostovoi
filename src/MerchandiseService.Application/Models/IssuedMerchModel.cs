using System;
using MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using MerchandiseService.Domain.AggregationModels.MerchItemAggregate;

namespace MerchandiseService.Application.Models
{
    public record IssuedMerchModel(long Sku, string Name, long Quantity, DateTime IssuedAt)
    {
        public IssuedMerchModel(IssuedMerch issuedMerch, MerchItem merchItem)
            : this(issuedMerch.Sku.Value, merchItem.Name.Value, issuedMerch.Quantity.Value, issuedMerch.IssuedAt)
        {
        }
    }
}