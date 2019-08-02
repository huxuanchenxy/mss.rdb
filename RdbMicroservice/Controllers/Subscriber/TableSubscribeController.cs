using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rdbMicroservice.Models;
using rdbMicroservice.Repository;


namespace rdbMicroservice.Controllers.Subscriber
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableSubscribeController : SubscribeControllerBase
    {
        public TableSubscribeController(ILogger<TableSubscribeController> logger, LiteDbRepository liteDbRepository)
        {
            _logger = logger;
            _liteDbRepository = liteDbRepository;
        }

        [HttpGet]
        public ActionResult<List<STable>> Get()
        {
            return _liteDbRepository.GetTable();
        }

        [HttpGet("{name}")]
        public ActionResult<STable> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();
            var table = _liteDbRepository.GetTable(name);
            if (table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }

        [HttpPost]
        public ActionResult<STable> Post([FromBody] STable value)
        {
            if (value==null||string.IsNullOrEmpty(value.Name))
                return BadRequest();
            var table = _liteDbRepository.GetTable(value.Name);
            if (table != null)
                return Conflict("table:" + value.Name + " already exist!");
            else
            {
                _liteDbRepository.CreateTable(value);
                return Ok(value);
            }

        }
     
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();
            if (_liteDbRepository.RemoveTable(name))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

          
        }
    }
}


