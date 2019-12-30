using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Horizon4.GF.RollingStock;
using Horizon4.GF;
using Horizon4.GFDataEditor.Properties;

namespace Horizon4.GFDataEditor
{
    public partial class frmTractionClassProfile : Form
    {
        #region Private Variables

        private TractionClass _TractionClass;
        private PowerCollection _PowerCollection;
        private TractionProfileCollection _TractionClassProfiles;
        private TractionProfile _SelectedTractionProfile;
        bool _HasChanged;

        #endregion Private Variables

        #region  Properties

        /// <summary>
        /// Gets or Sets a flag to indicate the form has been edited
        /// </summary>
        public bool HasChanged
        {
            get { return _HasChanged; }
            set
            {
                _HasChanged = value;
                HandleChange();

            }
        }

        #endregion Properties


        #region Constructors

        public frmTractionClassProfile(TractionClass TractionClass)
        {
            InitializeComponent();
            this._TractionClass = TractionClass;
            InitialiseForm();
        }

        public frmTractionClassProfile()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods
        /// <summary>
        /// Initialises the fors
        /// </summary>
        private void InitialiseForm()
        {
            GetTractionClassProfiles(); //Gets the Traction Profiles for the Traction Class;
            GetPowerCollection(); //Grabs the Power Collection;
            PopulateCombo(); //Populates the Power Combo;
            PopulateListView(); //Populate the List View with the Traction Profiles;

            if (listViewTractionProfiles.Items.Count > 0)
            {
                listViewTractionProfiles.Items[0].Selected = true;
                this._SelectedTractionProfile = (TractionProfile)listViewTractionProfiles.Items[0].Tag;
                EditProfile();
            }

            HasChanged = false;
        }

