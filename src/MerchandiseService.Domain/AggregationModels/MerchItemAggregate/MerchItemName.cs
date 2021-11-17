using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public record MerchItemName : ValueObject<string>
    {
        public MerchItemName(string name) : base(name)
        {
        }

        public override IEnumerable<string> GetValidationErrors() => _noValidation;
    }
}