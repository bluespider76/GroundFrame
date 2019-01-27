using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Horizon4.GF;
using Horizon4.GF.Logical;
using Horizon4.GF.Network;
using System.Globalization;
using Horizon4.GFDataEditor.Properties;

namespace Horizon4.GFDataEditor
{
    public partial class frmMain : Form
    {
        #region Global Variables

        #region User Variables

        private CultureInfo _UserCulture; //Private variable to store the culture of the user

        #endregion User Variables

        #region Form Variables

        private ActiveTab _ActiveFormTab; //Private variable to store the active form

        #endregion Form Variables

        #region GF Collections

        private RegionCollection _Regions; //Private variable to store a list of all regions
        private SectorCollection _Sectors; //Private variable to store a list of sectors

        #endregion GF Collections

        #endregion Global Variables

        #region Constructors

        /// <summary>
        /// Initialises a new instance of a frmMain class
        /// </summary>
        public frmMain()
        {
            //Intitialise the components
            InitializeComponent();

            //Set the Groundframe DB Connection string

            Common.SQLDBConn = @"Server=.;Database=GF_DEV;Trusted_Connection=True;";

            //Initiaise the form

            InitialiseForm();
        }

        #endregion Constructors

        #region Methods

        private void InitialiseForm()
        {
            //Set the application in the GF Library

            Common.Application = GF.Application.DataEditor;

            //Populate Groundframe Collections
            SetGFCollections();

            //Set User Variables
            SetUserVariables();

            //Initialise the tabs

            InitialiseTabs();

            //Initialise the menu

            InitialiseMenuItems(0);
        }

        /// <summary>
        /// Populates private GF collection variables
        /// </summary>
        private void SetGFCollections()
        {
            try
            {
                //Logical Collection
                PopulateRegionsCollection();
                //System Sector Collection
                PopulateSystemSectorCollection();
                //Sector Collection
                PopulateSectorCollection();
                //System Location Collection
                PopulateSystemLocationCollection();
                //Token Collection
                PopulateTokenCollection();
            }
            catch (Exception ex)
            {
                Audit.WriteLog(AuditType.Error, ex.GetCleanMessage());
                MessageBox.Show("The Data Editor has experienced a fatal error. Please see logs for details. The application will now quit.", "Groundframe Data Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Sets the user private variables
        /// </summary>
        private void SetUserVariables()
        {
            //Get the user culture

            _UserCulture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// Initialises all the tabs on the form
        /// </summary>
        private void InitialiseTabs()
        {
            InitialiseLogicalTab();
            InitialiseLocationTab();
        }

        /// <summary>
        /// Initialises the menu bar based on the active tab
        /// </summary>
        /// <param name="TabIndex"></param>
        private void InitialiseMenuItems(int TabIndex)
        {
            if (TabIndex == 0)
            {
                
            }
            else
            {

            }

            if (TabIndex == 1)
            {
                ToolStripLocationLocation.Visible = true;
                ToolStripLocationFile.Visible = true;
            }
            else
            {
                ToolStripLocationLocation.Visible = false;
                ToolStripLocationFile.Visible = false;
            }

            if (TabIndex == 2)
            {
                ToolStripTractionFile.Visible = true;
                ToolStripTractionTraction.Visible = true;
            }
            else
            {
                ToolStripTractionFile.Visible = false;
                ToolStripTractionTraction.Visible = false;
            }
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// Handles changing the selected tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Logical Tab
            if (tabControlMain.SelectedIndex == 0)
            {
                InitialiseLogicalTab();
            }

            //Location Tab
            if (tabControlMain.SelectedIndex == 1)
            {
                InitialiseLocationTab();
            }

            //Traction Tab
            if (tabControlMain.SelectedIndex == 2)
            {
                InitialiseTractionTab();
            }

            //Set the active form variable
            _ActiveFormTab = (ActiveTab)tabControlMain.SelectedIndex;

            //Initialise the menu
            InitialiseMenuItems(tabControlMain.SelectedIndex);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                if (_ActiveFormTab == ActiveTab.Location && saveLocationToolStripMenuItem.Enabled == true)
                {
                    SaveLocation();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion Events
    }
}
