using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace Horizon4.GF.Network
{
    /// <summary>
    /// SystemPath record
    /// </summary>
    public class SystemPath : ISystemObject
    {
        #region Private Variables

        private int _ID; //Private variable to hold the ID of the system path record
        private string _Name; //Private variable to hold the Name of the system path record
        private string _Description; //Private variable to hold the Description of the system path record
        private SystemLocation _StartLocation; //Private variable to hold the start location fo the system path record
        private SystemLocation _EndLocation; //Private variable to hold the end location fo the system path record

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the ID of the SystemPath
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the Name of the SystemPath
        /// </summary>
        public string Name { get { return this._Name; } set { this._Name = value; } }

        /// <summary>
        /// Gets the Name of the SystemPath
        /// </summary>
        public string Description { get { return this._Description; } set { this._Description = value; } }

        /// <summary>
        /// Gets the Start SystemLocation of the SystemPath
        /// </summary>
        public SystemLocation StartLocation { get { return this._StartLocation; } set { this._StartLocation = value; } }

        /// <summary>
        /// Gets the End SystemLocation of the SystemPath
        /// </summary>
        public SystemLocation EndLocation { get { return this._EndLocation; } set { this._EndLocation = value; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Constructs a new instance of a SystemPath struct.
        /// </summary>
        /// <param name="ID">The ID of the SystemPath record</param>
        /// <param name="Name">The Name of the SystemPath record</param>
        /// <param name="Description">The Description of the SystemPath record</param>
        /// <param name="StartLocation">The Start Location of the SystemPath record</param>
        /// <param name="EndLocation">The End Location of the SystemPath record</param>
        public SystemPath(string Name, string Description, SystemLocation StartLocation, SystemLocation EndLocation)
        {
            this._ID = 0;
            this._Name = Name;
            this._Description = Description;
            this._StartLocation = StartLocation;
            this._EndLocation = EndLocation;
        }

        /// <summary>
        /// Instantiates a new instance of a SystemPath from the GroundFrame DB for the supplied Itemno
        /// </summary>
        public SystemPath(int ID)
        {
            this._ID = ID;
            GetSystemPathFromDBByID();
        }

        /// <summary>
        /// Intialises a new instance of a SystemPath object
        /// </summary>
        public SystemPath()
        {
            this._ID = 0;
        }

        /// <summary>
        /// Instantiates a new instance of a SystemPath based on a SqlDataReader Object
        /// </summary>
        public SystemPath(SqlDataReader SQLReader)
        {
            ParseSQLReader(SQLReader);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Parses a SqlDataReader object into a SystemPath object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            if (Common.SystemLocations == null)
            {
                throw new Exception("Cannot parse SqlDataReader into a SystemPath object. Common.SystemLocations must be populated");
            }

            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("system_itemno"));
            this._Name = SQLReader.GetString(SQLReader.GetOrdinal("system_name"));
            this._Description = SQLReader.GetSafeString(SQLReader.GetOrdinal("system_description"));

            int StartLocationID = SQLReader.GetInt32(SQLReader.GetOrdinal("system_start_location_itemno"));
            this._StartLocation = Common.SystemLocations.Where(x => x.ID == StartLocationID).FirstOrDefault();

            int EndLocationID = SQLReader.GetInt32(SQLReader.GetOrdinal("system_end_location_itemno"));
            this._EndLocation = Common.SystemLocations.Where(x => x.ID == EndLocationID).FirstOrDefault();
        }

        /// <summary>
        /// Loads the SystemPath from the GroundFrame DB based on the SystemPath ID
        /// </summary>
        private void GetSystemPathFromDBByID()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_SYSTEMPATH_BY_ID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@system_path_itemno", this.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //If no record are found then throw an error. This should never happen
                        if (SQLReader.HasRows == false) { throw new Exception(string.Format(@"System Path with ID {0} doesn't exist in the GF Database", this.ID)); };

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            ParseSQLReader(SQLReader);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive SystemPath with ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Saves the SystemPath to the GroundFrame DB
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
                    using (SqlCommand cmd = new SqlCommand("network.Usp_SAVE_SYSTEMPATH", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this._ID);
                        cmd.Parameters.AddWithValue("@system_name", this._Name);
                        cmd.Parameters.AddWithValue("@system_description", string.IsNullOrEmpty(this._Description) ? (object)DBNull.Value : this._Description);
                        cmd.Parameters.AddWithValue("@system_start_location_itemno", this._StartLocation.ID);
                        cmd.Parameters.AddWithValue("@system_end_location_itemno", this._EndLocation.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("system_itemno"));
                        }

                        return Audit.WriteLog(AuditType.Information, string.Format(@"SystemPath {0} saved to the database:-", this._ID));
                    }
                }
                catch (Exception Ex)
                {
                    Response = Audit.WriteLog(AuditType.Error, string.Format(@"Error saving SystemPath {0} to the database:- {1}", this._Name, Ex.GetAuditMessage()), 1, this);
                    Response.Exception = new Exception(string.Format("Error trying to save SystemPath {0} to the GF Database", this._Name), Ex);
                }
            }

            return Response;
        }

        #endregion Methods
    }

    /// <summary>
    /// SystemPath Collection
    /// </summary>
    public class SystemPathCollection : IEnumerable<SystemPath>
    {
        private List<SystemPath> _SystemPaths = new List<SystemPath>();

        public IEnumerator<SystemPath> GetEnumerator() { return this._SystemPaths.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        /// <summary>
        /// Intialises a new SystemLocationCollection from the GF Database
        /// </summary>
        public SystemPathCollection()
        {
            GetAllSystemPathsFromDB();
        }

        /// <summary>
        /// Intialises a new SystemLocationCollection from the GF Database for the supplied system location
        /// </summary>
        public SystemPathCollection(SystemLocation Location)
        {
            GetAllSystemPathsByLocationFromDB(Location);
        }

        /// <summary>
        /// Gets a list of the SystemPaths from the GF Databasea for the supplied SystemLocation and populates _SystemPaths
        /// </summary>
        private void GetAllSystemPathsByLocationFromDB(SystemLocation Location)
        {
            //Initialise _SyetemLocations as a new List
            _SystemPaths = new List<SystemPath>();

            //Get the SystemPaths from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_SYSTEMPATHS_BY_LOCATION", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@system_location_itemno", Location.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _SystemPaths.Add(new SystemPath(SQLReader));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the SystemPaths from the GF Database for SystemLocation {0}", Location.Name), Ex);
                }
            }
        }

        /// <summary>
        /// Gets a list of the SystemPaths from the GF Databasea and populates _SystemPaths
        /// </summary>
        private void GetAllSystemPathsFromDB()
        {
            //Initialise _SyetemLocations as a new List
            _SystemPaths = new List<SystemPath>();

            //Get the SystemPaths from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_SYSTEMPATHS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _SystemPaths.Add(new SystemPath(SQLReader));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the SystemPaths from the GF Database", Ex);
                }
            }
        }
    }

    /// <summary>
    /// Class representing an instance of a path between 2 locations
    /// </summary>
    public class Path
    {
        #region Private Variables

        private int _ID; //Private variable to store the DB ID
        private SystemPath _PathID; //Private variable to store the path ID
        private Location _Start; //Private variable to store the start location
        private Location _End; //Private variable to store the end location
        private Distance _Distance; //Private variable to store the path distance
        private NetworkDirection _Direction; //Private variable to store the path direction
        private Token _Token; //Private variable to store the token needed to travel on the path
        private PathType _Type; //Private variable to store the path type
        private int _RouteAvailability; //Private variable to store the route availablity of the path
        private int _Berths; //Private variable to store the number of berths on the route.
        private int _PermissiblePowerSources; //Private variable to store the types of power available on the route. This is a bitwise of the PowerType enum
        private int _CrossingCount; //Private variable to store the number of crossings (foot, car etc) on the path
        private int _Score; //Private variable to store the score earnt when travelling over the path
        private bool _FreightOnly; //Private variable to store whether the path is freight only
        private int _MaxSpeed; //Private variable to store the max speed of the path.
        private decimal _Rating; //Private variable to store the route rating. 0 is level; between -1 and 0 is mostly downhill; between 0 and 1 is mostly uphill
        private NetworkSignalType _SignalType; //Private variable to store the signal type entering the path
        private int _Options; //Private variable to store the options relating to the path
        private YMDV _RecordStartYMDV; //Private variable to store the record start YMDV
        private YMDV _RecordEndYMDV; //Private variable to store the record end YMDV

        #endregion Private Variables

        #region Public Properties

        /// <summary>
        /// Gets the path instance ID
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the path ID
        /// </summary>
        public SystemPath PathID { get { return this._PathID; } set { this._PathID = value; } }

        /// <summary>
        /// Gets the path start location
        /// </summary>
        public Location Start { get { return this._Start; } set { this._Start = value; } }

        /// <summary>
        /// Gets the path end location
        /// </summary>
        public Location End { get { return this._End; } set { this._End = value; } }

        /// <summary>
        /// Gets the path distance
        /// </summary>
        public Distance Distance { get { return this._Distance; } set { this._Distance = value; } }

        /// <summary>
        /// Gets the path direction
        /// </summary>
        public NetworkDirection Direction { get { return this._Direction; } set { this._Direction = value; } }

        /// <summary>
        /// Gets the path token
        /// </summary>
        public Token Token { get { return this._Token; } set { this._Token = value; } }

        /// <summary>
        /// Gets the path type
        /// </summary>
        public PathType Type { get { return this._Type; } set { this._Type = value; } }
        
        /// <summary>
        /// Gets the path route availability
        /// </summary>
        public int RouteAvailability { get { return this._RouteAvailability; } set { this._RouteAvailability = value; } }
        
        /// <summary>
        /// Gets the number of berths available on the path
        /// </summary>
        public int Berths { get { return this._Berths; } set { this._Berths = value; } }

        /// <summary>
        /// Gets the permissible power source for the path. This is a bitwise of the PowerType enum
        /// </summary>
        public int PermissiblePowerSources { get { return this._PermissiblePowerSources; } set { this._PermissiblePowerSources = value; } }

        /// <summary>
        /// Gets the number of crossings on the path
        /// </summary>
        public int CrossingCount { get { return this._CrossingCount; } set { this._CrossingCount = value; } }

        /// <summary>
        /// Gets the score earnt by a player when passing along the route
        /// </summary>
        public int Score { get { return this._Score; } set { this._Score = value; } }

        /// <summary>
        /// Gets the flag to indicate whether the path is freight only
        /// </summary>
        public bool FreightOnly { get { return this._FreightOnly; } set { this._FreightOnly = value; } }

        /// <summary>
        /// Gets the max speed of the route
        /// </summary>
        public int MaxSpeed { get { return this._MaxSpeed; } set { this._MaxSpeed = value; } }

        /// <summary>
        /// Gets the rating of the route. Between -1 and 1. -1 being very downhill to 1 being very uphill
        /// </summary>
        public decimal Rating { get { return this._Rating; } set { this._Rating = value; } }

        /// <summary>
        /// Gets the signal type passed to access the route.
        /// </summary>
        public NetworkSignalType SignalType { get { return this._SignalType; } set { this._SignalType = value; } }

        /// <summary>
        /// Gets the options associated with the route.
        /// </summary>
        public int Options { get { return this._Options; } }

        /// <summary>
        /// Gets the path label
        /// </summary>
        public string Label { get { return string.Format(@"{0} ({1} - {2}) | Distance: {3}", this._PathID.Name, this._Start.Name, this._End.Name, this._Distance.MilesAndChains); } }

        /// <summary>
        /// Gets and sets the record start YMDV
        /// </summary>
        public YMDV RecordStartYMDV { get { return this._RecordStartYMDV; } set { this._RecordStartYMDV = value; } }

        /// <summary>
        /// Gets the record end YMDV
        /// </summary>
        public YMDV RecordEndYMDV { get { return this._RecordEndYMDV; } }

        /// <summary>
        /// Gets the straight line distance in meters
        /// </summary>
        public double StraighLineDistance { get { return this._Start.Distance(this._End); } }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Initialises the Path for the specific Path instance ID
        /// </summary>
        /// <param name="ID"></param>
        public Path(int ID)
        {
            if (ID == 0)
            {
                throw new Exception("You cannot instansiate a new Path by passing an ID of zero");
            }

            this._ID = ID;
            GetPathByIDFromDatabase();
        }

        /// <summary>
        /// Instansiates a new Path for the supplied system path
        /// </summary>
        /// <param name="SystemPath"></param>
        public Path(SystemPath SystemPath)
        {
            this._ID = 0;
            this._PathID = SystemPath;
            this._RecordStartYMDV = new YMDV(DateTime.Today);
            this._RecordEndYMDV = new YMDV(0);
            this._RouteAvailability = 7;
            this._Score = 10;
            this.Berths = 0;
        }

        /// <summary>
        /// Instantiates a new path objects from a SqlDataReader
        /// </summary>
        /// <param name="SQLReader"></param>
        public Path(SqlDataReader SQLReader)
        {
            ParseSQLReader(SQLReader);
        }

        /// <summary>
        /// Initialises the Path for a specific YMDV
        /// </summary>
        /// <param name="SystemPath">The System Path required</param>
        /// <param name="Date">The YMDV required</param>
        public Path(SystemPath SystemPath, YMDV YMDV)
        {
            GetPathBySystemLocationAndYMDVFromDatabase(SystemPath, YMDV);
        }

        /// <summary>
        /// Intialises a new instance of a Path object
        /// </summary>
        public Path()
        {
        }

        #endregion Constructors

        #region Methods


        /// <summary>
        /// Loads the Path from the Database based on the Path DB ID
        /// </summary>
        private void GetPathByIDFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_PATH_BY_ID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //If no record are found then throw an error. This should never happen
                        if (SQLReader.HasRows == false) { throw new Exception(string.Format(@"Path with ID {0} doesn't exist in the GF Database", this.ID)); };

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            ParseSQLReader(SQLReader);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the Path with ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Loads the Path from the DB for the specified SystemLocation and YMDV
        /// </summary>
        /// <param name="Location"></param>
        /// <param name="YMDV"></param>
        private void GetPathBySystemLocationAndYMDVFromDatabase(SystemPath Path, YMDV YMDV)
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_LOCATION_BY_SYSTEMPATHANDYMDV", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@path_itemno", Path.ID);
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //If no record are found then throw an error. This should never happen
                        if (SQLReader.HasRows == false) { throw new Exception(string.Format(@"Path with System ID {0} doesn't exist on YMDV {1} in the GF Database", Path.ID, YMDV.Value)); };

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            ParseSQLReader(SQLReader);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the Paths with System ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Validates the path
        /// </summary>
        /// <returns></returns>
        public List<DataValidationError> ValidatePath()
        {
            //TODO Path Validator
            return new List<DataValidationError>();
        }

        /// <summary>
        /// Saves the path record to the GroundFrame DB
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
                    using (SqlCommand cmd = new SqlCommand("network.Usp_SAVE_TPATH", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this._ID);
                        cmd.Parameters.AddWithValue("@start_ymdv", this._RecordStartYMDV.Value);
                        cmd.Parameters.AddWithValue("@end_ymdv", this._RecordEndYMDV.Value);
                        cmd.Parameters.AddWithValue("@path_itemno", this._PathID.ID);
                        cmd.Parameters.AddWithValue("@start_location_itemno", this._Start.ID);
                        cmd.Parameters.AddWithValue("@end_location_itemno", this._End.ID);
                        cmd.Parameters.AddWithValue("@distance", this._Distance.Meters);
                        cmd.Parameters.AddWithValue("@direction", (byte)this._Direction);
                        cmd.Parameters.AddWithValue("@token_itemno", this._Token == null ? (object)DBNull.Value : this._Token.ID == 0 ? (object)DBNull.Value : this._Token.ID);
                        cmd.Parameters.AddWithValue("@type_itemno", (Int16)this._Type);
                        cmd.Parameters.AddWithValue("@route_availability", (Int16)this._RouteAvailability);
                        cmd.Parameters.AddWithValue("@berths", (Int16)this._Berths);
                        cmd.Parameters.AddWithValue("@permissible_power", this._PermissiblePowerSources);
                        cmd.Parameters.AddWithValue("@cross_count", (Int16)this._CrossingCount);
                        cmd.Parameters.AddWithValue("@score", (Int16)this._Score);
                        cmd.Parameters.AddWithValue("@freight_only", this._FreightOnly);
                        cmd.Parameters.AddWithValue("@max_speed", this._MaxSpeed);
                        cmd.Parameters.AddWithValue("@rating", this._Rating);
                        cmd.Parameters.AddWithValue("@signal_type_itemno", (Int16)this._SignalType);
                        cmd.Parameters.AddWithValue("@options", this._Options);

                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
                        }

                        return Audit.WriteLog(AuditType.Information, string.Format(@"Path {0} saved to the database:-", this._ID));
                    }
                }
                catch (Exception Ex)
                {
                    Response = Audit.WriteLog(AuditType.Error, string.Format(@"Error saving Path {0} to the database:- {1}", this.Label, Ex.GetAuditMessage()), 1, this);
                    Response.Exception = new Exception(string.Format("Error trying to save Path {0} to the GF Database", this.Label), Ex);
                }
            }

            return Response;
        }

        /// <summary>
        /// Parses a SqlDataReader into the Path object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            this._ID = (int)SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));

            int _SystemPathID = SQLReader.GetSafeInt32(SQLReader.GetOrdinal("path_itemno"));
            this._PathID = new SystemPath(_SystemPathID);

            int _StartLocationID = SQLReader.GetSafeInt32(SQLReader.GetOrdinal("start_location_itemno"));
            this._Start = new Location(_StartLocationID);

            int _EndLocationID = SQLReader.GetSafeInt32(SQLReader.GetOrdinal("end_location_itemno"));
            this._End = new Location(_EndLocationID);

            this._Distance = new Distance(SQLReader.GetDecimal(SQLReader.GetOrdinal("distance")));
            this._Direction = (NetworkDirection)SQLReader.GetByte(SQLReader.GetOrdinal("direction"));

            int _TokenItemNo = SQLReader.GetSafeInt32(SQLReader.GetOrdinal("token_itemno"));
            if (_TokenItemNo != 0) { this._Token = new Token(_TokenItemNo); };

            this._Type = (PathType)SQLReader.GetInt16(SQLReader.GetOrdinal("type_itemno"));
            this._RouteAvailability = SQLReader.GetInt16(SQLReader.GetOrdinal("route_availability"));
            this._Berths = SQLReader.GetInt16(SQLReader.GetOrdinal("berths"));
            this._PermissiblePowerSources = SQLReader.GetInt16(SQLReader.GetOrdinal("permissible_power"));
            this._CrossingCount = SQLReader.GetInt16(SQLReader.GetOrdinal("crossing_count"));
            this._Score = SQLReader.GetInt16(SQLReader.GetOrdinal("score"));
            this._FreightOnly = SQLReader.GetBoolean(SQLReader.GetOrdinal("freight_only"));
            this._MaxSpeed = SQLReader.GetInt16(SQLReader.GetOrdinal("max_speed"));
            this._Rating = SQLReader.GetDecimal(SQLReader.GetOrdinal("rating"));
            this._SignalType = (NetworkSignalType)SQLReader.GetInt16(SQLReader.GetOrdinal("signal_type_itemno"));
            this._Options = (int)SQLReader.GetInt64(SQLReader.GetOrdinal("options"));

            int StartYMDV = (int)SQLReader.GetInt32(SQLReader.GetOrdinal("start_ymdv"));
            this._RecordStartYMDV = new YMDV(StartYMDV);

            int EndYMDV = (int)SQLReader.GetSafeInt32(SQLReader.GetOrdinal("end_ymdv"));
            this._RecordEndYMDV = new YMDV(EndYMDV);
        }

        #endregion Methods
    }

    public class PathCollection : IEnumerable<Path>
    {
        #region Private Variables

        private List<Path> _Paths = new List<Path>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<Path> GetEnumerator() { return this._Paths.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initlises a new collection of paths for the date provided
        /// </summary>
        /// <param name="Date"></param>
        public PathCollection(YMDV YMDV)
        {
            GetAllPathsFromDBbyYMDV(YMDV);
        }


        /// <summary>
        /// Initlises a new collection of paths for the location and date provideds 
        /// </summary>
        /// <param name="Date"></param>
        public PathCollection(Location Location, YMDV YMDV)
        {
            GetAllPathsFromDBbyLocationAndYMDV(Location, YMDV);
        }

        /// <summary>
        /// Initlises a new collection of paths for the SystemPath provided
        /// </summary>
        /// <param name="Date"></param>
        public PathCollection(SystemPath Path)
        {
            GetAllPathsFromDBbyPath(Path);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list all location fom the GF Database for a particular YMDV
        /// </summary>
        private void GetAllPathsFromDBbyYMDV(YMDV YMDV)
        {
            //Check Common.Locations is populated
            if (Common.Locations == null)
            {
                throw new Exception("Error trying to retreive all the Paths from the GF Database. The global LocationCollection stored at Common.Locations is empty");
            }

            //Check Common.SystemPaths is populated
            if (Common.SystemPaths == null)
            {
                throw new Exception("Error trying to retreive all the Paths from the GF Database. The global SystemPathCollection stored at Common.SystemPaths is empty");
            }

            //Initialise _Paths as a new List
            _Paths = new List<Path>();

            //Get the Paths from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_PATHS_BY_YMDV", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _Paths.Add(new Path(SQLReader));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format(@"Error trying to retreive all the Paths for YMDV {0} from the GF Database", YMDV.Value), Ex);
                }
            }
        }

        private void GetAllPathsFromDBbyLocationAndYMDV(Location Location, YMDV YMDV)
        {
            //Initialise _Paths as a new List
            _Paths = new List<Path>();

            //Get the Paths from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_PATHS_BY_LOCATION_AND_YMDV", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@location_itemno", Location.ID);
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _Paths.Add(new Path(SQLReader));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format(@"Error trying to retreive all the Paths for Location {0} and YMDV {1} from the GF Database", Location.DisplayName, YMDV.Value), Ex);
                }
            }
        }

        /// <summary>
        /// Gets a list all location fom the GF Database for the supplied Path
        /// </summary>
        private void GetAllPathsFromDBbyPath(SystemPath Path)
        {
            //Initialise _Paths as a new List
            _Paths = new List<Path>();

            //Get the Paths from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_PATHS_BY_SYSTEM_PATH", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@system_path_itemno", Path.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _Paths.Add(new Path(SQLReader));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format(@"Error trying to retreive all the Paths for Path {0} from the GF Database", Path.Name), Ex);
                }
            }
        }

        #endregion Constructors
    }
}
