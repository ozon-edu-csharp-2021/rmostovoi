using System.Collections.Generic;
using MerchandiseService.Application.Models;

namespace MerchandiseService.HttpModels.Responses.Merch.V1
{
    public class V1GetIssuedMerchInfoResponse
    {
        public V1GetIssuedMerchInfoResponse(IEnumerable<V1IssuedMerchModel> items)
        {
            Items = items;
        }

        public IEnumerable<V1IssuedMerchModel> Items { get; set; }
    }
}