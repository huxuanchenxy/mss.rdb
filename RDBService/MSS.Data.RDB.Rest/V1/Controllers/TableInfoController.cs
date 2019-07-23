using Microsoft.AspNetCore.Mvc;
using MSS.Data.RDB.Model;
using MSS.Data.RDB.Rest.V1.Business;
using System.Threading.Tasks;

namespace MSS.Data.RDB.Rest.V1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TableInfoController : ControllerBase
    {
        private readonly ITableInfoService _service;
        public TableInfoController(ITableInfoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ApiResult> GetAllEqp()
        {
            var ret = await _service.GetAllEqp();
            return ret;
        }

        [HttpGet("{eqpid}")]
        public async Task<ApiResult> GetPoints(string eqpid)
        {
            var ret = await _service.GetPoints(eqpid);
            return ret;
        }


    }
}