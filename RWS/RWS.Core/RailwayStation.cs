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
    /// Участки
    /// </summary>
    public List<Section> Sections { get; }

    /// <summary>
    /// Парки станции
    /// </summary>
    public List<Yard> Yards { get; }

    /// <summary>
    /// Пути стнции (все, как входящие в парки, так и нет)
    /// </summary>
    public List<Track> Tracks { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Наименование станции</param>
    public RailwayStation(string name) {
        Name = name;
    }

    /// <summary>
    /// Добавить участок
    /// </summary>
    /// <param name="section">Участок</param>
    public void AddSection(Section section) {
        if (!Sections.Contains(section)) {
            Sections.Add(section);
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
