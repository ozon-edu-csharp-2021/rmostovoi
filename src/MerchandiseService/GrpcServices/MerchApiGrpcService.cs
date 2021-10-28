using System.Threading.Tasks;
using Grpc.Core;
using MerchandiseService.Grpc;
using MerchandiseService.Services;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.GrpcServices
{
    public class MerchApiGrpcService : MerchApiGrpc.MerchApiGrpcBase
    {
        private readonly IMerchService _merchService;
        private readonly IModelsMapperService _modelsMapper;

        public MerchApiGrpcService(IMerchService merchService, IModelsMapperService modelsMapper)
        {
            _merchService = merchService;
            _modelsMapper = modelsMapper;
        }

        public override async Task<IssueMerchResponse> IssueMerch(IssueMerchRequest request, ServerCallContext context)
        {
            var response = _merchService.IssueMerch(_modelsMapper.Map(request), context.CancellationToken);
            return _modelsMapper.Map(response);
        }

        public override async Task<MerchInfoResponse> GetMerchInfo(MerchInfoRequest request, ServerCallContext context)
        {
            var response = _merchService.GetMerchInfo(_modelsMapper.Map(request), context.CancellationToken);
            return _modelsMapper.Map(response);
        }
    }
}