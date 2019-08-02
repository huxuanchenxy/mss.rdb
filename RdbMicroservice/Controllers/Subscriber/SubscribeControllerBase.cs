using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rdbMicroservice.Repository;
using rdbMicroservice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rdbMicroservice.Controllers.Subscriber
{
    public class SubscribeControllerBase:ControllerBase
    {
        protected  ILogger<ControllerBase> _logger;
        protected  LiteDbRepository _liteDbRepository;
      
    }

}
