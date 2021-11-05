using System.Collections.Generic;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public record MerchPack(MerchPackId Id, IReadOnlyCollection<Sku> Skus) : Entity;
}