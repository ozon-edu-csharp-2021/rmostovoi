using MerchandiseService.Application.Commands.MerchItemAggregate;
using MerchandiseService.Grpc;
using MerchandiseService.HttpModels.Responses.Merch.V1;

namespace MerchandiseService.Services.Interfaces
{
    public interface IModelsMapperService
    {
        IssueMerchResponse MapToGrpc(IssueMerchItemCommandResult result);

        GetIssuedMerchInfoResponse MapToGrpc(
            Application.Queries.GetIssuedMerchInfoAggregate.GetIssuedMerchInfoResponse response);

        V1IssueMerchResponse MapToHttp(IssueMerchItemCommandResult result);

        V1GetIssuedMerchInfoResponse MapToHttp(
            Application.Queries.GetIssuedMerchInfoAggregate.GetIssuedMerchInfoResponse response);
    }
}