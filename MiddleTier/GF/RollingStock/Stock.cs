using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Horizon4.GF.RollingStock
{
    public class Stock
    {
        #region Private Variables

        private int _ID; //Private variable to store the GF Database ID of the stock
        private StockType _Type; //Private variable to store the Type of the stock
        private string _Name; //Private variable to store the name of the stock
        private string _Description; //Private variable to store the description of the stock
        private int _CouplingTypes; //Private variable to store the coupling types available on the stock. See StockCouplingType enum for bitwise values
        private int _BrakeTypes; //Private variable to store the brake types available on the stock. See StockBrakeType enum for bitwise values
        private int _HeatTypes; //Private variable to store the heat types avialable on the stock. See StockHeatType enum for bitwise values
        private Speed _MaxSpeed; //Private variable to store the max speed of the stock.
        private Distance _Length; //Private variable to store the length of the stock.
        private int _Options; //Private variable to store the options of the stock.
        private int _ETHIndex; //Private variable to store the ETH index of the stock.
        private Weight _Weight; //Private variable to store the Tare weight of the stock.

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the stock GF Database ID
        /// </summary>
        public int ID { get { return this._ID; } }

        /// <summary>
        /// Gets the stock type
        /// </summary>
        public StockType Type { get { return this._Type; } }

        /// <summary>
        /// Gets the stock name
        /// </summary>
        public string Name { get { return this.Name; } }

        /// <summary>
        /// Get the stock description
        /// </summary>
        public string Description { get { return this._Description; } }

        /// <summary>
        /// Gets the stock coupling types. See StockCouplingType enum for bitwise values
        /// </summary>
        public int CouplingTypes { get { return this._CouplingTypes; } }

        /// <summary>
        /// Gets the stock brake types. See StockBrakeType enum for bitwise values
        /// </summary>
        public int BrakeTypes { get { return this._BrakeTypes; } }

        /// <summary>
        /// Gets the stock heat types. See StockBrakeType enum for bitwise values
        /// </summary>
        public int HeatTypes { get { return this._HeatTypes; } }

        /// <summary>
        /// Gets the stock max speed
        /// </summary>
        public Speed MaxSpeed { get { return this._MaxSpeed; } }

        /// <summary>
        /// Gets the stock length
        /// </summary>
        public Distance Length { get { return this._Length; } }

        /// <summary>
        /// Gets the stock options. See StockOption enum for bitwise values
        /// </summary>
        public int Options { get { return this._Options; } }

        /// <summary>
        /// Gets the stock ETH Index
        /// </summary>
        public int ETHIndex { get { return this._ETHIndex; } }

        /// <summary>
        /// Gets the Tare Weight of the stock
        /// </summary>
        public Weight Weight { get { return this.Weight; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialises a new instance of a Stock object based on the GroundFrame DB ID
        /// </summary>
        /// <param name="ID"></param>
        public Stock(int ID)
        {
            this._ID = ID;

            //Get Stock From Database
            GetStockByIDFromDatabase();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads the stock data from the GF Database based on the ID
        /// </summary>
        private void GetStockByIDFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_STOCK_BY_ID", conn))
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
            this._Type = (StockType)SQLReader.GetInt16(SQLReader.GetOrdinal("type_itemno"));
            this._Name = SQLReader.GetString(SQLReader.GetOrdinal("name"));
            this._Description = SQLReader.GetSafeString(SQLReader.GetOrdinal("description"));
            this._CouplingTypes = SQLReader.GetInt16(SQLReader.GetOrdinal("coupling_types"));
            this._BrakeTypes = SQLReader.GetInt16(SQLReader.GetOrdinal("brake_types"));
            this._HeatTypes = SQLReader.GetInt16(SQLReader.GetOrdinal("heating_types"));
            this._MaxSpeed = new Speed(SQLReader.GetInt16(SQLReader.GetOrdinal("max_speed")));
            this._Length = new Distance((decimal)SQLReader.GetDecimal(SQLReader.GetOrdinal("length")));
            this._Options = SQLReader.GetInt32(SQLReader.GetOrdinal("options"));
            this._ETHIndex = SQLReader.GetInt16(SQLReader.GetOrdinal("eth_index"));
            this._Weight = new Weight(SQLReader.GetInt16(SQLReader.GetOrdinal("weight")));
        }

        #endregion EndMethods
    }

    /// <summary>
    /// Class to represent a collection of Stock
    /// </summary>
    public class StockCollection : IEnumerable<Stock>
    {
        #region Private Variables

        private List<Stock> _StockList = new List<Stock>();

        #endregion Private Variables

        #region Properties

        public IEnumerator<Stock> GetEnumerator() { return this._StockList.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new StockCollection based on the YMDV
        /// </summary>
        public StockCollection(YMDV YMDV)
        {
            GetAllStockItemsFromDB(YMDV);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of the Stock Items from the GF database based on the YMDV
        /// </summary>
        private void GetAllStockItemsFromDB(YMDV YMDV)
        {
            //Check to see if the DB Connection string is set
            if (string.IsNullOrEmpty(Common.SQLDBConn))
            {
                throw new Exception("Error trying to retreive all the Stock Items from the GF Database. Common.SQLDBConn is <null>");
            }

            //Initialise _RakeElements as a new List
            _StockList = new List<Stock>();

            //Get the Rake Elements from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("rollingstock.Usp_GET_STOCKS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ymdv", YMDV.Value);
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Loop through each record and add it to the collection
                        while (SQLReader.Read())
                        {
                            _StockList.Add(new Stock(SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"))));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(string.Format("Error trying to retreive all the Stock Items from the GF Database for YMDV", YMDV.Value), Ex);
                }
            }
        }

        #endregion Methods
    }
}
