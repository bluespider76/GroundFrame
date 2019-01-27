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

namespace Horizon4.GFDataEditor
{
    public partial class frmEditSystemObject : Form
    {
        #region Private Variables

        private ISystemObject _SystemObject; //Private variable to store the object
        private bool _DescriptionActive;
        private bool _HasChanges; //Private variable to store a flag which indicates whether there are unsaved changes
        private string _FormText;
        private bool _IsEdit; //Private variable to store whether form is in edit more as opposed to "new" mode

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
        /// Gets the System Object edited by the form
        /// </summary>
        public ISystemObject SystemObject { get { return this._SystemObject; } }

        #endregion Properties

        #region Constructors

        public frmEditSystemObject()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the System Object edited by the form
        /// </summary>
        public frmEditSystemObject(ISystemObject SystemObject, string FormText, bool Edit = false)
        {
            InitializeComponent();
            _IsEdit = Edit;
            this._SystemObject = SystemObject;
            _FormText = FormText;
            this.Text = _FormText;
            InitialiseForm(Edit);

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

        private void InitialiseForm(bool Edit)
        {
            _IsEdit = Edit;
            _DescriptionActive = true;

            //Determine whether the description is active
            DescriptionActive();

            if (_DescriptionActive)
            {
                lblDescription.Visible = true;
                txtDescription.Visible = true;
                txtDescription.Text = _SystemObject.Description;
            }
            else
            {
                lblDescription.Visible = false;
                txtDescription.Visible = false;
            }

            txtName.Text = _SystemObject.Name;

            if (!string.IsNullOrEmpty(_SystemObject.Name))
            {
                txtName.Enabled = false;
            }
            else
            {
                txtName.Enabled = true;
            }

            ConfigureSaveButton();

            HasChanges = false;
        }

        /// <summary>
        /// Sets the _DescriptionActive flag to indicate whether the description controls should be active.
        /// </summary>
        private void DescriptionActive()
        {
            PropertyInfo[] Properties = _SystemObject.GetType().GetProperties();

            foreach (PropertyInfo Property in Properties)
            {
                if (Property.Name == "Description")
                {
                    object[] attributes = Property.GetCustomAttributes(false);

                    foreach (ObsoleteAttribute attribute in attributes.OfType<ObsoleteAttribute>())
                    {
                        _DescriptionActive = false;
                    }
                }
            }
        }

        /// <summary>
        /// Configures the Save button
        /// </summary>
        private void ConfigureSaveButton()
        {
            //If edit mode and no description don't enable the Save buttons
            if ((_IsEdit && _DescriptionActive) && !string.IsNullOrEmpty(_SystemObject.Name))
            {
                butSave.Enabled = true;
                butSaveAndNew.Enabled = true;
            }
            else if ((_IsEdit && _DescriptionActive) && string.IsNullOrEmpty(_SystemObject.Name))
            {
                butSave.Enabled = false;
                butSaveAndNew.Enabled = false;
            }
            else if (_IsEdit && (!_DescriptionActive))
            {
                butSave.Enabled = false;
                butSaveAndNew.Enabled = false;
            }
            else if ((!_IsEdit) && string.IsNullOrEmpty(_SystemObject.Name))
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
            DBResponse Response; //Variable to store the audit log ID

            try
            {
                //Save the System Object to the Database
                Response = _SystemObject.SaveToDB();

                //If no exception then nothing has errored.
                if (Response.Exception == null)
                {
                    this.Text = "System Sector";
                    txtName.Enabled = false;
                    HasChanges = false;
                }
                else
                {
                    //Something has errored when saving the object. Show a nice error.
                    MessageBox.Show(string.Format("An error has occured trying to save SystemSector {0} | ErrorID {1} : - {2}", _SystemObject.Name, Response.LogID, Response.Exception.GetCleanMessage()), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }


            }
            catch (Exception Ex)
            {
                //This is unexpected. Log the error and quit the application
                DBResponse ExceptionResonse = Audit.WriteLog(AuditType.Fatal, string.Format("An unexpected error has occured at frmEditSystemObject.SaveToDB:- {0}", Ex.GetAuditMessage()));
                MessageBox.Show(string.Format("An unexpected error has occured. Please contact the administrator quoting Log ID {0}", ExceptionResonse.LogID), CommonDataEditor.GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();  
            }
        }

        /// <summary>
        /// Instantiates a new instance of the system object and sets up thr form
        /// </summary>
        private void NewObject()
        {
            Type SystemObjectType = _SystemObject.GetType();
            _SystemObject = (ISystemObject)Activator.CreateInstance(SystemObjectType);
            InitialiseForm(true);
            this.Text = string.Format(@"New {0}", _FormText);
            txtName.Focus();
        }

        #endregion Methods

        #region Events

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            _SystemObject.Name = txtName.Text;
            ConfigureSaveButton();
            HasChanges = true;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            _SystemObject.Description = txtDescription.Text;
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
            NewObject();
        }

        #endregion Events
    }
}
