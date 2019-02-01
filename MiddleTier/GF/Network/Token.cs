using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Horizon4.GF.Network
{
    /// <summary>
    /// Class representing a block section token
    /// </summary>
    public class Token
    {
        #region Private Variables

        private int _ID; //Private variable to store the ID of the token
        private string _Name; //Private variable to store the name of the token
        private string _Description; //Private variable to store the description of the tokenb
        private bool _SystemToken; //Private varaible to store whether the token is an internal system token
        private bool _CannotSave; //Prviate variable to indicate the record cannot be saved to the GF database

        #endregion Private Variables

        #region Public Properties

        /// <summary>
        /// Gets the ID of the token
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the name of the token
        /// </summary>
        public string Name { get { return this._Name; } set { this._Name = value; } }

        /// <summary>
        /// Gets the description of the token
        /// </summary>
        public string Description { get { return this._Description; } set { this._Description = value; } }

        /// <summary>
        /// Gets the flag to indicate whether the token is a system token
        /// </summary>
        public bool SystemToken { get { return this._SystemToken; } set { this._SystemToken = value; } }

        #endregion Public Properties

        #region Constuctors

        /// <summary>
        /// Initialises a new instance of a token based on the name
        /// </summary>
        /// <param name="Name"></param>
        public Token(string Name)
        {
            this._ID = 0;
            this._Name = Name;
            this._SystemToken = false;

            //Flag the record as savable
            _CannotSave = false;
        }

        /// <summary>
        /// Initialises a new instance of a token based on the DB ID
        /// </summary>
        /// <param name="Name"></param>
        public Token(int ID)
        {
            this._ID = ID;

            //If an existing record load from the DB.
            if (ID != 0)
            {
                

                //Load Data from DB
                GetTokenByIDFromDatabase();
            }

            //Flag the record as savable
            _CannotSave = false;
        }

        public Token()
        {
            this._ID = 0;
            this._Name = "Not Applicable";
            this._SystemToken = true;

            //Flag the record as not savable
            _CannotSave = true;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Saves the Token to the GroundFrame Database
        /// </summary>
        public GFResponse SaveToDB()
        {
            //Can the record be saved? Stops "Not Applicable" being added to the database.
            if (_CannotSave == false)
            {
                
                using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("network.Usp_SAVE_TOKEN", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@itemno", this._ID);
                            cmd.Parameters.AddWithValue("@name", this._Name);
                            cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(this._Description) ? (object)DBNull.Value : this._Description);
                            cmd.Parameters.AddWithValue("@system_token", this._SystemToken);
                            SqlDataReader SQLReader = cmd.ExecuteReader();

                            //Parse the record returned by the reader
                            while (SQLReader.Read())
                            {
                                this._ID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
                            }

                            return Audit.WriteLog(new GFResponse(AuditType.Information, string.Format(@"Token {0} saved successfully to the GroundFrame database:-", this.ID)));
                        }
                    }
                    catch (Exception Ex)
                    {
                        return Audit.WriteLog(new GFResponse(AuditType.Error, string.Format(@"Error saving Token {0} to the GroundFrame database", this.Name), Ex), 1, this);
                    }
                }
            }
            else
            {
                return new GFResponse(AuditType.Information, string.Format("Token {0} cannot be saved.", this.Name));
            }
        }

        /// <summary>
        /// Loads the Token data from the GF Database based on the ID of the Token
        /// </summary>
        private void GetTokenByIDFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_TOKEN_BY_ID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemno", this.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //If no record are found then throw an error. This should never happen
                        if (SQLReader.HasRows == false) { throw new Exception(string.Format(@"Token with ID {0} doesn't exist in the GF Database", this.ID)); };

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            ParseSQLReader(SQLReader);
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
        /// Parses a SqlDataReader into the Token object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            int _Ordinal;
                
            _Ordinal = SQLReader.GetOrdinal("itemno");
            this._ID = SQLReader.GetInt32(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("token_name");
            this._Name = SQLReader.GetString(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("token_description");
            this._Description = SQLReader.GetString(_Ordinal);

            _Ordinal = SQLReader.GetOrdinal("system_token");
            this._SystemToken = SQLReader.GetBoolean(_Ordinal);
        }

        #endregion Methods
    }

    public class TokenCollection : IEnumerable<Token>
    {
        private List<Token> _Tokens = new List<Token>();

        public IEnumerator<Token> GetEnumerator() { return this._Tokens.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        /// <summary>
        /// Initlises a new collection of tokens
        /// </summary>
        /// <param name="Date"></param>
        public TokenCollection()
        {
            GetAllTokensFromDB();
        }

        /// <summary>
        /// Gets a list of all tokens from the GF Database
        /// </summary>
        private void GetAllTokensFromDB()
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

            //Initialise _Tokens  as a new List
            _Tokens = new List<Token>();

            //Get the Tokens from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("network.Usp_GET_TOKENS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _Tokens.Add(new Token(SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"))));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Tokens from the GF Database", Ex);
                }
            }
        }
    }
}

