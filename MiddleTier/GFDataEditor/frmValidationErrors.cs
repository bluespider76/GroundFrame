using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Horizon4.GF;

namespace Horizon4.GFDataEditor
{
    public partial class frmValidationErrors : Form
    {
        #region Private Variables

        private List<DataValidationError> _DataValidationErrors; //Private variable to store a list of the data validation errors

        #endregion Private Variables

        #region Properties
        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initalises a new instance of the frmValidationErrors class
        /// </summary>
        public frmValidationErrors()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initalises a new instance of the frmValidationErrors class and displays the supplied data validation errors
        /// </summary>
        public frmValidationErrors(List<DataValidationError> DataValidationErrors, string Title)
        {
            //Initialise the components
            InitializeComponent();

            //Assign the Data Validation errors to the private variable
            this._DataValidationErrors = DataValidationErrors;

            //Set the form title
            this.Text = Title;

            //Refresh the ListView
            PopulateListView();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Populates the Data Validation Errors List View
        /// </summary>
        private void PopulateListView()
        {
            listViewValidationErrors.BeginUpdate();
            listViewValidationErrors.Items.Clear();

            //Loop through each error and add to the list view
            foreach (DataValidationError Error in this._DataValidationErrors)
            {
                listViewValidationErrors.Items.Add(GenerateDataValidationErrorListViewItem(Error));
            }

            listViewValidationErrors.EndUpdate();
        }

        /// <summary>
        /// Converts a DataValidationError Struct into a ListViewItem
        /// </summary>
        /// <param name="Error">The DataValidationError to convert</param>
        /// <returns></returns>
        private ListViewItem GenerateDataValidationErrorListViewItem(DataValidationError Error)
        {
            ListViewItem Item = new ListViewItem(Error.Property);
            Item.SubItems.Add(Error.Error);

            return Item;
        }

        #endregion Methods

    }
}
