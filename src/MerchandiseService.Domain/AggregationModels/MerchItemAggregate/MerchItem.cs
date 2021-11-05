using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public record MerchItem(
        MerchItemId Id,
        Sku Sku,
        MerchItemName Name,
        Quantity Quantity,
        ClothingSize? ClothingSize
    ) : Entity
    {
        public bool CanBeIssued(Quantity inquiriedQuantity)
        {
            return inquiriedQuantity <= Quantity;
        }
    }
}