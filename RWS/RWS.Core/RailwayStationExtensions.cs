using RWS.Core.Algorithms.Dijkstra.Graphing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core;

/// <summary>
/// Методы расширения для класса RailwayStation
/// </summary>
public static class RailwayStationExtensions {

    /// <summary>
    /// Получение всех станционных точек для парка
    /// </summary>
    /// <param name="station">Станция</param>
    /// <param name="yardName">Имя парка</param>
    /// <returns>Массив станционных точек парка</returns>
    public static StationPoint[] GetAllYardPoints(this RailwayStation station, string yardName) {
        var allPoints = new List<StationPoint>();

        var yard = station.Yards.Find(yard => yard.Name.Equals(yardName));

        if (yard == null) return allPoints.ToArray();

        foreach (var track in yard.Tracks) {
            foreach (var section in track.Sections) {
                AddPointToList(allPoints, section.Point1);
                AddPointToList(allPoints, section.Point2);
            }
        }

        return allPoints.ToArray();
    }

    /// <summary>
    /// Получение всех станционных точек
    /// </summary>
    /// <param name="station">Станция</param>
    /// <returns>Массив станционных точек</returns>
    public static StationPoint[] GetAllStationPoints(this RailwayStation station) {
        var allPoints = new List<StationPoint>();

        foreach (var section in station.Sections) {
            AddPointToList(allPoints, section.Point1);
            AddPointToList(allPoints, section.Point2);
        }

        return allPoints.ToArray();
    }

    /// <summary>
    /// Добавить тчоку в список с проверкой её наличия в списке
    /// </summary>
    /// <param name="point">Станционная точка</param>
     private static void AddPointToList(List<StationPoint> list, StationPoint point) {
        if (!list.Contains(point)) list.Add(point);
    }

    /// <summary>
    /// Получить граф для станции для поиска пути
    /// </summary>
    /// <param name="station">Станция</param>
    /// <returns>Граф станции</returns>
    public static Graph GetStationGraph(this RailwayStation station) {
        var builder = new GraphBuilder();

        foreach (var point in GetAllStationPoints(station)) {
            builder.AddNode(point.Name);
        }

        foreach (var section in station.Sections) {
            builder.AddLink(section.Point1.Name, section.Point2.Name, section.Length);
            builder.AddLink(section.Point2.Name, section.Point1.Name, section.Length);
        }

        return builder.Build();
    }
}
