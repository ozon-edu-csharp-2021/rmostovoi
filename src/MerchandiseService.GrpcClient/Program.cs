using System;
using Grpc.Core;
using Grpc.Net.Client;
using MerchandiseService.Grpc;

using var channel = GrpcChannel.ForAddress("http://localhost:5000", new GrpcChannelOptions
{
    Credentials = ChannelCredentials.Insecure
});
var client = new MerchApiGrpc.MerchApiGrpcClient(channel);

try
{
    var response = await client.IssueMerchAsync(new IssueMerchRequest());
    Console.WriteLine(response.ToString());
}
catch (RpcException e)
{
    Console.WriteLine(e);
}