using System.Collections.Generic;
using System.Linq;
using MerchandiseService.Domain.Exceptions;

namespace MerchandiseService.Domain.Models
{
    public abstract record ValueObject
    {
        protected static readonly IEnumerable<string> _noValidation = Enumerable.Empty<string>();

        public bool IsValid => !GetValidationErrors().Any();
        public abstract IEnumerable<string> GetValidationErrors();

        public void ThrowIfNotValid()
        {
            var errors = GetValidationErrors().ToArray();
            if (errors.Length > 0) throw new VOValidationException(GetType(), ToString(), errors);
        }

        public ValueObject GetCopy()
        {
            return this with { };
        }
    }
}