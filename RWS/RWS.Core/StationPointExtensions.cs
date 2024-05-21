namespace RWS.Core;

/// <summary>
/// Методы расширения для класса StationPoint
/// </summary>
public static class StationPointHelpers {

    /// <summary>
    /// Метод вычисления позиции точки относительно луча
    /// (для алгоритма Джарвиса)
    /// </summary>
    /// <param name="thisPoint">Текущая станционная точка</param>
    /// <param name="point1">Точка 1</param>
    /// <param name="point2">Точка 2</param>
    /// <returns></returns>
    public static double LineEq(this StationPoint thisPoint,
                                     StationPoint point1,
                                     StationPoint point2) {
        return   thisPoint.X * (point1.Y - point2.Y)
               + thisPoint.Y * (point2.X - point1.X)
               + point1.X * point2.Y
               - point2.X * point1.Y;
    }

    /// <summary>
    /// Метод вычисления расстояния между точками
    /// (для алгоритма Джарвиса)
    /// </summary>
    /// <param name="thisPoint">Текущая станционная точка</param>
    /// <param name="otherPoint">Точка до которой вычисляется расстояние</param>
    /// <returns></returns>
    public static double DistanceTo(this StationPoint thisPoint,
                                         StationPoint otherPoint) {
        return Math.Sqrt(  Math.Pow(thisPoint.X - otherPoint.X, 2)
                         + Math.Pow(thisPoint.Y - otherPoint.Y, 2));
    }
}
