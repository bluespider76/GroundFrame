using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Horizon4.GF.Logical;
using Horizon4.GF;
using Horizon4.GFDataEditor.Properties;

namespace Horizon4.GFDataEditor
{
    public partial class frmMain : Form
    {
        #region Private Variables

        private Region _SelectedRegion; //Private variable to store the selected region which is being edited
        private SystemSector _SelectedSystemSector; //Private variable to store the selected SystemSector being edited
        private Sector _SelectedSector; //Private variable to store the selected sector
        private bool _RegionHasChanged; //Private variable to store whether a region has been edited and the change no comitted
        private bool _RegionNeedsYMDVValidation; //Private variable to store whether a change has been made to the region which requires YMDV validation
        private bool _SectorHasChanged; //Private variable to store whether a sector has been edited and the change no comitted
        private bool _SectorNeedsYMDVValidation; //Private variable to store whether a change has been made to the sector which requires YMDV validation

        #endregion Private Variables

        #region Methods

        private void InitialiseLogicalTab()
        {
            //Refresh Combos and List Views
            RefreshRegionListView();
            PopulateSystemSectorsCombo();
            
            //Set Date Pickers to be blank

            this.dateTimeLogicalRegionEndYMDV.Checked = false;
            this.dateTimeLogicalRegionStartYMDV.CustomFormat = " ";
            this.dateTimeLogicalRegionStartYMDV.Format = DateTimePickerFormat.Custom;

            //If there are items in the list view select the first one

            if (listViewRegions.Items.Count > 0)
            {
                listViewRegions.Items[0].Selected = true;
                txtLogicalRegionName.Focus();
            }
            else
            {
                //Otherwise initialise a new region
                NewRegion();
            }

            //Initialise Status Bar

            if (_SelectedRegion != null && _SelectedSector == null)
            {
                toolStripTab.Text = "Region";
                toolStripRecord.Text = _SelectedRegion.Name;
                toolStripStatus.Text = string.Empty;
            }
            else if (_SelectedRegion == null && _SelectedSector != null)
            {
                toolStripTab.Text = "Sector";
                toolStripRecord.Text = _SelectedSector.Description;
                toolStripStatus.Text = string.Empty;
            }
            else
            {
                toolStripTab.Text = "Region";
                toolStripRecord.Text = "None Selected";
                toolStripStatus.Text = string.Empty;
            }

            //Disable the Sector Save Button 

            butLogicalSectorSave.Enabled = false;
        }

        /// <summary>
        /// Populates the _Regions variable with all regions from the Groundframe Database
        /// </summary>
        private void PopulateRegionsCollection()
        {
            this._Regions = new RegionCollection();
        }

        /// <summary>
        /// Populates the _SystemSectors variable with all System Sectors from the Groundframe Database
        /// </summary>
        private void PopulateSystemSectorCollection()
        {
            Common.SystemSectors = new SystemSectorCollection();
        }

        /// <summary>
        /// Populates the _Sectors variable with all Sectors from the Groundframe Database
        /// </summary>
        private void PopulateSectorCollection()
        {
            this._Sectors = new SectorCollection();
        }

        /// <summary>
        /// Refreshs the listViewRegions List View
        /// </summary>
        private void RefreshRegionListView()
        {
            listViewRegions.BeginUpdate();
            listViewRegions.Items.Clear();

            foreach (Region _Region in this._Regions)
            {
                listViewRegions.Items.Add(GenerateRegionListViewItem(_Region));
            }

            listViewRegions.EndUpdate();
        }

        /// <summary>
        /// Generates a ListViewItem for the supplied region object
        /// </summary>
        /// <param name="Region"></param>
        /// <returns></returns>
        private ListViewItem GenerateRegionListViewItem(Region Region)
        {
            //Set up List View Item
            ListViewItem Item = new ListViewItem(Region.Name);
            Item.Tag = Region;

            //Add Start YMDV
            Item.SubItems.Add(Region.RecordStartYMDV.Date.ToString(this._UserCulture.DateTimeFormat.ShortDatePattern));
            //Add End YMDV
            if (Region.RecordEndYMDV.Value != 0) { Item.SubItems.Add(Region.RecordEndYMDV.Date.ToString(this._UserCulture.DateTimeFormat.ShortDatePattern)); };

            return Item;
        }

