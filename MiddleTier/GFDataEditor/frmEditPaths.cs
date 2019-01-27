using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Horizon4.GF.Network;
using Horizon4.GF;
using Horizon4.GFDataEditor.Properties;

namespace Horizon4.GFDataEditor
{
    public partial class frmEditPaths : Form
    {
        #region Private Variables
        
        SystemLocation _SystemLocation; //Private variable to store the SystemLocation
        SystemPathCollection _SystemPaths; //Private variable to store the SystemPaths 
        SystemPath _SelectedSystemPath; //Private variable to store the selected SystemPath
        PathCollection _Paths; //Private variable to store the collection of paths for the selected SystemPath (_SelectedSystemPath)
        LocationCollection _StartLocations; //Private variable to store the possible start locations
        LocationCollection _EndLocations; //Private variable to store the possible end locations
        Path _SelectedPath; //Private variable to store the selected path
        bool _PathHasChanged; //Private variable to store whether the path has changed
        
        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets or Sets a flag to indicate the form has been edited
        /// </summary>
        public bool PathHasChanged
        {
            get { return _PathHasChanged; }
            set
            {
                _PathHasChanged = value;
                HandlePathChanged();

            }
        }

        #endregion Properties

        #region Constructors

        public frmEditPaths()
        {
            InitializeComponent();

            //Populate System Path Collection

            _SystemPaths = new SystemPathCollection();

            //Initialise Form
            InitialiseForm();
        }

        public frmEditPaths(SystemLocation Location)
        {
            InitializeComponent();
            this._SystemLocation = Location;
            
            //Populate System Path Collection

            _SystemPaths = new SystemPathCollection(_SystemLocation);

            //Initialise Form
            InitialiseForm();
        }

        #endregion Constructors

        #region Methods

        private void ShowDistanceCalculator()
        {
            frmDistanceCalculator DistanceCalculator = new frmDistanceCalculator();
            DistanceCalculator.Show();
        }

        /// <summary>
        /// Opens the frmEditPath form and creates a new system path
        /// </summary>
        private void NewSystemPath()
        {
            frmEditSystemPath EditSystemPathForm = new frmEditSystemPath(new SystemPath(), @"New Path");
            EditSystemPathForm.ShowDialog();
            _SystemPaths = new SystemPathCollection();
            PopulateSystemPathsCombo();
            comboSystemPath.SelectedItem = EditSystemPathForm.SystemPath;
            NewPath();
        }

        /// <summary>
        /// Opens the frmEditPath form to allow the selected SystemPath to be edited
        /// </summary>
        private void EditSystemPath()
        {
            frmEditSystemPath EditSystemPathForm = new frmEditSystemPath(_SelectedSystemPath, _SelectedSystemPath.Name);
            EditSystemPathForm.ShowDialog();
            _SystemPaths = new SystemPathCollection();
            PopulateSystemPathsCombo();
            comboSystemPath.SelectedItem = _SelectedSystemPath;
        }

        /// <summary>
        /// Handles the PAth Changed Flag being changed
        /// </summary>
        private void HandlePathChanged()
        {
            //Set up Tab Name
            if (_PathHasChanged)
            {
                this.Text = "Paths *";
            }
            else
            {
                this.Text = "Paths";
            }
        }

        /// <summary>
        /// Initialises the form
        /// </summary>
        private void InitialiseForm()
        {
            PopulateSystemPathsCombo();
            PopulateLocationDirectionCombo();
            PopulateTokenCombo();
            PopulateTypeCombo();
            PopulateSignalTypeCombo();
        }

        /// <summary>
        /// Populates the SystemPath Combo
        /// </summary>
        private void PopulateSystemPathsCombo()
        {
            comboSystemPath.SelectedIndexChanged -= comboSystemPath_SelectedIndexChanged;
            comboSystemPath.DataSource = _SystemPaths.OrderBy(x => x.Name).ToList();
            comboSystemPath.DisplayMember = "Name";
            comboSystemPath.SelectedIndexChanged += comboSystemPath_SelectedIndexChanged;

            if (comboSystemPath.SelectedItem != null)
            {
                _SelectedSystemPath = (SystemPath)comboSystemPath.SelectedItem;
                HandleComboSelection();
                linkSystemPathEdit.Enabled = true;
            }
            else
            {
                //Disable Edit Path Controls
                linkSystemPathEdit.Enabled = false;
                panelPathControls.Enabled = false;
            }
        }

