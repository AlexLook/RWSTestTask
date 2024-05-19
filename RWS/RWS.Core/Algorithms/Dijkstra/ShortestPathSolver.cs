using RWS.Core.Algorithms.Dijkstra.Pathing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace RWS.Core.Algorithms.Dijkstra;
public class ShortestPathSolver {

    private RailwayStation station;

    public ShortestPathSolver(RailwayStation station) {
        this.station = station;
    }

    public StationPath GetShortestPath(string sectionStartName,
                                       string sectionFinishName) {
        var graph      = station.GetStationGraph();
        var pathFinder = new PathFinder(graph);

        var startSection  = station.Sections.Find(s => s.Name.Equals(sectionStartName));
        var finishSection = station.Sections.Find(s => s.Name.Equals(sectionFinishName));

        if (   startSection  == null
            || finishSection == null
            || startSection  == finishSection) return new StationPath(null, null);

        var startNode  = graph.Nodes.Single(node => node.Id == startSection.Point1.Name);
        var finishNode = graph.Nodes.Single(node => node.Id == finishSection.Point1.Name);

        if (   startNode  == null
            || finishNode == null
            || startNode  == finishNode)
            return new StationPath(null, null);

        var path               = pathFinder.FindShortestPath(startNode, finishNode);
        var originSection      = GetSectionByPoints(path.Segments[0]);
        var destinationSection = GetSectionByPoints(path.Segments[^1]);

        if (   originSection      == null
            || destinationSection == null)
            throw new InvalidOperationException("Ошибка поиска участка на станции!");

        var stationPath = new StationPath(startSection, finishSection);

        foreach (var p in path.Segments) {
            var section =  GetSectionByPoints(p)
                        ?? throw new InvalidOperationException("Ошибка поиска участка на станции!");

            stationPath.AddSection(section);
        }
        stationPath.AddSection(finishSection);

        return stationPath;
    }

    private Section? GetSectionByPoints(PathSegment p) {
        Section? section;

        section = station.Sections.Find(
            s =>    (   s.Point1.Name.Equals(p.Origin.Id,      StringComparison.OrdinalIgnoreCase)
                     && s.Point2.Name.Equals(p.Destination.Id, StringComparison.OrdinalIgnoreCase))
                 || (   s.Point1.Name.Equals(p.Destination.Id, StringComparison.OrdinalIgnoreCase)
                     && s.Point2.Name.Equals(p.Origin.Id,      StringComparison.OrdinalIgnoreCase)));

        return section;
    }
}
