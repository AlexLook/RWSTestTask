using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core;

/// <summary>
/// Парк
/// </summary>
public class Yard : IEquatable<Yard>{

    /// <summary>
    /// Наименование парка
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Пути принадлежащие парку
    /// </summary>
    public List<Track> Tracks { get; }


    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Наименование парка</param>
    public Yard(string name) {
        Name = name;
    }

    /// <summary>
    /// Добавить путь к парку
    /// </summary>
    /// <param name="track">Путь</param>
    public void AddTrack(Track track) {
        if (!Tracks.Contains(track)) {
            Tracks.Add(track);
        }
    }

    public override string ToString() => $"Парк: {Name}";

    public override int GetHashCode() => Name.GetHashCode();

    public override bool Equals(object? other) {
        if (other == null) {
            return false;
        }

        if (other is not Yard otherYard) {
            return false;
        }

        return Equals(otherYard);
    }

    public bool Equals(Yard other) => this.Name.Equals(other.Name);
}
