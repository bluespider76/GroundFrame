using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Horizon4.GF;
using Horizon4.GFDataEditor.Properties;
using Horizon4.GF.RollingStock;
using System.ComponentModel;

namespace Horizon4.GFDataEditor
{
    public partial class frmMain : Form
    {
        #region Private Variables

        private TractionClassCollection _TractionClasses; //Private variable to store the available traction classes
        private TractionClass _SelectedTractionClass; //Private variable to store the selected traction class
        bool _TractionClassHasChanged; //Private variable to store whether the Traction Class has changed

        #endregion Private Variables

        #region Properties


        /// <summary>
        /// Gets or Sets a flag to indicate the form has been edited
        /// </summary>
        public bool TractionClassHasChanged
        {
            get { return _TractionClassHasChanged; }
            set
            {
                _TractionClassHasChanged = value;
                HandleTractionClassChanged();

            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Handles the Traction Class Changed Flag being changed
        /// </summary>
        private void HandleTractionClassChanged()
        {
            //Set up Tab Name
            if (_TractionClassHasChanged)
            {
                tabControlMain.TabPages[2].Text = "Traction *";
            }
            else
            {
                tabControlMain.TabPages[2].Text = "Traction";
            }
        }

        private void InitialiseTractionTab()
        {
            PopulateTractionTypeCombo();

            //Set up the status bar
            if (_SelectedTractionClass != null)
            {
                toolStripTab.Text = "Traction";
                toolStripRecord.Text = _SelectedTractionClass.Name;
                toolStripStatus.Text = string.Empty;
            }
            else
            {
                toolStripTab.Text = "Traction";
                toolStripRecord.Text = "None Selected";
                toolStripStatus.Text = string.Empty;
            }

            comboTractionType.SelectedIndex = 0;
            HandleTractionTypeComboSelectionChange();
        }

        /// <summary>
        /// Populates the traction type combo
        /// </summary>
        private void PopulateTractionTypeCombo()
        {
            comboTractionType.SelectedIndexChanged -= comboTractionType_SelectedIndexChanged;
            comboTractionType.DataSource = (TractionType[])Enum.GetValues(typeof(TractionType));
            comboTractionType.SelectedIndexChanged += comboTractionType_SelectedIndexChanged;
            comboTractionType.SelectedIndex = 0;

            comboTractionTractionClassType.SelectedIndexChanged -= comboTractionTractionClassType_SelectedIndexChanged;
            comboTractionTractionClassType.DataSource = (TractionType[])Enum.GetValues(typeof(TractionType));
            comboTractionTractionClassType.SelectedIndexChanged += comboTractionTractionClassType_SelectedIndexChanged;
            comboTractionTractionClassType.SelectedIndex = 0;            
        }

        private void PopulateClassListView()
        {
            listViewTractionClasses.Items.Clear();

            foreach (TractionClass Class in _TractionClasses.OrderBy(x => x.Name))
            {
                listViewTractionClasses.Items.Add(GetListViewItemFromTractionClass(Class));
            }

            if (listViewTractionClasses.Items.Count == 0)
            {
                toolStripMenuItemProfile.Enabled = false;
            }
            else
            {
                toolStripMenuItemProfile.Enabled = true;
            }

        }

        /// <summary>
        /// Handles changing the traction type combo selection
        /// </summary>
        private void HandleTractionTypeComboSelectionChange()
        {
            if (comboTractionType.SelectedItem != null)
            {
                _TractionClasses = new TractionClassCollection((TractionType)comboTractionType.SelectedItem);
            }

            PopulateClassListView();

            if (listViewTractionClasses.Items.Count == 0)
            {
                panelTractionClassDetails.Enabled = false;
            }
            else
            {
                panelTractionClassDetails.Enabled = true;
                listViewTractionClasses.Items[0].Selected = true;
            }
        }

        /// <summary>
        /// Generates a List View Item fro the Supplied Traction Class
        /// </summary>
        /// <param name="Class"></param>
        /// <returns></returns>
        private ListViewItem GetListViewItemFromTractionClass(TractionClass Class)
        {
            ListViewItem Item = new ListViewItem(Class.Name);
            Item.SubItems.Add(Class.RA.ToString());
            Item.SubItems.Add(Class.InServiceStartYMDV.DisplayDate);
            Item.SubItems.Add(Class.InServiceEndYMDV.DisplayDate);
            Item.Tag = Class;

            return Item;
        }
        
        /// <summary>
        /// Handles the Traction Class List View Selection Change
        /// </summary>
        private void HandleTractionClassListViewSelection()
        {
            if (listViewTractionClasses.SelectedItems.Count != 0)
            {
                _SelectedTractionClass = (TractionClass)listViewTractionClasses.SelectedItems[0].Tag;
                EditTractionClass(true);
                toolStripMenuItemProfile.Enabled = true;
            }
            else
            {
                toolStripMenuItemProfile.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the editing the selected Traction Class 
        /// </summary>
        private void EditTractionClass(bool Edit)
        {
            if (Edit)
            {
                //Edit existing record
                txtTractionTractionClassName.Text = _SelectedTractionClass.Name;
                txtTractionTractionClassDescription.Text = _SelectedTractionClass.Description;
                dateTimeTractionTractionClassStartDate.Value = _SelectedTractionClass.InServiceStartYMDV.Date;

                dateTimeTractionTractionClassEndDate.ValueChanged -= dateTimeTractionTractionClassEndDate_ValueChanged;

                if (_SelectedTractionClass.InServiceEndYMDV.Value == 0)
                {
                    dateTimeTractionTractionClassEndDate.Checked = false;
                    dateTimeTractionTractionClassEndDate.CustomFormat = " ";
                    dateTimeTractionTractionClassEndDate.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dateTimeTractionTractionClassEndDate.Checked = true;
                    dateTimeTractionTractionClassEndDate.CustomFormat = _UserCulture.DateTimeFormat.ShortDatePattern;
                    dateTimeTractionTractionClassEndDate.Value = _SelectedTractionClass.InServiceEndYMDV.Date;
                }

                dateTimeTractionTractionClassEndDate.ValueChanged += dateTimeTractionTractionClassEndDate_ValueChanged;

                comboTractionTractionClassType.SelectedItem = _SelectedTractionClass.TractionType;
                numericUpDownTractionTractionClassLength.Value = _SelectedTractionClass.Length.Meters;
                numericUpDownTractionTractionClassRA.Value = _SelectedTractionClass.RA;

                if (_SelectedTractionClass.ParentClass != null)
                {
                    lblTractionTractionClassParent.Visible = true;
                    lblTractionTractionClassParent.Text = string.Format(@"Parent Class: {0}", _SelectedTractionClass.ParentClass.Name);
                }
                else
                {
                    lblTractionTractionClassParent.Visible = false;
                }

                toolStripTab.Text = "Traction Class";
                toolStripRecord.Text = _SelectedTractionClass.Name;
                toolStripStatus.Text = string.Empty;

                TractionClassHasChanged = false;
            }
            else
            {
                EditTractionClass(true);
                panelTractionClassDetails.Enabled = true;
                toolStripTab.Text = "Traction Class";
                toolStripRecord.Text = "New";
                toolStripStatus.Text = string.Empty;

                txtTractionTractionClassName.Focus();
            }
        }

        private void NewTractionClass(TractionClass ParentClass)
        {
            if (TractionClassHasChanged)
            {
                if (MessageBox.Show("You have unsaved traction class changes are you sure you want to continue?", "GroundFrame Data Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            if (comboTractionType.SelectedItem == null)
            {
                MessageBox.Show("You must select a traction type to continue.", "GroundFrame Data Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (ParentClass == null)
            {
                TractionType NewTractionType = (TractionType)comboTractionType.SelectedItem;
                this._SelectedTractionClass = new TractionClass(NewTractionType);
            }
            else
            {
                this._SelectedTractionClass = new TractionClass(ParentClass);
            }

            EditTractionClass(false);
        }

        private void EditTractionProfile()
        {
            frmTractionClassProfile ProfileForm = new frmTractionClassProfile(this._SelectedTractionClass);
            ProfileForm.ShowDialog(this);
        }

        #endregion Methods

        #region Events

        private void comboTractionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleTractionTypeComboSelectionChange();
        }

        private void listViewTractionClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleTractionClassListViewSelection();
        }

        private void comboTractionTractionClassType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimeTractionTractionClassEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimeTractionTractionClassEndDate.Checked == true && this._SelectedTractionClass.InServiceEndYMDV.Value == 0)
            {
                dateTimeTractionTractionClassEndDate.CustomFormat = _UserCulture.DateTimeFormat.ShortDatePattern;
                dateTimeTractionTractionClassEndDate.Format = DateTimePickerFormat.Short;
                dateTimeTractionTractionClassEndDate.Value = DateTime.Today;
                this._SelectedTractionClass.InServiceEndYMDV = new YMDV(dateTimeTractionTractionClassEndDate.Value);
                TractionClassHasChanged = true;
            }
            else if (dateTimeTractionTractionClassEndDate.Checked == false && this._SelectedTractionClass.InServiceEndYMDV.Value != 0)
            {
                dateTimeTractionTractionClassEndDate.CustomFormat = " ";
                dateTimeTractionTractionClassEndDate.Format = DateTimePickerFormat.Custom;
                this._SelectedTractionClass.InServiceEndYMDV = new YMDV(0);
                TractionClassHasChanged = true;
            }
            else
            {
                this._SelectedTractionClass.InServiceEndYMDV = new YMDV(dateTimeTractionTractionClassEndDate.Value);
                TractionClassHasChanged = true;
            }

            saveTractionClassToolStripMenuItem.Enabled = true;
        }


        private void txtTractionTractionClassName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTractionTractionClassName.Text))
            {
                MessageBox.Show("The Traction Class name cannot be null", Properties.Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                saveTractionClassToolStripMenuItem.Enabled = false;
                e.Cancel = true;
            }
        }

        private void txtTractionTractionClassName_TextChanged(object sender, EventArgs e)
        {
            this._SelectedTractionClass.Name = txtTractionTractionClassName.Text;
            saveTractionClassToolStripMenuItem.Enabled = true;
            TractionClassHasChanged = true;
        }

        private void txtTractionTractionClassDescription_TextChanged(object sender, EventArgs e)
        {
            this._SelectedTractionClass.Description = txtTractionTractionClassDescription.Text;
            TractionClassHasChanged = true;
        }

        private void dateTimeTractionTractionClassStartDate_ValueChanged(object sender, EventArgs e)
        {
            this._SelectedTractionClass.InServiceStartYMDV = new YMDV(dateTimeTractionTractionClassStartDate.Value);
            saveTractionClassToolStripMenuItem.Enabled = true;
            TractionClassHasChanged = true;
        }

        private void dateTimeTractionTractionClassStartDate_Validating(object sender, CancelEventArgs e)
        {
            if (dateTimeTractionTractionClassEndDate.Checked == true && dateTimeTractionTractionClassEndDate.Value < dateTimeTractionTractionClassStartDate.Value)
            {
                MessageBox.Show("The start date cannot be before the end date", Properties.Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                saveTractionClassToolStripMenuItem.Enabled = false;
                e.Cancel = true;
            }
        }

        private void dateTimeTractionTractionClassEndDate_Validating(object sender, CancelEventArgs e)
        {
            if (dateTimeTractionTractionClassEndDate.Checked == true && dateTimeTractionTractionClassEndDate.Value < dateTimeTractionTractionClassStartDate.Value)
            {
                MessageBox.Show("The start date cannot be before the end date", Properties.Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                saveTractionClassToolStripMenuItem.Enabled = false;
                e.Cancel = true;
            }
        }

        private void tractionClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTractionClass(null);
        }


        private void contextMenuStripTractionClassList_Opening(object sender, CancelEventArgs e)
        {
            if (listViewTractionClasses.SelectedItems.Count == 0 || this._SelectedTractionClass.ID == 0)
            {
                contextMenuStripTractionClassList.Enabled = false;
            }
            else
            {
                contextMenuStripTractionClassList.Enabled = true;

                TractionClass SelectedTractionClass = (TractionClass)listViewTractionClasses.SelectedItems[0].Tag;

                if (SelectedTractionClass.ParentClass != null)
                {
                    contextMenuStripTractionClassListItem1.Enabled = false;
                }
                else
                {
                    contextMenuStripTractionClassListItem1.Enabled = true;
                }
            }
        }


        private void contextMenuStripTractionClassListItem1_Click(object sender, EventArgs e)
        {
            TractionClass SelectedTractionClass = (TractionClass)listViewTractionClasses.SelectedItems[0].Tag;

            NewTractionClass(SelectedTractionClass);           
        }


        private void listViewTractionClasses_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewTractionClasses.SelectedItems.Count == 0 || this._SelectedTractionClass.ID == 0)
            {
                toolStripMenuItemProfile.Enabled = false;
            }
            else
            {
                toolStripMenuItemProfile.Enabled = true;
            }
        }

        private void toolStripMenuItemProfile_Click(object sender, EventArgs e)
        {
            EditTractionProfile();
        }

        #endregion Events
    }
}
