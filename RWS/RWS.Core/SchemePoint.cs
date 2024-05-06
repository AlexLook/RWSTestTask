using System;

namespace RWS.Core;

/// <summary>
/// Точка схемы станции (точки начала и конца секций)
/// </summary>
// Такое имя выбрано для избегания конфликта с типом Point из  библиотеки .Net
public class SchemePoint : IEquatable<SchemePoint> {

    /// <summary>
    /// Координата X
    /// </summary>
    public double X { get; }

    /// <summary>
    /// Координата Y
    /// </summary>
    public double Y { get; }

    /// <summary>
    /// Наименование точки
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="x">Координата X</param>
    /// <param name="y">Координата Y</param>
    /// <param name="name">Наименование точки</param>
    public SchemePoint(double x, double y, string name) {
        X    = x;
        Y    = y;
        Name = name;
    }

    public override int GetHashCode()
        => HashCode.Combine<int, int, int>(X.GetHashCode(), Y.GetHashCode(), Name.GetHashCode());

    public override bool Equals(object other) {
        if (other == null) {
            return false;
        }

        if (other is not SchemePoint otherPoint) {
            return false;
        }

        return Equals(otherPoint);
    }

    public bool Equals(SchemePoint other) =>    this.X == other.X
                                             && this.Y == other.Y
                                             && this.Name.Equals(other.Name);

    public override string ToString() =>  Name;
}
