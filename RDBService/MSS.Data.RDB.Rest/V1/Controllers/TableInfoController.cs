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

        [HttpGet("getallpid")]
        public async Task<ActionResult<HashSet<string>>> GetAllPID()
        {

            var ret = await _service.GetAllPID();
            return ret;
        }


    }
}