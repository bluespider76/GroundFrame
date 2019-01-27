using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horizon4.GF.Network;
using Horizon4.GF.RollingStock;
using Horizon4.GF.Logical;
using Horizon4.GF.WTT;

namespace Horizon4.GF
{
    public static class Common
    {
        #region Private variables

        private static string _SQLDBConn; //Private variable to the store the Connection String to the DB Connection

        #endregion Private variables

        /// <summary>
        /// Holds the Connection String to the DB
        /// </summary>
        public static string SQLDBConn { get { return GetSQLConnectionString(); } set { _SQLDBConn = value; } }

        public static Application? Application { get; set; }

        public static SystemLocationCollection SystemLocations { get; set; }

        public static TokenCollection Tokens { get; set; }

        public static LocationCollection Locations { get; set; }

        public static SystemPathCollection SystemPaths { get; set; }

        public static PathCollection Paths { get; set; }

        public static DepotCollection Depots { get; set; }

        public static TractionClassCollection TractionClasses { get; set; }

        public static SectorCollection Sectors { get; set; }

        public static StockCollection StockList { get; set; }

        public static YMDV CurrentYMDV { get; set; }

        public static RakeCollection Rakes { get; set; }

        public static TrainCollection Trains { get; set; }

        public static RegionCollection Regions { get; set; }

        public static SystemSectorCollection SystemSectors { get; set; }

        #region Methods

        /// <summary>
        /// Gets the connection string to the GroundFrame DB
        /// </summary>
        /// <returns></returns>
        private static string GetSQLConnectionString()
        {
            if (Application == null)
            {
                throw new Exception ("You must set the Application in order to access the Connection String");
            }
            else if (string.IsNullOrEmpty(_SQLDBConn))
            {
                throw new Exception ("No Connection String has been set");
            }
            else
            {
                return _SQLDBConn;
            }
        }

        #endregion Methods
    }
}
