using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Horizon4.GF.RollingStock
{
    /// <summary>
    /// Class which represents an instance of a Traction Class
    /// </summary>
    public class TractionClass
    {
        #region Private Variables

        private int _ID; //Private variable to store the DB ID of the class
        private string _Name; //Private variable to store the Name of the class
        private string _Description; //Private variable to store the Description of the class
        private TractionClass _ParentClass; //Private variable to store the parent Traction Class
        private TractionType _TractionType; //Private variable to store the traction type;
        private TractionProfileCollection _TractionProfile; //Private variable to store the traction profiles for the Traction Class
        private Distance _Length; //Private variable to store the length of the traction class
        private int _RA; //Private variable to store the route availablity of the traction class
        private YMDV _InServiceStartYMDV; //Private variable to store when the class entered service
        private YMDV _InServiceEndYMDV; //Private variable to store when the class was fully withdrawn

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the DB ID of the Traction Class
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets or sets the Name of the Traction Class
        /// </summary>
        public string Name { get { return this._Name; } set { this._Name = value; } }

        /// <summary>
        /// Gets or sets the Description of the Traction Class
        /// </summary>
        public string Description { get { return this._Description; } set { this._Description = value; } }


        /// <summary>
        /// Gets or sets the Parent Class
        /// </summary>
        public TractionClass ParentClass { get { return this._ParentClass; } set { this._ParentClass = value; } }

        /// <summary>
        /// Gets or sets the Traction Type
        /// </summary>
        public TractionType TractionType { get { return this._TractionType; } set { this._TractionType = value; } }

        /// <summary>
        /// Gets or sets the Traction Profiles
        /// </summary>
        public TractionProfileCollection TractionProfile { get { return this._TractionProfile; } set { this._TractionProfile = value; } }

        /// <summary>
        /// Gets or sets the length of the traction class
        /// </summary>
        public Distance Length { get { return this._Length; } set { this._Length = value; } }

        /// <summary>
        /// Gets or sets the route availability of the traction class
        /// </summary>
        public int RA { get { return this._RA; } set { this._RA = value; } }

        /// <summary>
        /// Gets or sets the In Service Start YMDV
        /// </summary>
        public YMDV InServiceStartYMDV { get { return this._InServiceStartYMDV; } set { this._InServiceStartYMDV = value; } }

        /// <summary>
        /// Gets or sets the In Service End YMDV
        /// </summary>
        public YMDV InServiceEndYMDV { get { return this._InServiceEndYMDV; } set { this._InServiceEndYMDV = value; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialises a new instance of a Traction Class based on the DB ID
        /// </summary>
        /// <param name="ID">Database ID</param>
        public TractionClass(int ID)
        {
            this._ID = ID;
            
            //Load data from GF DB
            GetTractionClassByIDFromDatabase();
        }

        /// <summary>
        /// Initialises a new instance of a traction class object
        /// </summary>
        public TractionClass(TractionType TractionType)
        {
            CreateNewTractionClass(TractionType);
        }

        /// <summary>
        /// Initialises a new instance of a child Traction Class
        /// </summary>
        /// <param name="ParentClass">The parent class</param>
        public TractionClass(TractionClass ParentClass)
        {
            //Create child traction class
            CreateNewTractionClass(ParentClass);
        }

        /// <summary>
        /// Initialises a new istnace of a Traction Class from the supplied SqlDataReaderObject
        /// </summary>
        /// <param name="ID">Database ID</param>
        public TractionClass(SqlDataReader SQLReader)
        {
            ParseSQLReader(SQLReader);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads the Token data from the GF Database based on the ID of the Token
        /// </summary>
        private void GetTractionClassByIDFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_TTRACTIONCLASS_BY_ID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //If no record are found then throw an error. This should never happen
                        if (SQLReader.HasRows == false) { throw new Exception(string.Format(@"Traction Class with ID {0} doesn't exist in the GF Database", this.ID)); };

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            ParseSQLReader(SQLReader);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the Traction Class with ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Parses a SqlDataReader into the Traction Class object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
            this._Name = SQLReader.GetString(SQLReader.GetOrdinal("name"));
            this._Description = SQLReader.GetSafeString(SQLReader.GetOrdinal("description"));

            int _ParentID = SQLReader.GetSafeInt32(SQLReader.GetOrdinal("parent_itemno"));
            if (_ParentID != 0) { this._ParentClass = new TractionClass(_ParentID); };

            this._TractionType = (TractionType)SQLReader.GetByte(SQLReader.GetOrdinal("traction_type_itemno"));
            this._TractionProfile = new TractionProfileCollection(this);
            this._Length = new Distance(Convert.ToDecimal(SQLReader.GetDecimal(SQLReader.GetOrdinal("length"))));
            this._RA = SQLReader.GetByte(SQLReader.GetOrdinal("route_availability"));

            int YMDV = SQLReader.GetInt32(SQLReader.GetOrdinal("start_ymdv"));
            this._InServiceStartYMDV = new YMDV(YMDV);

            YMDV = SQLReader.GetSafeInt32(SQLReader.GetOrdinal("end_ymdv"));
            this._InServiceEndYMDV = new YMDV(YMDV);
        }

        /// <summary>
        /// Saves the TractionClass object to the GroundFrame DB
        /// </summary>
        public GFResponse SaveToDB()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_SAVE_TTRACTIONCLASS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this._ID);
                        cmd.Parameters.AddWithValue("@start_ymdv", this._InServiceStartYMDV.Value);
                        cmd.Parameters.AddWithValue("@end_ymdv", this._InServiceEndYMDV.Value == (int)0 ? (object)DBNull.Value : this._InServiceEndYMDV.Value);
                        cmd.Parameters.AddWithValue("@name", this._Name);
                        cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(this._Description) ? (object)DBNull.Value : this._Description);
                        cmd.Parameters.AddWithValue("@parent_itemno", this._ParentClass == null ? (object)DBNull.Value : this._ParentClass.ID);
                        cmd.Parameters.AddWithValue("@traction_type_itemno", (int)this._TractionType);
                        cmd.Parameters.AddWithValue("@length", this._Length.Meters);
                        cmd.Parameters.AddWithValue("@route_availability", (Int16)this._RA);

                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
                        }

                        return Audit.WriteLog(new GFResponse(AuditType.Information, string.Format(@"Traction Class {0} saved successfully to the database:-", this.Name)));
                    }
                }
                catch (Exception Ex)
                {
                    return Audit.WriteLog(new GFResponse(AuditType.Error, string.Format(@"Error saving Traction Class {0} to the database", this.Name), Ex), 1, this);
                }
            }
        }

        /// <summary>
        /// Creates the default Traction Class record based on the passed traction type
        /// </summary>
        private void CreateNewTractionClass(TractionType TractionType)
        {
            this._ID = 0;
            this._Name = string.Empty;
            this._Description = string.Empty;
            this._InServiceStartYMDV = new YMDV(DateTime.Today);
            this._InServiceEndYMDV = new YMDV(0);
            this._ParentClass = null;
            this._Length = new Distance(0);
            this._RA = 5;
            this._TractionProfile = null;
            this._TractionType = TractionType;
        }

        /// <summary>
        /// Creates the default Traction Class record
        /// </summary>
        private void CreateNewTractionClass(TractionClass ParentClass)
        {
            this._ID = 0;
            this._Name = string.Empty;
            this._Description = string.Empty;
            this._InServiceStartYMDV = ParentClass.InServiceStartYMDV;
            this._InServiceEndYMDV = ParentClass.InServiceEndYMDV;
            this._ParentClass = ParentClass;
            this._Length = new Distance(0);
            this._RA = 5;
            this._TractionProfile = ParentClass.TractionProfile;
            this._TractionType = ParentClass.TractionType;
        }

        #endregion Methods
    }


    /// <summary>
    /// Class to represent a collection of depots
    /// </summary>
    public class TractionClassCollection : IEnumerable<TractionClass>
    {
        #region Private Variables

        private List<TractionClass> _TractionClasses = new List<TractionClass>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<TractionClass> GetEnumerator() { return this._TractionClasses.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new TractionClassCollection from the GF Database
        /// </summary>
        public TractionClassCollection(YMDV YMDV)
        {
            GetAllTractionClassesFromDBByYMDV(YMDV);
        }

        /// <summary>
        /// Intialises a new TractionClassCollection from the GF Database fro the supplied Traction Type
        /// </summary>
        /// <param name="Type"></param>
        public TractionClassCollection(TractionType Type)
        {
            GetAllTractionClassesFromDBByTractionType(Type);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of the Traction Classes from the GF Database for the supplied traction type
        /// </summary>
        private void GetAllTractionClassesFromDBByTractionType(TractionType Type)
        {
            //Initialise _TractionClasses as a new List
            _TractionClasses = new List<TractionClass>();

            //Get the Traction Classes from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_TTRACTIONCLASSES_BY_TYPE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@traction_type_itemno", (int)Type);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _TractionClasses.Add(new TractionClass(SQLReader));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the Traction Classes from the GF Database for Traction Type {0}", Type.ToString()), Ex);
                }
            }
        }

        /// <summary>
        /// Gets a list of the Traction Classes from the GF Database for a given YMDV and populates _Depots
        /// </summary>
        private void GetAllTractionClassesFromDBByYMDV(YMDV YMDV)
        {
            //Initialise _TractionClasses as a new List
            _TractionClasses = new List<TractionClass>();

            //Get the Traction Classes from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_TTRACTIONCLASSES_BY_YMDV", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _TractionClasses.Add(new TractionClass(SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"))));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Traction Classes from the GF Database", Ex);
                }
            }
        }

        #endregion Methods
    }
}
