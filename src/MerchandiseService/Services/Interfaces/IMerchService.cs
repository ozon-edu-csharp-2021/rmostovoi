using System.Threading;
using MerchandiseService.HttpModels.Requests;
using MerchandiseService.HttpModels.Responses;

namespace MerchandiseService.Services.Interfaces
{
    public interface IMerchService
    {
        IssueMerchResponse IssueMerch(IssueMerchModel model, CancellationToken token);
        MerchInfoResponse GetMerchInfo(MerchInfoModel model, CancellationToken token);
    }
}