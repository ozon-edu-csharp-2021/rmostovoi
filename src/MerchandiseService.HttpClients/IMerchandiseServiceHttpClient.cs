using System.Threading.Tasks;
using MerchandiseService.HttpModels.Requests;
using MerchandiseService.HttpModels.Responses;
using Refit;

namespace MerchandiseService.HttpClients
{
    public interface IMerchandiseServiceHttpClient
    {
        [Get("/Merch/IssueMerch")]
        Task<IssueMerchResponse> IssueMerch(IssueMerchModel model);
        
        [Get("/Merch/GetMerchInfo")]
        Task<MerchInfoResponse> GetMerchInfo(MerchInfoModel model);
    }
}