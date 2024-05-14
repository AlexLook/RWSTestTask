using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core;

/// <summary>
/// Железнодорожная станция
/// </summary>
public class RailwayStation {

    /// <summary>
    /// Наименование станции
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Точки станции
    /// </summary>
    public List<StationPoint> StationPoints { get; }

    /// <summary>
    /// Участки
    /// </summary>
    public List<Section> Sections { get; }

    /// <summary>
    /// Парки станции
    /// </summary>
    public List<Yard> Yards { get; }

    /// <summary>
    /// Пути станции (все, как входящие в парки, так и нет)
    /// </summary>
    public List<Track> Tracks { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Наименование станции</param>
    public RailwayStation(string name) {
        Name            = name;
        StationPoints   = new List<StationPoint>();
        Sections        = new List<Section>();
        Yards           = new List<Yard>();
        Tracks          = new List<Track>();
    }

    /// <summary>
    /// Добавить точку
    /// </summary>
    /// <param name="point">Точка</param>
    public void AddPoint(StationPoint point) {
        StationPoints.Add(point);
    }

    /// <summary>
    /// Добавить точку
    /// </summary>
    /// <param name="x">Координата X</param>
    /// <param name="y">Координата Y</param>
    /// <param name="name">Наименование точки</param>
    public void AddPoint(double x, double y, string name) {
        StationPoints.Add(new StationPoint(x, y, name));
    }

    /// <summary>
    /// Поиск точки
    /// </summary>
    /// <param name="pointName">Имя точки</param>
    /// <returns>Станционная точка</returns>
    public StationPoint? FindPoint(string pointName) {
        return StationPoints.Find(p => p.Name.Equals(pointName, StringComparison.Ordinal));
    }

    /// <summary>
    /// Добавить участок
    /// </summary>
    /// <param name="section">Участок</param>
    public void AddSection(Section section) {
        if (!Sections.Contains(section)) {
            Sections.Add(section);

            AddPoint(section.Point1);
            AddPoint(section.Point2);

            section.Point1.AddSection(section);
            section.Point2.AddSection(section);
        }
    }

    /// <summary>
    /// Добавить парк
    /// </summary>
    /// <param name="yard">Парк</param>
    public void AddYard(Yard yard) {
        if (!Yards.Contains(yard)) {
            Yards.Add(yard);
        }
    }

    /// <summary>
    /// Добавить путь
    /// </summary>
    /// <param name="track">Путь</param>
    public void AddTrack(Track track) {
        if (!Tracks.Contains(track)) {
            Tracks.Add(track);
        }
    }
}
