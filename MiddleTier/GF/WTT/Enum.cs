using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horizon4.GF.WTT
{
    /// <summary>
    /// Enum to represent the bitwise values available for the train configuration
    /// </summary>
    public enum TrainConfiguration
    {
        Freight = 1,
        Seating = 2,
        EmptyCoachingStock = 4,
        Sleeper = 8,
        Motorail = 16,
        Railtour = 32,
        Footex = 64,
        MerryMaker = 128
    }


    /// <summary>
    /// Enum representing days
    /// </summary>
    public enum WTTDays
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64
    }
}
