using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horizon4.GF
{
    /// <summary>
    /// Structure to handle speeds with the application
    /// </summary>
    public struct Speed
    {
        #region Constants

        const double MPHToKPH = 1.60934;

        #endregion Constants

        #region Private Variables

        private int _MPH; //Private variable to store the speed in MPH;

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the speed in the MPH
        /// </summary>
        public int MPH { get { return this._MPH; } }

        /// <summary>
        /// Gets the speed in the MPH
        /// </summary>
        public double KPH { get { return Math.Round(this._MPH * MPHToKPH,2); } }

        #endregion Properties

        #region Constuctors

        /// <summary>
        /// Initialises a new instance of a Speed structure based in Miles Per Hour
        /// </summary>
        /// <param name="MPH"></param>
        public Speed (int MPH)
        {
            this._MPH = MPH;
        }

        #endregion Constructors

    }
}
