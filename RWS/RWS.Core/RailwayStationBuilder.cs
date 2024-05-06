using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        return station;
    }
}
