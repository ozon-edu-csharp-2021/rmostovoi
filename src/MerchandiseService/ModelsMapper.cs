using MerchandiseService.Grpc;
using MerchandiseService.HttpModels.Requests;

namespace MerchandiseService
{
    // временный "маппер", пока не ответят на вопрос https://route256.slack.com/archives/C02FF0SQF0U/p1635374983015900?thread_ts=1634993145.006100&cid=C02FF0SQF0U
    public class ModelsMapper
    {
        public static ModelsMapper Instance = new();

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