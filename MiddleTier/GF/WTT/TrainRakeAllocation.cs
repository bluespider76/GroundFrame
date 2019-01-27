using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Horizon4.GF.WTT;

namespace Horizon4.GF.RollingStock
{
    /// <summary>
    /// Class to represent the allocation of a rake to a train and percentage likelihood of the rake being allocated
    /// </summary>
    public class TrainRakeAllocation
    {
        #region Private Variables

        private int _ID; //Private variable to store the DB ID of the TrainRakeAllocation
        private Rake _Rake; //Rake allocated to the Train;
        private decimal _Percentage; //The percentage likelihood that the rake is allocated to the train
        private bool _BookedRake; //Flag to indicate whether the rake is the booked rake

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the Groundframe DB ID of the TrainRakeAllocation
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the rake of the TrainRakeAllocation
        /// </summary>
        public Rake Rake { get { return this._Rake; } }

        /// <summary>
        /// Gets the percentage chance of being allocated of the TrainRakeAllocation
        /// </summary>
        public decimal Percentage { get { return this._Percentage; } }

        /// <summary>
        /// Gets a flag to indicate whether the item is the booked rake of the TrainRakeAllocation
        /// </summary>
        public bool BookedRake { get { return this._BookedRake; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialises a new instance of a TrainRakeAllocation object based on the GroundFrame DB ID
        /// </summary>
        /// <param name="ID"></param>
        public TrainRakeAllocation(int ID)
        {
            this._ID = ID;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads the Train Rake Allocation of the specified ID GF Database
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
                    using (SqlCommand cmd = new SqlCommand("wtt.Usp_GET_TTRAINRAKEALLOCATION_BY_ID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this._ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //If no record are found then throw an error. This should never happen
                        if (SQLReader.HasRows == false) { throw new Exception(string.Format(@"TrainRakeAllocation with ID {0} doesn't exist in the GF Database", this._ID)); };

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            ParseSQLReader(SQLReader);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive the TrainRakeAllocation with ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Parses a SqlDataReader object into a TrainRakeAllocation object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            int RakeItemNo = SQLReader.GetInt32(SQLReader.GetOrdinal("rake_itemno"));
            this._Rake = Common.Rakes.Where(x => x.ID == RakeItemNo).FirstOrDefault();

            this._Percentage = SQLReader.GetSafeDecimal(SQLReader.GetOrdinal("perc"));
            this._BookedRake = SQLReader.GetBoolean(SQLReader.GetOrdinal("booked_rake"));
        }
        #endregion Methods
    }


    /// <summary>
    /// Class to represent a collection of Train Traction Allocation
    /// </summary>
    public class TrainRakeAllocationCollection : IEnumerable<TrainRakeAllocation>
    {
        #region Private Variables

        private List<TrainRakeAllocation> _TrainRakeAllocations = new List<TrainRakeAllocation>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<TrainRakeAllocation> GetEnumerator() { return this._TrainRakeAllocations.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new TrainTractionAllocation Collection from the GF Database based on the YMDV and Train
        /// </summary>
        public TrainRakeAllocationCollection(YMDV YMDV, Train Train)
        {
            GetAllTrainTractionAllocationsFromDBByYMDVandTrain(YMDV, Train);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of Train Traction Allocations from the GF Database for the YMDV and Train
        /// </summary>
        private void GetAllTrainTractionAllocationsFromDBByYMDVandTrain(YMDV YMDV, Train Train)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the TrainRakeAllocations from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _TrainRakeAllocations as a new List
            _TrainRakeAllocations = new List<TrainRakeAllocation>();

            //Get the TrainRakeAllocations from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("wtt.Usp_GET_TRAINRAKEALLOCATIONS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        cmd.Parameters.AddWithValue("@train_itemno", Train.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _TrainRakeAllocations.Add(new TrainRakeAllocation(SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"))));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Train Rake Allocations from the GF Database", Ex);
                }

                if (HasBookedRake() == false)
                {
                    throw new Exception(string.Format("Train Rake Allocation for Train ID {0} ({1} - {2}) on YMDV {3} does not have a booked allocation item.", Train.ID, Train.Headcode, Train.Description, YMDV.Value));
                }
            }
        }

        /// <summary>
        /// Checks to see whether the Train Rake Allocation has a booked rake item. If False the zero or more than one item is set as the booked rake
        /// </summary>
        /// <returns>book (true = has booked rake | false = no booked rake)</returns>
        public bool HasBookedRake()
        {
            bool Result = false;

            if (_TrainRakeAllocations.Count(x => x.BookedRake == true) == 1)
            {
                Result = true;
            }

            return Result;
        }

        #endregion Methods
    }
}
