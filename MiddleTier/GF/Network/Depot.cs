using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Horizon4.GF.RollingStock;

namespace Horizon4.GF.Network
{
    /// <summary>
    /// Class to represent a depot
    /// </summary>
    public class Depot
    {
        #region Private Variables

        private int _ID; //Private variable to store the Depot DB ID
        private Location _Location; //Private variable to store the parent location
        private string _Code; //Private variable to store the Depot Code
        private decimal _EaseOfAccess; //Private variable to store how easy it is to get into the depot. 0 Very Easy | 100 Very Hard
        private decimal _PercentageVisible; //Private variable to store what percentage of the total trains on depot are visible from a passing train or on foot
        private int _Capabilities; //Private variable to store the bitwise of the capabilities of the depot
        private YMDV _RecordStartYMDV; //Private variable to store the record start YMDV
        private YMDV _RecordEndYMDV; //Private variable to store the record end YMDV

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the Depot Groundframe DB ID
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets or sets the Depot code
        /// </summary>
        public string Code { get { return this._Code; } set { this._Code = value; } }

        /// <summary>
        /// Gets or sets the Depot Location
        /// </summary>
        public Location Location { get { return this._Location; } set { this._Location = value; } }

        /// <summary>
        /// Get or sets the Depot capabilities bitwise value. See DepotCapabilities enum for details
        /// </summary>
        public int Capabilities { get { return this._Capabilities; } set { this._Capabilities = value; } }
        
        /// <summary>
        /// Gets or sets the percentage of trains which are visible
        /// </summary>
        public decimal PercentageVisible { get { return this._PercentageVisible; } set { this._PercentageVisible = value; } }
 
        /// <summary>
        /// Gets or sets the percentage which represents how easy it is to access the depot. 0 being easy > 100 being impossible
        /// </summary>
        public decimal EaseOfAccess { get { return this._EaseOfAccess; } set { this._EaseOfAccess = value; } }

        /// <summary>
        /// Gets or sets the record start YMDV
        /// </summary>
        public YMDV RecordStartYMDV { get { return this._RecordStartYMDV; } set { this._RecordStartYMDV = value; } }

        /// <summary>
        /// Gets or record end YMDV
        /// </summary>
        public YMDV RecordEndYMDV { get { return this._RecordEndYMDV; } }
        #endregion Properties

        #region Constructors

        /// <summary>
        /// Instantiates a new Depot of Object for the supplied Location and YMDV
        /// </summary>
        /// <param name="Location"></param>
        /// <param name="YMDV"></param>
        public Depot(Location Location, YMDV YMDV) 
        {
            GetDepotByLocationAndYMDVFromDatabase(Location, YMDV);
        }

        /// <summary>
        /// Instantiates a new Depot object from the supplied SqlDataReader Object
        /// </summary>
        /// <param name="SQLReader"></param>
        public Depot(SqlDataReader SQLReader)
        {
            ParseSQLReader(SQLReader);
        }

