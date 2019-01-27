using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horizon4.GF
{
    /// <summary>
    /// Struct to hold distances between 2 points
    /// </summary>
    public struct Distance
    {
        #region Constants

        //Constants to aid consistent conversion
        const decimal _InchesPerChain = 768;
        const decimal _InchesPerMeter = (decimal)37.37;
        const decimal _ChainsPerMile = (decimal)80.00;
        const decimal _InchesPerFoot = 12;
        const decimal _InchesPerYard = 36;

        #endregion Constants

        #region Private Variables

        private decimal _Inches; //Prviate variable to store the distance in Inches

        #endregion Private Variables

        #region Public Properties

        /// <summary>
        /// Get the distance in Inches
        /// </summary>
        public decimal Inches { get { return this._Inches; } }

        /// <summary>
        /// Get the distance in Meters
        /// </summary>
        public decimal Meters { get { return this._Inches / _InchesPerMeter; } }

        /// <summary>
        /// Get the distance in Feet
        /// </summary>
        public decimal Feet { get { return this._Inches / _InchesPerFoot; } }

        /// <summary>
        /// Get the distance in Yards
        /// </summary>
        public decimal Yards { get { return this._Inches / _InchesPerYard; } }

        /// <summary>
        /// Get the distance in Chains
        /// </summary>
        public decimal Chains { get { return this._Inches / _InchesPerChain; } }

        /// <summary>
        /// Get the distance formatted in Miles and Chains
        /// </summary>
        public string MilesAndChains { get { return GetMilesAndChains(); } }


        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Initialises the distance based on Chains
        /// </summary>
        /// <param name="Chains"></param>
        public Distance(int Chains)
        {
            _Inches = Chains * _InchesPerChain;
        }

        /// <summary>
        /// Initialises the distance based on Miles and Chains
        /// </summary>
        /// <param name="Chains"></param>
        public Distance(int Miles, int Chains)
        {
            _Inches = (Miles * _ChainsPerMile * _InchesPerChain) + (Chains * _InchesPerChain);
        }

        /// <summary>
        /// Initialises the distance based on Meters
        /// </summary>
        /// <param name="Chains"></param>
        public Distance(decimal Meters)
        {
            _Inches = Meters * _InchesPerMeter;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Formats the distance as a string representing Miles and Chains
        /// </summary>
        /// <param name="Chains"></param>
        private string GetMilesAndChains()
        {
            //Get The Number of Chains
            decimal _TotalChains = _Inches / _InchesPerChain;

            //Get The Number of Miles
            decimal _Miles = Math.Floor(_TotalChains / _ChainsPerMile);

            //Get the Remain Chains
            decimal _Chains = _TotalChains - (_Miles * _ChainsPerMile);

            //Return the string in the desired format
            return string.Format(@"{0}m {1}ch", _Miles, _Chains.ToString("F2"));
        }

        /// <summary>
        /// Subtracts one distance from the current distance
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public Distance Subtract(Distance X)
        {
            decimal Meters = this.Meters - X.Meters;
            return new Distance(Meters);
        }

        #endregion Methods
    }
}
