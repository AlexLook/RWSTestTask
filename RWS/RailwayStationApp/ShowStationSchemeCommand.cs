using Spectre.Console;

using RWS.Core;
using RWS.Core.Algorithms.JarvisMarch;

namespace RWS;

/// <summary>
/// Класс по выводу статистики и обасти заливки для парков.
/// </summary>
internal class ShowStationSchemeCommand : IShowStationSchemeCommand {

    private readonly IRepository repository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="repository">Репозиторий станции</param>
    public ShowStationSchemeCommand(IRepository repository) {
        this.repository = repository;
    }

    /// <summary>
    /// Выполнение команды
    /// </summary>
    public void Execute() {
        try {
            var station = repository.GetRailwayStation();

            AnsiConsole.WriteLine("Парки станции:");
            foreach (var yard in station.Yards) {
                AnsiConsole.WriteLine($"{yard.Name}:");
                foreach (var track in yard.Tracks) {
                    AnsiConsole.WriteLine($"\t {track}:");
                    foreach (var section in track.Sections) {
                        AnsiConsole.Write($"\t\t {section} ({section.Point1} - {section.Point2});");
                        AnsiConsole.WriteLine();
                    }
                    AnsiConsole.WriteLine();
                }
            }

            // Вывести заливки парков станции
            foreach (var yard1 in station.Yards) {
                var allPoints = station.GetAllYardPoints(yard1.Name);
                var solver = new ConvexHullSolver();
                var hull = solver.ComputeConvexHull(allPoints);
                PrintHull(yard1, hull);
            }

            AnsiConsole.WriteLine();
        }
        catch (Exception ex) {
            AnsiConsole.MarkupLine($"[red]{ex}[/]");
        }
    }

    /// <summary>
    /// Вывод заливки для парка.
    /// </summary>
    /// <param name="yard">Имя парка.</param>
    /// <param name="hull">Масив точек описывающих окружающую оболочку.</param>
    private void PrintHull(Yard yard, StationPoint[] hull) {
        AnsiConsole.WriteLine($"Заливка для парка {yard.Name}:");
        foreach (var point in hull) {
            AnsiConsole.WriteLine($"\t {point}");
        }

        AnsiConsole.WriteLine();
    }
}

