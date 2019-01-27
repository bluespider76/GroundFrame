using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horizon4.GF.RollingStock
{
    public struct Weight
    {
        #region Constants

        #endregion Constants

        #region Private Variables

        private int _Tons; //Private variable to store the weight in Tons

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the weight in Tons
        /// </summary>
        public int Tons { get { return this._Tons; } }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Intialisies a new Weight strucuture based on Tons
        /// </summary>
        /// <param name="Tons"></param>
        public Weight(int Tons)
        {
            this._Tons = Tons;
        }

        #endregion Contstructs
    }
}
