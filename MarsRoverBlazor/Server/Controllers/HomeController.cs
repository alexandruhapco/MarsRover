using MarsRoverLib.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRoverBlazor.Server.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Point> Get(string directives) {
            var q = new HoustonService();
            return q.sendDirective(directives);
        }

    }
}
