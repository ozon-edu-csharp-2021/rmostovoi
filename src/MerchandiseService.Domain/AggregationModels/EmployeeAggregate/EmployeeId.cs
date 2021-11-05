using StronglyTypedIds;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    [StronglyTypedId(converters: StronglyTypedIdConverter.TypeConverter)]
    public partial struct EmployeeId
    {
    }
}