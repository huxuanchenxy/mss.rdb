using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rdbMicroservice.Models;
using rdbMicroservice.Repository;

namespace rdbMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmController : ControllerBase
    {
        private readonly EssDbContext _context;
      
        public AlarmController(EssDbContext context)
        {
            _context = context;           

        }
        [HttpGet]
        public ActionResult<List<Alarm>> Get()
        {      

            return   _context.Alarms.ToList();
        }
    }
}