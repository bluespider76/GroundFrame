using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horizon4.GF
{
    public struct DBResponse
    {
        #region Private Variables

        private int _LogID; //Private variable to store the Log ID
        private AuditType _Type; //Private variable to store the LogType
        private Exception _Exception; //Private variable to the Exception

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the LogID
        /// </summary>
        public int LogID { get { return this._LogID; } }

        /// <summary>
        /// Gets the Audit Type
        /// </summary>
        public AuditType Type { get { return this._Type; } }

        /// <summary>
        /// Gets the Exception
        /// </summary>
        public Exception Exception { get { return this._Exception; } set { this._Exception = value; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new instance of a DBReponse
        /// </summary>
        /// <param name="LogID"></param>
        /// <param name="Type"></param>
        public DBResponse(int LogID, AuditType Type)
        {
            this._LogID = LogID;
            this._Type = Type;
            this._Exception = null;
        }

        /// <summary>
        /// Intialises a new instance of a DBReponse
        /// </summary>
        /// <param name="LogID"></param>
        /// <param name="Type"></param>
        /// <param name="Exception"></param>
        public DBResponse(int LogID, AuditType Type, Exception Exception)
        {
            this._LogID = LogID;
            this._Type = Type;
            this._Exception = Exception;
        }

        #endregion Constructors
    }
}
