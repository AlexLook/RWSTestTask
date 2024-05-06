using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core;

/// <summary>
/// Участок
/// </summary>
public class Section : IEquatable<Section> {

    /// <summary>
    /// Граница участка 1
    /// </summary>
    public SchemePoint Point1 { get; }

    /// <summary>
    /// Граница участка 2
    /// </summary>
    public SchemePoint Point2 { get; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="point1">Точка границы 1</param>
    /// <param name="point2">Точка границы 2</param>
    /// <param name="name">Наименование участка</param>
    public Section(SchemePoint point1, SchemePoint point2, string name) {
        Point1 = point1;
        Point2 = point2;
        Name   = name;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="point1">Точка границы 1</param>
    /// <param name="point2">Точка границы 2</param>
    public Section(SchemePoint point1, SchemePoint point2)
        : this(point1, point2, $"S_{point1.Name}_{point2.Name}") { }

    /// <summary>
    /// Длина участка
    /// </summary>
    public double Length
        => Math.Sqrt(Math.Pow(Point2.X - Point1.X, 2) + Math.Pow(Point2.Y - Point1.Y, 2));

    public override string ToString() => $"Участок: {Name}";

    public override int GetHashCode()
        => HashCode.Combine<int, int>(Point1.GetHashCode(), Point2.GetHashCode());

    public override bool Equals(object? other) {
        if (other == null) {
            return false;
        }

        if (other is not Section otherSection) {
            return false;
        }

        return Equals(otherSection);
    }

    public bool Equals(Section other)
        =>    (this.Point1 == other.Point1 || this.Point1 == other.Point2)
           && (this.Point2 == other.Point1 || this.Point2 == other.Point2);
}
