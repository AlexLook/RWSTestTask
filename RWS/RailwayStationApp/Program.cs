using System;

using Microsoft.Extensions.DependencyInjection;

using Spectre.Console;

using RWS.Core;

namespace RWS;

public static class Program {

    private static IServiceCollection ConfigureServices() {
        var services = new ServiceCollection();
        services.AddTransient<IRepository, Repository>();
        services.AddSingleton<IShowStationSchemeCommand, ShowStationSchemeCommand>();
        services.AddSingleton<IFindPathCommand, FindPathCommand>();
        return services;
    }

    public static int Main(string[] args) {
        var services        = ConfigureServices();
        var serviceProvider = services.BuildServiceProvider();

        var needExit = false;

        while (!needExit) {
            AnsiConsole.Clear();

            AnsiConsole.WriteLine("Railway Station test application.");
            AnsiConsole.WriteLine();

            AnsiConsole.WriteLine("Введите номер команды:");
            AnsiConsole.MarkupLine("1. Показать доступные парки, вершины парка и его заливку");
            AnsiConsole.MarkupLine("2. Найти путь на станции");
            AnsiConsole.MarkupLine("3. Завершить программу");

            var cmd = AnsiConsole.Ask<string>("[yellow]Комманда:[/]");
            AnsiConsole.WriteLine($"Выбранная комманда: {cmd}");

            switch (cmd) {
                case "1":
                    var showStationSchemeCommand = serviceProvider.GetService<IShowStationSchemeCommand>();
                    showStationSchemeCommand?.Execute();
                    break;
                case "2":
                    var findPathCommand = serviceProvider.GetService<IFindPathCommand>();
                    findPathCommand?.Execute();
                    break;
                case "3":
                    needExit = true;
                    break;
                default:
                    break;
            }

            if (!needExit) {
                AnsiConsole.WriteLine("Нажмите любую клавишу для продолжения");
                AnsiConsole.Console.Input.ReadKey(false);
            }
        }

        return 0;
    }
}

