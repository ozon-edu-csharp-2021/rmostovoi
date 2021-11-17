using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using MerchandiseService.Application.Commands.MerchItemAggregate;
using MerchandiseService.Application.Queries.GetIssuedMerchInfoAggregate;
using MerchandiseService.Grpc;
using MerchandiseService.Services.Interfaces;
using GetIssuedMerchInfoResponse = MerchandiseService.Grpc.GetIssuedMerchInfoResponse;

namespace MerchandiseService.GrpcServices
{
    public class MerchApiGrpcService : MerchApiGrpc.MerchApiGrpcBase
    {
        private readonly IMediator _mediator;
        private readonly IModelsMapperService _modelsMapper;

        public MerchApiGrpcService(IMediator mediator, IModelsMapperService modelsMapper)
        {
            _mediator = mediator;
            _modelsMapper = modelsMapper;
        }

        public override async Task<IssueMerchResponse> IssueMerch(IssueMerchRequest request, ServerCallContext context)
        {
            var command = new IssueMerchCommand(request.Sku, request.Quantity, request.EmployeeId);
            var result = await _mediator.Send(command, context.CancellationToken);
            return _modelsMapper.MapToGrpc(result);
        }

        public override async Task<GetIssuedMerchInfoResponse> GetIssuedMerchInfo(
            GetIssuedMerchInfoRequest request,
            ServerCallContext context)
        {
            var query = new GetIssuedMerchInfoQuery(request.EmployeeId);
            var response = await _mediator.Send(query, context.CancellationToken);
            return _modelsMapper.MapToGrpc(response);
        }
    }
}