namespace Horizon4.GFDataEditor
{
    partial class frmValidationErrors
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewValidationErrors = new System.Windows.Forms.ListView();
            this.columnHeaderProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderError = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewValidationErrors
            // 
            this.listViewValidationErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderProperty,
            this.columnHeaderError});
            this.listViewValidationErrors.FullRowSelect = true;
            this.listViewValidationErrors.Location = new System.Drawing.Point(12, 12);
            this.listViewValidationErrors.Name = "listViewValidationErrors";
            this.listViewValidationErrors.Size = new System.Drawing.Size(560, 147);
            this.listViewValidationErrors.TabIndex = 0;
            this.listViewValidationErrors.UseCompatibleStateImageBehavior = false;
            this.listViewValidationErrors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderProperty
            // 
            this.columnHeaderProperty.Text = "Property";
            this.columnHeaderProperty.Width = 180;
            // 
            // columnHeaderError
            // 
            this.columnHeaderError.Text = "Error";
            this.columnHeaderError.Width = 360;
            // 
            // frmValidationErrors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 171);
            this.Controls.Add(this.listViewValidationErrors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmValidationErrors";
            this.Text = "Validation Errors";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewValidationErrors;
        private System.Windows.Forms.ColumnHeader columnHeaderProperty;
        private System.Windows.Forms.ColumnHeader columnHeaderError;
    }
}