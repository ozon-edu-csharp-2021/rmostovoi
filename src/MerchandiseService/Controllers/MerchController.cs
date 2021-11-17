using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Application.Commands.MerchItemAggregate;
using MerchandiseService.Application.Queries.GetIssuedMerchInfoAggregate;
using MerchandiseService.HttpModels.Requests.Merch.V1;
using MerchandiseService.HttpModels.Responses.Merch.V1;
using MerchandiseService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/merch")]
    public class MerchController : ControllerBase
    {
        private readonly IModelsMapperService _mapper;
        private readonly IMediator _mediator;

        public MerchController(IMediator mediator, IModelsMapperService mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("issue")]
        public async Task<ActionResult<V1IssueMerchResponse>> IssueMerch(
            V1IssueMerchRequest request,
            CancellationToken cancellationToken)
        {
            var command = new IssueMerchCommand(request.Sku, request.Quantity, request.EmployeeId);
            var result = await _mediator.Send(command, cancellationToken);
            return _mapper.MapToHttp(result);
        }

        [HttpPost("get_issued_merch_info")]
        public async Task<ActionResult<V1GetIssuedMerchInfoResponse>> GetIssuedMerchInfo(
            V1MerchInfoRequest request,
            CancellationToken cancellationToken)
        {
            var query = new GetIssuedMerchInfoQuery(request.EmployeeId);
            var response = await _mediator.Send(query, cancellationToken);
            return _mapper.MapToHttp(response);
        }
    }
}