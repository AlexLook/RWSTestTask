using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core;

/// <summary>
/// Класс для поиска кратчайшего пути на станции (алгоритм Дейкстры)
/// </summary>
public class ShortestPathSolver {

    private readonly RailwayStation station;

    private List<StationPointInfo> infos;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="station">Станция</param>
    public ShortestPathSolver(RailwayStation station) {
        this.station = station;
    }

    /// <summary>
    /// Инициализация информации
    /// </summary>
    private void InitInfo() {
        infos = new List<StationPointInfo>();
        foreach (var point in station.StationPoints) {
            infos.Add(new StationPointInfo(point));
        }
    }

    /// <summary>
    /// Получение информации о станционной точке
    /// </summary>
    /// <param name="point">Станционная точка</param>
    /// <returns>Информацию о станционной точке или null, если она не найдена</returns>
    private StationPointInfo GetStationPointInfo(StationPoint point) {
        return infos.Find(i => i.StationPoint.Equals(point));
    }

    /// <summary>
    /// Поиск непосещенной вершины с минимальным значением суммы длин участков
    /// </summary>
    /// <returns>Информация о вершине</returns>
    private StationPointInfo FindUnvisitedPointWithMinSum() {
        var minValue = double.MaxValue;
        StationPointInfo minPointInfo = null;

        foreach (var pointInfo in infos) {
            if (pointInfo.IsUnvisited && pointInfo.LengthsSum < minValue) {
                minPointInfo = pointInfo;
                minValue     = pointInfo.LengthsSum;
            }
        }

        return minPointInfo;
    }

    /// <summary>
    /// Поиск кратчайшего пути
    /// </summary>
    /// <param name="startPointName">Имя начальной точки</param>
    /// <param name="finishPointName">Имя конечной точки</param>
    /// <returns>Список участков</returns>
    public Section[] FindShortestPath(string startPointName,
                                      string finishPointName) {
        return FindShortestPath(station.FindPoint(startPointName),
                                station.FindPoint(finishPointName));
    }

    /// <summary>
    /// Поиск кратчайшего пути
    /// </summary>
    /// <param name="startPoint">Начальная точка</param>
    /// <param name="finishPoint">Конечная точка</param>
    /// <returns>Список участков</returns>
    public Section[] FindShortestPath(StationPoint startPoint, StationPoint finishPoint) {
        InitInfo();
        var first = GetStationPointInfo(startPoint);
        first.LengthsSum = 0;
        while (true) {
            var current = FindUnvisitedPointWithMinSum();
            if (current == null) {
                break;
            }
            SetSumToNextPoint(current);
        }

        return GetPath(startPoint, finishPoint).ToArray();
    }

    /// <summary>
    /// Установить сумму длин участков дляследующей точки
    /// </summary>
    /// <param name="info"></param>
    private void SetSumToNextPoint(StationPointInfo info) {
        info.IsUnvisited = false;
        foreach (var section in info.StationPoint.Sections) {
            var nextInfo = GetStationPointInfo(section.Point2);
            var sum      = info.LengthsSum + section.Length;
            if (sum < nextInfo.LengthsSum) {
                nextInfo.LengthsSum           = sum;
                nextInfo.PreviousStationPoint = info.StationPoint;
            }
        }
    }

    /// <summary>
    /// Формирование пути
    /// </summary>
    /// <param name="startPoint">Стартовая точка</param>
    /// <param name="finishPoint">Конечная точка</param>
    /// <returns>Список секций пути</returns>
    private List<Section> GetPath(StationPoint startPoint, StationPoint finishPoint) {
        var endPoint = finishPoint;
        var path     = new List<Section>();
        var endInfo  = GetStationPointInfo(endPoint);
        var section  = station.Sections.Find(
            s =>   (s.Point1 == endPoint && s.Point2 == endInfo.PreviousStationPoint)
                || (s.Point2 == endPoint && s.Point1 == endInfo.PreviousStationPoint))
            ?? throw new InvalidOperationException("Section not found!");
        path.Add(section);
        while (startPoint != endPoint) {
            endPoint = GetStationPointInfo(endPoint).PreviousStationPoint;
            if (endPoint == null) break;
            endInfo  = GetStationPointInfo(endPoint);
            section  = station.Sections.Find(
                s =>   (s.Point1 == endPoint && s.Point2 == endInfo.PreviousStationPoint)
                    || (s.Point2 == endPoint && s.Point1 == endInfo.PreviousStationPoint))
                ?? throw new InvalidOperationException("Section not found!");
            path.Insert(0, section);
        }

        return path;
    }
}
