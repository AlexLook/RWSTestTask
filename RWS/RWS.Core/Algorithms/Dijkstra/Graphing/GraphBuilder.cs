using RWS.Core.Algorithms.Dijkstra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core.Algorithms.Dijkstra.Graphing;

public class GraphBuilder {

    private readonly Dictionary<string, Dictionary<string, Func<Node, Link>>> links;
    private readonly Dictionary<string, Func<Node>>                           nodes;

    public GraphBuilder() {
        nodes = new Dictionary<string, Func<Node>>();
        links = new Dictionary<string, Dictionary<string, Func<Node, Link>>>();
    }

    public GraphBuilder AddNode(string id) {
        if (nodes.ContainsKey(id))
            throw new GraphBuilderException($"Node \"{id}\" already exists.");

        nodes.Add(id, () => Node.Create(id));
        return this;
    }

    public GraphBuilder AddLink(string sourceId, string destinationId, double weight) {
        if (!links.ContainsKey(sourceId))
            links.Add(sourceId, new Dictionary<string, Func<Node, Link>>());

        if (links[sourceId].ContainsKey(destinationId))
            throw new GraphBuilderException(
                $"Link \"{sourceId}\" -> \"{destinationId}\" already exists.");

        links[sourceId].Add(destinationId, node => Link.Create(weight, node));
        return this;
    }

    public Graph Build() {
        var nodesDict = nodes.ToDictionary(node => node.Key, node => node.Value.Invoke());

        foreach (var source in links)
            foreach (var destination in source.Value) {
                if (!nodes.ContainsKey(source.Key))
                    throw new GraphBuilderException(
                        $"Node \"{source.Key}\" does not exist.");

                if (!nodes.ContainsKey(destination.Key))
                    throw new GraphBuilderException(
                        $"Node \"{destination.Key}\" does not exist.");

                nodesDict[source.Key].Add(
                    destination.Value.Invoke(
                        nodesDict[destination.Key]));
            }

        var graph = Graph.Create();

        foreach (var node in nodesDict.Values)
            graph.Add(node);

        return graph;
    }
}
