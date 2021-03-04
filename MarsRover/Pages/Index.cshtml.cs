using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;

        public int row { get; set; } = 5;
        public int col { get; set; } = 5;

        public IndexModel(ILogger<IndexModel> logger) {
            _logger = logger;
        }

        public void OnGet() {

        }

        public void buttonPress() {

        }
    }
}
