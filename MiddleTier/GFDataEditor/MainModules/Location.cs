using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Horizon4.GF.Network;
using Horizon4.GF;
using Horizon4.GFDataEditor.Properties;
using System.ComponentModel;

namespace Horizon4.GFDataEditor
{
    public partial class frmMain : Form
    {
        #region Private Variables

        SystemLocation _SelectedSystemLocation; //Private variable to store the select system location
        LocationCollection _Locations; //Private variable to store the locations for the selected system location
        Location _Location; //Private variable to store the selected location
        bool _LocationHasChanged; //Private variable to store whether the location has changed

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets or Sets a flag to indicate the form has been edited
        /// </summary>
        public bool LocationHasChanged
        {
            get { return _LocationHasChanged; }
            set
            {
                _LocationHasChanged = value;
                HandleLocationChanged();

            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Dispays the Depot Details Form
        /// </summary>
        private void ViewDepotDetails()
        {
            frmEditDepot EditDepotForm = new frmEditDepot(this._Location);
            EditDepotForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Location Changed Flag being changed
        /// </summary>
        private void HandleLocationChanged()
        {
            //Set up Tab Name
            if (_LocationHasChanged)
            {
                tabControlMain.TabPages[1].Text = "Locations *";
            }
            else
            { 
                tabControlMain.TabPages[1].Text = "Locations"; 
            }

            if (_Location != null)
            {
                if (string.IsNullOrEmpty(_Location.Name) || LocationHasChanged == false)
                {
                    //Disable Save
                    saveLocationToolStripMenuItem.Enabled = false;
                }
                else
                {
                    saveLocationToolStripMenuItem.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Refreshes the Location tab controls
        /// </summary>
        private void InitialiseLocationTab()
        {
            //Populate the Location Combo
            PopulateSystemLocationCombo();

            //Populate the Location Type Combo
            PopulateLocationTypeCombo();

            //Populate the Location Direction Combo
            PopulateLocationDirectionCombo();

            //Populate the token Combo
            PopulateTokenCombo();

            if (_Location != null)
            {
                toolStripTab.Text = "Location";
                toolStripRecord.Text = _Location.DisplayName;
                toolStripStatus.Text = string.Empty;
            }
            
            //If Location Combo is populated then select first item
            if (comboLocationLocation.Items.Count > 0)
            {
                comboLocationLocation.SelectedIndex = 0;
                HandleLocationComboSelection();
            }
        }

        private void PopulateSystemLocationCombo()
        {
            comboLocationLocation.SelectedIndexChanged -= comboLocationLocation_SelectedIndexChanged;
            comboLocationLocation.DataSource = Common.SystemLocations.OrderBy(x => x.Name).ToList();
            comboLocationLocation.DisplayMember = "Name";
            comboLocationLocation.SelectedIndexChanged += comboLocationLocation_SelectedIndexChanged;

            if (comboLocationLocation.SelectedItem != null)
            {
                _SelectedSystemLocation = (SystemLocation)comboLocationLocation.SelectedItem;
            }
        }

        /// <summary>
        /// Populates the internal  GF System Location variable
        /// </summary>
        private void PopulateSystemLocationCollection()
        {
            Common.SystemLocations = new SystemLocationCollection();
        }

        /// <summary>
        /// Configures the EdutoSystemObject form for a System Location, opens and handles the return
        /// </summary>
        /// <param name="SysSector"></param>
        /// <param name="FormText"></param>
        /// <param name="Edit"></param>
        private void OpenSystemLocationForm(SystemLocation SysLocation, string FormText, bool Edit)
        {
            //Configure the form
            frmEditSystemObject SystemLocationForm = new frmEditSystemObject(SysLocation, FormText, Edit);
            SystemLocationForm.ShowDialog();

            //Grab the last edited system sector
            SystemLocation LastLocation = (SystemLocation)SystemLocationForm.SystemObject;

            //Refresh the SystemLocations variable and refresh the combo
            Common.SystemLocations = new SystemLocationCollection();
            PopulateSystemLocationCombo();

            //Set comboLocationLocation selected item to be the last item edited
            if (LastLocation.ID != 0)
            {
                var MatchingItem = comboLocationLocation.Items.Cast<SystemLocation>().FirstOrDefault(z => z.ID == LastLocation.ID);
                comboLocationLocation.SelectedItem = MatchingItem;
            }
        }

        /// <summary>
        /// Populates the internal token collection
        /// </summary>
        private void PopulateTokenCollection()
        {
            Common.Tokens = new TokenCollection();
        }

        /// <summary>
        /// Populates the Location Tree View
        /// </summary>
        private void PopulateLocationTreeView()
        {
            //Clear existing Nodes
            treeViewLocations.Nodes.Clear();

            //Loop through each location in _Locations and add parent node
            foreach (Location Parent in _Locations.OrderBy(x => x.Name).OrderBy(y => y.RecordStartYMDV.Value))
            {
                TreeNode ParentNode = GetTreeNodeFromLocation(Parent);

                //Loop through the child nodes
                foreach (Location Child in Parent.ChildLocations)
                {
                    ParentNode.Nodes.Add(GetTreeNodeFromLocation(Child));
                }

                treeViewLocations.Nodes.Add(ParentNode);
            }
        }

        /// <summary>
        /// Generates a tree node from a Location
        /// </summary>
        /// <param name="Location"></param>
        /// <returns></returns>
        private TreeNode GetTreeNodeFromLocation(Location Location)
        {
            TreeNode Node = new TreeNode(GetTreeNodeText(Location));
            Node.Tag = Location;
            return Node;
        }

        /// <summary>
        /// Gets the Tree Node Location Text
        /// </summary>
        /// <param name="Location"></param>
        /// <returns></returns>
        private string GetTreeNodeText(Location Location)
        {
            return string.Format(@"{0} ({1} - {2})", Location.Name, Location.RecordStartYMDV.DisplayDate, Location.RecordEndYMDV.DisplayDate);
        }

        /// <summary>
        /// Hanldes Location Combo selection
        /// </summary>
        private void HandleLocationComboSelection()
        {
            if (LocationHasChanged)
            {
                if (MessageBox.Show("You have unsaved location changes are you sure you want to continue?", "GroundFrame Data Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    comboLocationLocation.SelectedIndexChanged -= comboLocationLocation_SelectedIndexChanged;
                    comboLocationLocation.SelectedItem = _SelectedSystemLocation;
                    comboLocationLocation.SelectedIndexChanged += comboLocationLocation_SelectedIndexChanged;
                    return;
                }
                else
                {
                    //Reset Flag
                    LocationHasChanged = false;

                    HandleLocationComboSelection();
                }
            }
            else
            {
                //Only do something if an item is selected
                if (comboLocationLocation.SelectedItem != null)
                {
                    //Get selected System Location
                    _SelectedSystemLocation = (SystemLocation)comboLocationLocation.SelectedItem;

                    //Get a collection of location for the system location
                    _Locations = new LocationCollection(_SelectedSystemLocation, true);

                    //Populate the tree view
                    PopulateLocationTreeView();

                    //Select First Node

                    if (treeViewLocations.Nodes.Count > 0)
                    {
                        treeViewLocations.SelectedNode = treeViewLocations.Nodes[0];
                    }
                    else
                    {
                        NewLocation(_SelectedSystemLocation);
                    }
                }
            }
        }

        /// <summary>
        /// Initialises a new location for the supplied SystemLocation
        /// </summary>
        /// <param name="SystemLocation"></param>
        private void NewLocation(SystemLocation SystemLocation)
        {
            _Location = new Location(SystemLocation);
            ConfigureLocation(false);
        }

        /// <summary>
        /// Initialises a new parent location for the supplied parent location
        /// </summary>
        /// <param name="ParentLocation"></param>
        private void NewLocation(Location ParentLocation)
        {
            _Location = new Location(ParentLocation);
            ConfigureLocation(false);
        }

        private void ConfigureLocation(bool Edit)
        {
            if (Edit)
            {
                txtLocationName.Text = _Location.Name;
                txtLocationTIPLOC.Text = _Location.TIPLOC;
                txtLocationSTANOX.Text = _Location.STANOX == 0 ? string.Empty : _Location.STANOX.ToString();
                txtLocationSTANME.Text = _Location.STANME;
                txtLocationNLC.Text = _Location.NLC == 0 ? string.Empty : _Location.NLC.ToString();
                comboLocationType.SelectedItem = _Location.Type;
                txtLocationLatitude.Text = _Location.Latitude == 0 ? string.Empty : _Location.Latitude.ToString();
                txtLocationLongitude.Text = _Location.Longitude == 0 ? string.Empty : _Location.Longitude.ToString();
                txtLocationLength.Text = _Location.Length.Meters == 0 ? string.Empty : _Location.Length.Meters.ToString();
                numericUpDownLocationBerths.Value = _Location.Berths;
                comboLocationDirections.SelectedItem = _Location.Direction;
                comboLocationToken.SelectedValue = _Location.Token == null ? 0 : _Location.Token.ID;
                checkBoxLocationSingleTrainWorking.Checked = _Location.SingleTrainWorking;
                checkBoxLocationFreightOnly.Checked = _Location.FreightOnly;
                checkBoxLocationEmbarkPassengers.Checked = _Location.EmbarkPassengers;
                checkBoxLocationDisembarkPassengers.Checked = _Location.DisembarkPassengers;
                checkBoxLocationUseAsTimingPoint.Checked = _Location.UseAsTimingPount;
                checkBoxLocationTOPSOffice.Checked = _Location.TOPSOffice;
                numericUpDownLocationScore.Value = _Location.Score;

                this.dateTimeLocationActiveFrom.CustomFormat = _UserCulture.DateTimeFormat.ShortDatePattern;

                if (_Location.RecordStartYMDV.Value == 0)
                {
                    this.dateTimeLocationActiveFrom.Checked = false;
                }
                else
                {
                    this.dateTimeLocationActiveFrom.Checked = true;
                    this.dateTimeLocationActiveFrom.Value = _Location.RecordStartYMDV.Date;
                }

                if (_Location.RecordEndYMDV.Value == 0)
                {
                    this.dateTimeLocationActiveTo.ValueChanged -= dateTimeLocationActiveTo_ValueChanged;
                    this.dateTimeLocationActiveTo.CustomFormat = " ";
                    this.dateTimeLocationActiveTo.Checked = false;
                    this.dateTimeLocationActiveTo.Format = DateTimePickerFormat.Custom;
                    this.dateTimeLocationActiveTo.ValueChanged += dateTimeLocationActiveTo_ValueChanged;
                }
                else
                {
                    this.dateTimeLocationActiveTo.ValueChanged -= dateTimeLocationActiveTo_ValueChanged;
                    this.dateTimeLocationActiveTo.Checked = true;
                    this.dateTimeLocationActiveTo.CustomFormat = _UserCulture.DateTimeFormat.ShortDatePattern;
                    this.dateTimeLocationActiveTo.Value = _Location.RecordEndYMDV.Date;
                    this.dateTimeLocationActiveTo.ValueChanged += dateTimeLocationActiveTo_ValueChanged;
                }

                //Power

                checkBoxLocationPowerSteam.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.Steam);
                checkBoxLocationPowerDiesel.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.Diesel);
                checkBoxLocationPower4th600.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.Electric4thRail600);
                checkBoxLocationPower3rd750.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.Electric3rdRail750);
                checkBoxLocationPower3rd1500.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.Electric3rdRail1500);
                checkBoxLocationPowerOH1500.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.ElectricOverhead1500);
                checkBoxLocationPowerOH625.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.ElectricOverhead6250);
                checkBoxLocationPowerOHead25.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.ElectricOverhead25000);
                checkBoxLocationPowerBattery.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.Battery);

