using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core.Algorithms.Dijkstra.Graphing;
public class Node {

    private readonly List<Link> links;

    public string              Id  { get; }

    public IReadOnlyList<Link> Links => links;

    private Node(string id) {
        Id    = id;
        links = new List<Link>();
    }

    internal static Node Create(string id) {
        return new Node(id);
    }

    internal void Add(Link link) {
        links.Add(link);
    }
}