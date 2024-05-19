using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core.Algorithms.Dijkstra.Exceptions;
public class GraphBuilderException : Exception {
    public GraphBuilderException(string message) : base(message) {}
}

