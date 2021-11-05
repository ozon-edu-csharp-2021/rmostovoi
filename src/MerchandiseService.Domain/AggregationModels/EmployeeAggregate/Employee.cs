using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public record Employee(EmployeeId Id) : Entity;
}