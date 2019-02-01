using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.ComponentModel;
using Horizon4.GF.RollingStock;
using Horizon4.GF;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Horizon4.GF.Logical
{
    [Serializable]
    public class Region
    {
        #region Private Variables

        private int _ID; //Private variable to store the DB ID of the region
        private string _Name; //Private variable to store the name of the region
        private string _Description; //Private variable to store the description of the region
        private YMDV _RecordStartYMDV; //Private variable to store the Start YMDV of the record
        private YMDV _RecordEndYMDV; //Private variable to store the End YMDV of the record

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the GroundFrame DB ID of the Region
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the name of the region
        /// </summary>
        public string Name { get { return this._Name; } set { this._Name = value;} }

        /// <summary>
        /// Gets the description of the region
        /// </summary>
        public string Description { get { return this._Description; } set { this._Description = value; } }

        /// <summary>
        /// Gets the end YMDV for the region
        /// </summary>
        public YMDV RecordStartYMDV { get { return this._RecordStartYMDV; } set { this._RecordStartYMDV = value; } }

        /// <summary>
        /// Gets the end YMDV for the region
        /// </summary>
        public YMDV RecordEndYMDV { get { return this._RecordEndYMDV; } set { this._RecordEndYMDV = value; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intitialises an instance of a region for the supplied GroundFrame DB ID
        /// </summary>
        public Region(int ID)
        {
            this._ID = ID;
            GetRegionFromDatabaseByID();
        }

        /// <summary>
        /// Intitialises an instance of a new region 
        /// </summary>
        public Region()
        {
            this._ID = 0;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Saves the region back to the Groundframe DB
        /// </summary>
        public GFResponse SaveToDB()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("logical.Usp_SAVE_REGION", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this._ID);
                        cmd.Parameters.AddWithValue("@name", this._Name);
                        cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(this._Description) ? (object)DBNull.Value : this._Description);
                        cmd.Parameters.AddWithValue("@start_ymdv", this._RecordStartYMDV.Value);
                        cmd.Parameters.AddWithValue("@end_ymdv", this._RecordEndYMDV.Value == 0 ? (object)DBNull.Value : this._RecordEndYMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the ID of the record returned
                        while (SQLReader.Read())
                        {
                            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
                        }

                        return Audit.WriteLog(new GFResponse(AuditType.Information, string.Format(@"Region ID {0} saved successfully to the GroundFrame database.", this.Name)));
                    }
                }
                catch (Exception Ex)
                {
                    return Audit.WriteLog(new GFResponse(AuditType.Error, string.Format(@"Error saving region {0} to the GroundFrame database.", this.Name), Ex), 1, this);
                }
            }
        }

        /// <summary>
        /// Loads the Train Traction Allocation of the specified ID GF Database
        /// </summary>
        /// <param name="SystemLocation"></param>
        /// <param name="YMDV"></param>
        private void GetRegionFromDatabaseByID()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("logical.Usp_GET_REGION_BY_ID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this._ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //If no record are found then throw an error. This should never happen
                        if (SQLReader.HasRows == false) { throw new Exception(string.Format(@"Region with ID {0} doesn't exist in the GF Database", this._ID)); };

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            ParseSQLReader(SQLReader);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive the Region with the ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Parses a SqlDataReader object into a Region object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            this._Name = SQLReader.GetString(SQLReader.GetOrdinal("name"));
            this._Description = SQLReader.GetSafeString(SQLReader.GetOrdinal("description"));
            this._RecordStartYMDV = new YMDV(SQLReader.GetInt32(SQLReader.GetOrdinal("start_ymdv")));

            int EndYMDV = SQLReader.GetSafeInt32(SQLReader.GetOrdinal("end_ymdv"));
            //Only set the YMDV if it's not <null> / 0
            if (EndYMDV != 0) { this._RecordEndYMDV = new YMDV(EndYMDV); };
        }

        /// <summary>
        /// Validates the data stored in the object. If errors are found a list is returned.
        /// </summary>
        /// <returns></returns>
        public List<DataValidationError> ValidateData()
        {
            List<DataValidationError> Result = new List<DataValidationError>();

            if (string.IsNullOrEmpty(this._Name))
            {
                Result.Add(new DataValidationError("Name", "The region name cannot be <null> or an empty string"));
            }

            if (new RegionCollection().Count(x => x._Name.ToLower() == this._Name && x.ID != this.ID) > 0)
            {
                Result.Add(new DataValidationError("Name", string.Format("A region with name {0} already exists in the GroundFrame database", this._Name)));
            }

            if (this._RecordEndYMDV.Value != 0 && this._RecordEndYMDV.Value < this._RecordStartYMDV.Value)
            {
                Result.Add(new DataValidationError("EndYMDV", string.Format("The end YMDV must be <null> or after the StartYMDV", this._Name)));
            }


            return Result;
        }

        #endregion Methods
    }

    /// <summary>
    /// Class to represent a collection of regions
    /// </summary>
    public class RegionCollection : IEnumerable<Region>
    {
        #region Private Variables

        private List<Region> _Regions = new List<Region>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<Region> GetEnumerator() { return this._Regions.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new RegionCollection from the GF Database
        /// </summary>
        public RegionCollection()
        {
            GetAllRegionsFromDB();
        }

        /// <summary>
        /// Intialises a new RegionCollection from the GF Database for the specified YMDV
        /// </summary>
        public RegionCollection(YMDV YMDV)
        {
            GetAllRegionsFromDB(YMDV);
        }

        /// <summary>
        /// Intialises a new RegionCollection for a Rake
        /// </summary>
        public RegionCollection(Rake Rake)
        {
            GetRakeRegionsFromDB(Rake);
        }


        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of all region from the GF Database and populates _Regions
        /// </summary>
        private GFResponse GetAllRegionsFromDB()
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Regions from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _Regions as a new List
            _Regions = new List<Region>();

            //Get the SystemLocations from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("logical.Usp_GET_REGIONS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _Regions.Add(new Region(SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"))));
                        }
                    }
                    conn.Close();

                    //Write Log
                    return Audit.WriteLog(new GFResponse(AuditType.Information, "All regions retrieved from the Database"));
                }
                catch (Exception Ex)
                {
                    //Write Log
                    return Audit.WriteLog(new GFResponse(AuditType.Error, @"Error reading all regions from the database", Ex), 1);
                }
            }
        }

        /// <summary>
        /// Adds a new region to the collection
        /// </summary>
        /// <param name="Region"></param>
        public void Add(Region Region)
        {
            if (_Regions.Count(x => x.ID == Region.ID) > 0)
            {
                throw new Exception(string.Format("Region with ID {0} ({1}) already exists in the collection", Region.ID, Region.Name));
            }
            else
            {
                _Regions.Add(Region);
            }
        }

        /// <summary>
        /// Gets a list of the region from the GF Database for a given YMDV and populates _Regions
        /// </summary>
        private void GetAllRegionsFromDB(YMDV YMDV)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Regions from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _Regions as a new List
            _Regions = new List<Region>();

            //Get the SystemLocations from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("logical.Usp_GET_REGIONS_YMDV", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _Regions.Add(new Region(SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"))));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Regions from the GF Database", Ex);
                }
            }
        }

        /// <summary>
        /// Gets a list of the region from the GF Database for a given YMDV and rake
        /// </summary>
        private void GetRakeRegionsFromDB(Rake Rake)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Regions from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _Regions as a new List
            _Regions = new List<Region>();

            //Get the SystemLocations from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_RAKE_REGIONS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@rake_itemno", Rake.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _Regions.Add(new Region(SQLReader.GetInt32(SQLReader.GetOrdinal("region_itemno"))));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Rake Regions from the GF Database", Ex);
                }
            }
        }

        #endregion Methods
    }
}
