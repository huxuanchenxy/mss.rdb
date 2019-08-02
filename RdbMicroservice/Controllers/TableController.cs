using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using rdbMicroservice.Service;

namespace rdbMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : Controller
    {
        private readonly ILogger<TableController> _logger;
        private readonly RdbService _repository;
        public TableController(ILogger<TableController> logger, IRdbService repository)
        {
            _logger = logger;
            _repository = (RdbService)repository;
        }

        [HttpGet("{name}")]
        public ActionResult<string> Get(string name)
        {
            if (!_repository.Actived)
                return Content("the Rdb Server not actived!");
            else
            {
                string result = JsonConvert.SerializeObject(_repository.ReadTable(name));
                return Ok(result);
            }
        }   

    }
}
