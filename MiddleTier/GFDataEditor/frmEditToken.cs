using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Horizon4.GF;
using Horizon4.GF.Network;
using System.Reflection;

namespace Horizon4.GFDataEditor
{
    public partial class frmEditToken : Form
    {
        #region Private Variables

        private Token _Token; //Private variable to store the token
        private bool _HasChanges = false; //Private variable to store a flag which indicates whether there are unsaved changes
        private bool _IsEdit; //Private variable to store whether form is in edit more as opposed to "new" mode

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets or sets whether a change has been detected.
        /// </summary>
        public bool HasChanges
        {
            get { return this._HasChanges; }

            set { 
                    this._HasChanges = value;
                    ConfigureHasChanges();
            } 
        }

        /// <summary>
        /// Gets the Token being edited
        /// </summary>
        public Token Token { get { return this._Token; } }
        
        #endregion Properties

        #region Constructors

        public frmEditToken()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the System Object edited by the form
        /// </summary>
        public frmEditToken(Token Token, bool Edit)
        {
            InitializeComponent();
            this._Token = Token;
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
                this.Text = "Token *";
            }
            else
            {
                this.Text = "Token";
            }
        }

        private void InitialiseForm(bool Edit)
        {
            _IsEdit = Edit;

            txtName.Text = _Token.Name;
            txtDescription.Text = _Token.Description;
            checkBoxSystemToken.Checked = _Token.SystemToken;

            ConfigureSaveButton();

            HasChanges = false;
        }

        /// <summary>
        /// Configures the Save button
        /// </summary>
        private void ConfigureSaveButton()
        {
            if (string.IsNullOrEmpty(_Token.Name))
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
                Response = _Token.SaveToDB();

                //If no exception then nothing has errored.
                if (Response.Exception == null)
                {
                    HasChanges = false;
                }
                else
                {
                    //Something has errored when saving the object. Show a nice error.
                    MessageBox.Show(string.Format("An error has occured trying to save Token {0} | ErrorID {1} : - {2}", _Token.Name, Response.LogID, Response.Exception.GetCleanMessage()), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _Token = new Token();
            InitialiseForm(false);
            txtName.Focus();
        }

        #endregion Methods

        #region Events

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            _Token.Name = txtName.Text;
            ConfigureSaveButton();
            HasChanges = true;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            _Token.Description = txtDescription.Text;
            ConfigureSaveButton();
            HasChanges = true;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            SaveToDB();
            this.Close();
        }

        private void butSaveAndNew_Click(object sender, EventArgs e)
        {
            SaveToDB();
            NewObject();
        }

        private void checkBoxSystemToken_CheckedChanged(object sender, EventArgs e)
        {
            _Token.SystemToken = checkBoxSystemToken.Checked;
            HasChanges = true;
        }

        #endregion Events
    }
}
