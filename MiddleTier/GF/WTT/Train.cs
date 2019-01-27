using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horizon4.GF.Network;
using Horizon4.GF.RollingStock;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Horizon4.GF.WTT
{
    public class Train
    {
        #region Private Variables

        private int _ID; //Private variable to store the DB ID of the train
        private string _Headcode; //Private variable to store the Header of the train
        private string _Description; //Private variable to store the description of the train
        private Location _StartLocation; //Private variable to store the start location of the train
        private Location _EndLocation; //Private variable to store the end location of the train
        private Train _MotivePowerNextTrain; //Private variable to store the next train the motive power is booked
        private double _MotivePowerNextTrainPercentage; //Private variable to store the likely hood that the motive power must operate next train. 100% is it must operate next train
        private int _MotivePowerNextTrainMinTurnaround; //Private variable to store the minimum number of minutes to elapse before stock can depart on next train
        private Train _StockNextTrain; //Private variable to store the next train the stock is booked
        private double _StockNextTrainPercentage; //Private variable to store the likely hood that the motive power must operate next train. 100% is it must operate next train
        private int _StockNextTrainMinTurnaround; //Private variable to store the minimum number of minutes to elapse before stock can depart on next train
        private Train _ParentTrain; //Private variable to store the parent train. Used if train changes power during journey
        private int _MinutesAllocatedOnTOPS; //Private variable to store the number of minutes prior to departure the motive power is allocated in TOPS
        private TimeSpan _StartTime; //Private variable to store the train start time.
        private int _Days; //Private variable to store the days the train runs. See WTTDays enun for bitwise values
        private int _StockBrakeTypes; //Private variable to store the brake types available on the stock
        private int _StockHeatTypes; //Private variable to store the heating type available on the stock
        private long _Configuration; //Private variable to store whether the train config. See TrainConfiguration enum for bitwise details
        private TrainTractionAllocationCollection _BookedTraction; //Private variable to store the booked traction
        private TrainRakeAllocationCollection _BookedStock; //Prviate variable to store the booked stock
        private Speed _MaxSpeed; //Private variable to store the max speed of the train
        private Speed _MaxSpeedIfLate; //Private variable to store the max speed of the train if more than 30 minutes late
        private CallingPointCollection _CallingPoints; //Private variable to store the calling points of the train
        private Train _TrainOverRide; //Private variable to store the train that this train overrides
        private bool _RunAsRequired; //Private variable to store whether the train runs as required
        private int _RunAsRequiredPerc; //Private variable to store whether % of the time the train runs as required
        private bool _RunsOnce; //Private variable to store whether the train runs as a once off.

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the GF Database ID for the train
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the Headcode of the train
        /// </summary>
        public string Headcode { get { return this._Headcode; } }

        /// <summary>
        /// Gets the description of the train
        /// </summary>
        public string Description { get { return this._Description; } }

        /// <summary>
        /// Gets the start location of the train
        /// </summary>
        public Location StartLocation { get { return this._StartLocation; } }

        /// <summary>
        /// Gets the end location of the train
        /// </summary>
        public Location EndLocation { get { return this._EndLocation; } }

        /// <summary>
        /// Gets the next train the motive power ia booked to work
        /// </summary>
        public Train MotivePowerNextTrain { get { return this._MotivePowerNextTrain; } }

        /// <summary>
        /// Gets the % chance that the motive power will work it's next train
        /// </summary>
        public double MotivePowerNextTrainPercentage { get { return this._MotivePowerNextTrainPercentage; } }

        /// <summary>
        /// Gets the minimum time before the motive power's next train can start after the arrival of this one.
        /// </summary>
        public int MotivePowerNextTrainMinTurnaround { get { return this._MotivePowerNextTrainMinTurnaround; } }

        /// <summary>
        /// Gets the next train the stock is booked to work
        /// </summary>
        public Train StockNextTrain { get { return this._StockNextTrain; } }

        /// <summary>
        /// Gets the % chance that the stock will work it's next train
        /// </summary>
        public double StockNextTrainPercentage { get { return this._StockNextTrainPercentage; } }

        /// <summary>
        /// Gets the minimum time before the stock's next train can start after the arrival of this one.
        /// </summary>
        public int StockNextTrainMinTurnaround { get { return this._StockNextTrainMinTurnaround; } }

        /// <summary>
        /// Gets the parent train
        /// </summary>
        public Train ParentTrain { get { return this._ParentTrain; } }

        /// <summary>
        /// Gets the number of minutes prior to departure the motive power and stock are allocated on TOPS
        /// </summary>
        public int MinutesAllocatedOnTOPS { get { return this._MinutesAllocatedOnTOPS; } }

        /// <summary>
        /// Gets the start time of the train
        /// </summary>
        public TimeSpan StartTime { get { return this._StartTime; } }

        /// <summary>
        /// Gets the days which the train is booked to run. See WTTDays enum for bitwise values
        /// </summary>
        public int Days { get { return this._Days; } }

        /// <summary>
        /// Gets the brake type of the train
        /// </summary>
        public int StockBrakeTypes { get { return this._StockBrakeTypes; } }

        /// <summary>
        /// Gets the heating type of the train
        /// </summary>
        public int StockHeatTypes { get { return this._StockHeatTypes; } }

        /// <summary>
        /// Gets the configuration of the train. See TrainConfiguration enum for bitwise values
        /// </summary>
        public long Configuration { get { return this._Configuration; } }

        /// <summary>
        /// Gets the booked traction collection for the train
        /// </summary>
        public TrainTractionAllocationCollection BookedTraction { get { return this._BookedTraction; } }

        /// <summary>
        /// Gets the book stock list for the train
        /// </summary>
        public TrainRakeAllocationCollection BookedStock { get { return this._BookedStock; } }

        /// <summary>
        /// Gets the max speed of the train
        /// </summary>
        public Speed MaxSpeed { get { return this._MaxSpeed; } }

        /// <summary>
        /// Gets the max speed of the train if it's running more than 30 minutes late.
        /// </summary>
        public Speed MaxSpeedIfLate { get { return this._MaxSpeedIfLate; } }

        /// <summary>
        /// Gets the calling points of the train
        /// </summary>
        public CallingPointCollection CallingPoints { get { return this._CallingPoints; } }

        /// <summary>
        /// Gets a flag to indicate whether the trains runs as required
        /// </summary>
        public bool RunAsRequired { get { return this._RunAsRequired; } }

        /// <summary>
        /// Gets the percentage chance the train will run if it Runs As Required
        /// </summary>
        public int RunAsRequiredPerc { get { return this._RunAsRequiredPerc; } }

        /// <summary>
        /// Gets a flag to indicate whether a train should run once.
        /// </summary>
        public bool RunsOnce {get { return this._RunsOnce; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initiaites a new train based on the GF Database ID
        /// </summary>
        /// <param name="ID"></param>
        public Train(int ID)
        {
            this._ID = ID;
            GetTrainByIDFromDatabase();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads the Rake Element data from the GF Database based on the ID of the Rake Element
        /// </summary>
        private void GetTrainByIDFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("wtt.Usp_GET_TRAIN_BY_ID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            ParseSQLReader(SQLReader);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive the Train with ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Parses a SqlDataReader into the Train object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            this._Headcode = SQLReader.GetString(SQLReader.GetOrdinal("headcode"));
            this._Description = SQLReader.GetSafeString(SQLReader.GetOrdinal("description"));
            this._StartLocation = Common.Locations.Where(x => x.ID == SQLReader.GetInt32(SQLReader.GetOrdinal("start_location_itemno"))).FirstOrDefault();
            this._EndLocation = Common.Locations.Where(x => x.ID == SQLReader.GetInt32(SQLReader.GetOrdinal("end_location_itemno"))).FirstOrDefault();

            int _MPNextTrainID = SQLReader.GetSafeInt32(SQLReader.GetOrdinal("mp_next_train_itemno"));
            if (_MPNextTrainID != 0)
            {
                this._MotivePowerNextTrain = new Train(_MPNextTrainID);
                this._MotivePowerNextTrainPercentage = SQLReader.GetDouble(SQLReader.GetOrdinal("mp_next_train_perc"));
                this._MotivePowerNextTrainMinTurnaround = SQLReader.GetInt32(SQLReader.GetOrdinal("mp_next_train_min_turnaround"));
            }

            int _StockNextTrainID = SQLReader.GetSafeInt32(SQLReader.GetOrdinal("stock_next_train_itemno"));
            if (_StockNextTrainID != 0)
            {
                this._StockNextTrain = new Train(_StockNextTrainID);
                this._StockNextTrainPercentage = SQLReader.GetDouble(SQLReader.GetOrdinal("stock_next_train_perc"));
                this._StockNextTrainMinTurnaround = SQLReader.GetInt32(SQLReader.GetOrdinal("stock_next_train_min_turnaround"));
            }

            int _ParentTrainID = SQLReader.GetSafeInt32(SQLReader.GetOrdinal("parent_train_itemno"));
            this._ParentTrain = new Train(_ParentTrainID);

            this._MinutesAllocatedOnTOPS = SQLReader.GetInt32(SQLReader.GetOrdinal("mins_allocation_on_tops"));
            this._StartTime = new TimeSpan(SQLReader.GetInt64(SQLReader.GetOrdinal("start_time")));
            this._Days = SQLReader.GetInt32(SQLReader.GetOrdinal("days"));
            this._StockBrakeTypes = SQLReader.GetInt32(SQLReader.GetOrdinal("brake_types"));
            this._StockHeatTypes = SQLReader.GetInt32(SQLReader.GetOrdinal("heat_types"));
            this._Configuration = SQLReader.GetInt32(SQLReader.GetOrdinal("configuration"));
            this._MaxSpeed = new Speed(SQLReader.GetInt32(SQLReader.GetOrdinal("max_speed")));
            this._MaxSpeedIfLate = new Speed(SQLReader.GetInt32(SQLReader.GetOrdinal("max_speed_if_late")));
            this._BookedTraction = new TrainTractionAllocationCollection(Common.CurrentYMDV, this);
            this._BookedStock = new TrainRakeAllocationCollection(Common.CurrentYMDV, this);
            this._CallingPoints = new CallingPointCollection(this);
            this._RunAsRequired = SQLReader.GetBoolean(SQLReader.GetOrdinal("run_as_required"));
            this._RunAsRequiredPerc = SQLReader.GetByte(SQLReader.GetOrdinal("run_as_required_perc"));
            this._RunsOnce = SQLReader.GetBoolean(SQLReader.GetOrdinal("runs_once"));
        }

        #endregion Methods
    }

    /// <summary>
    /// Class to represent a collection of Trains
    /// </summary>
    public class TrainCollection : IEnumerable<Train>
    {
        #region Private Variables

        private List<Train> _TrainCollection = new List<Train>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<Train> GetEnumerator() { return this._TrainCollection.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new Train Element from the GF Database for the YMDV
        /// </summary>
        public TrainCollection(YMDV YMDV)
        {
            GetAllTrainsFromDB(YMDV);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of the Trains from the GF Database for a given YMDV
        /// </summary>
        private void GetAllTrainsFromDB(YMDV YMDV)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Trains from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _TrainCollection as a new List
            _TrainCollection = new List<Train>();

            //Get the Trains from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("wtt.Usp_GET_TRAINS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        cmd.Parameters.AddWithValue("@wtt_day", (int)YMDV.WTTDay);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _TrainCollection.Add(new Train(SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"))));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the Trains from YMDV {0}", YMDV.Value), Ex);
                }
            }
        }

        #endregion Methods
    }
}
