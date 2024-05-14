using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core;

/// <summary>
/// Вспомогательный класс с информацией о точке для алгоритма поиска пути
/// </summary>
internal class StationPointInfo {

    /// <summary>
    /// Точка станции
    /// </summary>
    public StationPoint StationPoint { get; set; }

    /// <summary>
    /// Признак непосещенности точки
    /// </summary>
    public bool IsUnvisited { get; set; }

    /// <summary>
    /// Сумма весов участков
    /// </summary>
    public double LengthsSum { get; set; }

    /// <summary>
    /// Предыдущая точка
    /// </summary>
    public StationPoint? PreviousStationPoint { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="point">Станционная точка</param>
    public StationPointInfo(StationPoint point) {
        StationPoint         = point;
        IsUnvisited          = true;
        LengthsSum           = double.MaxValue;
        PreviousStationPoint = null;
    }
}
