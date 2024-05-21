using System.Text;

namespace RWS.Core;

/// <summary>
/// Связанный отрезок на станции
/// </summary>
/// <remarks>
/// Всегда добавлять начальный и конечный участки. Начальный добавляется в конструкторе,
/// конечный надо добавлять в коде по завершению добавления участков!
/// Если такой сектор есть в наборе - он не добавится, а так он может не попасть
/// по той причине, что граничная точка принадлежит двум участкам и в зависимости от
/// направления движения крайний сектор может быть пропущен, но путь будет найден в
/// любом случае, т.к. мы по любому двигаемся с границы участка.
/// </remarks>
public class StationPath {

    /// <summary>
    /// Начальный участок
    /// </summary>
    public Section Origin { get; }

    /// <summary>
    /// Конечный участок
    /// </summary>
    public Section Destination { get; private set; }

    /// <summary>
    /// Список участков в отрезке
    /// </summary>
    public List<Section> Sections { get; }

    /// <summary>
    /// Длинна отрезка
    /// </summary>
    public double Length { 
        get {
            var len = 0.0d;
            foreach (var section in Sections) {
                len += section.Length;
            }

            return len;
        }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="origin">Начальный участок</param>
    /// <param name="destination">Конечный участок</param>
    public StationPath(Section origin, Section destination) {
        Origin      = origin;
        Destination = destination;
        Sections    = new List<Section>();
        AddSection(Origin);
    }

    /// <summary>
    /// Добавление участка к отрезку
    /// </summary>
    /// <param name="section">Участок</param>
    public void AddSection(Section section) {
        if (!Sections.Contains(section)) Sections.Add(section);
    }

    public override string ToString() {
        var builder = new StringBuilder();
        foreach (var section in Sections) {
            builder.Append(section.Name);
            builder.Append('-');
        }
        builder.Remove(builder.Length - 1, 1);

        return builder.ToString();
    }
}
