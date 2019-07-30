using Microsoft.AspNetCore.Mvc;
using MSS.Data.RDB.Model;
using MSS.Data.RDB.Rest.Ess.V1.Business;
using System.Threading.Tasks;

namespace MSS.Data.RDB.Rest.Ess.V1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ElogController : ControllerBase
    {
        private readonly IElogService _service;
        public ElogController(IElogService service)
        {
            _service = service;
        }


        [HttpGet("{ack}")]
        public async Task<ApiResult> GetElog(int ack)
        {
            var ret = await _service.GetElogList(ack);
            return ret;
        }

        [HttpPost("page")]
        public async Task<ActionResult<ApiResult>> ListPageElog(ElogReq query)
        {
            ApiResult ret = new ApiResult { code = Code.Failure };
            ret = await _service.ListPageElog(query);
            return ret;
        }
    }
}