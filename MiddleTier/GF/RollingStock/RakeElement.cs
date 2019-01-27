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
    /// Structure to hold an element of a rake. An element being the number of stock items from which depot. A complete rake is made from a list of elements
    /// </summary>
    public class RakeElement
    {
        #region Private Variables

        private int _ID; //Private variable to store the DB ID of the Rake Element
        private Stock _Stock;
        private int _Number;

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the Groundframe DB ID of the Rake Element
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the Stock of the Rake Element
        /// </summary>
        public Stock Stock { get { return this._Stock; } }

        /// <summary>
        /// Gets the Number of stock items in the Element
        /// </summary>
        public int Number { get { return this._Number; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialises a new Rake Element
        /// </summary>
        /// <param name="Stock"></param>
        /// <param name="Number"></param>
        public RakeElement(Stock Stock, int Number)
        {
            this._ID = 0;
            this._Stock = Stock;
            this._Number = Number;
        }

        /// <summary>
        /// Initialises a new Rake Element based on the GF Database ID
        /// </summary>
        /// <param name="ID"></param>
        public RakeElement(int ID)
        {
            this._ID = ID;
            GetRateElementByIDFromDatabase();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads the Rake Element data from the GF Database based on the ID of the Rake Element
        /// </summary>
        private void GetRateElementByIDFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_RAKE_ELEMENT_BY_ID", conn))
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
                    throw new Exception(string.Format("Error trying to retreive all the Rake Element with ID {0} from the GF Database", this.ID), Ex);
                }
            }
        }

        /// <summary>
        /// Parses a SqlDataReader into the Rake Element object
        /// </summary>
        /// <param name="SQLReader"></param>
        private void ParseSQLReader(SqlDataReader SQLReader)
        {
            this._Stock = Common.StockList.Where(x => x.ID == SQLReader.GetInt32(SQLReader.GetOrdinal("rake_itemno"))).FirstOrDefault();
            this._Number = SQLReader.GetByte(SQLReader.GetOrdinal("number"));
        }

        #endregion Methods
    }

    /// <summary>
    /// Class to represent a collection of Rake Elements
    /// </summary>
    public class RakeElementCollection : IEnumerable<RakeElement>
    {
        #region Private Variables

        private List<RakeElement> _RakeElements = new List<RakeElement>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<RakeElement> GetEnumerator() { return this._RakeElements.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new RakeElementCollection from the GF Database for the specifc Rake
        /// </summary>
        public RakeElementCollection(Rake Rake)
        {
            GetAllRakeElementsFromDB(Rake);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of the Rake Elements from the GF Database for a given Rake
        /// </summary>
        private void GetAllRakeElementsFromDB(Rake Rake)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Rake Elements from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _RakeElements as a new List
            _RakeElements = new List<RakeElement>();

            //Get the Rake Elements from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_RAKE_ELEMENTS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@rake_itemno", Rake.ID);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _RakeElements.Add(new RakeElement(SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"))));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the Rake Elements from the GF Database for Rake ID", Rake.ID), Ex);
                }
            }
        }

        #endregion Methods
    }
}
