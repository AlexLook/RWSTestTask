using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core;

/// <summary>
/// Путь
/// </summary>
public class Track : IEquatable<Track> {
    
    /// <summary>
    /// Наименование пути
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Список участков составляющих путь
    /// </summary>
    public List<Section> Sections { get; }

    /// <summary>
    /// Начальный участок
    /// </summary>
    public Section BeginSection { get; }

    /// <summary>
    /// Конечный участок
    /// </summary>
    public Section EndSection   { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="sections">Участки</param>
    /// <param name="name">Наименование пути</param>
    public Track(Section[] sections, string name) {
        Name         = name;
        Sections     = new List<Section>(sections.Length);
        BeginSection = sections[0];
        EndSection   = sections[^1];
        Sections.AddRange(sections);
    }

    /// <summary>
    /// Длина пути
    /// </summary>
    public double Length {
        get {
            double length = 0.0d;
            foreach (var section in Sections) {
                length += section.Length;
            }
            return length;
        }
    }

    public override string ToString() => Name;

    public override int GetHashCode() => Name.GetHashCode();

    public override bool Equals(object? other) {
        if (other == null) {
            return false;
        }

        if (other is not Track otherTrack) {
            return false;
        }

        return Equals(otherTrack);
    }

    public bool Equals(Track? other) {
        if (other == null) return false;

        return this.Name.Equals(other.Name, StringComparison.Ordinal);
    }
}
