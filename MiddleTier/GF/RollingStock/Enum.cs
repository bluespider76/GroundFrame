using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horizon4.GF.RollingStock
{
    /// <summary>
    /// Enum to define the stock type
    /// </summary>
    public enum StockType
    {
        Mark1 = 1,
        Mark2 = 2,
        Mark3 = 3,
        Mark4 = 4,
        NSPCC = 5
    }

    /// <summary>
    /// Enum to define coupling types
    /// </summary>
    public enum StockCouplingType
    {
        Drawbar = 1,
        Buckeye = 2,
        Dellner = 4,
        BSI = 8
    }

    /// <summary>
    /// Enum to represent the bitwise values available for the train brake systems
    /// </summary>
    public enum StockBrakeType
    {
        Vacuum = 1,
        Air = 2,
        ElectroPnuematic = 4
    }

    /// <summary>
    /// Enum to represent the bitwise values available train heating systems
    /// </summary>
    public enum StockHeatType
    {
        Steam = 1,
        ETH = 2,
        Onboard = 4
    }

    /// <summary>
    /// Enum to represent the bitwise valules avilaable to stock options
    /// </summary>
    public enum StockOption
    {
        HasSeating = 1,
        IsSleeper = 2
    }

    /// <summary>
    /// Enum to represent the traction type
    /// </summary>
    public enum TractionType
    {
        Loco = 1,
        DMU = 2,
        EMU = 3,
        DEMU = 4
    }
}
