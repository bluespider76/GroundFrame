using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Horizon4.GF;
using System.Reflection;
using Horizon4.GF.Network;

namespace Horizon4.GFDataEditor
{
    public partial class frmEditSystemPath : Form
    {
        #region Private Variables

        private SystemPath _SystemPath; //Private variable to store the system path
        private bool _HasChanges; //Private variable to store a flag which indicates whether there are unsaved changes
        private bool _IsEdit; //Private variable to store whether form is in edit more as opposed to "new" mode
        private string _FormText; //Private variable to store the normal form text
        private SystemLocationCollection _SystemLocations; //Private variable to store the system locations

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets or sets whether a change has been detected.
        /// </summary>
        public bool HasChanges
        {
            get { return this._HasChanges; }

            set
            {
                this._HasChanges = value;
                ConfigureHasChanges();
            }
        }

        /// <summary>
        /// Gets the SystemPath edited by the form
        /// </summary>
        public SystemPath SystemPath { get { return this._SystemPath; } }

        #endregion Properties

        #region Constructors

        public frmEditSystemPath()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the SystemPath edited by the form
        /// </summary>
        public frmEditSystemPath(SystemPath Path, string FormText)
        {
            InitializeComponent();
            this._SystemPath = Path;
            this._FormText = this.Text;
            InitialiseForm();

        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Configures the form is changes are detected;
        /// </summary>
        private void ConfigureHasChanges()
        {
            if (_HasChanges)
            {
                this.Text = string.Format(@"{0} *", _FormText);
            }
            else
            {
                this.Text = _FormText;
            }
        }

        private void InitialiseForm()
        {
            _SystemLocations = new SystemLocationCollection();
            PopulateStartLocationCombo();
            _IsEdit = _SystemPath.ID == 0 ? false : true;
            txtName.Text = _SystemPath.Name;
            txtDescription.Text = _SystemPath.Description;

            if (_IsEdit)
            {
                comboStartLocation.SelectedValue = _SystemPath.StartLocation.ID;
                if (comboStartLocation.SelectedItem != null)
                {
                    PopulateEndLocationCombo((SystemLocation)comboStartLocation.SelectedItem);
                    comboEndLocation.SelectedValue = _SystemPath.EndLocation.ID;
                }
            }
            else
            {
                comboStartLocation.SelectedIndex = 0;
                if (comboStartLocation.SelectedItem != null)
                {
                    PopulateEndLocationCombo((SystemLocation)comboStartLocation.SelectedItem);
                    comboEndLocation.SelectedIndex = 0;
                }
            }

            ConfigureSaveButton();
            HasChanges = false;
        }

        /// <summary>
        /// Populates the Start Location Combo
        /// </summary>
        private void PopulateStartLocationCombo()
        {
            comboStartLocation.SelectedIndexChanged -= comboStartLocation_SelectedIndexChanged;
            List<SystemLocation> _SystemLocationsList = _SystemLocations.OrderBy(y => y.Name).ToList();
            comboStartLocation.DataSource = null;
            comboStartLocation.DataSource = _SystemLocationsList;
            comboStartLocation.ValueMember = "ID";
            comboStartLocation.DisplayMember = "Name";
            comboStartLocation.SelectedIndexChanged += comboStartLocation_SelectedIndexChanged;
        }

        /// <summary>
        /// Populates the End Location Combo but excludes the start location
        /// </summary>
        /// <param name="StartLocation"></param>
        private void PopulateEndLocationCombo(SystemLocation StartLocation)
        {
            comboEndLocation.SelectedIndexChanged -= comboEndLocation_SelectedIndexChanged;
            List<SystemLocation> _SystemLocationsList = _SystemLocations.Where(x => x.ID != StartLocation.ID).OrderBy(y => y.Name).ToList();
            comboEndLocation.DataSource = null;
            comboEndLocation.DataSource = _SystemLocationsList;
            comboEndLocation.ValueMember = "ID";
            comboEndLocation.DisplayMember = "Name";
            comboEndLocation.SelectedIndexChanged += comboEndLocation_SelectedIndexChanged;
        }

        /// <summary>
        /// Configures the Save button
        /// </summary>
        private void ConfigureSaveButton()
        {
            //If edit mode and no description don't enable the Save buttons
            if (string.IsNullOrEmpty(_SystemPath.Name))
            {
                butSave.Enabled = false;
                butSaveAndNew.Enabled = false;
            }
            else
            {
                butSave.Enabled = true;
                butSaveAndNew.Enabled = true;
            }
        }

        /// <summary>
        /// Saves the SystemSector to the GroundFrame DB
        /// </summary>
        private void SaveToDB()
        {
            GFResponse Response; //Variable to store the audit log ID

            try
            {
                //Save the System Path to the Database
                Response = _SystemPath.SaveToDB();

                //If no exception then nothing has errored.
                if (Response.Exception == null)
                {
                    this.Text = "System Sector";
                    txtName.Enabled = false;
                    HasChanges = false;
                }
                else
                {
                    //Something has errored when saving the SystemPath. Show a nice error.
                    MessageBox.Show(string.Format("An error has occured trying to save SystemPath {0} | ErrorID {1} : - {2}", _SystemPath.Name, Response.AuditID, Response.Exception.GetCleanMessage()), CommonDataEditor.GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }


            }
            catch (Exception Ex)
            {
                //This is unexpected. Log the error and quit the application
                GFResponse ExceptionResonse = Audit.WriteLog(new GFResponse(AuditType.Fatal, "An unexpected error has occured at frmEditSystemPath.SaveToDB()", Ex));
                MessageBox.Show(string.Format("An unexpected error has occured. Please contact the administrator quoting Log ID {0}", ExceptionResonse.AuditID), CommonDataEditor.GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Instantiates a new instance of the system object and sets up thr form
        /// </summary>
        private void NewPath()
        {
            _SystemPath = new SystemPath();
            InitialiseForm();
            this.Text = string.Format(@"New {0}", _FormText);
            txtName.Focus();
        }

        #endregion Methods

        #region Events

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            _SystemPath.Name = txtName.Text;
            ConfigureSaveButton();
            HasChanges = true;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            _SystemPath.Description = txtDescription.Text;
            ConfigureSaveButton();
            HasChanges = true;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            SaveToDB();
        }

        private void butSaveAndNew_Click(object sender, EventArgs e)
        {
            SaveToDB();
            NewPath();
        }

        #endregion Events

        private void comboStartLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStartLocation.SelectedItem != null)
            {
                _SystemPath.StartLocation = (SystemLocation)comboStartLocation.SelectedItem;
            }
            HasChanges = true;
        }

        private void comboEndLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEndLocation.SelectedItem != null)
            {
                _SystemPath.EndLocation = (SystemLocation)comboEndLocation.SelectedItem;
            }
            HasChanges = true;
        }
    }
}