        /// <summary>
        /// Initialises a new Region
        /// </summary>
        private void NewSector()
        {
            //Check that an existing sector remains unsaved

            if (_SectorHasChanged == true)
            {
                if (MessageBox.Show("You have unsaved changes. Are you sure you want to continue?", "GroundFrame", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    InitialiseNewSector();
                }

            }
            else
            {
                InitialiseNewSector();
            }
        }

        /// <summary>
        /// Sets up the sector details controls ready for editing
        /// </summary>
        private void EditSector()
        {
            this.txtLogicalSectorDescription.Text = _SelectedSector.Description;
            this.dateTimeLogicalSectorStartYMDV.CustomFormat = _UserCulture.DateTimeFormat.ShortDatePattern;
            this.dateTimeLogicalSectorStartYMDV.Value = _SelectedSector.RecordStartYMDV.Date;

            if (_SelectedSector.RecordEndYMDV.Value == 0)
            {
                this.dateTimeLogicalSectorEndYMDV.Checked = false;
            }
            else
            {
                this.dateTimeLogicalSectorStartYMDV.CustomFormat = _UserCulture.DateTimeFormat.ShortDatePattern;
                this.dateTimeLogicalSectorEndYMDV.Value = _SelectedSector.RecordEndYMDV.Date;
            }

            butLogicalSectorSave.Enabled = false;

            _SectorHasChanged = false;
            _SectorNeedsYMDVValidation = false;

            //Initialise Status Bar

            toolStripTab.Text = "Sector";
            toolStripRecord.Text = _SelectedSector.Description;
            toolStripStatus.Text = string.Empty;
        }

        /// <summary>
        /// Sets up the region details controls ready for editing
        /// </summary>
        private void EditRegion()
        {
            this.txtLogicalRegionName.Text = _SelectedRegion.Name;
            this.txtLogicalRegionDescription.Text = _SelectedRegion.Description;
            this.dateTimeLogicalRegionStartYMDV.CustomFormat = _UserCulture.DateTimeFormat.ShortDatePattern;
            this.dateTimeLogicalRegionStartYMDV.Value = _SelectedRegion.RecordStartYMDV.Date;

            if (_SelectedRegion.RecordEndYMDV.Value == 0)
            {
                this.dateTimeLogicalRegionEndYMDV.Checked = false;
            }
            else
            {
                this.dateTimeLogicalRegionEndYMDV.CustomFormat = _UserCulture.DateTimeFormat.ShortDatePattern;
                this.dateTimeLogicalRegionEndYMDV.Value = _SelectedRegion.RecordEndYMDV.Date;
            }

            butLogicalRegionSave.Enabled = false;

            _RegionHasChanged = false;
            _RegionNeedsYMDVValidation = false;

            //Initialise Status Bar

            toolStripTab.Text = "Region";
            toolStripRecord.Text = _SelectedRegion.Name;
            toolStripStatus.Text = string.Empty;
        }

        /// <summary>
        /// Validates the region data.
        /// </summary>
        /// <returns>False = Errors have been found | True No Errors Found</returns>
        private bool ValidateRegionData()
        {
            if (_SelectedRegion.ValidateData().Count > 0)
            {
                //Errors have been found. Show list of errors and then return false;
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validates the sector data.
        /// </summary>
        /// <returns>False = Errors have been found | True No Errors Found</returns>
        private bool ValidateSectorData()
        {
            if (_SelectedSector.ValidateData().Count > 0)
            {
                //Errors have been found. Show list of errors and then return false;
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Saves the selected sector to the GroundFrame database if no errors are found.
        /// </summary>
        private void SaveSectorToDB()
        {
            if (ValidateSectorData())
            {
                try
                {
                    //Save to the DB
                    _SelectedSector.SaveToDB();

                    //If it's a new region add to the collection

                    if (_Sectors.Count(x => x.ID == _SelectedRegion.ID) == 0)
                    {
                        _Sectors.Add(_SelectedSector);
                    };

                    //Refresh the List View
                    RefreshSectorListView();

                    //Select the region
                    SelectCurrentSectorInListView();

                    //Reset the Change Flag
                    _RegionHasChanged = false;

                    //Initialise Status Bar

                    toolStripTab.Text = "Sector";
                    toolStripRecord.Text = _SelectedSector.Description;
                    toolStripStatus.Image = Resources.tick;
                    toolStripStatus.Text = string.Format("Record Saved Successfully at {0} (UTC)", DateTime.UtcNow.ToString());
                }
                catch (Exception Ex)
                {
                    //Initialise Status Bar
                    toolStripTab.Text = "Sector";
                    toolStripStatus.Image = Resources.error;
                    GFResponse Reponse = Audit.WriteLog(new GFResponse(AuditType.Error, "The application experienced an error at frmMain.SaveSectorToDB()", Ex));
                    toolStripStatus.Text = string.Format("Error:- Please see log ID {0} for details", Reponse.AuditID);
                }

            }
            else
            {
                toolStripTab.Text = "Sector";
                toolStripStatus.Image = Resources.warning;
                toolStripStatus.Text = "Validation errors found. Please review";

                frmValidationErrors ErrorsForm = new frmValidationErrors(_SelectedRegion.ValidateData(), string.Format(@"Sector {0} Data Validation Errors", _SelectedSector.Description));
                ErrorsForm.ShowDialog();
            };
        }

        /// <summary>
        /// Saves the selected region to the GroundFrame database if no errors are found.
        /// </summary>
        private void SaveRegionToDB()
        {
            if (ValidateRegionData())
            {
                try
                {
                    //Save to the DB
                    _SelectedRegion.SaveToDB();

                    //If it's a new region add to the collection

                    if (_Regions.Count(x => x.ID == _SelectedRegion.ID) == 0)
                    {
                        _Regions.Add(_SelectedRegion);
                    };

                    //Refresh the List View
                    RefreshRegionListView();

                    //Select the region
                    SelectCurrentRegionInListView();

                    //Reset the Change Flag
                    _RegionHasChanged = false;

                    //Initialise Status Bar

                    toolStripTab.Text = "Region";
                    toolStripRecord.Text = _SelectedRegion.Name;
                    toolStripStatus.Image = Resources.tick;
                    toolStripStatus.Text = string.Format("Record Saved Successfully at {0} (UTC)", DateTime.UtcNow.ToString());
                }
                catch (Exception Ex)
                {
                    //Initialise Status Bar
                    toolStripTab.Text = "Region";
                    toolStripStatus.Image = Resources.error;

                    GFResponse Response = Audit.WriteLog(new GFResponse(AuditType.Error, "GF Data Editor experienced an error tring to save a region", Ex));
                    toolStripStatus.Text = string.Format("Error:- Please see log ID {0} for details", Response.AuditID);
                }

            }
            else
            {
                toolStripTab.Text = "Region";
                toolStripStatus.Image = Resources.warning;
                toolStripStatus.Text = "Validation errors found. Please review";
                frmValidationErrors ErrorsForm = new frmValidationErrors(_SelectedRegion.ValidateData(), string.Format(@"Region {0} Data Validation Errors", _SelectedRegion.Name));
                ErrorsForm.ShowDialog();
            };
        }

        /// <summary>
        /// Selects the current selected sector in the Sector List View
        /// </summary>
        private void SelectCurrentSectorInListView()
        {
            //Loop through each item and select in the list view
            foreach (ListViewItem Item in listViewSectors.Items)
            {
                if ((Sector)Item.Tag == _SelectedSector)
                {
                    listViewSectors.Items[Item.Index].Selected = true;
                }
            }
        }

        /// <summary>
        /// Selects the current selected region in the Region List View
        /// </summary>
        private void SelectCurrentRegionInListView()
        {
            //Loop through each item and select in the list view
            foreach (ListViewItem Item in listViewRegions.Items)
            {
                if ((Region)Item.Tag == _SelectedRegion)
                {
                    listViewRegions.Items[Item.Index].Selected = true;
                }
            }
        }

        /// <summary>
        /// Initialises a new Region
        /// </summary>
        private void NewRegion()
        {
            //Check that an existing region remains unsaved

            if (_RegionHasChanged == true)
            {
                if (MessageBox.Show("You have unsaved changes. Are you sure you want to continue?", "GroundFrame", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    InitialiseNewRegion();
                }

            }
            else
            {
                InitialiseNewRegion();
            }
        }

        /// <summary>
        /// Initialises the sector controls for a new sector
        /// </summary>
        private void InitialiseNewSector()
        {
            //Initialise Controls

            listViewSectors.SelectedItems.Clear();
            _SelectedSector = new Sector();
            txtLogicalSectorDescription.Text = string.Empty;
            dateTimeLogicalSectorStartYMDV.Value = DateTime.Today; //Default to 01/01/1948 which was when BR was first privatised
            _SelectedRegion.RecordStartYMDV = new YMDV(dateTimeLogicalSectorStartYMDV.Value);
            dateTimeLogicalSectorStartYMDV.Checked = true;
            dateTimeLogicalSectorEndYMDV.Checked = false;

            //Set Focus

            txtLogicalSectorDescription.Focus();

            //Set changed flag to false

            _SectorHasChanged = false;

            //Initialise Status Bar

            toolStripTab.Text = "Sector";
            toolStripRecord.Text = "New Sector";
            toolStripStatus.Text = string.Empty;
        }

        /// <summary>
        /// Initialises the region controls for a new region
        /// </summary>
        private void InitialiseNewRegion()
        {
            //Initialise Controls

            listViewRegions.SelectedItems.Clear();
            _SelectedRegion = new Region();
            txtLogicalRegionName.Text = string.Empty;
            txtLogicalRegionDescription.Text = string.Empty;
            dateTimeLogicalRegionStartYMDV.Value = new DateTime(1948,1,1); //Default to 01/01/1948 which was when BR was first privatised
            _SelectedRegion.RecordStartYMDV = new YMDV(dateTimeLogicalRegionStartYMDV.Value);
            dateTimeLogicalRegionStartYMDV.Checked = true;
            dateTimeLogicalRegionEndYMDV.Checked = false;

            //Set Focus

            txtLogicalRegionName.Focus();

            //Set changed flag to false

            _RegionHasChanged = false;

            //Initialise Status Bar

            toolStripTab.Text = "Region";
            toolStripRecord.Text = "New Region";
            toolStripStatus.Text = string.Empty;
        }

        /// <summary>
        /// Populates the System Sectors Combo
        /// </summary>
        private void PopulateSystemSectorsCombo()
        {
            comboLogicalSystemSectors.SelectedIndexChanged -= comboLogicalSystemSectors_SelectedIndexChanged;
            comboLogicalSystemSectors.DataSource = Common.SystemSectors.OrderBy(x => x.Name).ToList();
            comboLogicalSystemSectors.DisplayMember = "Name";
            comboLogicalSystemSectors.SelectedIndexChanged += comboLogicalSystemSectors_SelectedIndexChanged;

            if (comboLogicalSystemSectors.SelectedItem != null)
            {
                _SelectedSystemSector = (SystemSector)comboLogicalSystemSectors.SelectedItem;
                RefreshSectorListView();
            }
        }

        /// <summary>
        /// Configures the EdutoSystemObject form for a System Sector, opens and handles the return
        /// </summary>
        /// <param name="SysSector"></param>
        /// <param name="FormText"></param>
        /// <param name="Edit"></param>
        private void OpenSystemSectorForm(SystemSector SysSector, string FormText, bool Edit)
        {
            //Configure the form
            frmEditSystemObject SystemSectorForm = new frmEditSystemObject(SysSector, FormText, Edit);
            SystemSectorForm.ShowDialog();

            //Grab the last edited system sector
            SystemSector LastSector = (SystemSector)SystemSectorForm.SystemObject;

            //Refresh the SystemSectos variable and refresh the combo
            Common.SystemSectors = new SystemSectorCollection();
            PopulateSystemSectorsCombo();

            //Set comboLogicalSystemSectors selected item to be the last item edited
            if (LastSector.ID != 0)
            {
                var MatchingItem = comboLogicalSystemSectors.Items.Cast<SystemSector>().FirstOrDefault(z => z.ID == LastSector.ID);
                comboLogicalSystemSectors.SelectedItem = MatchingItem;
            }
        }

        /// <summary>
        /// Populates Sectors List View
        /// </summary>
        private void RefreshSectorListView()
        {
            listViewSectors.Items.Clear();

            foreach (Sector _Sector in this._Sectors.Where(x => x.Code.ID == _SelectedSystemSector.ID).OrderBy(o => o.Description).ToList())
            {
                listViewSectors.Items.Add(GetListViewItemFromSector(_Sector));
            }
        }

        /// <summary>
        /// Returns a ListViewItem for the supplied sector
        /// </summary>
        /// <param name="Sector"></param>
        /// <returns></returns>
        private ListViewItem GetListViewItemFromSector(Sector Sector)
        {
            ListViewItem Item = new ListViewItem(Sector.Description);

            //Add Start YMDV
            Item.SubItems.Add(Sector.RecordStartYMDV.Date.ToString(this._UserCulture.DateTimeFormat.ShortDatePattern));
            //Add End YMDV
            if (Sector.RecordEndYMDV.Value != 0) { Item.SubItems.Add(Sector.RecordEndYMDV.Date.ToString(this._UserCulture.DateTimeFormat.ShortDatePattern)); };

            Item.Tag = Sector;
            
            return Item;
        }

        #endregion Methods

        #region Events

        private void butLogicalRegionSave_Click(object sender, EventArgs e)
        {
            SaveRegionToDB();
        }


        private void butLogicalSectorSave_Click(object sender, EventArgs e)
        {
            SaveSectorToDB();
        }

        private void listViewRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRegions.SelectedItems.Count > 0)
            {
                this._SelectedRegion = (Region)listViewRegions.SelectedItems[0].Tag;
                EditRegion();
            }
        }

        private void txtLogicalRegionName_TextChanged(object sender, EventArgs e)
        {
            //Update Region object
            this._SelectedRegion.Name = txtLogicalRegionName.Text;

            //Flag Region has changed
            this._RegionHasChanged = true;

            //Disable the Save button if the Region name is blank.

            if (string.IsNullOrEmpty(txtLogicalRegionName.Text))
            {
                butLogicalRegionSave.Enabled = false;
            }
            else
            {
                butLogicalRegionSave.Enabled = true;
            }
        }

        private void txtLogicalRegionDescription_TextChanged(object sender, EventArgs e)
        {
            //Update Region object
            this._SelectedRegion.Description = txtLogicalRegionDescription.Text;
            //Enable save button
            butLogicalRegionSave.Enabled = true;
            //Update change flag
            this._RegionHasChanged = true;
        }

        private void dateTimeLogicalRegionStartYMDV_ValueChanged(object sender, EventArgs e)
        {
            //Set the format string so the date is visible
            this.dateTimeLogicalRegionStartYMDV.CustomFormat = _UserCulture.DateTimeFormat.ShortDatePattern;
            //Update Region object
            _SelectedRegion.RecordStartYMDV = new YMDV(dateTimeLogicalRegionStartYMDV.Value);
            //Enable save button
            butLogicalRegionSave.Enabled = true;
            //Update change flag
            this._RegionHasChanged = true;
            //Update requires YMDV validation flag
            this._RegionNeedsYMDVValidation = true;
        }


        private void dateTimeLogicalSectorStartYMDV_ValueChanged(object sender, EventArgs e)
        {
            //Set the format string so the date is visible
            this.dateTimeLogicalSectorStartYMDV.CustomFormat = _UserCulture.DateTimeFormat.ShortDatePattern;
            //Update Sector object
            _SelectedSector.RecordStartYMDV = new YMDV(dateTimeLogicalSectorStartYMDV.Value);
            //Enable save button
            butLogicalSectorSave.Enabled = true;
            //Update change flag
            this._SectorHasChanged = true;
            //Update requires YMDV validation flag
            this._SectorNeedsYMDVValidation = true;
        }

        private void dateTimeLogicalRegionEndYMDV_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimeLogicalRegionEndYMDV.Checked == true)
            {
                //Picker is checked so set the end YMDV
                _SelectedRegion.RecordEndYMDV = new YMDV(dateTimeLogicalRegionEndYMDV.Value);
            }
            else
            {
                //Nothing Selected to set to default YMDV
                _SelectedRegion.RecordEndYMDV = new YMDV(0);
            }

            //Enable save button
            butLogicalRegionSave.Enabled = true;
            //Update change flag
            this._RegionHasChanged = true;

            this._RegionNeedsYMDVValidation = true; 
        }


        private void dateTimeLogicalSectorEndYMDV_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimeLogicalSectorEndYMDV.Checked == true)
            {
                //Picker is checked so set the end YMDV
                _SelectedSector.RecordEndYMDV = new YMDV(dateTimeLogicalSectorEndYMDV.Value);
            }
            else
            {
                //Nothing Selected to set to default YMDV
                _SelectedSector.RecordEndYMDV = new YMDV(0);
            }

            //Enable save button
            butLogicalSectorSave.Enabled = true;
            //Update change flag
            this._SectorHasChanged = true;

            this._SectorNeedsYMDVValidation = true;
        }

