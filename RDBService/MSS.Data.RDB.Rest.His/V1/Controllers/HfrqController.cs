using Microsoft.AspNetCore.Mvc;
using MSS.Data.RDB.Model;
using MSS.Data.RDB.Rest.His.V1.Business;
using System.Threading.Tasks;

namespace MSS.Data.RDB.Rest.His.V1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HfrqController : ControllerBase
    {
        private readonly IHfrqService _service;
        public HfrqController(IHfrqService service)
        {
            _service = service;
        }



        [HttpPost("page")]
        public async Task<ActionResult<ApiResult>> ListPage(HfrqParam query)
        {
            ApiResult ret = new ApiResult { code = Code.Failure };
            ret = await _service.ListPage(query);
            return ret;
        }
    }
}