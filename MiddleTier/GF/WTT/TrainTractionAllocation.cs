using Horizon4.GF.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horizon4.GF.Logical;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Horizon4.GF.WTT;

namespace Horizon4.GF.RollingStock
{
    public class TrainTractionAllocation
    {
        #region Private Variables

        private int _ID; //Private variable to store the DB ID of the TrainRakeAllocation
        private TractionClass _TractionClass; //Rake allocated to the Train;
        private Sector _Sector; //Prviate variable to store the sector of the allocation traction;
        private Location _DepotLocation; //Private variable to store the depot of the allocated traction;
        private decimal _Percentage; //The percentage likelihood that the rake is allocated to the train;
        private bool _BookedTraction; //Flag to indicate whether this is the booked traction
        private Region _Region; //Flag to store the region of the allocation traction;

        #endregion Private Variables

        #region Properties
        
        /// <summary>
        /// Gets the Groundframe DB ID of the TrainTractionAllocation
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the TractionClass of the TrainTractionAllocation
        /// </summary>
        public TractionClass TractionClass { get { return this._TractionClass; } }

        /// <summary>
        /// Gets the Sector of the TrainTractionAllocation
        /// </summary>
        public Sector Sector { get { return this._Sector; } }

        /// <summary>
        /// Gets the Depot of the TrainTractionAllocation
        /// </summary>
        public Location DepotLocation { get { return this._DepotLocation; } }

        /// <summary>
        /// Gets the Percentage of the TrainTractionAllocation
        /// </summary>
        public decimal Percentage { get { return this._Percentage; } }

        /// <summary>
        /// Gets the flag to indicate whether the TrainTractionAllocation is the booked traction
        /// </summary>
        public bool BookedTraction { get { return this._BookedTraction; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialises a new instance of a TrainTractionAllocation object based on the GroundFrame DB ID
        /// </summary>
        /// <param name="ID"></param>
        public TrainTractionAllocation(int ID)
        {
            this._ID = ID;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads the Train Traction Allocation of the specified ID GF Database
        /// </summary>
        /// <param name="SystemLocation"></param>
        /// <param name="YMDV"></param>
        private void GetTrainTractionAllocationFromDatabaseByID()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("wtt.Usp_GET_TTRAINTRACTIONALLOCATION_BY_ID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this._ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //If no record are found then throw an error. This should never happen
                        if (SQLReader.HasRows == false) { throw new Exception(string.Format(@"TrainTractionAllocation with ID {0} doesn't exist in the GF Database", this._ID)); };

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            ParseSQLReader(SQLReader);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive the TrainTractionAllocation with System Loction ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Parses a SqlDataReader object into a TrainTractionAllocation object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            int TractionClassID = SQLReader.GetInt32(SQLReader.GetOrdinal("traction_class_itemno"));
            this._TractionClass = Common.TractionClasses.Where(x => x.ID == TractionClassID).FirstOrDefault();

            int SectorItemNo = SQLReader.GetSafeInt32(SQLReader.GetOrdinal("sector_itemno"));
            if (SectorItemNo != 0) { this._Sector = Common.Sectors.Where(x => x.ID == SectorItemNo).FirstOrDefault(); };

            int DepotLocationItemNo = SQLReader.GetSafeInt32(SQLReader.GetOrdinal("depot_location_itemno"));
            if (DepotLocationItemNo != 0) { this._DepotLocation = new Location(DepotLocationItemNo); };

            int RegionItemNo = SQLReader.GetSafeInt32(SQLReader.GetOrdinal("region_itemno"));
            if (RegionItemNo != 0) { this._Region = Common.Regions.Where(x => x.ID == RegionItemNo).FirstOrDefault(); };

            this._Percentage = SQLReader.GetSafeDecimal(SQLReader.GetOrdinal("perc"));
            this._BookedTraction = SQLReader.GetBoolean(SQLReader.GetOrdinal("booked_traction"));
        }

        #endregion Methods
    }

    /// <summary>
    /// Class to represent a collection of Train Traction Allocation
    /// </summary>
    public class TrainTractionAllocationCollection : IEnumerable<TrainTractionAllocation>
    {
        #region Private Variables

        private List<TrainTractionAllocation> _TrainTractionAllocations = new List<TrainTractionAllocation>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<TrainTractionAllocation> GetEnumerator() { return this._TrainTractionAllocations.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new TrainTractionAllocation Collection from the GF Database based on the YMDV and Train
        /// </summary>
        public TrainTractionAllocationCollection(YMDV YMDV, Train Train)
        {
            GetAllTrainTractionAllocationsFromDBByYMDBVandTrain(YMDV, Train);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of Train Traction Allocations from the GF Database for the YMDV and Train
        /// </summary>
        private void GetAllTrainTractionAllocationsFromDBByYMDBVandTrain(YMDV YMDV, Train Train)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the TrainTractionAllocations from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _TrainTractionAllocations as a new List
            _TrainTractionAllocations = new List<TrainTractionAllocation>();

            //Get the TrainTractionAllocations from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("wtt.Usp_GET_TRAINTRACTIONALLOCATIONS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        cmd.Parameters.AddWithValue("@train_itemno", Train.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _TrainTractionAllocations.Add(new TrainTractionAllocation(SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"))));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Train Traction Allocations from the GF Database", Ex);
                }

                if (HasBookedTraction() == false)
                {
                    throw new Exception(string.Format("Train Traction Allocation for Train ID {0} ({1} - {2}) on YMDV {3} does not have a booked allocation item.", Train.ID, Train.Headcode, Train.Description, YMDV.Value));
                }
            }
        }

        /// <summary>
        /// Checks to see whether the Train Traction Allocation has a booked traction item. If False the zero or more than one item is set as the booked traction
        /// </summary>
        /// <returns>book (true = has booked traction | false = no booked traction)</returns>
        public bool HasBookedTraction()
        {
            bool Result = false;

            if (_TrainTractionAllocations.Count(x => x.BookedTraction == true) == 1)
            {
                Result = true;
            }

            return Result;
        }

        #endregion Methods
    }
}