        /// <summary>
        /// Populates the Path List View
        /// </summary>
        private void PopulatePathListView()
        {
            //Clear existing Items
            listViewPaths.Items.Clear();

            //Loop through each location in _Locations and add parent node
            foreach (Path Path in _Paths.OrderBy(y => y.RecordStartYMDV.Value))
            {
                listViewPaths.Items.Add(GetListViewItemFromPath(Path));
            }
        }

        /// <summary>
        /// Handles the selection of a SystemPath in the Combo Box
        /// </summary>
        private void HandleComboSelection()
        {
            if (comboSystemPath.SelectedItem != null)
            {
                _SelectedSystemPath = (SystemPath)comboSystemPath.SelectedItem;
                _Paths = new PathCollection(_SelectedSystemPath);
                PopulatePathListView();

                if (listViewPaths.Items.Count > 0)
                {
                    listViewPaths.Items[0].Selected = true;
                    panelPathControls.Enabled = true;
                }
                else
                {
                    panelPathControls.Enabled = false;
                }
            }
            else
            {
                panelPathControls.Enabled = false;
            }
        }

        /// <summary>
        /// Generates a ListViewItem for the supplied Path
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        private ListViewItem GetListViewItemFromPath(Path Path)
        {
            ListViewItem Item = new ListViewItem(Path.Start.Name);
            Item.SubItems.Add(Path.End.Name);
            Item.SubItems.Add(Path.RecordStartYMDV.DisplayDate);
            Item.SubItems.Add(Path.RecordEndYMDV.DisplayDate);
            Item.Tag = Path;

            return Item;
        }

        /// <summary>
        /// Populates the Start and End Locations LocationCollections
        /// </summary>
        private void PopulateStartAndEndLocationCollections()
        {
            _StartLocations = new LocationCollection(_SelectedSystemPath.StartLocation, new YMDV(dateTimeLocationActiveFrom.Value));
            _EndLocations = new LocationCollection(_SelectedSystemPath.EndLocation, new YMDV(dateTimeLocationActiveFrom.Value));
        }

        /// <summary>
        /// Handles changing the Path ListView selected item
        /// </summary>
        private void HandlePathListViewItemSelection()
        {
            if (listViewPaths.SelectedItems.Count > 0)
            {
                _SelectedPath = (Path)listViewPaths.SelectedItems[0].Tag;
                
                //Populate Location Combos Data
                PopulateStartAndEndLocationCollections();

                //Set up Controls
                ConfigureControls(true);

                //Set up Status Bar
                toolStripPathRecord.Text = _SelectedPath.Label;
                toolStripPathStatus.Text = string.Empty;
                toolStripPathStatus.Image = Resources.tick;
            }
        }

