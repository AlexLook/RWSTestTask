using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Spectre.Console;

using RWS.Core;
using RWS.Core.Algorithms.Dijkstra;

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

    public FindPathCommand(IRepository repository) {
        this.repository = repository;
    }

    public void Execute() {
        try {
            var station = repository.GetRailwayStation();

            var sectionStartName  = AnsiConsole.Ask<string>("Введите начальный участок:");
            var sectionFinishName = AnsiConsole.Ask<string>("Введите конечный участок:");

            AnsiConsole.WriteLine("Путь:");

            var solver      = new ShortestPathSolver(station);
            var stationPath = solver.GetShortestPath(sectionStartName, sectionFinishName);

            AnsiConsole.WriteLine($"\t Начальный участок : {stationPath.Origin.Name}");
            AnsiConsole.WriteLine($"\t Конечный участок  : {stationPath.Destination.Name}");
            AnsiConsole.WriteLine($"\t Участки           : ");
            foreach (var section in stationPath.Sections) {
                AnsiConsole.WriteLine($"\t\t {section.Name} ({section.Point1}:{section.Point2})");
            }
        } catch (Exception ex) {
            AnsiConsole.MarkupLine($"[red]{ex}[/]");
            throw;
        }
    }
}
