using MarsRoverBlazor.Shared;
using MarsRoverLib.Model;
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
        private readonly IHoustonService houstonService;

        public HomeController(ILogger<HomeController> logger, IHoustonService houstonService) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.houstonService = houstonService ?? throw new ArgumentNullException(nameof(houstonService));
        }

        [HttpGet]
        public IEnumerable<Directive> Get(string directives) {
            try {
                var directiveList = houstonService.sendDirective(directives);
                return houstonService.sendDirective(directives).ToList();
            } catch (Exception ex) {
                _logger.LogError("Error:ProcessError - Type: {Type} Message: {Message}", ex.GetType(), ex.Message);
                //throw; 
            }
            return new List<Directive>();
        }

    }
}
