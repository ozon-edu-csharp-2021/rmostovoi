using StronglyTypedIds;

namespace MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    [StronglyTypedId(converters: StronglyTypedIdConverter.TypeConverter)]
    public partial struct MerchItemId
    {
    }
}