using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core.Algorithms.Dijkstra.Graphing;
public  class Link {
    
    public double Weight      { get; }

    public Node   Destination { get; }

    private Link(double weight, Node destination) {
        Weight      = weight;
        Destination = destination;
    }

    internal static Link Create(double weight, Node destination) {
        return new Link(weight, destination);
    }
}

