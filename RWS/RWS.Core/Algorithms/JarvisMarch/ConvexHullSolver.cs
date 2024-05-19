using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core.Algorithms.JarvisMarch;

/// <summary>
/// Поиск выпуклой оболочки по алгоритму Джарвиса
/// </summary>
/// <remarks>
/// Источник: https://github.com/mihaighidoveanu/Jarvis-March/tree/master
/// </remarks>
public class ConvexHullSolver
{
    public ConvexHullSolver() {

    }

    public StationPoint[] ComputeConvexHull(StationPoint[] allPoints) {
        var hull = new List<StationPoint>();
        if (allPoints == null || allPoints.Length == 0)
            return hull.ToArray();

        if (allPoints.Length >= 3) {
            var leftMost = 0;
            for (var i = 1; i < allPoints.Length; i++) {
                if (allPoints[i].X < allPoints[leftMost].X)
                    leftMost = i;
            }

            var current = leftMost;
            var next = 0;

            do {
                hull.Add(allPoints[current]);

                next = (current + 1) % allPoints.Length;

                for (var i = 0; i < allPoints.Length; i++) {
                    if (i == current || i == next)
                        continue;

                    var direction = allPoints[i].LineEq(allPoints[current], allPoints[next]);
                    if (direction < 0)
                        next = i;

                    if (direction == 0
                        && allPoints[current].DistanceTo(allPoints[i])
                           > allPoints[current].DistanceTo(allPoints[next]))
                        next = i;
                }

                current = next;
            } while (current != leftMost);
        }

        return hull.ToArray();
    }
}
