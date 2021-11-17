using MerchandiseService.Application.Commands.MerchItemAggregate;

namespace MerchandiseService.HttpModels.Responses.Merch.V1
{
    public class V1IssueMerchResponse
    {
        public V1IssueMerchResponse(V1IssueMerchResult result)
        {
            Result = result;
        }

        public V1IssueMerchResult Result { get; set; }
    }
}