using System;
using MerchandiseService.Application.Commands.MerchItemAggregate;
using MerchandiseService.Grpc;
using MerchandiseService.HttpModels.Requests.Merch.V1;
using MerchandiseService.HttpModels.Responses.Merch.V1;

namespace MerchandiseService.Services.Interfaces
{
    public interface IModelsMapperService
    {
        IssueMerchResponse Map(V1IssueMerchResponse response);
        V1IssueMerchRequest Map(IssueMerchRequest model);

        IssueMerchResponse MapToGrpc(IssueMerchItemCommandResult result);

        GetIssuedMerchInfoResponse MapToGrpc(
            Application.Queries.GetIssuedMerchInfoAggregate.GetIssuedMerchInfoResponse response);
    }
}