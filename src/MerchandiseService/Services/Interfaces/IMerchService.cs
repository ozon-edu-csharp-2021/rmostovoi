using System.Threading;
using MerchandiseService.HttpModels.Requests.Merch.V1;
using MerchandiseService.HttpModels.Responses.Merch.V1;

namespace MerchandiseService.Services.Interfaces
{
    public interface IMerchService
    {
        V1IssueMerchResponse IssueMerch(V1IssueMerchRequest model, CancellationToken token);
        V1MerchInfoResponse GetMerchInfo(V1MerchInfoRequest model, CancellationToken token);
    }
}