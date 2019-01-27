using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horizon4.GF
{
    /// <summary>
    /// Enum representing power types
    /// </summary>
    public enum PowerType
    {
        Steam = 1,
        Diesel = 2,
        Electric3rdRail750 = 4,
        Electric3rdRail1500 = 8,
        Electric4thRail600 = 16,
        ElectricOverhead1500 = 32,
        ElectricOverhead6500 = 64,
        ElectricOverhead25000 = 128,
        Battery = 256
    }

    public enum Application
    {
        Sandpit = 1,
        DataEditor = 2
    }
}
