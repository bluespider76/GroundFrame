using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horizon4.GF.Logical;
using Horizon4.GF.Network;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Horizon4.GF.RollingStock
{
    public class Rake
    {
        #region Private Variables

        private int _ID; //Private variable to the store the ID of the rake
        private string _Name; //Private variable to store the name of the rake
        private string _Description; //Private variable to store the description of the rake
        private RakeElementCollection _RakeElements; //Private variable to store the elements of the rake
        private SectorCollection _Sectors; //Private variable to store the sectors that the rake can be sourced from
        private DepotCollection _Depots; //Private variable to store the list of depots the rake can be sourced from
        private RegionCollection _Regions; //Private variable to store the list of regions the rake can be sourced from

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the GF Database ID of the Rake
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the name of the Rake
        /// </summary>
        public string Name { get { return this._Name; } }

        /// <summary>
        /// Gets the description of the Rake
        /// </summary>
        public string Description { get { return this._Description; } }

        /// <summary>
        /// Gets the elements of the Rake
        /// </summary>
        public RakeElementCollection RakeElements { get { return this._RakeElements; } }

        /// <summary>
        /// Gets the depots of the Rake
        /// </summary>
        public DepotCollection Depot { get { return this._Depots; } }

        /// <summary>
        /// Gets the sectors of the Rake
        /// </summary>
        public SectorCollection Sectors { get { return this._Sectors; } }

        /// <summary>
        /// Gets the regions of the Rake
        /// </summary>
        public RegionCollection Regions {get { return this._Regions;}}

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialises a new instance of a Rake object based on the GF Database ID
        /// </summary>
        /// <param name="ID"></param>
        public Rake(int ID)
        {
            this._ID = ID;
            GetRakeFromDatabaseByID();
        }

        #endregion Constructors

        #region Methods
        /// <summary>
        /// Loads the Rake data from the GF Database based on the ID of the Rake
        /// </summary>
        private void GetRakeFromDatabaseByID()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_RAKE_BY_ID", conn))
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
                    throw new Exception(string.Format("Error trying to retreive all the Rake with ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Parses a SqlDataReader into the Rake object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            this._Name = SQLReader.GetString(SQLReader.GetOrdinal("name"));
            this._Description = SQLReader.GetSafeString(SQLReader.GetOrdinal("description"));
            this._RakeElements = new RakeElementCollection(this);
            this._Depots = new DepotCollection(this, Common.CurrentYMDV);
            this._Sectors = new SectorCollection(this);
            this._Regions = new RegionCollection(this);
        }

        #endregion Methods
    }

    /// <summary>
    /// Class to represent a collection of Rakes
    /// </summary>
    public class RakeCollection : IEnumerable<Rake>
    {
        #region Private Variables

        private List<Rake> _Rakes = new List<Rake>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<Rake> GetEnumerator() { return this._Rakes.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new RakeCollection based on the YMDV
        /// </summary>
        public RakeCollection(YMDV YMDV)
        {
            GetAllRakesFromDB(YMDV);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of the Rakes from the GF database based on the YMDV
        /// </summary>
        private void GetAllRakesFromDB(YMDV YMDV)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Rake Items from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _Rakes as a new List
            _Rakes = new List<Rake>();

            //Get the Rake Elements from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_RAKES", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _Rakes.Add(new Rake(SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"))));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the Rakes from the GF Database for YMDV", YMDV.Value), Ex);
                }
            }
        }

        #endregion Methods
    }
}
