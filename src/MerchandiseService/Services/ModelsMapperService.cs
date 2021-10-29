using MerchandiseService.Grpc;
using MerchandiseService.HttpModels.Requests.Merch.V1;
using MerchandiseService.HttpModels.Responses.Merch.V1;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
    public class ModelsMapperService : IModelsMapperService
    {
        public MerchInfoResponse Map(V1MerchInfoResponse response)
        {
            return new MerchInfoResponse();
        }

        public IssueMerchResponse Map(V1IssueMerchResponse response)
        {
            return new IssueMerchResponse();
        }

        public V1MerchInfoRequest Map(MerchInfoRequest model)
        {
            return new V1MerchInfoRequest();
        }

        public V1IssueMerchRequest Map(IssueMerchRequest model)
        {
            return new V1IssueMerchRequest();
        }
    }
}