        private void butLogicalRegionNew_Click(object sender, EventArgs e)
        {
            NewRegion();
        }


        private void butLogicalSectorNew_Click(object sender, EventArgs e)
        {
            NewSector();
        }
        
        private void comboLogicalSystemSectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLogicalSystemSectors.SelectedItem != null)
            {
                _SelectedSystemSector = (SystemSector)comboLogicalSystemSectors.SelectedItem;
                RefreshSectorListView();
            }
        }


        private void listViewSectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripTab.Text = "Sector";

            if (listViewSectors.SelectedItems.Count == 0)
            {
                toolStripRecord.Text = "None Selected";
                toolStripStatus.Text = string.Empty;
            }
            else
            {
                this._SelectedSector = (Sector)listViewSectors.SelectedItems[0].Tag;
                EditSector();
            }
        }

        private void txtLogicalSectorDescription_TextChanged(object sender, EventArgs e)
        {
            //Update Sector object
            this._SelectedSector.Description = txtLogicalSectorDescription.Text;

            //Flag Sector has changed
            this._SectorHasChanged = true;

            //Disable the Save button if the Region name is blank.

            if (string.IsNullOrEmpty(txtLogicalSectorDescription.Text))
            {
                butLogicalSectorSave.Enabled = false;
            }
            else
            {
                butLogicalSectorSave.Enabled = true;
            }
        }

        private void linkLogicalNewSystemSector_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenSystemSectorForm(new SystemSector(), "New System Sector", false);
        }

        private void linkLogicalEditSystemSector_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboLogicalSystemSectors.SelectedItem != null)
            {
                SystemSector _Sector = (SystemSector)comboLogicalSystemSectors.SelectedItem;

                OpenSystemSectorForm(_Sector, "System Sector", true);
            }
        }

        #endregion Events

    }
}
