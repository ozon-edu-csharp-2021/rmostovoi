using System;
using System.Linq;
using Google.Protobuf.WellKnownTypes;
using MerchandiseService.Application.Commands.MerchItemAggregate;
using MerchandiseService.Grpc;
using MerchandiseService.HttpModels.Responses.Merch.V1;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
    public class ModelsMapperService : IModelsMapperService
    {
        public IssueMerchResponse MapToGrpc(IssueMerchItemCommandResult result)
        {
            return new IssueMerchResponse
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
            getIssuedMerchInfoResponse.Items.AddRange(response.Items.Select(it => new GetIssuedMerchInfoItem
            {
                Sku = it.Sku,
                Name = it.Name,
                Quantity = it.Quantity,
                IssuedAt = it.IssuedAt.ToTimestamp()
            }));
            return getIssuedMerchInfoResponse;
        }

        public V1IssueMerchResponse MapToHttp(IssueMerchItemCommandResult result)
        {
            return new V1IssueMerchResponse(
                result switch
                {
                    IssueMerchItemCommandResult.Issued => V1IssueMerchResult.Issued,
                    IssueMerchItemCommandResult.Inquiried => V1IssueMerchResult.Inquiried,
                    IssueMerchItemCommandResult.AlreadyIssued => V1IssueMerchResult.AlreadyIssued,
                    _ => throw new ArgumentOutOfRangeException(nameof(result), result, null)
                }
            );
        }

        public V1GetIssuedMerchInfoResponse MapToHttp(
            Application.Queries.GetIssuedMerchInfoAggregate.GetIssuedMerchInfoResponse response)
        {
            return new V1GetIssuedMerchInfoResponse(
                response.Items.Select(it => new V1IssuedMerchModel(it.Sku, it.Name, it.Quantity, it.IssuedAt)));
        }
    }
}