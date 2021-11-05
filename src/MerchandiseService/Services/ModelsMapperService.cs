using System;
using System.Linq;
using Google.Protobuf.WellKnownTypes;
using MerchandiseService.Application.Commands.MerchItemAggregate;
using MerchandiseService.Grpc;
using MerchandiseService.HttpModels.Requests.Merch.V1;
using MerchandiseService.HttpModels.Responses.Merch.V1;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
    public class ModelsMapperService : IModelsMapperService
    {
        public IssueMerchResponse Map(V1IssueMerchResponse response)
        {
            return new IssueMerchResponse();
        }

        public V1IssueMerchRequest Map(IssueMerchRequest model)
        {
            return new V1IssueMerchRequest();
        }

        public IssueMerchResponse MapToGrpc(IssueMerchItemCommandResult result)
        {
            return new IssueMerchResponse()
            {
                Result = result switch
                {
                    IssueMerchItemCommandResult.Issued => IssueMerchItemResult.Issued,
                    IssueMerchItemCommandResult.Inquiried => IssueMerchItemResult.Inquiried,
                    IssueMerchItemCommandResult.AlreadyIssued => IssueMerchItemResult.AlreadyIssued,
                    _ => throw new ArgumentOutOfRangeException(nameof(result), result, null)
                }
            };
        }

        public GetIssuedMerchInfoResponse MapToGrpc(
            Application.Queries.GetIssuedMerchInfoAggregate.GetIssuedMerchInfoResponse response)
        {
            var getIssuedMerchInfoResponse = new GetIssuedMerchInfoResponse();
            getIssuedMerchInfoResponse.Items.AddRange(response.Items.Select(it => new GetIssuedMerchInfoItem()
            {
                Sku = it.Sku,
                Name = it.Name,
                Quantity = it.Quantity,
                IssuedAt = it.IssuedAt.ToTimestamp()
            }));
            return getIssuedMerchInfoResponse;
        }
    }
}