using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core.Algorithms.Dijkstra.Graphing;
public class Graph {

    private readonly List<Node> nodes;

    public IReadOnlyList<Node> Nodes => nodes;

    private Graph() {
        nodes = new List<Node>();
    }

    internal static Graph Create() {
        return new Graph();
    }

    internal void Add(Node node) {
        nodes.Add(node);
    }
}
