using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Horizon4.GF.RollingStock;

namespace Horizon4.GF.Logical
{
    /// <summary>
    /// SystemSector record
    /// </summary>
    public struct SystemSector : ISystemObject
    {
        #region Private Variables

        private int _ID; //Private variable to hold the ID of the system sector record
        private string _Name; //Private variable to hold the code of the system sector record
        private string _Description; //Private variable to hold the description. In this case description is not needed but added to keep integrity to ISystemObject

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the ID of the SystemSector
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets or sets the name of the SystemSector
        /// </summary>
        public string Name { get { return this._Name; } set { this._Name = value; } }

        /// <summary>
        /// Gets or sets the description of the SystemSector
        /// </summary>
        [Obsolete("Not required by the SystemSector Object")]
        public string Description { get { return this._Description; } set { this._Description = value; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Constructs a new instance of a SystemSector struct.
        /// </summary>
        /// <param name="ID">The ID of the SystemSector record</param>
        /// <param name="Name">The Code of the SystemSector record</param>
        public SystemSector(int ID, string Code)
        {
            this._ID = ID;
            this._Name = Code;
            this._Description = string.Empty;
        }

        public SystemSector(SqlDataReader SQLReader)
        {
            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
            this._Name = SQLReader.GetString(SQLReader.GetOrdinal("code"));
            this._Description = string.Empty;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Saves the SystemSector back to the Groundframe DB
        /// </summary>
        public GFResponse SaveToDB()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("logical.Usp_SAVE_SYSTEMSECTOR", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this._ID);
                        cmd.Parameters.AddWithValue("@code", this._Name);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
                        }

                        
                    }

                    //Write audit and return response
                    return Audit.WriteLog(new GFResponse(AuditType.Information, string.Format(@"SystemSector {0} saved to the database:-", this.Name)));
                }
                catch (Exception Ex)
                {
                    return Audit.WriteLog(new GFResponse(AuditType.Error, string.Format(@"Error saving SystemSector {0} to the database}", this.Name), Ex), 1, this);
                }
            }
        }

        #endregion Methods
    }


    /// <summary>
    /// Class to represent a collection of depots
    /// </summary>
    public class SystemSectorCollection : IEnumerable<SystemSector>
    {
        #region Private Variables

        private List<SystemSector> _SystemSectors = new List<SystemSector>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<SystemSector> GetEnumerator() { return this._SystemSectors.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new SystemSectorCollection from the GF Database
        /// </summary>
        public SystemSectorCollection()
        {
            GetAllSystemSectors();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets all SystemSectors from the database
        /// </summary>
        private void GetAllSystemSectors()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("logical.Usp_GET_ALL_SYSTEMSECTORS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            this._SystemSectors.Add(new SystemSector(SQLReader));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all SystemSectors from the GF Database", Ex);
                }
            }
        }

        #endregion Methods
    }

    public class Sector
    {
        #region Private Variables

        private int _ID; //Private variable to store the DB ID of the sector
        private SystemSector _Code; //Private variable to store the Code of the sector
        private string _Description; //Private variable to store the Description of the sector
        private YMDV _RecordStartYMDV; //Private variable to store the Start YMDV for the sector
        private YMDV _RecordEndYMDV; //Private variable to store the Start YMDV for the sector

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the Sector GF Database ID
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the Sector Code
        /// </summary>
        public SystemSector Code { get { return this._Code; } }

        /// <summary>
        /// Gets the Sector Description
        /// </summary>
        public string Description { get { return this._Description; } set { this._Description = value; } }

        /// <summary>
        /// Gets the Sector Start YMDV
        /// </summary>
        public YMDV RecordStartYMDV { get { return this._RecordStartYMDV; } set { this._RecordStartYMDV = value; } }

        /// <summary>
        /// Gets the Sector End YMDV
        /// </summary>
        public YMDV RecordEndYMDV { get { return this._RecordEndYMDV; } set { this._RecordEndYMDV = value; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialises an instance of a sector from the GF Database ID
        /// </summary>
        /// <param name="ID"></param>
        public Sector(int ID)
        {
            this._ID = ID;

            //Get the record from the GF Database
            GetSectorByIDFromDatabase();
        }

        /// <summary>
        /// Initialises an instance of a sector
        /// </summary>
        public Sector()
        {
            this._ID = 0;
        }

        /// <summary>
        /// Initialises a instance of a sector from a SqlDataReader object
        /// </summary>
        /// <param name="SQLReader"></param>
        public Sector(SqlDataReader SQLReader)
        {
            ParseSQLReader(SQLReader);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads the sector data from the GF Database based on the ID of the Sector
        /// </summary>
        private void GetSectorByIDFromDatabase()
        {
            if (Common.SystemSectors == null)
            {
                throw new Exception(string.Format("Cannot load Sector {0} from GF Database - SystemSectors must be populated with the system sectors", this._ID));
            }

            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("logical.Usp_GET_SECTOR_BY_ID", conn))
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
                    throw new Exception(string.Format("Error trying to retreive all the Sector with ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Parses a SqlDataReader into the Sector object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
            int SystemSectorID = SQLReader.GetInt32(SQLReader.GetOrdinal("code_itemno"));
            this._Code = Common.SystemSectors.Where(x => x.ID == SystemSectorID).FirstOrDefault();
            this._Description = SQLReader.GetSafeString(SQLReader.GetOrdinal("description"));
            this._RecordStartYMDV = new YMDV(SQLReader.GetInt32(SQLReader.GetOrdinal("start_ymdv")));
            this._RecordEndYMDV = new YMDV(SQLReader.GetSafeInt32(SQLReader.GetOrdinal("end_ymdv")));
        }

        /// <summary>
        /// Validates the data stored in the object. If errors are found a list is returned.
        /// </summary>
        /// <returns></returns>
        public List<DataValidationError> ValidateData()
        {
            List<DataValidationError> Result = new List<DataValidationError>();

            if (string.IsNullOrEmpty(this._Description))
            {
                Result.Add(new DataValidationError("Description", "The sector description cannot be <null> or an empty string"));
            }

            if (new SectorCollection().Count(x => x._Description.ToLower() == this._Description && x.ID != this.ID) > 0)
            {
                Result.Add(new DataValidationError("Description", string.Format("A sector with description {0} already exists in the GroundFrame database", this._Description)));
            }

            if (this._RecordEndYMDV.Value != 0 && this._RecordEndYMDV.Value < this._RecordStartYMDV.Value)
            {
                Result.Add(new DataValidationError("EndYMDV", string.Format("The end YMDV must be <null> or after the StartYMDV", this._Description)));
            }

            return Result;
        }

        /// <summary>
        /// Saves the sector back to the Groundframe DB
        /// </summary>
        public GFResponse SaveToDB()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("logical.Usp_SAVE_SECTOR", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@description", this._Description);
                        cmd.Parameters.AddWithValue("@ymdv", this._RecordStartYMDV.Value);
                        cmd.Parameters.AddWithValue("@code_itemno", this.Code.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the ID of the record returned
                        while (SQLReader.Read())
                        {
                            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
                            this._RecordEndYMDV = new YMDV(SQLReader.GetSafeInt32(SQLReader.GetOrdinal("end_ymdv")));
                        }

                        GFResponse Response = new GFResponse(AuditType.Information, string.Format(@"Sector ID {0} saved to the database.", this._ID));
                        return Audit.WriteLog(Response);
                    }
                }
                catch (Exception Ex)
                {
                    GFResponse Response = new GFResponse(AuditType.Error, string.Format(@"Error trying to save Sector {0} to the GroundFrame database.", this.Code), Ex);
                    return Audit.WriteLog(Response, 1, this);
                }
            }
        }

        #endregion Methods
    }


    /// <summary>
    /// Class to represent a collection of depots
    /// </summary>
    public class SectorCollection : IEnumerable<Sector>
    {
        #region Private Variables

        private List<Sector> _Sectors = new List<Sector>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<Sector> GetEnumerator() { return this._Sectors.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new SectorsCollection from the GF Database containing all Sectors
        /// </summary>
        public SectorCollection()
        {
            GetAllSectorsFromDB();
        }

        /// <summary>
        /// Intialises a new SectorsCollection from the GF Database for the specifc YMDV
        /// </summary>
        public SectorCollection(YMDV YMDV)
        {
            GetAllSectorsFromDBByYMDV(YMDV);
        }

        /// <summary>
        /// Intialises a new SectorsCollection from the GF Database for the specifc Rake
        /// </summary>
        public SectorCollection(Rake Rake)
        {
            GetRakeSectorsFromDB(Rake);
        }


        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds a sector to the collection
        /// </summary>
        /// <param name="Sector"></param>
        public void Add(Sector Sector)
        {
            if (_Sectors.Count(x => x.ID == Sector.ID) > 0)
            {
                throw new Exception(string.Format("Sector with ID {0} ({1}) already exists in the collection", Sector.ID, Sector.Description));
            }
            else
            {
                _Sectors.Add(Sector);
            }
        }

        /// <summary>
        /// Gets a list of the Sector from the GF Database for a given YMDV and populates _Depots
        /// </summary>
        private void GetAllSectorsFromDB()
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Sectors from the GF Database. Common.SQLDBConn is <null>");
            }

            //Check to see if the DB Connection string is set
            if (Common.SystemSectors == null)
            {
                throw new Exception("Error trying to retreive all the Sectors from the GF Database. Common.SystemSectors must be populated");
            }

            //Initialise _Sectors as a new List
            _Sectors = new List<Sector>();

            //Get the Sectors from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("logical.Usp_GET_SECTORS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _Sectors.Add(new Sector(SQLReader));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Sectors from the GF Database", Ex);
                }
            }
        }

        /// <summary>
        /// Gets a list of the Sector from the GF Database for a given YMDV and populates _Depots
        /// </summary>
        private void GetAllSectorsFromDBByYMDV(YMDV YMDV)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Sectors from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _Sectors as a new List
            _Sectors = new List<Sector>();

            //Get the Sectors from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("logical.Usp_GET_SECTORS_BY_YMDV", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _Sectors.Add(new Sector(SQLReader));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Sectors from the GF Database", Ex);
                }
            }
        }

        /// <summary>
        /// Gets a list of the Sector from the GF Database for a given YMDV and populates _Depots
        /// </summary>
        private void GetRakeSectorsFromDB(Rake Rake)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Rake Sectors from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _Sectors as a new List
            _Sectors = new List<Sector>();

            //Get the Sectors from the Database for the Rake
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_RAKE_SECTORS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@rake_itemno", Rake.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _Sectors.Add(new Sector(SQLReader));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Sectors from the GF Database", Ex);
                }
            }
        }

        #endregion Methods
    }
}
