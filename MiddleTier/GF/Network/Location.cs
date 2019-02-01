using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using Horizon4.GF;
using System.Device.Location;

namespace Horizon4.GF.Network
{
    /// <summary>
    /// SystemLocation record
    /// </summary>
    public class SystemLocation : ISystemObject
    {
        #region Private Variables

        private int _ID; //Private variable to hold the ID of the system location record
        private string _Name; //Private variable to hold the name of the system locaton record
        private string _Description; //Private variable to hold the description of the system locaton record

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the ID of the SystemLocation
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the Name of the SystemLocation
        /// </summary>
        public string Name { get { return this._Name; } set { this._Name = value; } }

        /// <summary>
        /// Gets the Description of the SystemLocation
        /// </summary>
        [Obsolete("Not required by the SystemSector Object")]
        public string Description { get { return this._Description; } set { this._Description = value; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Constructs a new instance of a SystemLocation class.
        /// </summary>
        /// <param name="ID">The ID of the SystemLocation record</param>
        /// <param name="Name">The Name of the SystemLocation record</param>
        public SystemLocation(int ID, string Name)
        {
            this._ID = ID;
            this._Name = Name;
            this._Description = null;
        }

        /// <summary>
        /// Constructs a new instance of a SystemLocation.
        /// </summary>
        public SystemLocation()
        {
            this._ID = 0;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Saves the System Location record to the GroundFrame DB
        /// </summary>
        /// <returns></returns>
        public GFResponse SaveToDB()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_SAVE_SYSTEMLOCATION", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this._ID);
                        cmd.Parameters.AddWithValue("@system_name", this._Name);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
                        }

                        return Audit.WriteLog(new GFResponse(AuditType.Information, string.Format(@"SystemLocation {0} sucessfully saved to the database:-", this.Name)));
                    }
                }
                catch (Exception Ex)
                {
                    return Audit.WriteLog(new GFResponse(AuditType.Error, string.Format(@"Error saving SystemLocation {0} to the database", this.Name), Ex), 1, this);
                }
            }
        }

        #endregion Methods
    }

    /// <summary>
    /// SystemLocation Collection
    /// </summary>
    public class SystemLocationCollection : IEnumerable<SystemLocation>
    {
        #region Private Variables

        private List<SystemLocation> _SystemLocations = new List<SystemLocation>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<SystemLocation> GetEnumerator() { return this._SystemLocations.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new SystemLocationCollection from the GF Database
        /// </summary>
        public SystemLocationCollection()
        {
            GetAllSystemLocationsFromDB();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of the SystemLocations from the GF Databasea and populates _SystemLocations
        /// </summary>
        private void GetAllSystemLocationsFromDB()
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the SystemLocations from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _SyetemLocations as a new List
            _SystemLocations = new List<SystemLocation>();

            //Get the SystemLocations from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_TSYSTEMLOCATIONS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _SystemLocations.Add(new SystemLocation(SQLReader.GetInt32(SQLReader.GetOrdinal("system_itemno")), SQLReader.GetString(SQLReader.GetOrdinal("system_name"))));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the SystemLocations from the GF Database", Ex);
                }
            }
        }

        #endregion Methods
    }

    /// <summary>
    /// Object which represents a physical location on the network.
    /// </summary>
    public class Location
    {
        #region Private Variables
        
        private int _ID; //Private variable to hold the ID of the location record
        private SystemLocation _SystemLocation; //Private variable to hold the Location ID of the locaton record
        private string _Name; //Private variable to hold the name of the location
        private string _TIPLOC; //Private variable  to hold the TIPLOC code of the location
        private int _STANOX; //Private variable to hold the Station Number of the location
        private string _STANME; //Private variable to hold the Station Number Name of the location
        private int _NLC; //Private variable to hold the National Location Code
        private LocationType _Type; //Private variable to hold the type of the location
        private decimal _Latitude; //Private variable to hold the latitude of the location
        private decimal _Longitude; //Private variable to hold the longitude of the location
        private Distance _Length; //Private variable to hold the length of the location
        private bool _DisembarkPassengers; //Private variable to hold a flag to indicate whether passengers can disembark at the location
        private bool _EmbarkPassengers; //Private variable to hold a flag to indicate whether passengers can emabark at the location
        private bool _FreightOnly; //Private variable to hold a flag to indicate whether the location is freight only
        private bool _SingleTrainWorking; //Private variable to flag whether the location is single train working
        private Token _Token; //Private variable to indicate whether the location requires a token
        private int _Berths; //Private variable to indicate the number of the berths at the location
        private Location _ParentLocation; //Private variable to store the parent location
        private LocationCollection _ChildLocations; //Private variable to store the child locations
        private NetworkDirection _Direction; //Private variable to store the permissible directions of travel from the location
        private int _Score; //Private variable to store the score earnt at the location
        private bool _UseAsTimingPoint; //Private variable to store whether the location is used as a timing point;
        private int _Options; //Private variable to store the options for the location
        private int _PermissiblePowerSources; //Private variable to store the types of power available on the location. This is a bitwise of the PowerType enum
        private bool _TOPSOffice; //Private variable to store whether the location has a TOPS office
        private YMDV _RecordStartYMDV; //Private variable to store the record start YMDV
        private YMDV _RecordEndYMDV; //Private variable to store the record end YMDV

        #endregion Private Variables

        #region Public Properties

        /// <summary>
        /// Gets the ID of the location Record
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the SystemLocation of the location
        /// </summary>
        public SystemLocation SystemLocation { get { return this._SystemLocation; } }

        /// <summary>
        /// Gets and sets the name of the location
        /// </summary>
        public string Name { get { return this._Name; } set { this._Name = value; } }

        /// <summary>
        /// Gets the displau name of the location
        /// </summary>
        public string DisplayName { get { return this._ParentLocation == null ? this._Name : string.Format(@"{0} ({1})", this._ParentLocation.Name, this._Name); } }

        /// <summary>
        /// Gets and sets the Timing Point Location Code (TIPLOC) of the location
        /// </summary>
        public string TIPLOC { get { return this._TIPLOC; } set { this._TIPLOC = value; } }

        /// <summary>
        /// Gets and sets the Station Number (STANOX) of the location
        /// </summary>
        public int STANOX { get { return this._STANOX; } set { this._STANOX = value; } }

        /// <summary>
        /// Gets and sets the Station Number Name (STANME) of the location
        /// </summary>
        public string STANME { get { return this._STANME; } set { this._STANME = value; } }

        /// <summary>
        /// Gets and sets the National Location Code (NLC) of the location
        /// </summary>
        public int NLC { get { return this._NLC; } set { this._NLC = value; } }

        /// <summary>
        /// Gets and sets the type of the location
        /// </summary>
        public LocationType Type { get { return this._Type; } set { this._Type = value; } }

        /// <summary>
        /// Gets and sets the Latitude of the location
        /// </summary>
        public decimal Latitude { get { return this._Latitude; } set { this._Latitude = value; } }

        /// <summary>
        /// Gets and sets the Latiude of the location
        /// </summary>
        public decimal Longitude { get { return this._Longitude; } set { this._Longitude = value; } }

        /// <summary>
        /// Gets and sets the Length of the location
        /// </summary>
        public Distance Length { get { return this._Length; } set { this._Length = value; } }

        /// <summary>
        /// Gets and sets the token of the location. Only applicable if location is SingleTrainWorking
        /// </summary>
        public Token Token { get { return this._Token; } set { this._Token = value; } }

        /// <summary>
        /// Gets and sets the token of the location. Only applicable if location is SingleTrainWorking
        /// </summary>
        public bool SingleTrainWorking { get { return this._SingleTrainWorking; } set { this._SingleTrainWorking = value; } }

        /// <summary>
        /// Get and sets flag to indicate whether passengers can disembark at location
        /// </summary>
        public bool DisembarkPassengers { get { return this._DisembarkPassengers; } set { this._DisembarkPassengers = value; } }

        /// <summary>
        /// Gets and sets and sets the flag to indicate whether passengers can embark at location
        /// </summary>
        public bool EmbarkPassengers { get { return this._EmbarkPassengers; } set { this._EmbarkPassengers = value; } }

        /// <summary>
        /// Gets and sets flag to indicate whether location is freight only
        /// </summary>
        public bool FreightOnly { get { return this._FreightOnly; } set { this._FreightOnly = value; } }

        /// <summary>
        /// Gets and sets the number of berths at a location
        /// </summary>
        public int Berths { get { return this._Berths; } set { this._Berths = value; } }

        /// <summary>
        /// Gets and sets the parent location
        /// </summary>
        public Location ParentLocation { get { return this._ParentLocation; } set { this._ParentLocation = value; } }

        /// <summary>
        /// Gets the child locations
        /// </summary>
        public LocationCollection ChildLocations { get { return this._ChildLocations; } }

        /// <summary>
        /// Gets and sets the direction permissible from the location
        /// </summary>
        public NetworkDirection Direction { get { return this._Direction; } set { this._Direction = value; } }

        /// <summary>
        /// Gets and sets the score earnt by the player arriving at the location
        /// </summary>
        public int Score { get { return this._Score; } set { this._Score = value; } }

        /// <summary>
        /// Gets and sets the flag to indicate whether the location is used as timing point
        /// </summary>
        public bool UseAsTimingPount { get { return this._UseAsTimingPoint; } set { this._UseAsTimingPoint = value; } }

        /// <summary>
        /// Gets and sets the options for the location. See LocationOptions for bitwise values
        /// </summary>
        public int Options { get { return this._Options; } set { this._Options = value; } }

        /// <summary>
        /// Gets and sets the permissible power sources for the location. See PowerType enum for bitwise values
        /// </summary>
        public int PermissiblePowerSources { get { return this._PermissiblePowerSources; } set { this._PermissiblePowerSources = value; } }

        /// <summary>
        /// Gets and sets the the flag which indicates whether the location has a TOPS office
        /// </summary>
        public bool TOPSOffice { get { return this._TOPSOffice; } set { this._TOPSOffice = value; } }

        /// <summary>
        /// Gets and sets the record start YMDV
        /// </summary>
        public YMDV RecordStartYMDV { get { return this._RecordStartYMDV; } set { this._RecordStartYMDV = value; } }

        /// <summary>
        /// Gets the record end YMDV
        /// </summary>
        public YMDV RecordEndYMDV { get { return this._RecordEndYMDV; } set { this._RecordEndYMDV = value; } }

        /// <summary>
        /// Gets a flag to indicate whether the location is a child location
        /// </summary>
        public bool IsChild { get { if (this._ParentLocation != null) { return true; } else { return false; }; } }

        /// <summary>
        /// Gets the Location Display Name and Record Dates
        /// </summary>
        public string DisplayNameAndDates { get { return GetNameAndDates(); } }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Initialises a new instance of a location object for the DB ID
        /// </summary>
        /// <param name="ID">DB ID</param>
        /// <param name="GetChildren">Flag to indicate whether the child locations should be loaded for the location</param>
        public Location(int ID)
        {
            this._ID = ID;
            GetLocationByIDFromDatabase(true);
        }

        /// <summary>
        /// Initialises a new instance of a location object for SqlDataReader Object
        /// </summary>
        /// <param name="SQLReader">The SqlDataReader object to parse</param>
        public Location(SqlDataReader SQLReader, bool GetChildren)
        {
            ParseSQLReader(SQLReader, GetChildren);
        }

        /// <summary>
        /// Initialises an emptoy instance of location object
        /// </summary>
        public Location()
        {
            this._ID = 0;
        }

        /// <summary>
        /// Initialises a child Location
        /// </summary>
        public Location(Location ParentLocation)
        {
            this._SystemLocation = null;
            this._ParentLocation = ParentLocation;
            this._Type = ParentLocation.Type;
            this._ID = 0;
        }

        /// <summary>
        /// Initialises a new location for the supplied System Location
        /// </summary>
        public Location(SystemLocation SystemLocation)
        {
            this._SystemLocation = SystemLocation;
            this._ParentLocation = null;
            this._ID = 0;
        }

        /// <summary>
        /// Initialises a new instance of a parent location object for the DB ID
        /// </summary>
        /// <param name="ID">DB ID</param>
        /// <param name="GetChildren">Should always be set to false</param>
        private Location(int ID, bool GetChildren)
        {
            this._ID = ID;
            GetLocationByIDFromDatabase(false);
        }

        /// <summary>
        /// Initialises a new instance of a location object for the System Location and YMDV
        /// </summary>
        /// <param name="ID">DB ID</param>
        /// <param name="GetChildren">Should always be set to false</param>
        public Location(SystemLocation Location, YMDV YMDV, bool GetChildren)
        {
            GetLocationBySystemLocationAndYMDVFromDatabase(Location, YMDV, GetChildren);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the distance in meters to the supplied Location
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public double Distance(Location X)
        {
            var sCoord = new GeoCoordinate((double)this._Latitude, (double)this._Longitude);
            var eCoord = new GeoCoordinate((double)X._Latitude, (double)X._Longitude);

            return sCoord.GetDistanceTo(eCoord);
        }

        /// <summary>
        /// Gets the Location Name and Record Start and End Dates in a friendly format
        /// </summary>
        /// <returns></returns>
        private string GetNameAndDates()
        {
            return string.Format(@"{0} | {1} - {2}", this._Name, this._RecordStartYMDV.DisplayDate, this._RecordEndYMDV.DisplayDate);
        }

        /// <summary>
        /// Validates a the location
        /// </summary>
        /// <returns></returns>
        public List<DataValidationError> ValidateLocation()
        {
            //TODO Location Validator
            return new List<DataValidationError>();
        }

        /// <summary>
        /// Saves the location record to the GroundFrame DB
        /// </summary>
        /// <returns></returns>
        public GFResponse SaveToDB()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_SAVE_TLOCATION", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this._ID);
                        cmd.Parameters.AddWithValue("@start_ymdv", this._RecordStartYMDV.Value);
                        cmd.Parameters.AddWithValue("@end_ymdv", this._RecordEndYMDV.Value);
                        cmd.Parameters.AddWithValue("@location_itemno", IsChild == true ? (object)DBNull.Value : this._SystemLocation.ID);
                        cmd.Parameters.AddWithValue("@name", this._Name);
                        cmd.Parameters.AddWithValue("@tiploc", IsChild == true ? (object)DBNull.Value : string.IsNullOrEmpty(this._TIPLOC) ? (object)DBNull.Value : this._TIPLOC);
                        cmd.Parameters.AddWithValue("@stanox", IsChild == true ? 0 : this._STANOX);
                        cmd.Parameters.AddWithValue("@stanme", IsChild == true ? (object)DBNull.Value : string.IsNullOrEmpty(this._STANME) ? (object)DBNull.Value : this._STANME);
                        cmd.Parameters.AddWithValue("@nlc", IsChild == true ? 0 : this._NLC);
                        cmd.Parameters.AddWithValue("@location_typeitemno", IsChild == true ? (int)this._ParentLocation.Type : (int)this._Type);
                        cmd.Parameters.AddWithValue("@latitude", IsChild == true ? 0 : this._Latitude);
                        cmd.Parameters.AddWithValue("@longitude", IsChild == true ? 0 :  this._Longitude);
                        cmd.Parameters.AddWithValue("@parent_location_itemno", IsChild == true ? this._ParentLocation.ID : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@length", this._Length.Meters);
                        cmd.Parameters.AddWithValue("@disembark_passengers", this._DisembarkPassengers);
                        cmd.Parameters.AddWithValue("@embark_passengers", this._EmbarkPassengers);
                        cmd.Parameters.AddWithValue("@freight_only", this._FreightOnly);
                        cmd.Parameters.AddWithValue("@single_train_working", this._SingleTrainWorking);
                        cmd.Parameters.AddWithValue("@token_itemno", IsChild == true ? this._ParentLocation.Token == null ? (object)DBNull.Value : this._ParentLocation.Token.ID : this._Token == null || this._Token.ID == 0 ? (object)DBNull.Value : this._Token.ID);
                        cmd.Parameters.AddWithValue("@berths", this._Berths);
                        cmd.Parameters.AddWithValue("@direction", (int)this._Direction);
                        cmd.Parameters.AddWithValue("@score", this._Score);
                        cmd.Parameters.AddWithValue("@use_as_timing_point", this._UseAsTimingPoint);
                        cmd.Parameters.AddWithValue("@options", this._Options);
                        cmd.Parameters.AddWithValue("@permissible_power", this._PermissiblePowerSources);
                        cmd.Parameters.AddWithValue("@tops_office", this._TOPSOffice);

                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
                        }

                        return Audit.WriteLog(new GFResponse(AuditType.Information, string.Format(@"Location {0} saved to the database:-", this.Name)));
                    }
                }
                catch (Exception Ex)
                {
                    return Audit.WriteLog(new GFResponse(AuditType.Error, string.Format(@"Error saving Location {0} to the database", this.Name), Ex), 1, this);
                }
            }
        }

        /// <summary>
        /// Loads the Location from the Database based on the Location DB ID
        /// </summary>
        /// <param name="GetChildren">Flag to indicate whether parsing the SqlDataReader should get the child records. Should be set to false if retreving a parent location object</param>
        private void GetLocationByIDFromDatabase(bool GetChildren)
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_LOCATION_BY_ID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //If no record are found then throw an error. This should never happen
                        if (SQLReader.HasRows == false) { throw new Exception(string.Format(@"Location with ID {0} doesn't exist in the GF Database", this.ID)); };

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            ParseSQLReader(SQLReader, GetChildren);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the Location with ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Loads the Location from the DB for the specified SystemLocation and YMDV
        /// </summary>
        /// <param name="Location"></param>
        /// <param name="YMDV"></param>
        private void GetLocationBySystemLocationAndYMDVFromDatabase(SystemLocation SystemLocation, YMDV YMDV, bool GetChildren)
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_LOCATION_BY_SYSTEMLOCATIONANDYMDV", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@location_itemno", SystemLocation.ID);
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //If no record are found then throw an error. This should never happen
                        if (SQLReader.HasRows == false) { throw new Exception(string.Format(@"Location with System ID {0} doesn't exist on YMDV {1} in the GF Database", SystemLocation.ID, YMDV.Value)); };

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            ParseSQLReader(SQLReader, GetChildren);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the Locations with System Loction ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Parses a SqlDataReader into the Location object
        /// </summary>
        /// <param name="SQLReader"></param>
        /// <param name="GetChildren">Indicates whether the Parse should attempt to load the Location children</param>
        private void ParseSQLReader(SqlDataReader SQLReader, bool GetChildren)
        {
            //Check Common.SystemLocations is populated
            if (Common.SystemLocations == null)
            {
                throw new Exception("Cannot Parse Location SqlDataReader because the global SystemLocationCollection stored at Common.SystemLocations is empty");
            }

            //Check Common.Tokens is populated
            if (Common.Tokens == null)
            {
                throw new Exception("Cannot Parse Location SqlDataReader because the global TokenCollection stored at Common.Tokens is empty");
            }
            
            
            int _Ordinal; //Holds the field ordinal

            //Set the ID

            _Ordinal = SQLReader.GetOrdinal("itemno");
            this._ID = SQLReader.GetSafeInt32(_Ordinal);

            //Set the System Location
            _Ordinal = SQLReader.GetOrdinal("location_itemno");
            int _SystemLocationID = SQLReader.GetSafeInt32(_Ordinal);

            if (_SystemLocationID != 0)
            {
                this._SystemLocation = Common.SystemLocations.Where(x => x.ID == _SystemLocationID).FirstOrDefault();
            }
            else
            {
                this._SystemLocation = null;
            }

            _Ordinal = SQLReader.GetOrdinal("name");
            this._Name = SQLReader.GetString(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("tiploc");
            this._TIPLOC = SQLReader.GetSafeString(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("stanox");
            this._STANOX = SQLReader.GetInt32(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("stanme");
            this._STANME = SQLReader.GetSafeString(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("nlc");
            this._NLC = SQLReader.GetInt32(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("location_type_itemno");
            this._Type = (LocationType)SQLReader.GetInt16(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("latitude");
            this._Latitude = SQLReader.GetSafeDecimal(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("longitude");
            this._Longitude = SQLReader.GetSafeDecimal(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("parent_itemno");
            int ParentItemNo = SQLReader.GetSafeInt32(_Ordinal);
            if (ParentItemNo == 0) { this._ParentLocation = null; } else { this._ParentLocation = new Location(ParentItemNo, false); };

            _Ordinal = SQLReader.GetOrdinal("length");
            this._Length = new Distance(SQLReader.GetDecimal(_Ordinal));

            _Ordinal = SQLReader.GetOrdinal("disembark_passengers");
            this._DisembarkPassengers = SQLReader.GetBoolean(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("embark_passengers");
            this._EmbarkPassengers = SQLReader.GetBoolean(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("freight_only");
            this._FreightOnly = SQLReader.GetBoolean(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("single_train_working");
            this._SingleTrainWorking = SQLReader.GetBoolean(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("token_itemno");
            int TokenItemno = SQLReader.GetSafeInt32(_Ordinal);
            this._Token = TokenItemno == 0 ? null : new Token(TokenItemno);

            _Ordinal = SQLReader.GetOrdinal("berths");
            this._Berths = SQLReader.GetInt16(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("direction");
            this._Direction = (NetworkDirection)SQLReader.GetByte(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("score");
            this._Score = SQLReader.GetInt16(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("use_as_timing_point");
            this._UseAsTimingPoint = SQLReader.GetBoolean(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("options");
            this._Options = (int)SQLReader.GetInt64(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("permissible_power");
            this._PermissiblePowerSources = (int)SQLReader.GetInt64(_Ordinal);

            //Get Child Locations
            if (GetChildren) { this._ChildLocations = new LocationCollection(this); };

            _Ordinal = SQLReader.GetOrdinal("tops_office");
            this._TOPSOffice = SQLReader.GetBoolean(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("start_ymdv");
            this._RecordStartYMDV = new YMDV(SQLReader.GetInt32(_Ordinal));

            _Ordinal = SQLReader.GetOrdinal("end_ymdv");
            this._RecordEndYMDV = new YMDV(SQLReader.GetSafeInt32(_Ordinal));
        }

        #endregion Methods
    }

    public class LocationCollection : IEnumerable<Location>
    {
        #region Private Variables

        private List<Location> _Locations = new List<Location>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<Location> GetEnumerator() { return this._Locations.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initlises a new collection of locations for the date provided
        /// </summary>
        /// <param name="Date"></param>
        public LocationCollection(YMDV YMDV)
        {
            GetAllLocationsFromDB(YMDV);
        }
    
        /// <summary>
        /// Intitialises a new location collection
        /// </summary>
        /// <param name="Paths"></param>
        public LocationCollection(List<Location> Locations)
        {
            this._Locations = Locations;
        }

        /// <summary>
        /// Initialises a collection of child locations for a parent Location
        /// </summary>
        /// <param name="ParentLocation"></param>
        public LocationCollection(Location ParentLocation)
        {
            GetChildLocationsFromDB(ParentLocation);
        }

        /// <summary>
        /// Initialises a collection of locations for a system location
        /// </summary>
        /// <param name="ParentLocation"></param>
        public LocationCollection(SystemLocation SystemLocation, bool GetChildren)
        {
            GetLocationsBySystemLocationFromDB(SystemLocation, GetChildren);
        }

        /// <summary>
        /// Initialises a collection of location for a system location and YMDV
        /// </summary>
        /// <param name="SystemLocation"></param>
        /// <param name="YMDV"></param>
        public LocationCollection(SystemLocation SystemLocation, YMDV YMDV)
        {
            GetLocationBySystemLocationAndYMDVFromDatabase(SystemLocation, YMDV, false);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads the Location from the DB for the specified SystemLocation and YMDV
        /// </summary>
        /// <param name="Location"></param>
        /// <param name="YMDV"></param>
        private GFResponse GetLocationBySystemLocationAndYMDVFromDatabase(SystemLocation SystemLocation, YMDV YMDV, bool GetChildren)
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    _Locations = new List<Location>();

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_LOCATION_BY_SYSTEMLOCATIONANDYMDV", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@location_itemno", SystemLocation.ID);
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            _Locations.Add(new Location(SQLReader, GetChildren));
                        }
                    }

                    return new GFResponse(AuditType.Information, string.Format("Locations with System Loction ID {0} retreived successfully from the GF Database", SystemLocation.ID));
                }
                catch (Exception Ex)
                {
                    return new GFResponse(AuditType.Error, string.Format("Error trying to retreive all the Locations with System Loction ID {0} from the GF Database", SystemLocation.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Adds a location to the collection
        /// </summary>
        /// <param name="Location"></param>
        public void Add(Location Location)
        {
            if (_Locations.Count(x => x.ID == Location.ID) > 0)
            {
                throw new Exception(string.Format("Location with ID {0} ({1}) already exists in the collection", Location.ID, Location.Name));
            }
            else
            {
                _Locations.Add(Location);
            }
        }

        /// <summary>
        /// Loads the Child Locations from the GF database
        /// </summary>
        /// <param name="ParentLocation">Parent Location</param>
        private void GetChildLocationsFromDB(Location ParentLocation)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Child Locations from the GF Database. Common.SQLDBConn is <null>");
            }


            //Initialise _SyetemLocations as a new List
            _Locations = new List<Location>();

            //Get the SystemLocations from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_CHILD_LOCATIONS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@parent_itemno", ParentLocation.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Only need to parse the records if data is returned by the query
                        if (SQLReader.HasRows)
                        {
                            //Loop through each record and add it to the collection
                            while (SQLReader.Read())
                            {
                                int _Ordinal;

                                _Ordinal = SQLReader.GetOrdinal("itemno");
                                int _ID = SQLReader.GetInt32(_Ordinal);

                                _Locations.Add(new Location(_ID));
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Locations from the GF Database", Ex);
                }
            }
        }

        /// <summary>
        /// Gets a list all location fom the GF Database for a particular System Location and YMDV
        /// </summary>
        private void GetLocationsBySystemLocationAndYMVFromDB(SystemLocation Location, YMDV YMDV, bool GetChildren)
        {
            //Initialise _SyetemLocations as a new List
            _Locations = new List<Location>();

            //Get the SystemLocations from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_LOCATION_BY_SYSTEMLOCATION", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@location_itemno", Location.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            int _Ordinal;

                            _Ordinal = SQLReader.GetOrdinal("itemno");
                            int _ID = SQLReader.GetInt32(_Ordinal);

                            _Locations.Add(new Location(SQLReader, GetChildren));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Locations from the GF Database", Ex);
                }
            }
        }

        /// <summary>
        /// Gets a list all location fom the GF Database for a particular System Location
        /// </summary>
        private void GetLocationsBySystemLocationFromDB(SystemLocation Location, bool GetChildren)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Locations from the GF Database. Common.SQLDBConn is <null>");
            }

            //Check Common.SystemLocations is populated
            if (Common.SystemLocations == null)
            {
                throw new Exception("Error trying to retreive all the Locations from the GF Database. The global SystemLocationCollection stored at Common.SystemLocations is empty");
            }

            //Initialise _SyetemLocations as a new List
            _Locations = new List<Location>();

            //Get the SystemLocations from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_LOCATION_BY_SYSTEMLOCATION", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@location_itemno", Location.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            int _Ordinal;

                            _Ordinal = SQLReader.GetOrdinal("itemno");
                            int _ID = SQLReader.GetInt32(_Ordinal);

                            _Locations.Add(new Location(SQLReader, GetChildren));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Locations from the GF Database", Ex);
                }
            }
        }


        /// <summary>
        /// Gets a list all location fom the GF Database for a particular YMDV
        /// </summary>
        private void GetAllLocationsFromDB(YMDV YMDV)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Locations from the GF Database. Common.SQLDBConn is <null>");
            }

            //Check Common.SystemLocations is populated
            if (Common.SystemLocations == null)
            {
                throw new Exception("Error trying to retreive all the Locations from the GF Database. The global SystemLocationCollection stored at Common.SystemLocations is empty");
            }

            //Initialise _SyetemLocations as a new List
            _Locations = new List<Location>();

            //Get the SystemLocations from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_LOCATIONS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            int _Ordinal;

                            _Ordinal = SQLReader.GetOrdinal("itemno");
                            int _ID = SQLReader.GetInt32(_Ordinal);

                            _Locations.Add(new Location(_ID));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Locations from the GF Database", Ex);
                }
            }
        }

        #endregion Constructors
    }
}
