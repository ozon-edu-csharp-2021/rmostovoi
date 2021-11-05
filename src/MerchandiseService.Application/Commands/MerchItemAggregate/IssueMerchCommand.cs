using System;
using MediatR;

#pragma warning disable 8618

namespace MerchandiseService.Application.Commands.MerchItemAggregate
{
    public class IssueMerchCommand : IRequest<IssueMerchItemCommandResult>
    {
        public IssueMerchCommand(long sku, long quantity, string employeeId)
        {
            Sku = sku;
            Quantity = quantity;
            EmployeeId = employeeId ?? throw new ArgumentNullException(nameof(employeeId));
        }

        public long Sku { get; init; }
        public long Quantity { get; init; }
        public string EmployeeId { get; init; }
    }
}