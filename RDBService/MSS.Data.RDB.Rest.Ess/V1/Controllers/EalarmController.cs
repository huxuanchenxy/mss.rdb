using Microsoft.AspNetCore.Mvc;
using MSS.Data.RDB.Model;
using MSS.Data.RDB.Rest.Ess.V1.Business;
using System.Threading.Tasks;

namespace MSS.Data.RDB.Rest.Ess.V1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EalarmController : ControllerBase
    {
        private readonly IEalarmService _service;
        public EalarmController(IEalarmService service)
        {
            _service = service;
        }


        [HttpGet("{ack}")]
        public async Task<ApiResult> GetEalarm(int ack)
        {
            var ret = await _service.GetEalarmList(ack);
            return ret;
        }


    }
}