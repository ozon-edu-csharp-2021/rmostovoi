using System.Threading;
using MerchandiseService.HttpModels.Requests;
using MerchandiseService.HttpModels.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MerchController : ControllerBase
    {
        [HttpPost]
        public ActionResult<IssueMerchResponse> IssueMerch([FromBody] IssueMerchModel model, CancellationToken token)
        {
            return new IssueMerchResponse();
        }

        [HttpPost]
        public ActionResult<MerchInfoResponse> GetMerchInfo([FromBody] MerchInfoModel model, CancellationToken token)
        {
            return new MerchInfoResponse();
        }
    }
}