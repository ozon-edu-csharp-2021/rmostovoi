using MerchandiseService.Grpc;
using MerchandiseService.HttpModels.Requests;

namespace MerchandiseService.Services.Interfaces
{
    public interface IModelsMapperService
    {
        MerchInfoResponse Map(HttpModels.Responses.MerchInfoResponse response);
        IssueMerchResponse Map(HttpModels.Responses.IssueMerchResponse response);
        MerchInfoModel Map(MerchInfoRequest model);
        IssueMerchModel Map(IssueMerchRequest model);
    }
}