using System;
using System.Collections.Generic;

namespace MerchandiseService.Domain.Exceptions
{
    public class VOValidationException : DomainException
    {
        public VOValidationException(Type type, object value, IEnumerable<string> errors)
            : base($"{type} validation errors: {string.Join(',', errors)}. Actual value was {value}.")
        {
        }
    }
}