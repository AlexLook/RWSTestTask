using Spectre.Console;

using RWS.Core;
using RWS.Core.Algorithms.Dijkstra;
using RWS.Core.Algorithms.Dijkstra.Exceptions;

namespace RWS;

/// <summary>
/// Класс по поиску кратчайшего пути на станции.
/// </summary>
/// <remarks>
/// Внимание! Все пути с двусторонним движением!
/// Для одностороннего движения надо задавать только связи в сторону движения,
/// а в схеме станции предусматривать переходные участки с двусторонним движением.
/// </remarks>
internal class FindPathCommand : IFindPathCommand {

    private readonly IRepository repository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="repository">Репозиторий станции</param>
    public FindPathCommand(IRepository repository) {
        this.repository = repository;
    }

    /// <summary>
    /// Выполнение команды
    /// </summary>
    public void Execute() {
        try {
            var station = repository.GetRailwayStation();

            var sectionStartName = AnsiConsole.Ask<string>("Введите начальный участок:");
            var sectionFinishName = AnsiConsole.Ask<string>("Введите конечный участок:");

            AnsiConsole.WriteLine("Путь:");

            var solver = new ShortestPathSolver(station);
            var stationPath = solver.GetShortestPath(sectionStartName, sectionFinishName);

            AnsiConsole.WriteLine($"\t Начальный участок : {stationPath.Origin.Name}");
            AnsiConsole.WriteLine($"\t Конечный участок  : {stationPath.Destination.Name}");
            AnsiConsole.WriteLine($"\t Участки           : ");
            foreach (var section in stationPath.Sections) {
                AnsiConsole.WriteLine($"\t\t {section.Name} ({section.Point1}:{section.Point2})");
            }
        } catch (PathNotFoundException) {
            AnsiConsole.MarkupLine($"[red]Пути между участками не существует![/]");
        } catch (Exception ex) {
            AnsiConsole.MarkupLine($"[red]{ex}[/]");
        }
    }
}
