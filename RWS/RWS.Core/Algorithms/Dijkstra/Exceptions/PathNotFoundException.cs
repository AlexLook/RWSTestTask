using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core.Algorithms.Dijkstra.Exceptions;
public class PathNotFoundException : Exception {
    public PathNotFoundException(string message)
        : base(message) {}
}
