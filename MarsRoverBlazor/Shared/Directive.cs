using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverBlazor.Shared {

    public record Directive {
        public int x { get; set; }
        public int y { get; set; }
        public char direction { get; set; }
    }

}
