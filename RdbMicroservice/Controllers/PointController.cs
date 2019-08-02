using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rdbMicroservice.Service;
using Newtonsoft;
using Newtonsoft.Json;

namespace rdbMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly ILogger<PointController> _logger;

        private readonly RdbService _repository;

        public PointController(ILogger<PointController> logger, IRdbService repository)
        {
            _logger = logger;
           _repository = (RdbService)repository;
        }

  
        [HttpGet("{pid}")]
        public ActionResult<string> Get(string pid)
        {
            if(!_repository.Actived)
               return Content("the Rdb Server not actived!");
            else
            {
              string result=  JsonConvert.SerializeObject(_repository.ReadPoint(pid));
                return Ok(result);
            }
        } 

   
    }
}
