using System.ComponentModel.DataAnnotations;

#pragma warning disable 8618

namespace MerchandiseService.HttpModels.Requests.Merch.V1
{
    public class V1MerchInfoRequest
    {
        [Required] public string EmployeeId { get; set; }
    }
}