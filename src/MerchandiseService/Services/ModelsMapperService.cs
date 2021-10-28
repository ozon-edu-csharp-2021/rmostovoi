using MerchandiseService.Grpc;
using MerchandiseService.HttpModels.Requests;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
    public class ModelsMapperService : IModelsMapperService
    {
        public MerchInfoResponse Map(HttpModels.Responses.MerchInfoResponse response)
        {
            return new MerchInfoResponse();
        }

        public IssueMerchResponse Map(HttpModels.Responses.IssueMerchResponse response)
        {
            return new IssueMerchResponse();
        }

        public MerchInfoModel Map(MerchInfoRequest model)
        {
            return new MerchInfoModel();
        }

        public IssueMerchModel Map(IssueMerchRequest model)
        {
            return new IssueMerchModel();
        }
    }
}