namespace RWS.Core;

/// <summary>
/// Точка схемы станции (точки начала и конца секций)
/// </summary>
/// <remarks>
/// Такое имя выбрано для избегания конфликта с типом Point из  библиотеки .Net
/// </remarks>
public class StationPoint : IEquatable<StationPoint> {

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
    /// Список участков исходящих из этой точки
    /// </summary>
    public List<Section> Sections { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="x">Координата X</param>
    /// <param name="y">Координата Y</param>
    /// <param name="name">Наименование точки</param>
    public StationPoint(double x, double y, string name) {
        X        = x;
        Y        = y;
        Name     = name;
        Sections = new List<Section>();
    }

    public override int GetHashCode()
        => HashCode.Combine<int, int, int>(X.GetHashCode(),
                                           Y.GetHashCode(),
                                           Name.GetHashCode());

    public override bool Equals(object? other) {
        if (other == null) {
            return false;
        }

        if (other is not StationPoint otherPoint) {
            return false;
        }

        return Equals(otherPoint);
    }

    public bool Equals(StationPoint? other) {
        if (other == null) return false;

        return    this.X == other.X
               && this.Y == other.Y
               && this.Name.Equals(other.Name);
    }

    public override string ToString() => $"{Name}({X}:{Y})";

    /// <summary>
    /// Добавить участок
    /// </summary>
    /// <param name="section">Участок</param>
    public void AddSection(Section section) {
        Sections.Add(section);
    }

    /// <summary>
    /// Добавить участок
    /// </summary>
    /// <param name="point">Точка к которой направлен участок</param>
    /// <param name="name">Название участка</param>
    public void AddSection(StationPoint point, string name) {
        AddSection(new Section(this, point, name));
    }

    /// <summary>
    /// Добавить участок
    /// </summary>
    /// <param name="point">Точка к которой направлен участок</param>
    public void AddSection(StationPoint point) {
        AddSection(new Section(this, point, $"S_{this.Name}_{point.Name}"));
    }
}
