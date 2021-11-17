using System.ComponentModel.DataAnnotations;

#pragma warning disable 8618

namespace MerchandiseService.HttpModels.Requests.Merch.V1
{
    public class V1IssueMerchRequest
    {
        public long Sku { get; set; }
        public long Quantity { get; set; }

        [Required] public string EmployeeId { get; set; }
    }
}