        /// <summary>
        /// Instantiates a new depot object for the supplied location
        /// </summary>
        /// <param name="Location"></param>
        public Depot(Location Location)
        {
            this._ID = 0;
            this._Location = Location;
            this._RecordStartYMDV = new YMDV(DateTime.Today);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Validates the depot
        /// </summary>
        /// <returns></returns>
        public List<DataValidationError> ValidatePath()
        {
            //TODO Path Validator
            return new List<DataValidationError>();
        }

        /// <summary>
        /// Saves the depot record to the GroundFrame DB
        /// </summary>
        /// <returns></returns>
        public DBResponse SaveToDB()
        {
            DBResponse Response = new DBResponse(0, AuditType.Information);

            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_SAVE_TDEPOT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@itemno", this._ID);
                        cmd.Parameters.AddWithValue("@location_itemno", this._Location.ID);
                        cmd.Parameters.AddWithValue("@ymdv", this._RecordStartYMDV.Value);
                        cmd.Parameters.AddWithValue("@code", this._Code.ToUpper());
                        cmd.Parameters.AddWithValue("@ease_of_access", this._EaseOfAccess);
                        cmd.Parameters.AddWithValue("@percentage_visible_from_train", this._PercentageVisible);
                        cmd.Parameters.AddWithValue("@capabilities", this._Capabilities);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
                        }

                        return Audit.WriteLog(AuditType.Information, string.Format(@"Depot {0} saved to the database:-", this._ID));
                    }
                }
                catch (Exception Ex)
                {
                    Response = Audit.WriteLog(AuditType.Error, string.Format(@"Error saving Depot at Location {0} to the database:- {1}", this._Location.ID, Ex.GetAuditMessage()), 1, this);
                    Response.Exception = new Exception(string.Format("Error trying to save Depot at Location {0} to the GF Database", this._Location.ID), Ex);
                }
            }

            return Response;
        }

        /// <summary>
        /// Loads the depot of the specified Location and YMDV from the GF Database
        /// </summary>
        /// <param name="SystemLocation"></param>
        /// <param name="YMDV"></param>
        private void GetDepotByLocationAndYMDVFromDatabase(Location Location, YMDV YMDV)
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_DEPOT_BY_LOCATIONANDYMDV", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@location_itemno", Location.ID);
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //If no record are found then throw an error. This should never happen
                        if (SQLReader.HasRows == false) { throw new Exception(string.Format(@"Depot with Location ID {0} doesn't exist on YMDV {1} in the GF Database", Location.ID, YMDV.Value)); };

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            ParseSQLReader(SQLReader);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive the Depot with Location ID {0} from the GF Database", Location.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Parses a SqlDataReader into the Depot object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));

            //Get Location ID
            int LocationID = this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("location_itemno"));
            this._Location = new Location(LocationID);
            
            this._Code = SQLReader.GetString(SQLReader.GetOrdinal("code"));
            this._EaseOfAccess = SQLReader.GetDecimal(SQLReader.GetOrdinal("ease_of_access"));
            this._PercentageVisible = SQLReader.GetDecimal(SQLReader.GetOrdinal("percentage_visible_from_train"));
            this._Capabilities = SQLReader.GetInt32(SQLReader.GetOrdinal("capabilities"));
            this._RecordStartYMDV = new YMDV(SQLReader.GetInt32(SQLReader.GetOrdinal("start_ymdv")));
            this._RecordEndYMDV = new YMDV(SQLReader.GetSafeInt32(SQLReader.GetOrdinal("end_ymdv")));
        }

        #endregion Methods
    }

    /// <summary>
    /// Class to represent a collection of depots
    /// </summary>
    public class DepotCollection : IEnumerable<Depot>
    {
        #region Private Variables

        private List<Depot> _Depots = new List<Depot>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<Depot> GetEnumerator() { return this._Depots.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new DepotCollection from the GF Database
        /// </summary>
        public DepotCollection(YMDV YMDV)
        {
            GetAllDepotsFromDB(YMDV);
        }

        /// <summary>
        /// Intialises a new DepotCollection for the specified Rake and YMDV
        /// </summary>
        public DepotCollection(Rake Rake, YMDV YMDV)
        {
            GetRakeDepotsFromDB(Rake, YMDV);
        }

        /// <summary>
        /// Intialises a new DepotCollection for the supplied Location
        /// </summary>
        public DepotCollection(Location Location)
        {
            GetAllDepotsByLocationFromDB(Location);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of the Depots from the GF Database for the supplied location
        /// </summary>
        private void GetAllDepotsByLocationFromDB(Location Location)
        {
            //Initialise _Depots as a new List
            _Depots = new List<Depot>();

            //Get the Depots from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_DEPOTS_BY_LOCATION", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@location_itemno", Location.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _Depots.Add(new Depot(SQLReader));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the Depots for Location ID {0} from the GF Database", Location.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Gets a list of the Depots from the GF Database for a given YMDV and populates _Depots
        /// </summary>
        private void GetAllDepotsFromDB(YMDV YMDV)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Depots from the GF Database. Common.SQLDBConn is <null>");
            }

            //Check to see if the DB Connection string is set
            if (Common.SystemLocations == null)
            {
                throw new Exception("Error trying to retreive all the Depots from the GF Database. The global SystemLocations lists stored at Common.SystemLocations is <null>");
            }

            //Initialise _Depots as a new List
            _Depots = new List<Depot>();

            //Get the SystemLocations from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_DEPOTS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _Depots.Add(new Depot(SQLReader));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Depots from the GF Database", Ex);
                }
            }
        }

        /// <summary>
        /// Gets a list of the Depots from the GF Database for a given Rake
        /// </summary>
        private void GetRakeDepotsFromDB(Rake Rake, YMDV YMDV)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Depots from the GF Database. Common.SQLDBConn is <null>");
            }

            //Check to see if the DB Connection string is set
            if (Common.SystemLocations == null)
            {
                throw new Exception("Error trying to retreive all the Depots from the GF Database. The global SystemLocations lists stored at Common.SystemLocations is <null>");
            }

            //Initialise _Depots as a new List
            _Depots = new List<Depot>();

            //Get the SystemLocations from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_RAKE_DEPOTS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@rake_itemno", Rake.ID);
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            Location Location = new Location(SQLReader.GetInt32(SQLReader.GetOrdinal("location_itemno")));
                            _Depots.Add(new Depot(Location, Common.CurrentYMDV));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the Depots from the GF Database for Rake ID {0}", Rake.ID), Ex);
                }
            }
        }

        #endregion Methods
    }
}