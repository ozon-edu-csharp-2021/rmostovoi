using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels.Requests;
using MerchandiseService.HttpModels.Responses;
using Refit;

namespace MerchandiseService.HttpClients
{
    public interface IMerchandiseServiceHttpClient
    {
        [Post("/Merch/IssueMerch")]
        Task<IssueMerchResponse> IssueMerch(IssueMerchModel model, CancellationToken token);

        [Post("/Merch/GetMerchInfo")]
        Task<MerchInfoResponse> GetMerchInfo(MerchInfoModel model, CancellationToken token);
    }
}