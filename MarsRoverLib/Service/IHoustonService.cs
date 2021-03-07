using MarsRoverBlazor.Shared;
using System.Collections.Generic;

namespace MarsRoverLib.Service {
    public interface IHoustonService {
        IEnumerable<Directive> sendDirective(string directive);
    }
}