                //Options

                checkBoxLocationOptionCannotStop.Checked = GetOptions(_Location.Options, LocationOptions.CannotStopAtLocation);
                checkBoxLocationOptionOnlyStopIfReversing.Checked = GetOptions(_Location.Options, LocationOptions.OnlyStopIfReversing);
                checkBoxLocationOptionPassengerTrainCannotStop.Checked = GetOptions(_Location.Options, LocationOptions.PassengerTrainsCannotStop);
                checkBoxLocationOptionCallOn.Checked = GetOptions(_Location.Options, LocationOptions.HasCallOn);

                //Enable Menu Items

                saveLocationToolStripMenuItem.Enabled = true;

                //Set Location Changed Flag
                LocationHasChanged = false;

                //Set Up Child Location Controls
                ConfigureChildLocationControls(_Location.ParentLocation == null ? true : false);

                //Set up Status Menu

                toolStripTab.Text = "Location";
                toolStripRecord.Text = _Location.DisplayName;
                toolStripStatus.Text = string.Empty;
            }
            else
            {
                txtLocationName.Text = string.Empty;
                txtLocationTIPLOC.Text = string.Empty;
                txtLocationSTANOX.Text = string.Empty;
                txtLocationSTANME.Text = string.Empty;
                txtLocationNLC.Text = string.Empty;
                comboLocationType.SelectedIndex = 0;
                txtLocationLatitude.Text = string.Empty;
                txtLocationLongitude.Text = string.Empty;
                txtLocationLength.Text = string.Empty;
                numericUpDownLocationBerths.Value = 1;
                comboLocationDirections.SelectedIndex = 0;
                comboLocationToken.SelectedValue = 0;
                checkBoxLocationSingleTrainWorking.Checked = false;
                checkBoxLocationFreightOnly.Checked = false;
                checkBoxLocationEmbarkPassengers.Checked = false;
                checkBoxLocationDisembarkPassengers.Checked = false;
                checkBoxLocationUseAsTimingPoint.Checked = false;
                checkBoxLocationTOPSOffice.Checked = false;
                numericUpDownLocationScore.Value = 0;

                this.dateTimeLocationActiveFrom.CustomFormat = _UserCulture.DateTimeFormat.ShortDatePattern;
                this.dateTimeLocationActiveFrom.Value = new DateTime(1850, 1, 1);

                if (_Location.RecordEndYMDV.Value == 0)
                {
                    this.dateTimeLocationActiveTo.CustomFormat = " ";
                    this.dateTimeLocationActiveTo.Checked = false;
                    this.dateTimeLocationActiveTo.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    this.dateTimeLocationActiveTo.CustomFormat = _UserCulture.DateTimeFormat.ShortDatePattern;
                    this.dateTimeLocationActiveTo.Value = _Location.RecordEndYMDV.Date;
                }

                //Power

                checkBoxLocationPowerSteam.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.Steam);
                checkBoxLocationPowerDiesel.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.Diesel);
                checkBoxLocationPower4th600.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.Electric4thRail600);
                checkBoxLocationPower3rd750.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.Electric3rdRail750);
                checkBoxLocationPower3rd1500.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.Electric3rdRail1500);
                checkBoxLocationPowerOH1500.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.ElectricOverhead1500);
                checkBoxLocationPowerOH625.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.ElectricOverhead6250);
                checkBoxLocationPowerOHead25.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.ElectricOverhead25000);
                checkBoxLocationPowerBattery.Checked = GetPowerOptions(_Location.PermissiblePowerSources, PowerType.Battery);

                //Options

                checkBoxLocationOptionCannotStop.Checked = GetOptions(_Location.Options, LocationOptions.CannotStopAtLocation);
                checkBoxLocationOptionOnlyStopIfReversing.Checked = GetOptions(_Location.Options, LocationOptions.OnlyStopIfReversing);
                checkBoxLocationOptionPassengerTrainCannotStop.Checked = GetOptions(_Location.Options, LocationOptions.PassengerTrainsCannotStop);
                checkBoxLocationOptionCallOn.Checked = GetOptions(_Location.Options, LocationOptions.HasCallOn);

                //Enable Menu Items

                saveLocationToolStripMenuItem.Enabled = true;

                //Set Location Changed Flag
                LocationHasChanged = false;

                //Set Up Child Location Controls
                ConfigureChildLocationControls(_Location.ParentLocation == null ? true : false);

                //Set up Status Menu

                toolStripTab.Text = "Location";
                toolStripRecord.Text = _Location.DisplayName;
                toolStripStatus.Text = string.Empty;
            }
        }

        private void ConfigureChildLocationControls(bool IsMasterLocation)
        {
            txtLocationTIPLOC.Enabled = IsMasterLocation;
            txtLocationSTANOX.Enabled = IsMasterLocation;
            txtLocationSTANME.Enabled = IsMasterLocation;
            txtLocationNLC.Enabled = IsMasterLocation;
            comboLocationType.Enabled = IsMasterLocation;
            txtLocationLatitude.Enabled = IsMasterLocation;
            txtLocationLongitude.Enabled = IsMasterLocation;
            comboLocationToken.Enabled = IsMasterLocation;

            if (!IsMasterLocation)
            {
                comboLocationType.SelectedItem = _Location.ParentLocation.Type;
                comboLocationToken.SelectedValue = _Location.ParentLocation.Token == null ? 0 : _Location.ParentLocation.Token.ID;
            }
        }

        /// <summary>
        /// Returns true or false if the Option is present in the Bitwise
        /// </summary>
        /// <param name="BitWise"></param>
        /// <param name="Power"></param>
        /// <returns></returns>
        private bool GetOptions(int BitWise, LocationOptions Option)
        {
            int _Option = BitWise & (int)Option;

            if (_Option >= (int)Option)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        /// Calulated the Option Value from the Checked Box Provided
        /// </summary>
        /// <param name="Checked"></param>
        private void CalculateOptionValue(CheckBox Checked)
        {
            int BitWise = Convert.ToInt16(Checked.Tag);
            int ExistingBit = _Location.Options & BitWise;

            if (BitWise == 0)
            {
                throw new Exception("Supplied CheckBox doesn't have a valid Tag value set for the Option Bit Wise");
            }

            if (Checked.Checked == true && !(ExistingBit >= BitWise))
            {
                _Location.Options = _Location.Options + BitWise;
            }

            if (Checked.Checked == false && (ExistingBit >= BitWise))
            {
                _Location.Options = _Location.Options - BitWise;
            }
        }

        /// <summary>
        /// Calulated the PermissiblePowerValue from the Checked Box Provided
        /// </summary>
        /// <param name="Checked"></param>
        private void CalculatePermissiblePowerValue(CheckBox Checked)
        {
            int BitWise = Convert.ToInt16(Checked.Tag);
            int ExistingBit = _Location.PermissiblePowerSources & BitWise;

            if (BitWise == 0)
            {
                throw new Exception("Supplied CheckBox doesn't have a valid Tag value set for the Permissible Power Bit Wise");
            }

            if (Checked.Checked == true && !(ExistingBit >= BitWise))
            {
                _Location.PermissiblePowerSources = _Location.PermissiblePowerSources + BitWise;
            }

            if (Checked.Checked == false && (ExistingBit >= BitWise))
            {
                _Location.PermissiblePowerSources = _Location.PermissiblePowerSources - BitWise;
            }
        }

        /// <summary>
        /// Populates the Token Combo
        /// </summary>
        private void PopulateTokenCombo()
        {
            comboLocationToken.SelectedIndexChanged -= comboBoxToken_SelectedIndexChanged;
            List<Token> TokenList = Common.Tokens.ToList();
            TokenList.Add(new Token());
            comboLocationToken.DataSource = TokenList;
            comboLocationToken.DisplayMember = "Name";
            comboLocationToken.ValueMember = "ID";
            comboLocationToken.SelectedIndexChanged += comboBoxToken_SelectedIndexChanged;
        }

        /// <summary>
        /// Populates the Location Type Combo
        /// </summary>
        private void PopulateLocationTypeCombo()
        {
            comboLocationType.SelectedIndexChanged -= comboLocationType_SelectedIndexChanged;
            comboLocationType.DataSource = (LocationType[])Enum.GetValues(typeof(LocationType));
            comboLocationType.SelectedIndexChanged += comboLocationType_SelectedIndexChanged;
        }

        /// <summary>
        /// Populates the Location Direction Combo
        /// </summary>
        private void PopulateLocationDirectionCombo()
        {
            comboLocationDirections.SelectedIndexChanged -= comboLocationDirections_SelectedIndexChanged;
            comboLocationDirections.DataSource = (NetworkDirection[])Enum.GetValues(typeof(NetworkDirection));
            comboLocationDirections.SelectedIndexChanged += comboLocationDirections_SelectedIndexChanged;
        }

        /// <summary>
        /// Saves the Location Record
        /// </summary>
        private void SaveLocation()
        {
            if (LocationHasChanged)
            {
                List<DataValidationError> Errors = _Location.ValidateLocation();

                if (Errors.Count != 0)
                {
                    frmValidationErrors ErrorForm = new frmValidationErrors(Errors, "Location Validation Errors");
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

                        if (_Location.ID == 0)
                        {
                            NewRecord = true;
                        }

                        //Save the Location to the Database
                        Response = _Location.SaveToDB();

                        //If no exception then nothing has errored.
                        if (Response.Exception == null)
                        {
                            toolStripTab.Text = "Location";
                            toolStripRecord.Text = _Location.Name;
                            toolStripStatus.Image = Resources.tick;
                            toolStripStatus.Text = string.Format("Record Saved Successfully at {0} (UTC)", DateTime.UtcNow.ToString());
                            LocationHasChanged = false;

                            //Refresh Tree View
                            if (!NewRecord)
                            {
                                UpdateTreeNode();
                            }
                            else
                            {
                                AppendNewTreeNode();
                            }

                        }
                        else
                        {
                            //Something has errored when saving the object. Show a nice error.
                            toolStripTab.Text = "Location";
                            toolStripRecord.Text = _Location.Name;
                            toolStripStatus.Image = Resources.error;
                            string ErrorMessage = string.Format("An error has occured trying to save Location {0} | ErrorID {1} : - {2}", _Location.Name, Response.AuditID, Response.Exception.GetCleanMessage());
                            toolStripStatus.Text = ErrorMessage.Substring(0,255);
                        }
                    }
                    catch (Exception Ex)
                    {
                        //This is unexpected. Log the error and quit the application
                        GFResponse ExceptionResonse = Audit.WriteLog(new GFResponse(AuditType.Fatal, "An unexpected error has occured at frmMain.Locations.SaveToDB:", Ex));
                        MessageBox.Show(string.Format("An unexpected error has occured. Please contact the administrator quoting Log ID {0}", ExceptionResonse.AuditID), CommonDataEditor.GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Updates the tree view selected node
        /// </summary>
        private void UpdateTreeNode()
        {
            foreach (TreeNode Node in GetAllTreeNodes(treeViewLocations.Nodes))
            {
                Location NodeLocation = (Location)Node.Tag;

                if (NodeLocation.ID == _Location.ID)
                {
                    Node.Text = GetTreeNodeText(_Location);
                }
            }
        }

        private void AppendNewTreeNode()
        {
            if (_Location.IsChild)
            {
                //Child Location need to be added as children to the parent
                foreach (TreeNode Node in GetAllTreeNodes(treeViewLocations.Nodes))
                {
                    Location NodeLocation = (Location)Node.Tag;

                    if (NodeLocation.ID == _Location.ParentLocation.ID)
                    {
                        Node.Nodes.Add(GetTreeNodeFromLocation(_Location));
                    }
                }
            }
            else
            {
                treeViewLocations.Nodes.Add(GetTreeNodeFromLocation(_Location));
            }
        }

        /// <summary>
        /// Creates a new token
        /// </summary>
        private void NewToken()
        {
            Token SelectedToken = (Token)comboLocationToken.SelectedItem;

            frmEditToken TokenForm = new frmEditToken(new Token(0), true);
            TokenForm.ShowDialog();

            Common.Tokens = new TokenCollection();
            PopulateTokenCombo();

            if (TokenForm.Token.ID != 0)
            {
                comboLocationToken.SelectedValue = TokenForm.Token.ID;
            }
            else
            {
                comboLocationToken.SelectedValue = SelectedToken.ID;
            }
        }

        /// <summary>
        /// Edits the selected token
        /// </summary>
        private void EditToken()
        {
            if (comboLocationToken.SelectedItem != null)
            {
                Token SelectedToken = (Token)comboLocationToken.SelectedItem;

                if (SelectedToken.ID == 0)
                {
                    MessageBox.Show("You cannot edit the 'Not Applicable' token", "GroundFrame Data Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    frmEditToken TokenForm = new frmEditToken(SelectedToken, true);
                    TokenForm.ShowDialog();
                    Common.Tokens = new TokenCollection();
                    PopulateTokenCombo();
                    comboLocationToken.SelectedValue = SelectedToken.ID;
                }
            }
        }

        /// <summary>
        /// Handles if the selected value changes
        /// </summary>
        private void HandleTreeSelectionChange()
        {
            if (LocationHasChanged)
            {
                if (MessageBox.Show("You have unsaved location changes are you sure you want to continue?", "GroundFrame Data Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    //Reselect existing Location
                    foreach (TreeNode Node in GetAllTreeNodes(treeViewLocations.Nodes))
                    {
                        Location NodeLocation = (Location)Node.Tag;

                        if (NodeLocation.ID == _Location.ID)
                        {
                            treeViewLocations.SelectedNode = Node;
                        }
                    }
                    contextMenuStripLocationTreeView.Close();
                    return;
                }
                else
                {
                    //Reset flag 

                    LocationHasChanged = false;

                    //Reload Location from DB and update treenode tab
                    _Location = new Location(_Location.ID);

                    foreach (TreeNode Node in GetAllTreeNodes(treeViewLocations.Nodes))
                    {
                        Location NodeLocation = (Location)Node.Tag;

                        if (NodeLocation.ID == _Location.ID)
                        {
                            Node.Tag = _Location;
                        }
                    }
                }
            }

            if (treeViewLocations.SelectedNode != null)
            {
                _Location = (Location)treeViewLocations.SelectedNode.Tag;
                ConfigureLocation(true);
            }
        }

        /// <summary>
        /// Shows the Edit Path Form for the selected system location
        /// </summary>
        private void EditPaths()
        {
            frmEditPaths EditPathForm = new frmEditPaths(_SelectedSystemLocation);
            EditPathForm.ShowDialog();
        }

        #endregion Methods

        #region Events

        private void newLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLocation(_SelectedSystemLocation);
        }

        private void comboLocationLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleLocationComboSelection();
        }

        private void linkLocationNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenSystemLocationForm(new SystemLocation(), "New System Location", false);
        }

        private void linkLocationEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboLocationLocation.SelectedItem != null)
            {
                SystemLocation _Location = (SystemLocation)comboLocationLocation.SelectedItem;

                OpenSystemLocationForm(_Location, "System Location", true);
            }
        }

        private IEnumerable<TreeNode> GetAllTreeNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                yield return node;

                foreach (var child in GetAllTreeNodes(node.Nodes))
                    yield return child;
            }
        }

        private void treeViewLocations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            HandleTreeSelectionChange();

            if (e.Action == TreeViewAction.ByMouse)
            {
                txtLocationName.Focus();
            }
        }

        private void txtLocationName_TextChanged(object sender, EventArgs e)
        {
            _Location.Name = txtLocationName.Text;
            LocationHasChanged = true;
        }

        private void dateTimeLocationActiveFrom_ValueChanged(object sender, EventArgs e)
        {
            _Location.RecordStartYMDV = new YMDV(dateTimeLocationActiveFrom.Value);
            LocationHasChanged = true;
        }

        private void txtLocationTIPLOC_TextChanged(object sender, EventArgs e)
        {
            _Location.TIPLOC = txtLocationTIPLOC.Text.ToUpper();
            LocationHasChanged = true;
        }

        private void txtLocationSTANOX_TextChanged(object sender, EventArgs e)
        {
            int STANOX;
            bool isNumeric = int.TryParse(string.IsNullOrEmpty(txtLocationSTANOX.Text) ? "0" : txtLocationSTANOX.Text, out STANOX);

            if (isNumeric == false)
            {
                MessageBox.Show("The STANOX Code must be a number or blank", "GroundFrame Data Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocationSTANOX.Text = _Location.STANOX == 0 ? string.Empty : _Location.STANOX.ToString();
            }
            else
            {
                _Location.STANOX = STANOX;
                LocationHasChanged = true;
            }
        }

        private void txtLocationNLC_TextChanged(object sender, EventArgs e)
        {
            int NLC;
            bool isNumeric = int.TryParse(string.IsNullOrEmpty(txtLocationNLC.Text) ? "0" : txtLocationNLC.Text, out NLC);

            if (isNumeric == false)
            {
                MessageBox.Show("The NLC must be a number or blank", "GroundFrame Data Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocationSTANOX.Text = _Location.NLC == 0 ? string.Empty : _Location.NLC.ToString();
            }
            else
            {
                _Location.NLC = NLC;
                LocationHasChanged = true;
            }
        }


        private void comboLocationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLocationType.SelectedItem != null)
            {
                _Location.Type = (LocationType)(comboLocationType.SelectedItem);
            }
            LocationHasChanged = true;

            //Enable Depot Details

            if (_Location.Type == LocationType.Depot)
            {
                linkDepotDetails.Enabled = true;
            }
            else
            {
                linkDepotDetails.Enabled = false;
            }
        }

        private void txtLocationLatitude_TextChanged(object sender, EventArgs e)
        {
            decimal Latitude;
            bool isDecimal = decimal.TryParse(string.IsNullOrEmpty(txtLocationLatitude.Text) ? "0" : txtLocationLatitude.Text, out Latitude);

            if (isDecimal == false)
            {
                MessageBox.Show("The Latitude must be a number or blank", "GroundFrame Data Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocationLatitude.Text = _Location.Latitude == 0 ? string.Empty : _Location.Latitude.ToString();
            }
            else
            {
                _Location.Latitude = Latitude;
                LocationHasChanged = true;
            }
        }

        private void txtLocationLongitude_TextChanged(object sender, EventArgs e)
        {
            decimal Longitude;
            bool isDecimal = decimal.TryParse(string.IsNullOrEmpty(txtLocationLongitude.Text) ? "0" : txtLocationLongitude.Text, out Longitude);

            if (isDecimal == false)
            {
                MessageBox.Show("The Longitude must be a number or blank", "GroundFrame Data Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocationLongitude.Text = _Location.Longitude == 0 ? string.Empty : _Location.Longitude.ToString();
            }
            else
            {
                _Location.Longitude = Longitude;
                LocationHasChanged = true;
            }
        }

        private void txtLocationLength_TextChanged(object sender, EventArgs e)
        {
            decimal Meters;
            bool isDecimal = decimal.TryParse(string.IsNullOrEmpty(txtLocationLength.Text) ? "0" : txtLocationLength.Text, out Meters);

            if (isDecimal == false)
            {
                MessageBox.Show("The Length must be a number or blank", "GroundFrame Data Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocationLength.Text = _Location.Length.Meters == 0 ? string.Empty : _Location.Length.Meters.ToString();
            }
            else
            {
                _Location.Length = new Distance(Meters);
                LocationHasChanged = true;
            }
        }

        private void numericUpDownLocationBerths_ValueChanged(object sender, EventArgs e)
        {
            _Location.Berths = (int)numericUpDownLocationBerths.Value;
            LocationHasChanged = true;
        }

        private void comboLocationDirections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLocationDirections.SelectedItem != null)
            {
                _Location.Direction = (NetworkDirection)(comboLocationDirections.SelectedItem);
            }
            LocationHasChanged = true;
        }

        private void comboBoxToken_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Only do something if the combo has a token selected
            if (comboLocationToken.SelectedItem != null)
            {
                //Grab the token from the comob
                Token SelectedToken = (Token)comboLocationToken.SelectedItem;

                //If selected token different to exsting location token update and flag
                if (SelectedToken != _Location.Token)
                {
                    _Location.Token = (Token)(comboLocationToken.SelectedItem);
                    LocationHasChanged = true;
                }
            }

            if (_Location.Token.ID == 0)
            {
                linkLocationEditToken.Enabled = false;
            }
            else
            {
                linkLocationEditToken.Enabled = true;
            }
        }

        private void checkBoxLocationSingleTrainWorking_CheckedChanged(object sender, EventArgs e)
        {
            _Location.SingleTrainWorking = checkBoxLocationSingleTrainWorking.Checked;
            LocationHasChanged = true;
        }

        private void checkBoxLocationFreightOnly_CheckedChanged(object sender, EventArgs e)
        {
            _Location.FreightOnly = checkBoxLocationFreightOnly.Checked;
            LocationHasChanged = true;
        }

        private void checkBoxLocationEmbarkPassengers_CheckedChanged(object sender, EventArgs e)
        {
            _Location.EmbarkPassengers = checkBoxLocationEmbarkPassengers.Checked;
            LocationHasChanged = true;
        }

        private void checkBoxLocationDisembarkPassengers_CheckedChanged(object sender, EventArgs e)
        {
            _Location.DisembarkPassengers = checkBoxLocationDisembarkPassengers.Checked;
            LocationHasChanged = true;
        }

        private void checkBoxLocationUseAsTimingPoint_CheckedChanged(object sender, EventArgs e)
        {
            _Location.UseAsTimingPount = checkBoxLocationUseAsTimingPoint.Checked;
            LocationHasChanged = true;
        }

        private void checkBoxLocationTOPSOffice_CheckedChanged(object sender, EventArgs e)
        {
            _Location.TOPSOffice = checkBoxLocationTOPSOffice.Checked;
            LocationHasChanged = true;
        }

        private void numericUpDownLocationScore_ValueChanged(object sender, EventArgs e)
        {
            _Location.Score = (int)numericUpDownLocationScore.Value;
            LocationHasChanged = true;
        }

        private void checkBoxLocationPowerSteam_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            LocationHasChanged = true;
        }

        private void checkBoxLocationPowerDiesel_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            LocationHasChanged = true;
        }

        private void checkBoxLocationPower4th600_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            LocationHasChanged = true;
        }

        private void checkBoxLocationPower3rd750_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            LocationHasChanged = true;
        }

        private void checkBoxLocationPower3rd1500_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            LocationHasChanged = true;
        }

        private void checkBoxLocationPowerOH1500_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            LocationHasChanged = true;
        }

        private void checkBoxLocationPowerOH625_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            LocationHasChanged = true;
        }

        private void checkBoxLocationPowerOHead25_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            LocationHasChanged = true;
        }

        private void checkBoxLocationPowerBattery_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissiblePowerValue((CheckBox)sender);
            LocationHasChanged = true;
        }


        private void checkBoxLocationOptionCallOn_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            LocationHasChanged = true;
        }

        private void saveLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLocation();
        }

        private void newChildLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLocation(_Location);
        }

        private void checkBoxLocationOptionCannotStop_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            LocationHasChanged = true;
        }

        private void checkBoxLocationOptionOnlyStopIfReversing_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            LocationHasChanged = true;
        }

        private void checkBoxLocationOptionPassengerTrainCannotStop_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            LocationHasChanged = true;
        }

        private void treeViewLocations_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TreeNode SelectedNode = treeViewLocations.GetNodeAt(e.X, e.Y);

                if (SelectedNode != null)
                {
                    Location SelectedLocation = (Location)SelectedNode.Tag;

                    treeViewLocations.SelectedNode = SelectedNode;

                    if (treeViewLocations.SelectedNode != null)
                    {
                        if (treeViewLocations.SelectedNode.Level == 0)
                        {
                            contextMenuStripLocationTreeView.Show(treeViewLocations, e.Location);
                        }
                        else
                        {
                            contextMenuStripLocationTreeView.Close();
                        }
                    }
                    else
                    {
                        contextMenuStripLocationTreeView.Close();
                    }
                }
            }
        }
        private void linkLocationEditToken_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditToken();
        }

        private void linkLocationNewToken_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewToken();
        }

        private void editPathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPaths();
        }

        private void checkBoxLocationOptionCannotSurrenderToken_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOptionValue((CheckBox)sender);
            LocationHasChanged = true;
        }

        private void txtLocationSTANME_TextChanged(object sender, EventArgs e)
        {
            _Location.STANME = txtLocationSTANME.Text.ToUpper();
            LocationHasChanged = true;
        }

        private void linkDepotDetails_Click(object sender, EventArgs e)
        {
            ViewDepotDetails();
        }

        private void dateTimeLocationActiveTo_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimeLocationActiveTo.Checked == true)
            {
                this.dateTimeLocationActiveTo.CustomFormat = _UserCulture.DateTimeFormat.ShortDatePattern;
                _Location.RecordEndYMDV = new YMDV(dateTimeLocationActiveTo.Value);

            }
            else
            {
                this.dateTimeLocationActiveTo.CustomFormat = " ";
                this.dateTimeLocationActiveTo.Checked = false;
                this.dateTimeLocationActiveTo.Format = DateTimePickerFormat.Custom;
                _Location.RecordEndYMDV = new YMDV(0);
            }
            LocationHasChanged = true;
        }

        #endregion Events
    }
}
