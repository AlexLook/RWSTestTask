using System.Text;

using RWS.Core;

namespace RWS.Tests;

/// <summary>
/// Класс с тестами по структуре станции
/// </summary>
public class RailwayStationTests {

    /// <summary>
    /// Тесты структуры парка
    /// </summary>
    /// <param name="yardName">Имя парка</param>
    /// <param name="actualYardStructure">Эталонное значение</param>
    [Theory]
    [InlineData("Парк 1", "Путь 2; Путь 3")]
    [InlineData("Парк 2", "Путь 4; Путь 5")]
    public void Station_yard_structure(string yardName, string actualYardStructure) {
        var stationBuilder = new RailwayStationBuilder();
        var station        = stationBuilder.Build();

        var yard   = station.Yards.Find(y => y.Name == yardName);
        var tracks = YardStructure(yard);

        Assert.Equal(tracks, actualYardStructure);
    }

    /// <summary>
    /// Тесты структуры пути
    /// </summary>
    /// <param name="trackName">Имя пути</param>
    /// <param name="actualTrackStructure"Эталонное значение></param>
    [Theory]
    [InlineData("Путь 1", "S2-S3-S4-S5-S6")]
    [InlineData("Путь 2", "S12-S13-S14")]
    [InlineData("Путь 3", "S20-S21-S22-S19")]
    [InlineData("Путь 4", "S24-S25-S26")]
    [InlineData("Путь 5", "S31-S32-S33-S29-S30")]
    public void Station_track_structure(string trackName, string actualTrackStructure) {
        var stationBuilder = new RailwayStationBuilder();
        var station        = stationBuilder.Build();

        var track    = station.Tracks.Find(t => t.Name == trackName);
        var sections = TrackStructure(track);

        Assert.Equal(sections, actualTrackStructure);
    }

    /// <summary>
    /// Тесты структуры участка
    /// </summary>
    /// <param name="sectionName">Имя секции</param>
    /// <param name="actualSectionStructure">Эталонное значение</param>
    [Theory]
    [InlineData("S1",  "P1(1:16) - P2(4:16)")]
    [InlineData("S2",  "P2(4:16) - P3(9:16)")]
    [InlineData("S30", "P25(28:7) - P22(30:10)")]
    [InlineData("S18", "P16(19:22) - P17(27:22)")]
    public void Station_section_structure(string sectionName, string actualSectionStructure) {
        var stationBuilder = new RailwayStationBuilder();
        var station        = stationBuilder.Build();

        var section = station.Sections.Find(s => s.Name == sectionName);
        var points  = SectionStructure(section);

        Assert.Equal(points, actualSectionStructure);
    }

    /// <summary>
    /// Текстовое представление парка для проверки структуры
    /// </summary>
    /// <param name="yard">Путь</param>
    /// <returns>Текстовое представление парка</returns>
    private string YardStructure(Yard yard) {
        var structure = new StringBuilder();
        foreach (var track in yard.Tracks) {
            structure.Append(track.Name);
            structure.Append("; ");
        }
        structure.Remove(structure.Length - 2, 2);
        return structure.ToString();
    }

    /// <summary>
    /// Текстовое представлениепути для проверки структуры
    /// </summary>
    /// <param name="track">Путь</param>
    /// <returns>Текстовое представление</returns>
    private string TrackStructure(Track track) {
        var structure = new StringBuilder();
        foreach (var section in track.Sections) {
            structure.Append(section.Name);
            structure.Append('-');
        }
        structure.Remove(structure.Length - 1, 1);
        return structure.ToString();
    }

    /// <summary>
    /// Текстовое представление участка для проверки структуры
    /// </summary>
    /// <param name="section">Участок</param>
    /// <returns>Текстовое представление</returns>
    private string SectionStructure(Section section) {
        return $"{section.Point1} - {section.Point2}";
    }
}
