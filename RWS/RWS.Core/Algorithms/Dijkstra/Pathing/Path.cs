using RWS.Core.Algorithms.Dijkstra.Graphing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core.Algorithms.Dijkstra.Pathing;
public class Path {

    private readonly List<PathSegment> segments;

    public Node                       Origin      { get; }
    public Node                       Destination { get; private set; }
    public IReadOnlyList<PathSegment> Segments    => segments;

    private Path(Node origin) {
        Origin   = origin;
        segments = new List<PathSegment>();
    }

    public static Path Create(Node origin) {
        return new Path(origin);
    }

    internal void AddSegment(PathSegment segment) {
        Destination = segment.Destination;
        segments.Add(segment);
    }
}
