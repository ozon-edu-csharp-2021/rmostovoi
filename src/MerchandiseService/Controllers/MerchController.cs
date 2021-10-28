using System.Threading;
using MerchandiseService.HttpModels.Requests;
using MerchandiseService.HttpModels.Responses;
using MerchandiseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MerchController : ControllerBase
    {
        private readonly MerchService _merchService;

        public MerchController(MerchService merchService)
        {
            _merchService = merchService;
        }

        [HttpPost]
        public ActionResult<IssueMerchResponse> IssueMerch([FromBody] IssueMerchModel model, CancellationToken token)
        {
            return _merchService.IssueMerch(model, token);
        }

        [HttpPost]
        public ActionResult<MerchInfoResponse> GetMerchInfo([FromBody] MerchInfoModel model, CancellationToken token)
        {
            return _merchService.GetMerchInfo(model, token);
        }
    }
}