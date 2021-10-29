using System.Threading;
using MerchandiseService.HttpModels.Requests.Merch.V1;
using MerchandiseService.HttpModels.Responses.Merch.V1;
using MerchandiseService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/merch")]
    public class MerchController : ControllerBase
    {
        private readonly IMerchService _merchService;

        public MerchController(IMerchService merchService)
        {
            _merchService = merchService;
        }

        [HttpPost("issue")]
        public ActionResult<V1IssueMerchResponse> IssueMerch([FromBody] V1IssueMerchRequest model,
            CancellationToken token)
        {
            return _merchService.IssueMerch(model, token);
        }

        [HttpPost("getinfo")]
        public ActionResult<V1MerchInfoResponse> GetMerchInfo([FromBody] V1MerchInfoRequest model,
            CancellationToken token)
        {
            return _merchService.GetMerchInfo(model, token);
        }
    }
}