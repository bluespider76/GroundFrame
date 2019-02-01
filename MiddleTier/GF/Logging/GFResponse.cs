using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horizon4.GF
{
    public class GFResponse
    {
        #region Private Variables

        private int _AuditID; //Private variable to store the Log ID
        private AuditType _Type; //Private variable to store the LogType
        private Exception _Exception; //Private variable to the Exception
        private string _Message; //Private variable to store the message

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the LogID
        /// </summary>
        public int AuditID { get { return this._AuditID; } set { this._AuditID = value; } }

        /// <summary>
        /// Gets the Audit Type
        /// </summary>
        public AuditType Type { get { return this._Type; } }

        /// <summary>
        /// Gets the Exception
        /// </summary>
        public Exception Exception { get { return this._Exception; } set { this._Exception = value; } }

        /// <summary>
        /// Gets the Exception
        /// </summary>
        public string Message { get { return this._Message; } set { this._Message = value; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialises a new instance of a DBReponse
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Message"></param>
        public GFResponse(AuditType Type, string Message)
        {
            this._AuditID = 0;
            this._Type = Type;
            this._Message = Message;
        }

        /// <summary>
        /// Intialises a new instance of a DBReponse
        /// </summary>
        /// <param name="LogID"></param>
        /// <param name="Type"></param>
        /// <param name="Message"></param>
        public GFResponse(int AuditID, AuditType Type, string Message)
        {
            this._AuditID = AuditID;
            this._Type = Type;
            this._Message = Message;
        }

        /// <summary>
        /// Intialises a new instance of a DBReponse
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Message"></param>
        /// <param name="Excepton"></param>
        public GFResponse(AuditType Type, string Message, Exception Exception)
        {
            this._AuditID = 0;
            this._Type = Type;
            this._Message = Message;
            this._Exception = Exception;
        }

        #endregion Constructors
    }
}
