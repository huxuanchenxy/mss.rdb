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
    public class EventController : ControllerBase
    {
     
        private readonly EssDbContext _context;

        public EventController(EssDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public ActionResult<List<Event>> Get()
        {

            return _context.Events.OrderByDescending(e=>e.ETime).Take(10).ToList();
        }
       
    }
}