using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels.Requests.Merch.V1;
using MerchandiseService.HttpModels.Responses.Merch.V1;
using Refit;

namespace MerchandiseService.HttpClients
{
    public interface IMerchandiseServiceHttpClient
    {
        [Post("v1/merch/issue")]
        Task<V1IssueMerchResponse> IssueMerch(V1IssueMerchRequest model, CancellationToken token);

        [Post("v1/merch/getinfo")]
        Task<V1GetIssuedMerchInfoResponse> GetMerchInfo(V1MerchInfoRequest model, CancellationToken token);
    }
}