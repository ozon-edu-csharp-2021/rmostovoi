using System;

namespace MerchandiseService.HttpModels.Responses.Merch.V1
{
    public record V1IssuedMerchModel(long Sku, string Name, long Quantity, DateTime IssuedAt);
}