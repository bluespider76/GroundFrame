using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horizon4.GF.Network;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Horizon4.GF.WTT
{
    public class CallingPoint
    {
        #region Private Variables

        private int _ID; //Private variable to store the GroundFrame DB ID of the calling point
        private Location _Location; //Private variable to store the calling point location
        private TimeSpan _Arr; //Private variable to store the arrival time
        private TimeSpan _Dep; //Private variable to store the departure time
        private bool _SetDownOnly; //Private variable to indicate whether the calling point is set down only
        private bool _PickUpOnly; //Private variable to indicate whether the calling point is pick up only
        private TimeSpan _MinDwellTime; //Private variable to store the minimum dwell time
        private int _Order; //Private variable to store the order of the calling point

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the GroundFrame DB ID of the calling point
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the Location of the calling pointlocation
        /// </summary>
        public Location Location { get { return this._Location; } }

        /// <summary>
        /// Gets the Arrival time of the calling point. If blank then the train is booked to pass at the departure time
        /// </summary>
        public TimeSpan Arr { get { return this._Arr; } }

        /// <summary>
        /// Gets the Departure timeof the calling point of the calling point.
        /// </summary>
        public TimeSpan Dep { get { return this._Dep; } }

        /// <summary>
        /// Gets the flag to indicate whether the calling point is to set down only
        /// </summary>
        public bool SetDownOnly { get { return this._SetDownOnly; } }

        /// <summary>
        /// Gets the flag to indicate whether the calling point is to pick up only
        /// </summary>
        public bool PickUpOnly { get { return this._PickUpOnly; } }

        /// <summary>
        /// Gets the Minimum Dwell time at the calling point. If empty then there is no minimum dwell time
        /// </summary>
        public TimeSpan MinDwellTime { get { return this._MinDwellTime; } }

        /// <summary>
        /// Gets the order the calling point.
        /// </summary>
        public int Order { get { return this._Order; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialises a new instance of a calling point based on the GroundFrame Calling Point
        /// </summary>
        /// <param name="ID"></param>
        public CallingPoint(int ID)
        {
            this._ID = ID;
            GetCallingPountByIDFromDatabase();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads the Rake Element data from the GF Database based on the ID of the Rake Element
        /// </summary>
        private void GetCallingPountByIDFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("wtt.Usp_GET_CALLINGPOINT_BY_ID", conn))
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
                    throw new Exception(string.Format("Error trying to retreive the CallingPoint with ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }


        /// <summary>
        /// Parses a SqlDataReader object into the CallingPoint object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            int LocationItemNo = SQLReader.GetInt32(SQLReader.GetOrdinal("location_itemno"));
            this._Location = Common.Locations.Where(x => x.ID == LocationItemNo).FirstOrDefault();

            long Arr = SQLReader.GetInt64(SQLReader.GetOrdinal("arr"));
            if (Arr != 0) { this._Arr = new TimeSpan(Arr); };

            long Dep = SQLReader.GetInt64(SQLReader.GetOrdinal("dep"));
            if (Dep != 0) { this._Dep = new TimeSpan(Dep); };

            this._SetDownOnly = SQLReader.GetBoolean(SQLReader.GetOrdinal("setdownonly"));
            this._PickUpOnly = SQLReader.GetBoolean(SQLReader.GetOrdinal("pickuponly"));

            long MinDwellTime = SQLReader.GetInt64(SQLReader.GetOrdinal("mindwelltime"));
            if (MinDwellTime != 0) { this._MinDwellTime = new TimeSpan(MinDwellTime); };

            this._Order = SQLReader.GetInt16(SQLReader.GetOrdinal("order"));
        }

        #endregion Methods
    }

    /// <summary>
    /// Class to represent a collection of calling points
    /// </summary>
    public class CallingPointCollection : IEnumerable<CallingPoint>
    {
        #region Private Variables

        private List<CallingPoint> _CallingPoints = new List<CallingPoint>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<CallingPoint> GetEnumerator() { return this._CallingPoints.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new CallingPoint collection based on the train
        /// </summary>
        public CallingPointCollection(Train Train)
        {
            GetAllCAllingPointsFromDB(Train);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of the callings for the supplied train
        /// </summary>
        private void GetAllCAllingPointsFromDB(Train Train)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all calling points from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _CallingPoints as a new List
            _CallingPoints = new List<CallingPoint>();

            //Get the Trains from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("wtt.Usp_GET_CALLINGPOINTS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@train_itemno", Train.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _CallingPoints.Add(new CallingPoint(SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"))));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the calling points for Train ID {0} ({1} - {2})", Train.ID, Train.Headcode, Train.Description), Ex);
                }
            }
        }

        #endregion Methods
    }
}
