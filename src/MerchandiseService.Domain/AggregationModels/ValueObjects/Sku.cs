using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.ValueObjects
{
    public record Sku : ValueObject<long>
    {
        public Sku(long Value) : base(Value)
        {
        }

        public override IEnumerable<string> GetValidationErrors()
        {
            if (Value < 0) yield return "Sku should be more or equal to 0";
        }
    }
}