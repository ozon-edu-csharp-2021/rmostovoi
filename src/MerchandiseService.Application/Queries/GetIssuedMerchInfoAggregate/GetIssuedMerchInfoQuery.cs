using System;
using MediatR;

#pragma warning disable 8618

namespace MerchandiseService.Application.Queries.GetIssuedMerchInfoAggregate
{
    public class GetIssuedMerchInfoQuery : IRequest<GetIssuedMerchInfoResponse>
    {
        public GetIssuedMerchInfoQuery(string employeeId)
        {
            EmployeeId = employeeId ?? throw new ArgumentNullException(nameof(employeeId));
        }

        public string EmployeeId { get; init; }
    }
}