        private void ConfigureControls(bool Edit)
        {
            if (Edit)
            {
                dateTimeLocationActiveFrom.Value = _SelectedPath.RecordStartYMDV.Date;
                PopulateStartAndEndLocationCollections();
                PopulateStartLocationCombo();
                comboStartLocation.SelectedIndex = GetLocationComoboItemIndex(comboStartLocation, _SelectedPath.Start);
                PopulateEndLocationCombo();
                comboEndLocation.SelectedIndex = GetLocationComoboItemIndex(comboStartLocation, _SelectedPath.End);
                txtLength.Text = _SelectedPath.Distance.Meters.ToString();
                comboDirections.SelectedItem = _SelectedPath.Direction;
                checkBoxFreightOnly.Checked = _SelectedPath.FreightOnly;
                comboToken.SelectedValue = _SelectedPath.Token == null ? 0 : _SelectedPath.Token.ID;
                numericUpDownBerths.Value = _SelectedPath.Berths;
                comboPathType.SelectedItem = _SelectedPath.Type;
                comboBoxSignalType.SelectedItem = _SelectedPath.SignalType;
                numericUpDownRA.Value = _SelectedPath.RouteAvailability;
                numericUpDownCrossingCount.Value = _SelectedPath.CrossingCount;
                numericUpDownSpeed.Value = _SelectedPath.MaxSpeed;
                numericUpDownScore.Value = _SelectedPath.Score;
                numericUpDownRating.Value = _SelectedPath.Rating;
                checkBoxLocationPowerSteam.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.Steam);
                checkBoxLocationPowerDiesel.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.Diesel);
                checkBoxLocationPower4th600.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.Electric4thRail600);
                checkBoxLocationPower3rd750.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.Electric3rdRail750);
                checkBoxLocationPower3rd1500.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.Electric3rdRail1500);
                checkBoxLocationPowerOH1500.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.ElectricOverhead1500);
                checkBoxLocationPowerOH625.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.ElectricOverhead6500);
                checkBoxLocationPowerOHead25.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.ElectricOverhead25000);
                checkBoxLocationPowerBattery.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.Battery);
            }
            else
            {
                dateTimeLocationActiveFrom.Value = _SelectedPath.RecordStartYMDV.Date;
                PopulateStartAndEndLocationCollections();
                PopulateStartLocationCombo();
                comboStartLocation.SelectedIndex = 0;
                _SelectedPath.Start = (Location)comboStartLocation.SelectedItem;
                PopulateEndLocationCombo();
                comboEndLocation.SelectedIndex = 0;
                _SelectedPath.End = (Location)comboEndLocation.SelectedItem;
                txtLength.Text = "0";
                comboDirections.SelectedItem = NetworkDirection.Both;
                _SelectedPath.Direction = (NetworkDirection)comboDirections.SelectedItem;
                checkBoxFreightOnly.Checked = false;
                comboToken.SelectedValue = 0;
                _SelectedPath.Token = (Token)comboToken.SelectedItem;
                numericUpDownBerths.Value = 1;
                comboPathType.SelectedItem = PathType.Main;
                _SelectedPath.Type = (PathType)comboPathType.SelectedItem;
                comboBoxSignalType.SelectedItem = NetworkSignalType.MainAspect;
                _SelectedPath.SignalType = (NetworkSignalType)comboBoxSignalType.SelectedItem;
                numericUpDownRA.Value = 7;
                numericUpDownCrossingCount.Value = 0;
                numericUpDownSpeed.Value = 50;
                numericUpDownScore.Value = _SelectedPath.Score;
                numericUpDownRating.Value = 0;
                checkBoxLocationPowerSteam.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.Steam);
                checkBoxLocationPowerDiesel.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.Diesel);
                checkBoxLocationPower4th600.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.Electric4thRail600);
                checkBoxLocationPower3rd750.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.Electric3rdRail750);
                checkBoxLocationPower3rd1500.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.Electric3rdRail1500);
                checkBoxLocationPowerOH1500.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.ElectricOverhead1500);
                checkBoxLocationPowerOH625.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.ElectricOverhead6500);
                checkBoxLocationPowerOHead25.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.ElectricOverhead25000);
                checkBoxLocationPowerBattery.Checked = GetPowerOptions(_SelectedPath.PermissiblePowerSources, PowerType.Battery);
            }

            PathHasChanged = false;
        }

        /// <summary>
        /// Populates the Location Direction Combo
        /// </summary>
        private void PopulateLocationDirectionCombo()
        {
            comboDirections.SelectedIndexChanged -= comboDirections_SelectedIndexChanged;
            comboDirections.DataSource = (NetworkDirection[])Enum.GetValues(typeof(NetworkDirection));
            comboDirections.SelectedIndexChanged += comboDirections_SelectedIndexChanged;
        }

        /// <summary>
        /// Populates the Type Combo
        /// </summary>
        private void PopulateTypeCombo()
        {
            comboPathType.SelectedIndexChanged -= comboPathType_SelectedIndexChanged;
            comboPathType.DataSource = (PathType[])Enum.GetValues(typeof(PathType));
            comboPathType.SelectedIndexChanged += comboPathType_SelectedIndexChanged;
        }

        /// <summary>
        /// Populates the Signal Type Combo
        /// </summary>
        private void PopulateSignalTypeCombo()
        {
            comboBoxSignalType.SelectedIndexChanged -= comboBoxSignalType_SelectedIndexChanged;
            comboBoxSignalType.DataSource = (NetworkSignalType[])Enum.GetValues(typeof(NetworkSignalType));
            comboBoxSignalType.SelectedIndexChanged += comboBoxSignalType_SelectedIndexChanged;
        }

        /// <summary>
        /// Populates the Token Combo
        /// </summary>
        private void PopulateTokenCombo()
        {
            comboToken.SelectedIndexChanged -= comboToken_SelectedIndexChanged;
            List<Token> TokenList = Common.Tokens.ToList();
            TokenList.Add(new Token());
            comboToken.DataSource = TokenList;
            comboToken.DisplayMember = "Name";
            comboToken.ValueMember = "ID";
            comboToken.SelectedIndexChanged += comboToken_SelectedIndexChanged;
        }

        /// <summary>
        /// Gets the index value from the combo for the supplied Location
        /// </summary>
        /// <param name="Combo"></param>
        /// <param name="Location"></param>
        /// <returns></returns>
        private int GetLocationComoboItemIndex(ComboBox Combo, Location Location)
        {
            for (int i = 0; i < Combo.Items.Count; i++)
            {
                if ((Combo.Items[i] as Location).ID == Location.ID)
                {
                    return i;
                }
            }

            return 0;
        }

        /// <summary>
        /// Returns true or false if Power Type is present in the Bitwise
        /// </summary>
        /// <param name="BitWise"></param>
        /// <param name="Power"></param>
        /// <returns></returns>
        private bool GetPowerOptions(int BitWise, PowerType Power)
        {
            int _Power = BitWise & (int)Power;

            if (_Power >= (int)Power)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Populates the Start Location Combo
        /// </summary>
        private void PopulateStartLocationCombo()
        {
            comboStartLocation.SelectedIndexChanged -= comboStartLocation_SelectedIndexChanged;
            comboStartLocation.DataSource = _StartLocations.OrderBy(x => x.Name).ToList();
            comboStartLocation.DisplayMember = "DisplayNameAndDates";
            comboStartLocation.SelectedIndexChanged += comboStartLocation_SelectedIndexChanged;
        }

        /// <summary>
        /// Populates the End Location Combo
        /// </summary>
        private void PopulateEndLocationCombo()
        {
            comboEndLocation.SelectedIndexChanged -= comboEndLocation_SelectedIndexChanged;
            comboEndLocation.DataSource = _EndLocations.OrderBy(x => x.Name).ToList();
            comboEndLocation.DisplayMember = "DisplayNameAndDates";
            comboEndLocation.SelectedIndexChanged += comboEndLocation_SelectedIndexChanged;
        }

        /// <summary>
        /// Calulated the PermissiblePowerValue from the Checked Box Provided
        /// </summary>
        /// <param name="Checked"></param>
        private void CalculatePermissiblePowerValue(CheckBox Checked)
        {
            int BitWise = Convert.ToInt16(Checked.Tag);
            int ExistingBit = _SelectedPath.PermissiblePowerSources & BitWise;

            if (BitWise == 0)
            {
                throw new Exception("Supplied CheckBox doesn't have a valid Tag value set for the Permissible Power Bit Wise");
            }

            if (Checked.Checked == true && !(ExistingBit >= BitWise))
            {
                _SelectedPath.PermissiblePowerSources = _SelectedPath.PermissiblePowerSources + BitWise;
            }

            if (Checked.Checked == false && (ExistingBit >= BitWise))
            {
                _SelectedPath.PermissiblePowerSources = _SelectedPath.PermissiblePowerSources - BitWise;
            }
        }

        /// <summary>
        /// Saves the Path Record
        /// </summary>
        private void SavePath()
        {
            if (PathHasChanged)
            {
                List<DataValidationError> Errors = _SelectedPath.ValidatePath();

                if (Errors.Count != 0)
                {
                    frmValidationErrors ErrorForm = new frmValidationErrors(Errors, "Path Validation Errors");
                    ErrorForm.ShowDialog();
                    return;
                }
                else
                {
                    DBResponse Response;

                    try
                    {
                        //Detect whether a new record is being saved
                        bool NewRecord = false;

                        if (_SelectedPath.ID == 0)
                        {
                            NewRecord = true;
                        }

                        //Save the Location to the Database
                        Response = _SelectedPath.SaveToDB();

                        //If no exception then nothing has errored.
                        if (Response.Exception == null)
                        {
                            toolStripPathRecord.Text = _SelectedPath.Label;
                            toolStripPathStatus.Image = Resources.tick;
                            toolStripPathStatus.Text = string.Format("Record Saved Successfully at {0} (UTC)", DateTime.UtcNow.ToString());
                            PathHasChanged = false;

                            //Refresh Tree View
                            if (NewRecord)
                            {
                                _Paths = new PathCollection(_SelectedSystemPath);
                                PopulatePathListView();

                                for (int i = 0; i < listViewPaths.Items.Count; i++)
                                {
                                    if ((listViewPaths.Items[i].Tag as Path).ID == _SelectedPath.ID)
                                    {
                                        listViewPaths.Items[i].Selected = true;
                                    }
                                }
                            }

                        }
                        else
                        {
                            //Something has errored when saving the object. Show a nice error.
                            toolStripPathRecord.Text = _SelectedPath.Label;
                            toolStripPathStatus.Image = Resources.error;
                            toolStripPathStatus.Text = string.Format("An error has occured trying to save Location {0} | ErrorID {1} : - {2}", _SelectedPath.Label, Response.LogID, Response.Exception.GetCleanMessage());

                        }
                    }
                    catch (Exception Ex)
                    {
                        //This is unexpected. Log the error and quit the application
                        DBResponse ExceptionResonse = Audit.WriteLog(AuditType.Fatal, string.Format("An unexpected error has occured at frmMain.Locations.SaveToDB:- {0}", Ex.GetAuditMessage()));
                        MessageBox.Show(string.Format("An unexpected error has occured. Please contact the administrator quoting Log ID {0}", ExceptionResonse.LogID), CommonDataEditor.GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }
        }

        private void NewPath()
        {
            if (_SelectedSystemPath != null)
            {
                if (PathHasChanged)
                {
                    if (MessageBox.Show("You have unsaved changes. Are you sure you want to continue?", "GroundFrame Data Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        dateTimeLocationActiveFrom.Focus();
                        return;
                    }
                    else
                    {
                        PathHasChanged = false;
                        HandlePathListViewItemSelection();
                    }
                }
                else
                {
                    _SelectedPath = new Path(_SelectedSystemPath);
                    ConfigureControls(false);
                    toolStripPathRecord.Text = "New Path";
                    toolStripPathStatus.Text = string.Empty;
                    toolStripPathStatus.Image = Resources.tick;
                    panelPathControls.Enabled = true;
                    dateTimeLocationActiveFrom.Focus();
                }
            }
        }

        #endregion Methods

        #region Events

        private void comboSystemPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleComboSelection();
        }

        private void dateTimeLocationActiveFrom_ValueChanged(object sender, EventArgs e)
        {
            PopulateStartAndEndLocationCollections();
            PopulateStartLocationCombo();
            PopulateEndLocationCombo();
        }

        private void listViewPaths_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePathListViewItemSelection();
        }

        private void comboStartLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStartLocation.SelectedItem != null)
            {
                PathHasChanged = true;
                _SelectedPath.Start = (Location)comboStartLocation.SelectedItem;
            }
        }

        private void comboEndLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEndLocation.SelectedItem != null)
            {
                PathHasChanged = true;
                _SelectedPath.End = (Location)comboEndLocation.SelectedItem;
            }
        }

        private void comboDirections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDirections.SelectedItem != null)
            {
                PathHasChanged = true;
                _SelectedPath.Direction = (NetworkDirection)comboDirections.SelectedItem;
            }
        }

        private void comboToken_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboToken.SelectedItem != null)
            {
                PathHasChanged = true;
                _SelectedPath.Token = (Token)comboToken.SelectedItem;
            }
        }

        private void comboPathType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPathType.SelectedItem != null)
            {
                PathHasChanged = true;
                _SelectedPath.Type = (PathType)comboPathType.SelectedItem;
            }
        }

        private void comboBoxSignalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSignalType.SelectedItem != null)
            {
                PathHasChanged = true;
                _SelectedPath.SignalType = (NetworkSignalType)comboBoxSignalType.SelectedItem;
            }
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            PathHasChanged = true;
        }

        private void txtLength_Validating(object sender, CancelEventArgs e)
        {
            decimal Distance;

            if (decimal.TryParse(txtLength.Text, out Distance))
            {
                if (Distance > 0)
                {
                    PathHasChanged = true;
                    _SelectedPath.Distance = new Distance(Distance);
                }
                else
                {
                    MessageBox.Show("The length must be a number greater than 0", "GroundFrame Data Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("The length must be a number greater than 0", "GroundFrame Data Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;    
            }

            _SelectedPath.Distance = new Distance(Distance);
        }

        private void checkBoxFreightOnly_CheckedChanged(object sender, EventArgs e)
        {
            PathHasChanged = true;
            _SelectedPath.FreightOnly = checkBoxFreightOnly.Checked;
        }

        private void numericUpDownScore_ValueChanged(object sender, EventArgs e)
        {
            PathHasChanged = true;
            _SelectedPath.Score = (int)numericUpDownScore.Value;
        }

        private void numericUpDownBerths_ValueChanged(object sender, EventArgs e)
        {
            PathHasChanged = true;
            _SelectedPath.Berths = (int)numericUpDownBerths.Value;
        }

        private void numericUpDownRA_ValueChanged(object sender, EventArgs e)
        {
            PathHasChanged = true;
            _SelectedPath.RouteAvailability = (int)numericUpDownRA.Value;
        }

        private void numericUpDownCrossingCount_ValueChanged(object sender, EventArgs e)
        {
            PathHasChanged = true;
            _SelectedPath.CrossingCount = (int)numericUpDownCrossingCount.Value;
        }

        private void numericUpDownSpeed_ValueChanged(object sender, EventArgs e)
        {
            PathHasChanged = true;
            _SelectedPath.MaxSpeed = (int)numericUpDownSpeed.Value;
        }

        private void numericUpDownRating_ValueChanged(object sender, EventArgs e)
        {
            PathHasChanged = true;
            _SelectedPath.Rating = (int)numericUpDownRating.Value;
        }

        private void checkBoxLocationPowerSteam_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            PathHasChanged = true;
        }

        private void checkBoxLocationPowerDiesel_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            PathHasChanged = true;
        }

        private void checkBoxLocationPower4th600_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            PathHasChanged = true;
        }

        private void checkBoxLocationPower3rd750_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            PathHasChanged = true;
        }

        private void checkBoxLocationPower3rd1500_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            PathHasChanged = true;
        }

        private void checkBoxLocationPowerOH1500_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            PathHasChanged = true;
        }

        private void checkBoxLocationPowerOH625_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            PathHasChanged = true;
        }

        private void checkBoxLocationPowerOHead25_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            PathHasChanged = true;
        }

        private void checkBoxLocationPowerBattery_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            PathHasChanged = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePath();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPath();
            PathHasChanged = true;
        }

        private void listViewPaths_Click(object sender, EventArgs e)
        {
            if (listViewPaths.SelectedItems.Count > 0)
            {
                if (PathHasChanged)
                {
                    if (MessageBox.Show("You have unsaved changes. Are you sure you want to continue?", "GroundFrame Data Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        dateTimeLocationActiveFrom.Focus();
                        return;
                    }
                    else
                    {
                        PathHasChanged = false;
                        HandlePathListViewItemSelection();
                    }
                }
            }
        }

        private void linkSystemPathEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Edit the System Path
            EditSystemPath();
        }

        private void linkSystemPathNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //New System Path
            NewSystemPath();
        }

        private void distanceCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDistanceCalculator();
        }
        #endregion Events
    }
}
