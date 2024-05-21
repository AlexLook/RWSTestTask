using RWS.Core;
using RWS.Core.Algorithms.Dijkstra;
using RWS.Core.Algorithms.Dijkstra.Exceptions;

namespace RWS.Tests;

/// <summary>
/// Класс для тестирования метода поиска кратчайшего пути
/// (по алгоритму Дейкстры)
/// </summary>
public class PathFinderTests
{

    /// <summary>
    /// Поиск кратчайшего пути
    /// </summary>
    /// <param name="originName">Начальный участок</param>
    /// <param name="destinationName">Конечный участок</param>
    /// <param name="realPath">Кратчайший путь (эталон)</param>
    [Theory]
    [InlineData("S16", "S29", "S16-S11-S2-S23-S24-S27-S28-S29")]
    [InlineData("S28", "S25", "S28-S27-S25")]
    [InlineData( "S1",  "S7", "S1-S2-S3-S4-S5-S6-S7")]
    [InlineData( "S7",  "S1", "S7-S6-S5-S4-S3-S2-S1")]
    [InlineData("S22", "S27", "S22-S19-S15-S26-S25-S27")]
    [InlineData("S34", "S35", "S34-S35")]
    public void Path_is_found_and_shortest(string originName,
                                           string destinationName,
                                           string realPath) {
        var stationBuilder     = new RailwayStationBuilder();
        var station            = stationBuilder.Build();
        var shortestPathSolver = new ShortestPathSolver(station);

        var stationPath = shortestPathSolver.GetShortestPath(originName,
                                                             destinationName);

        Assert.Equal(stationPath.Origin.Name,      originName);
        Assert.Equal(stationPath.Destination.Name, destinationName);
        Assert.Equal(stationPath.ToString(),       realPath);
    }

    /// <summary>
    /// Проверка выкидывания исключения, если пути нету
    /// </summary>
    [Fact]
    public void Path_not_found_exception() {
        var stationBuilder     = new RailwayStationBuilder();
        var station            = stationBuilder.Build();
        var shortestPathSolver = new ShortestPathSolver(station);
        var exceptionType      = typeof(PathNotFoundException);

        var exception = Record.Exception(
            () => shortestPathSolver.GetShortestPath("S34", "S2"));

        Assert.NotNull(exception);
        Assert.IsType<PathNotFoundException>(exception);
    }
}