        /// <summary>
        /// Handles if a control has changed
        /// </summary>
        private void HandleChange()
        {
            if (_HasChanged)
            {
                this.Text = "Traction Class Profiles*";
                saveToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.Text = "Traction Class Profiles";
                saveToolStripMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Populates the Power Combo
        /// </summary>
        private void PopulateCombo()
        {
            comboBoxPower.SelectedIndexChanged -= comboBoxPower_SelectedIndexChanged;
            comboBoxPower.DataSource = null;
            comboBoxPower.DataSource = this._PowerCollection.ToList();
            comboBoxPower.DisplayMember = "Name";
            comboBoxPower.SelectedIndexChanged += comboBoxPower_SelectedIndexChanged;
        }

        private void EditProfile()
        {
            Power SelectedPower = this._PowerCollection.Where(x => x.Type == this._SelectedTractionProfile.Power).FirstOrDefault();
            comboBoxPower.SelectedItem = SelectedPower;
            numericUpDownMaxSpeed.Value = this._SelectedTractionProfile.MaxSpeed.MPH;

            if (this._TractionClass.TractionType == TractionType.Loco)
            {
                numericUpDownMaxSpeedLL.Value = this._SelectedTractionProfile.MaxSpeedLightLoco.MPH;
                numericUpDownMaxSpeedLL.Enabled = true;
            }
            else
            {
                numericUpDownMaxSpeedLL.Value = 0;
                numericUpDownMaxSpeedLL.Enabled = false;
            }

            numericUpDownTE.Value = this._SelectedTractionProfile.TractiveEffort;
            numericUpDownHP.Value = this._SelectedTractionProfile.HorsePower;

            this.HasChanged = false;
        }

        private void NewProfile()
        {
            if (HasChanged)
            {
                if (MessageBox.Show("You have unsaved changes. Are you sure you want to continue?", "GroundFrame Data Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    comboBoxPower.Focus();
                    return;
                }
            }

            this._SelectedTractionProfile = new TractionProfile(this._TractionClass);
            EditProfile();
            HasChanged = false;
        }

        /// <summary>
        /// Handles saving the traction profile
        /// </summary>
        private void SaveRecord()
        {
            if (HasChanged)
            {
                List<DataValidationError> Errors = this._SelectedTractionProfile.ValidateProfile();

                if (Errors.Count != 0)
                {
                    frmValidationErrors ErrorForm = new frmValidationErrors(Errors, "Traction Class Profile Validation Errors");
                    ErrorForm.ShowDialog();
                    return;
                }
                else
                {
                    GFResponse Response;
                    try
                    {
                        //Detect whether a new record is being saved
                        bool NewRecord = false;

                        if (this._SelectedTractionProfile.ID == 0)
                        {
                            NewRecord = true;
                        }

                        //Save the profile
                        Response = this._SelectedTractionProfile.SaveToDB();//If no exception then nothing has errored.

                        if (Response.Exception == null)
                        {
                            toolStripProfileRecord.Text = this._SelectedTractionProfile.Power.ToString();
                            toolStripProfileStatus.Image = Resources.tick;
                            toolStripProfileStatus.Text = string.Format("Record Saved Successfully at {0} (UTC)", DateTime.UtcNow.ToString());
                            HasChanged = false;

                            //Refresh Tree View
                            this._TractionClassProfiles = new TractionProfileCollection(this._TractionClass);
                            PopulateListView();

                            for (int i = 0; i < listViewTractionProfiles.Items.Count; i++)
                            {
                                if ((listViewTractionProfiles.Items[i].Tag as TractionProfile).ID == this._SelectedTractionProfile.ID)
                                {
                                    listViewTractionProfiles.Items[i].Selected = true;
                                }
                            }

                        }
                        else
                        {
                            //Something has errored when saving the object. Show a nice error.
                            toolStripProfileRecord.Text = this._SelectedTractionProfile.Power.ToString();
                            toolStripProfileStatus.Image = Resources.error;
                            toolStripProfileStatus.Text = string.Format("An error has occured trying to save Location {0} | ErrorID {1} : - {2}", this._SelectedTractionProfile.Power.ToString(), Response.AuditID, Response.Exception.GetCleanMessage());

                        }
                    }
                        catch (Exception Ex)
                    {
                        //This is unexpected. Log the error and quit the application
                        GFResponse ExceptionResonse = Audit.WriteLog(new GFResponse(AuditType.Error, "An unexpected error has occured at frmTractionClassProfile.SaveToDB", Ex));
                        MessageBox.Show(string.Format("An unexpected error has occured. Please contact the administrator quoting Log ID {0}", ExceptionResonse.AuditID), CommonDataEditor.GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the list of the all the power objects
        /// </summary>
        private void GetPowerCollection()
        {
            this._PowerCollection = new PowerCollection();
        }

        /// <summary>
        /// Gets the list of profiles for the 
        /// </summary>
        private void GetTractionClassProfiles()
        {
            this._TractionClassProfiles = new TractionProfileCollection(this._TractionClass);
        }

        private void PopulateListView()
        {
            listViewTractionProfiles.SelectedIndexChanged -= listViewTractionProfiles_SelectedIndexChanged;
            listViewTractionProfiles.Items.Clear();

            if (this._TractionClassProfiles != null)
            {
                foreach(TractionProfile Profile in this._TractionClassProfiles)
                {
                    string PowerName = this._PowerCollection.Where(x => x.Type == Profile.Power).FirstOrDefault().Name;

                    ListViewItem Items = new ListViewItem(PowerName);
                    Items.SubItems.Add(Profile.MaxSpeed.MPH.ToString());
                    Items.SubItems.Add(this._TractionClass.TractionType == TractionType.Loco ? Profile.MaxSpeedLightLoco.MPH.ToString() : "N/a");
                    Items.SubItems.Add(Profile.TractiveEffort.ToString());
                    Items.SubItems.Add(Profile.HorsePower.ToString());
                    Items.Tag = Profile;
                    listViewTractionProfiles.Items.Add(Items);
                }
            }

            listViewTractionProfiles.SelectedIndexChanged += listViewTractionProfiles_SelectedIndexChanged;
        }

        #endregion Methods

        private void listViewTractionProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTractionProfiles.SelectedItems.Count > 0)
            {
                this._SelectedTractionProfile = (TractionProfile)listViewTractionProfiles.SelectedItems[0].Tag;
            }
        }

        private void comboBoxPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._SelectedTractionProfile.Power = (comboBoxPower.SelectedItem as Power).Type;
            this.HasChanged = true;
        }

        private void numericUpDownMaxSpeed_ValueChanged(object sender, EventArgs e)
        {
            this._SelectedTractionProfile.MaxSpeed = new Speed(Convert.ToInt32(numericUpDownMaxSpeed.Value));
            this.HasChanged = true;
        }

        private void numericUpDownMaxSpeedLL_ValueChanged(object sender, EventArgs e)
        {
            if (this._TractionClass.TractionType == TractionType.Loco)
            {
                this._SelectedTractionProfile.MaxSpeedLightLoco = new Speed(Convert.ToInt32(numericUpDownMaxSpeedLL.Value));
            }
            else
            {
                this._SelectedTractionProfile.MaxSpeedLightLoco = new Speed(0);
            }
            this.HasChanged = true;
        }

        private void numericUpDownTE_ValueChanged(object sender, EventArgs e)
        {
            this._SelectedTractionProfile.TractiveEffort = Convert.ToInt32(numericUpDownTE.Value);
            this.HasChanged = true;
        }

        private void numericUpDownHP_ValueChanged(object sender, EventArgs e)
        {
            this._SelectedTractionProfile.HorsePower = Convert.ToInt32(numericUpDownHP.Value);
            this.HasChanged = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProfile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
        }
    }
}
