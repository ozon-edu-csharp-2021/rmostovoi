namespace MerchandiseService.Domain.Models
{
    public abstract record ValueObject<TValue> : ValueObject
    {
        protected ValueObject(TValue value, bool validate = true)
        {
            Value = value;
            if (validate) ThrowIfNotValid();
        }

        public TValue Value { get; }
    }
}