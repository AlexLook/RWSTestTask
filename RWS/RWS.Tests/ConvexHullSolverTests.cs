using System.Text;

using RWS.Core;
using RWS.Core.Algorithms.JarvisMarch;

namespace RWS.Tests;

/// <summary>
/// Класс с тестами для алгоритма поиска окружающей оболочки
/// </summary>
public class ConvexHullSolverTests {

    /// <summary>
    /// Проверка метода поиска внешней оболочки
    /// </summary>
    /// <param name="yardName">Имя парка</param>
    /// <param name="correctHull">Эталонная оболочка</param>
    [Theory]
    [InlineData("Парк 1", "P11-P14-P19-P18-P15")]
    [InlineData("Парк 2", "P20-P26-P27-P25-P22-P7")]
    public void Hull_yards(string yardName, string correctHull) {
        var stationBuilder = new RailwayStationBuilder();
        var station        = stationBuilder.Build();
        var allPoints      = station.GetAllYardPoints(yardName);
        var solver         = new ConvexHullSolver();
        var hull           = solver.ComputeConvexHull(allPoints);
        var path           = HullToString(hull);

        Assert.Equal(path, correctHull);
    }

    /// <summary>
    /// Преобразование массива в строку для сверки с ручными данными
    /// </summary>
    /// <param name="hull">Массив  станционных точек</param>
    /// <returns>Строковое представление оболочки</returns>
    private string HullToString(StationPoint[] hull) {
        var path = new StringBuilder();
        foreach (var point in hull) {
            path.Append(point.Name);
            path.Append('-');
        }

        if (path.Length > 0) path.Remove(path.Length - 1, 1);

        return path.ToString();
    }
}
