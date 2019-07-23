using Microsoft.AspNetCore.Mvc;
using MSS.API.Operlog.V1.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSS.API.Operlog.V1.Controllers
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
        public async Task<ActionResult<HashSet<string>>> GetAllEqp()
        {

            var ret = await _service.GetAllEqp();
            return ret;
        }

        [HttpGet("{tablename}")]
        public async Task<ActionResult<HashSet<string>>> GetAllPID(string tablename)
        {

            var ret = await _service.GetAllPID(tablename);
            return ret;
        }


    }
}