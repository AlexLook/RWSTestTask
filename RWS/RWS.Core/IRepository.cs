using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.Core;

/// <summary>
/// Интерфейс репозитория для станции
/// </summary>
public interface IRepository
{
    RailwayStation GetRailwayStation();
}
