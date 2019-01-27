using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Horizon4.GF;

namespace Horizon4.GFDataEditor
{
    public partial class frmDistanceCalculator : Form
    {
        #region Private Variables

        private Distance _Result;
        private Distance _Start;
        private Distance _End;

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets the result of the distance calcuation
        /// </summary>
        public Distance Result { get { return this._Result; } }

        #endregion Properties

        #region Methods

        public frmDistanceCalculator()
        {
            InitializeComponent();
            CalculateResult();
        }

        public void DisplayResults()
        {
            txtResultMeters.Text = _Result.Meters.ToString("N2");
        }

        private void CalculateResult()
        {
            _Start = new Distance((int)numericUpDownStartMiles.Value, (int)numericUpDownStartChains.Value);
            _End = new Distance((int)numericUpDownEndMiles.Value, (int)numericUpDownEndChains.Value);
            _Result = _Start.Subtract(_End);
            DisplayResults();
        }

        #endregion Methods

        private void numericUpDownStartMiles_ValueChanged(object sender, EventArgs e)
        {
            CalculateResult();
        }

        private void numericUpDownStartChains_ValueChanged(object sender, EventArgs e)
        {
            CalculateResult();
        }

        private void numericUpDownEndMiles_ValueChanged(object sender, EventArgs e)
        {
            CalculateResult();
        }

        private void numericUpDownEndChains_ValueChanged(object sender, EventArgs e)
        {
            CalculateResult();
        }
    }
}
