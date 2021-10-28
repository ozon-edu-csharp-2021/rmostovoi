using System.Threading;
using Grpc.Core;
using MerchandiseService.HttpModels.Requests;
using MerchandiseService.HttpModels.Responses;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
    public class MerchService : IMerchService
    {
        public IssueMerchResponse IssueMerch(IssueMerchModel model, CancellationToken token)
        {
            return new IssueMerchResponse();
        }

        public MerchInfoResponse GetMerchInfo(MerchInfoModel model, CancellationToken token)
        {
            return new MerchInfoResponse();
        }
    }
}