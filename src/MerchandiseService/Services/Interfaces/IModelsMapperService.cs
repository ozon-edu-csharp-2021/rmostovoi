using MerchandiseService.Grpc;
using MerchandiseService.HttpModels.Requests.Merch.V1;
using MerchandiseService.HttpModels.Responses.Merch.V1;

namespace MerchandiseService.Services.Interfaces
{
    public interface IModelsMapperService
    {
        MerchInfoResponse Map(V1MerchInfoResponse response);
        IssueMerchResponse Map(V1IssueMerchResponse response);
        V1MerchInfoRequest Map(MerchInfoRequest model);
        V1IssueMerchRequest Map(IssueMerchRequest model);
    }
}