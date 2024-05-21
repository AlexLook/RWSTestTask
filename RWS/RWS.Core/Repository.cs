namespace RWS.Core;

/// <summary>
/// Репозиторий для работы со станцией
/// </summary>
public class Repository : IRepository {
    public RailwayStation GetRailwayStation() {
        var builder = new RailwayStationBuilder();

        return builder.Build();
    }
}
