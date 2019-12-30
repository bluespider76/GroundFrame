using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horizon4.GF;
using System.Data.SqlClient;
using System.Data;

namespace Horizon4.GF.RollingStock
{
    /// <summary>
    /// Class to represent a Traction Profile
    /// </summary>
    public class TractionProfile
    {
        #region Private Variables

        private int _ID; //Private variable to store the DB ID
        private Speed _MaxSpeed; //Private variable to store the max speed of the profile
        private Speed _MaxSpeedLightLoco; //Private variable to store the max speed of the profile when travelling light
        private PowerType _Power; //Private variable to store the power type of the profile
        private int _TractiveEffort; //Private variable to store the tractive effort of the profile
        private int _HorsePower; //Private variable to store the horse power of the profile
        private int _TractionClassID; //Private variable to store the parent traction class

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the DB ID of the Trction Profile
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the Max Speed of the Traction Profile
        /// </summary>
        public Speed MaxSpeed { get { return this._MaxSpeed; } set { this._MaxSpeed = value; } }

        /// <summary>
        /// Gets the Max Speed as a Light Loco of the Traction Profile
        /// </summary>
        public Speed MaxSpeedLightLoco { get { return this._MaxSpeedLightLoco; } set { this._MaxSpeedLightLoco = value; } }

        /// <summary>
        /// Gets the Power Type of the Traction Profile
        /// </summary>
        public PowerType Power { get { return this._Power; } set { this._Power = value; } }

        /// <summary>
        /// Gets the Tractive Effort of the Traction Profile
        /// </summary>
        public int TractiveEffort { get { return this._TractiveEffort; } set { this._TractiveEffort = value; } }

        /// <summary>
        /// Gets the Horse Power of the Traction Profile
        /// </summary>
        public int HorsePower { get { return this._HorsePower; } set { this._HorsePower = value; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the Traction Profile Class based on the DB ID
        /// </summary>
        /// <param name="ID"></param>
        public TractionProfile(int ID)
        {
            this._ID = ID;

            //Load record from GF ID
            GetTractionProfileByIDFromDatabase();
        }

        /// <summary>
        /// Instantiates a new instance of a Traction Profile Class for a new record
        /// </summary>
        public TractionProfile(TractionClass TractionClass)
        {
            this._ID = 0;
            this._TractionClassID = TractionClass.ID;
            this._MaxSpeed = new Speed(0);
            this._MaxSpeedLightLoco = new Speed(0);
            this._TractiveEffort = 0;
            this._HorsePower = 0;

        }

        #endregion Constructors

        #region Methods

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
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_SAVE_TTRACTIONPROFILE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@traction_class_itemno", this._TractionClassID);
                        cmd.Parameters.AddWithValue("@max_speed", this.MaxSpeed.MPH);
                        cmd.Parameters.AddWithValue("@max_speed_light_loco", this.MaxSpeedLightLoco.MPH);
                        cmd.Parameters.AddWithValue("@power_itemno", (int)this.Power);
                        cmd.Parameters.AddWithValue("@tractive_effort", this.TractiveEffort);
                        cmd.Parameters.AddWithValue("@horse_power", this.HorsePower);

                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
                        }

                        return Audit.WriteLog(new GFResponse(AuditType.Information, string.Format(@"Traction Class Profile {0} for {1} saved successfully to the database:-", this.Power.ToString(), this._TractionClassID)));
                    }
                }
                catch (Exception Ex)
                {
                    return Audit.WriteLog(new GFResponse(AuditType.Error, string.Format(@"Error saving Traction Class Profile {0} for {1} to the database", this.Power.ToString(), this._TractionClassID), Ex), 1, this);
                }
            }
        }

        /// <summary>
        /// Validates the traction class profile and returns a list of errors.
        /// </summary>
        /// <returns></returns>
        public List<DataValidationError> ValidateProfile()
        {
            //TODO: Sort Traction Profile validation
            return new List<DataValidationError>();
        }

        /// <summary>
        /// Loads the Traction Profile data from the GF Database based on the ID of the Token
        /// </summary>
        private void GetTractionProfileByIDFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_TTRACTIONPROFILE_BY_ID", conn))
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
                    throw new Exception(string.Format("Error trying to retreive all the Traction Class with ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Parses a SqlDataReader into the Traction Profile object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
            this._MaxSpeed = new Speed(SQLReader.GetInt16(SQLReader.GetOrdinal("max_speed")));
            this._MaxSpeedLightLoco = new Speed(SQLReader.GetInt16(SQLReader.GetOrdinal("max_speed_light_loco")));
            this._Power = (PowerType)SQLReader.GetInt32(SQLReader.GetOrdinal("power_itemno"));
            this._TractiveEffort = SQLReader.GetInt32(SQLReader.GetOrdinal("tractive_effort"));
            this._HorsePower = SQLReader.GetInt32(SQLReader.GetOrdinal("horse_power"));
            this._TractionClassID = SQLReader.GetInt32(SQLReader.GetOrdinal("traction_class_itemno"));
        }

        #endregion Methods
    }

    /// <summary>
    /// Class to represent a collection of Traction Profiles
    /// </summary>
    public class TractionProfileCollection : IEnumerable<TractionProfile>
    {
        #region Private Variables

        private List<TractionProfile> _TractionProfiles = new List<TractionProfile>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<TractionProfile> GetEnumerator() { return this._TractionProfiles.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intitialises a new instance of a TractionProfileCollection for the specified Traction Class
        /// </summary>
        /// <param name="TractionClass"></param>
        public TractionProfileCollection(TractionClass TractionClass)
        {
            GetAllTractionProfilesFromDB(TractionClass);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of the Traction Pofiles from the GF Database for the specified Traction Class
        /// </summary>
        private void GetAllTractionProfilesFromDB(TractionClass TractionClass)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Traction Profiles from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _TractionClasses as a new List
            _TractionProfiles = new List<TractionProfile>();

            //Get the Traction Profiles from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_TTRACTIONPROFILES", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@traction_class_itemno", TractionClass.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _TractionProfiles.Add(new TractionProfile(SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"))));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Traction Profiles from the GF Database", Ex);
                }
            }
        }

        #endregion Methods
    }
}