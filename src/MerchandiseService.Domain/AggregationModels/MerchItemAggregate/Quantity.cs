using System;
using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public record Quantity : ValueObject<long>, IComparable<Quantity>
    {
        public Quantity(long value) : base(value)
        {
        }

        public int CompareTo(Quantity? other)
        {
            if (other is null) return 1;
            return Value.CompareTo(other.Value);
        }

        public override IEnumerable<string> GetValidationErrors()
        {
            if (Value < 0) yield return "Quantity should be more or equal to 0";
        }

        public static bool operator >(Quantity a, Quantity b) => a.CompareTo(b) == 1;

        public static bool operator <(Quantity a, Quantity b) => a.CompareTo(b) == -1;
        
        public static bool operator >=(Quantity a, Quantity b) => a.CompareTo(b) is 1 or 0;

        public static bool operator <=(Quantity a, Quantity b) => a.CompareTo(b) is -1 or 0;

        public static Quantity operator +(Quantity a, Quantity b) => new(a.Value + b.Value);

        public static Quantity operator -(Quantity a, Quantity b) => new(a.Value - b.Value);
    }
}