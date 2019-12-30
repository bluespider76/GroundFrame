using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Horizon4.GF
{
    /// <summary>
    /// Enum representing power types
    /// </summary>
    public enum PowerType
    {
        Steam = 1,
        Diesel = 2,
        Electric3rdRail750 = 4,
        Electric3rdRail1500 = 8,
        Electric4thRail600 = 16,
        ElectricOverhead1500 = 32,
        ElectricOverhead6250 = 64,
        ElectricOverhead25000 = 128,
        Battery = 256
    }

    public class Power
    {
        #region Private Variables

        private PowerType _Type;
        private string _Name;
        private string _Description;

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the Power Enum of the Power Type
        /// </summary>
        public PowerType Type { get { return this._Type; } }

        /// <summary>
        /// Gets the name of the Power Type
        /// </summary>
        public string Name { get { return this._Name; } }

        /// <summary>
        /// Gets the description of the Power Type
        /// </summary>
        public string Description { get { return this._Description; } }

        #endregion Properties

        #region Constructors

        internal Power(SqlDataReader SQLReader)
        {
            this.ParseSQLReader(SQLReader);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Parses a SqlDataReader object into a Power Object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            this._Type = (PowerType)SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
            this._Name = SQLReader.GetString(SQLReader.GetOrdinal("name"));
            this._Description = SQLReader.GetSafeString(SQLReader.GetOrdinal("description"));
        }

        #endregion Methods
    }

    /// <summary>
    /// Class to represent a collection of power types
    /// </summary>
    public class PowerCollection : IEnumerable<Power>
    {
        #region Private Variables

        private List<Power> _PowerTypes = new List<Power>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<Power> GetEnumerator() { return this._PowerTypes.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new PowerColletion from the GF Database containing only Power Types within the Bitwise
        /// </summary>
        public PowerCollection(int BitWise)
        {
            GetAllPowerTypesForBitWise(BitWise);
        }

        /// <summary>
        /// Intialises a new PowerColletion from the GF Database
        /// </summary>
        /// <param name="Type"></param>
        public PowerCollection()
        {
            GetAllPowerTypes();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of the Power Types from the GF Database for the supplied bit wise
        /// </summary>
        private void GetAllPowerTypesForBitWise(int BitWise)
        {
            //Initialise _PowerTypes as a new List
            this._PowerTypes = new List<Power>();

            //Get the Traction Classes from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("common.Usp_GET_POWERTYPES", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            int ItemNo = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
                            int _Power = BitWise & ItemNo;

                            if (_Power >= ItemNo)
                            {
                                _PowerTypes.Add(new Power(SQLReader));
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the Power Types from the GF Database for Bitwise value {0}", BitWise), Ex);
                }
            }
        }

        /// <summary>
        /// Gets a list of the Power Types from the GF Database
        /// </summary>
        private void GetAllPowerTypes()
        {
            //Initialise _PowerTypes as a new List
            this._PowerTypes = new List<Power>();

            //Get the Traction Classes from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("common.Usp_GET_POWERTYPES", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _PowerTypes.Add(new Power(SQLReader));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception("Error trying to retreive all the Power Types from the GF Database", Ex);
                }
            }
        }

        #endregion Methods
    }
}
