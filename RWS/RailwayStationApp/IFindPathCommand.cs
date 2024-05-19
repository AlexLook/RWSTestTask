using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS;

/// <summary>
/// Интерфейс по поиску кратчайшего пути на станции.
/// </summary>
internal interface IFindPathCommand {
    void Execute();
}
