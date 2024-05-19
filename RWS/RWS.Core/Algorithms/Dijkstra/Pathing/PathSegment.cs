using RWS.Core.Algorithms.Dijkstra.Graphing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core.Algorithms.Dijkstra.Pathing;
public class PathSegment {

    public Node   Origin      { get; }
    public Node   Destination { get; }
    public double Weight      { get; }

    private PathSegment(Node origin, Node destination, double weight) {
        Weight      = weight;
        Origin      = origin;
        Destination = destination;
    }

    internal static PathSegment Create(Node   origin,
                                       Node   destination,
                                       double weigth) {
        return new PathSegment(origin, destination, weigth);
    }
}
