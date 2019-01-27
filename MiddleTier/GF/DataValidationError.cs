using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horizon4.GF
{
    /// <summary>
    /// Data structure to store a data error within an object property.
    /// </summary>
    public struct DataValidationError
    {
        #region Private Variables
 
        private string _Property; //Private variable to store the property being validated
        private string _Error; //Private variable to store the error message

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the property containing the errro;
        /// </summary>
        public string Property { get { return this._Property; } }

        /// <summary>
        /// Gets the property errror
        /// </summary>
        public string Error { get { return this._Error; } }

        #endregion Properties

        #region Constructors

        public DataValidationError(string Property, string Error)
        {
            this._Property = Property;
            this._Error = Error;
        }

        #endregion Constructors
    }
}
