using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace RWS.Core;

/// <summary>
/// Класс для создания объекта типа RailwayStation
/// </summary>
public class RailwayStationBuilder {

    /// <summary>
    /// Создание объекта RailwayStation
    /// </summary>
    /// <returns>Созданный объект</returns>
    public RailwayStation Build() {
        var station = new RailwayStation("Тестовая станция");

        // Объявлем точки станции и добавляем их в станцию
        var point1    = new StationPoint( 1, 16,  "P1");
        var point2    = new StationPoint( 4, 16,  "P2");
        var point3    = new StationPoint( 9, 16,  "P3");
        var point4    = new StationPoint(14, 16,  "P4");
        var point5    = new StationPoint(18, 16,  "P5");
        var point6    = new StationPoint(29, 16,  "P6");
        var point7    = new StationPoint(33, 16,  "P7");
        var point8    = new StationPoint(37, 16,  "P8");
        var point9    = new StationPoint(18, 14,  "P9");
        var point10   = new StationPoint(29, 14, "P10");
        var point11   = new StationPoint( 7, 19, "P11");
        var point12   = new StationPoint(13, 19, "P12");
        var point13   = new StationPoint(24, 19, "P13");
        var point14   = new StationPoint(30, 19, "P14");
        var point15   = new StationPoint( 9, 22, "P15");
        var point16   = new StationPoint(19, 22, "P16");
        var point17   = new StationPoint(27, 22, "P17");
        var point18   = new StationPoint(13, 26, "P18");
        var point19   = new StationPoint(23, 26, "P19");
        var point20   = new StationPoint(13, 10, "P20");
        var point21   = new StationPoint(16, 10, "P21");
        var point22   = new StationPoint(30, 10, "P22");
        var point23   = new StationPoint(18,  7, "P23");
        var point24   = new StationPoint(24,  7, "P24");
        var point25   = new StationPoint(28,  7, "P25");
        var point26   = new StationPoint(17,  4, "P26");
        var point27   = new StationPoint(21,  4, "P27");
        
        // Объявляем участки
        var section1  = new Section( point1,  point2,  "S1");
        var section2  = new Section( point2,  point3,  "S2");
        var section3  = new Section( point3,  point4,  "S3");
        var section4  = new Section( point4,  point5,  "S4");
        var section5  = new Section( point5,  point6,  "S5");
        var section6  = new Section( point6,  point7,  "S6");
        var section7  = new Section( point7,  point8,  "S7");
        var section8  = new Section( point4,  point9,  "S8");
        var section9  = new Section( point9, point10,  "S9");
        var section10 = new Section(point10,  point7, "S10");
        var section11 = new Section( point2, point11, "S11");
        var section12 = new Section(point11, point12, "S12");
        var section13 = new Section(point12, point13, "S13");
        var section14 = new Section(point13, point14, "S14");
        var section15 = new Section(point14,  point7, "S15");
        var section16 = new Section(point11, point15, "S16");
        var section17 = new Section(point15, point16, "S17");
        var section18 = new Section(point16, point17, "S18");
        var section19 = new Section(point17, point14, "S19");
        var section20 = new Section(point15, point18, "S20");
        var section21 = new Section(point18, point19, "S21");
        var section22 = new Section(point19, point17, "S22");
        var section23 = new Section( point3, point20, "S23");
        var section24 = new Section(point20, point21, "S24");
        var section25 = new Section(point21, point22, "S25");
        var section26 = new Section(point22,  point7, "S26");
        var section27 = new Section(point21, point23, "S27");
        var section28 = new Section(point23, point24, "S28");
        var section29 = new Section(point24, point25, "S29");
        var section30 = new Section(point25, point22, "S30");
        var section31 = new Section(point20, point26, "S31");
        var section32 = new Section(point26, point27, "S32");
        var section33 = new Section(point27, point24, "S33");

        // Объявляем пути
        var track1 = new Track(new Section[] {  section2,  section3,  section4,  section5,  section6 }, "Путь 1");
        var track2 = new Track(new Section[] { section12, section13, section14                       }, "Путь 2");
        var track3 = new Track(new Section[] { section20, section21, section22, section19            }, "Путь 3");
        var track4 = new Track(new Section[] { section24, section25, section26                       }, "Путь 4");
        var track5 = new Track(new Section[] { section31, section32, section33, section29, section30 }, "Путь 5");

        // Объявляем парки
        var yard1  = new Yard("Парк 1");
        var yard2  = new Yard("Парк 2");

        // Добавляем участки к станции
        station.AddSection( section1);
        station.AddSection( section2);
        station.AddSection( section3);
        station.AddSection( section4);
        station.AddSection( section5);
        station.AddSection( section6);
        station.AddSection( section7);
        station.AddSection( section8);
        station.AddSection( section8);
        station.AddSection( section9);
        station.AddSection(section10);
        station.AddSection(section11);
        station.AddSection(section12);
        station.AddSection(section13);
        station.AddSection(section14);
        station.AddSection(section15);
        station.AddSection(section16);
        station.AddSection(section17);
        station.AddSection(section18);
        station.AddSection(section19);
        station.AddSection(section20);
        station.AddSection(section21);
        station.AddSection(section22);
        station.AddSection(section23);
        station.AddSection(section24);
        station.AddSection(section25);
        station.AddSection(section26);
        station.AddSection(section27);
        station.AddSection(section28);
        station.AddSection(section29);
        station.AddSection(section30);
        station.AddSection(section31);
        station.AddSection(section32);
        station.AddSection(section33);

        // Добавляем пути к станции
        station.AddTrack(track1);
        station.AddTrack(track2);
        station.AddTrack(track3);
        station.AddTrack(track4);
        station.AddTrack(track5);

        // Добавляем пути в парки
        yard1.AddTrack(track2);
        yard1.AddTrack(track3);

        yard2.AddTrack(track4);
        yard2.AddTrack(track5);

        // Добавляем парки к станции
        station.AddYard(yard1);
        station.AddYard(yard2);

        // Возвращаем сконструированную станцию
        return station;
    }
}
