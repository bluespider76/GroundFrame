using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Horizon4.GF.Network
{
    /// <summary>
    /// Enum representing a location options
    /// </summary>
    public enum LocationOptions
    {
        None = 0,
        CannotStopAtLocation = 1,
        OnlyStopIfReversing = 2,
        PassengerTrainsCannotStop = 4,
        HasCallOn = 8,
        CannotSurrenderToken = 16
    }

    /// <summary>
    /// Enum representing signal types
    /// </summary>
    public enum NetworkSignalType
    {
        MainAspect = 1,
        ShuntSignal = 2
    }

    /// <summary>
    /// Enum representing a location type
    /// </summary>
    public enum LocationType
    {
        Station = 1,
        Siding = 2,
        Junction = 3,
        PassingLoop = 4,
        Depot = 5,
        ReversingPoint = 6,
        InternalTimingPoint = 7,
        GroundFrame = 8
    }

    /// <summary>
    /// Enum representing a track permissible direction
    /// </summary>
    public enum NetworkDirection
    {
        NotApplicable = 0,      
        Up = 1,
        Down = 2,
        Both = 3
    }

    /// <summary>
    /// Enum representing a path type
    /// </summary>
    public enum PathType
    {
        Main = 1,
        Relief = 2,
        SingleTrainWorking = 3
    }

    /// <summary>
    /// Enum representing depot capabilities
    /// </summary>
    public enum DepotCapabilities
    {
        AExam = 1,
        BExam = 2,
        CExam = 4,
        DExam = 8,
        EExam = 16,
        FExam = 32,
        WheelLathe = 64,
        Fuel = 128,
        Coal = 256,
        Water = 512,
        MaintenanceDiesel = 1024,
        MaintenanceOverhead = 2048,
        Maintenance3rdRail = 4096,
        MaintenanceLoco = 8192,
        MaintenanceEMU = 16384,
        MaintenanceDMU = 32768,
        MaintenanceDEMU = 65536,
        MaintenanceCarriage = 131072,
        MaintenanceWagon = 262144
    }
}
