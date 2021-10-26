using System;
using MerchandiseService.HttpModels;
using MerchandiseService.HttpModels.Requests;
using MerchandiseService.HttpModels.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MerchController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IssueMerchResponse> IssueMerch(IssueMerchModel model)
        {
            return new IssueMerchResponse();
        }

        [HttpGet]
        public ActionResult<MerchInfoResponse> GetMerchInfo(MerchInfoModel model)
        {
            return new MerchInfoResponse();
        }
    }
}