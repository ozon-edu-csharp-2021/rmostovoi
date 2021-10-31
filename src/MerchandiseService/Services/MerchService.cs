using System.Threading;
using MerchandiseService.HttpModels.Requests.Merch.V1;
using MerchandiseService.HttpModels.Responses.Merch.V1;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
    public class MerchService : IMerchService
    {
        public V1IssueMerchResponse IssueMerch(V1IssueMerchRequest model, CancellationToken token)
        {
            return new V1IssueMerchResponse();
        }

        public V1MerchInfoResponse GetMerchInfo(V1MerchInfoRequest model, CancellationToken token)
        {
            return new V1MerchInfoResponse();
        }
    }
}