using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Horizon4.GF.Network;
using System.Globalization;
using System.Text.RegularExpressions;
using Horizon4.GF;
using Horizon4.GFDataEditor.Properties;

namespace Horizon4.GFDataEditor
{
    public partial class frmEditDepot : Form
    {
        #region Private Variables

        Location _SelectedLocation; //Private variable to store the parent location.
        DepotCollection _Depots; //Private variable to store the depot records for the location.
        Depot _SelectedDepot; //Private variable to store the selected depot.
        string _FormTitle; //Private variable to store the Form title.
        bool _DepotHasChanged; //Private variable to store whether the location has changed

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets or Sets a flag to indicate the form has been edited
        /// </summary>
        public bool DepotHasChanged
        {
            get { return _DepotHasChanged; }
            set
            {
                _DepotHasChanged = value;
                HandleDepotChanged();

            }
        }

        #endregion Properties

        #region Constructors

        public frmEditDepot()
        {
            InitializeComponent();
        }

        public frmEditDepot(Location Location)
        {
            this._SelectedLocation = Location;
            InitializeComponent();
            GetLocationDepots();
            PopulateListView();
            _FormTitle = string.Format(@"{0} Depot Details", Location.DisplayName);
            this.Text = _FormTitle;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the Depot Changed Flag being changed
        /// </summary>
        private void HandleDepotChanged()
        {
            //Set up Tab Name
            if (_DepotHasChanged)
            {
                this.Text = string.Format(@"{0} *", this._FormTitle);
            }
            else
            {
                this.Text = _FormTitle;
            }

            if (_SelectedDepot != null)
            {
                if (string.IsNullOrEmpty(_SelectedDepot.Code) || DepotHasChanged == false)
                {
                    //Disable Save
                    saveToolStripMenuItem.Enabled = false;
                }
                else
                {
                    saveToolStripMenuItem.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Gets the list of depots for the supplied location
        /// </summary>
        private void GetLocationDepots()
        {
            _Depots = new DepotCollection(_SelectedLocation);
        }

        private void PopulateListView()
        {
            listViewDepots.SelectedIndexChanged -= listViewDepots_SelectedIndexChanged;
            listViewDepots.Items.Clear();

            foreach (Depot _Depot in _Depots.OrderBy(x => x.RecordStartYMDV.Value))
            {
                listViewDepots.Items.Add(GetListViewItemFromDepot(_Depot));
            }

            //If items in listview select first record
            if (listViewDepots.Items.Count != 0)
            {
                listViewDepots.Items[0].Selected = true;
                _SelectedDepot = (Depot)listViewDepots.Items[0].Tag;
                EditDepot();
            }

            listViewDepots.SelectedIndexChanged += listViewDepots_SelectedIndexChanged;
        }

        private void EditDepot()
        {
            toolStripDepotRecord.Text = _SelectedDepot.Code;
            toolStripDepotStatus.Image = Resources.tick;
            toolStripDepotStatus.Text = string.Empty;

            this.dateTimeDepotActiveFrom.Value = _SelectedDepot.RecordStartYMDV.Date;

            if (_SelectedDepot.RecordEndYMDV.Value == 0)
            {
                this.dateTimeDepotActiveTo.Checked = false;
            }
            else
            {
                this.dateTimeDepotActiveTo.CustomFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.dateTimeDepotActiveTo.Value = _SelectedDepot.RecordEndYMDV.Date;
            }

            this.txtBoxCode.Text = _SelectedDepot.Code;
            this.numericUpDownEaseofAccess.Value = _SelectedDepot.EaseOfAccess;
            this.numericUpDownPercVisible.Value = _SelectedDepot.PercentageVisible;
            this.checkBoxWheelLathe.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.WheelLathe);
            this.checkBoxFuel.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.Fuel);
            this.checkBoxCoal.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.Coal);
            this.checkBoxWater.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.Water);
            this.checkBoxAExam.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.AExam);
            this.checkBoxBExam.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.BExam);
            this.checkBoxCExam.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.CExam);
            this.checkBoxDExam.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.DExam);
            this.checkBoxEExam.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.EExam);
            this.checkBoxFExam.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.FExam);
            this.checkBoxExamPowerDiesel.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.MaintenanceDiesel);
            this.checkBoxExamPowerOverhead.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.MaintenanceOverhead);
            this.checkBoxExamPower3rdRail.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.Maintenance3rdRail);
            this.checkBoxTractionLoco.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.MaintenanceLoco);
            this.checkBoxTractionEMU.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.MaintenanceEMU);
            this.checkBoxTractionDMU.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.MaintenanceDMU);
            this.checkBoxTractionDEMU.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.MaintenanceDEMU);
            this.checkBoxTractionCarriage.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.MaintenanceCarriage);
            this.checkBoxTractionWagon.Checked = GetCapabilityOptions(_SelectedDepot.Capabilities, DepotCapabilities.MaintenanceWagon);

            DepotHasChanged = false;
        }

        /// <summary>
        /// Generates a ListView Item from the supplied depot object
        /// </summary>
        /// <param name="Depot"></param>
        /// <returns></returns>
        private ListViewItem GetListViewItemFromDepot(Depot Depot)
        {
            ListViewItem Item = new ListViewItem(Depot.Code);
            Item.SubItems.Add(Depot.RecordStartYMDV.DisplayDate);
            Item.SubItems.Add(Depot.RecordEndYMDV.DisplayDate);
            Item.Tag = Depot;

            return Item;
        }

        /// <summary>
        /// Calulated the Capability Value from the Checked Box Provided
        /// </summary>
        /// <param name="Checked"></param>
        private void CalculateOptionValue(CheckBox Checked)
        {
            int BitWise = Convert.ToInt32(Checked.Tag);
            int ExistingBit = _SelectedDepot.Capabilities & BitWise;

            if (BitWise == 0)
            {
                throw new Exception("Supplied CheckBox doesn't have a valid Tag value set for the Option Bit Wise");
            }

            if (Checked.Checked == true && !(ExistingBit >= BitWise))
            {
                _SelectedDepot.Capabilities = _SelectedDepot.Capabilities + BitWise;
            }

            if (Checked.Checked == false && (ExistingBit >= BitWise))
            {
                _SelectedDepot.Capabilities = _SelectedDepot.Capabilities - BitWise;
            }
        }

        /// <summary>
        /// Returns true or false if Depot Capability is present in the Bitwise
        /// </summary>
        /// <param name="BitWise"></param>
        /// <param name="Power"></param>
        /// <returns></returns>
        private bool GetCapabilityOptions(int BitWise, DepotCapabilities Capabilities)
        {
            int _Power = BitWise & (int)Capabilities;

            if (_Power >= (int)Capabilities)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveDepot()
        {
            if (DepotHasChanged)
            {
                List<DataValidationError> Errors = _SelectedDepot.ValidatePath();

                if (Errors.Count != 0)
                {
                    frmValidationErrors ErrorForm = new frmValidationErrors(Errors, "Depot Validation Errors");
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

                        //Save the Location to the Database
                        Response = _SelectedDepot.SaveToDB();

                        //If no exception then nothing has errored.
                        if (Response.Exception == null)
                        {
                            toolStripDepotRecord.Text = _SelectedDepot.Code;
                            toolStripDepotStatus.Image = Resources.tick;
                            toolStripDepotStatus.Text = string.Format("Record Saved Successfully at {0} (UTC)", DateTime.UtcNow.ToString());
                            DepotHasChanged = false;

                            //Refresh Tree View
                            if (NewRecord)
                            {
                                _Depots = new DepotCollection(_SelectedLocation);
                                PopulateListView();

                                for (int i = 0; i < listViewDepots.Items.Count; i++)
                                {
                                    if ((listViewDepots.Items[i].Tag as Path).ID == _SelectedDepot.ID)
                                    {
                                        listViewDepots.Items[i].Selected = true;
                                    }
                                }
                            }

                        }
                        else
                        {
                            //Something has errored when saving the object. Show a nice error.
                            toolStripDepotRecord.Text = _SelectedDepot.Code;
                            toolStripDepotStatus.Image = Resources.error;
                            toolStripDepotStatus.Text = string.Format("An error has occured trying to save Location {0} | ErrorID {1} : - {2}", _SelectedDepot.Code, Response.AuditID, Response.Exception.GetCleanMessage());

                        }
                    }
                    catch (Exception Ex)
                    {
                        //This is unexpected. Log the error and quit the application
                        GFResponse ExceptionResonse = Audit.WriteLog(new GFResponse(AuditType.Fatal, "An unexpected error has occured at frmMain.Locations.SaveToDB", Ex));
                        MessageBox.Show(string.Format("An unexpected error has occured. Please contact the administrator quoting Log ID {0}", ExceptionResonse.AuditID), CommonDataEditor.GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void NewDepot()
        {
            if (DepotHasChanged)
            {
                if (MessageBox.Show("You have unsaved changes. Are you sure you want to continue?", Properties.Settings.Default.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            _SelectedDepot = new Depot(_SelectedLocation);
            EditDepot();
            toolStripDepotRecord.Text = "New Depot";
            toolStripDepotStatus.Image = Resources.tick;
            toolStripDepotStatus.Text = string.Empty;
            dateTimeDepotActiveFrom.Focus();
        }

        #endregion Methods

        private void checkBoxWheelLathe_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxFuel_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxCoal_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxWater_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxAExam_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxBExam_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxCExam_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxDExam_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxEExam_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxFExam_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxExamPowerDiesel_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxExamPowerOverhead_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxExamPower3rdRail_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxTractionLoco_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxTractionEMU_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxTractionDMU_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxTractionDEMU_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxTractionCarriage_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void checkBoxTractionWagon_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            DepotHasChanged = true;
        }

        private void txtBoxCode_Validating(object sender, CancelEventArgs e)
        {
                if (!Regex.IsMatch(txtBoxCode.Text,@"^[a-zA-Z]+$"))
            {
                MessageBox.Show("The Depot Code must contain letters only and be 2 or 3 characters", Properties.Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                {
                    e.Cancel = true;
                }
            }
            else
            {
                _SelectedDepot.Code = txtBoxCode.Text.ToUpper();
                DepotHasChanged = true;
            }
        }

        private void numericUpDownEaseofAccess_ValueChanged(object sender, EventArgs e)
        {
            _SelectedDepot.EaseOfAccess = (int)numericUpDownEaseofAccess.Value;
            DepotHasChanged = true;
        }

        private void numericUpDownPercVisible_ValueChanged(object sender, EventArgs e)
        {
            _SelectedDepot.PercentageVisible = (int)numericUpDownPercVisible.Value;
            DepotHasChanged = true;
        }

        private void frmEditDepot_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DepotHasChanged)
            {
                if (MessageBox.Show("You have unsaved changes. Are you sure you want to continue?", Properties.Settings.Default.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void listViewDepots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DepotHasChanged)
            {
                if (MessageBox.Show("You have unsaved changes. Are you sure you want to continue?", Properties.Settings.Default.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    foreach (ListViewItem Item in listViewDepots.Items)
                    {
                        if ((Item.Tag as Depot).ID == _SelectedDepot.ID)
                        {
                            Item.Selected = true;
                        }
                    }

                    return;
                }
            }

            if (listViewDepots.SelectedItems.Count != 0)
            {
                _SelectedDepot = (Depot)listViewDepots.SelectedItems[0].Tag;
                EditDepot();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDepot();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDepot();
        }

    }
}
