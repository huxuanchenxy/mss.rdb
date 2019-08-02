using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rdbMicroservice.Controllers.Subscriber;
using rdbMicroservice.Models;
using rdbMicroservice.Repository;
using rdbMicroservice.Service;

namespace rdbMicroservice.Controllers.Subscriber
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointSubscribeController : SubscribeControllerBase
    {    

        public PointSubscribeController(ILogger<PointSubscribeController> logger, LiteDbRepository liteDbRepository)
        {
            _logger = logger;
            _liteDbRepository = liteDbRepository;     
        }

        [HttpGet]
        public ActionResult<List<SPoint>> Get()
        {  
            return _liteDbRepository.GetPoint();
        }
        
        [HttpGet("{pid}", Name = "Get")]
        public ActionResult<SPoint> Get(string pid)
        {
            if (string.IsNullOrEmpty(pid))
                return BadRequest();
            var point = _liteDbRepository.GetPoint(pid);
            if (point == null)
            {
                return NotFound();
            }
            return Ok(point);
        }
        [HttpPost]
        public ActionResult<SPoint> Post([FromBody] SPoint value)
        {
            if (value==null||string.IsNullOrEmpty(value.PID))
                return BadRequest();
            var point = _liteDbRepository.GetPoint(value.PID);
            if (point != null)
                return Conflict("pid:" + value.PID + " already exist!");
            else
            {
                _liteDbRepository.CreatePoint(value);
                return Ok(value);
            }
        }
        
        [HttpDelete("{pid}")]
        public IActionResult Delete(string pid)
        {
            if (string.IsNullOrEmpty(pid))
                return BadRequest();
            if (_liteDbRepository.RemovePoint(pid))
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
