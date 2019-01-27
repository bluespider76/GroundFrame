namespace Horizon4.GFDataEditor
{
    partial class frmEditSystemPath
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
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.lblEndLocation = new System.Windows.Forms.Label();
            this.comboEndLocation = new System.Windows.Forms.ComboBox();
            this.comboStartLocation = new System.Windows.Forms.ComboBox();
            this.labelStartLocation = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.butSaveAndNew = new System.Windows.Forms.Button();
            this.groupBoxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.lblEndLocation);
            this.groupBoxDetails.Controls.Add(this.comboEndLocation);
            this.groupBoxDetails.Controls.Add(this.comboStartLocation);
            this.groupBoxDetails.Controls.Add(this.labelStartLocation);
            this.groupBoxDetails.Controls.Add(this.txtDescription);
            this.groupBoxDetails.Controls.Add(this.lblDescription);
            this.groupBoxDetails.Controls.Add(this.txtName);
            this.groupBoxDetails.Controls.Add(this.lblName);
            this.groupBoxDetails.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(365, 200);
            this.groupBoxDetails.TabIndex = 0;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Details";
            // 
            // lblEndLocation
            // 
            this.lblEndLocation.AutoSize = true;
            this.lblEndLocation.Location = new System.Drawing.Point(15, 57);
            this.lblEndLocation.Name = "lblEndLocation";
            this.lblEndLocation.Size = new System.Drawing.Size(73, 13);
            this.lblEndLocation.TabIndex = 6;
            this.lblEndLocation.Text = "End Location:";
            // 
            // comboEndLocation
            // 
            this.comboEndLocation.FormattingEnabled = true;
            this.comboEndLocation.Location = new System.Drawing.Point(110, 54);
            this.comboEndLocation.Name = "comboEndLocation";
            this.comboEndLocation.Size = new System.Drawing.Size(240, 21);
            this.comboEndLocation.TabIndex = 5;
            this.comboEndLocation.SelectedIndexChanged += new System.EventHandler(this.comboEndLocation_SelectedIndexChanged);
            // 
            // comboStartLocation
            // 
            this.comboStartLocation.FormattingEnabled = true;
            this.comboStartLocation.Location = new System.Drawing.Point(110, 19);
            this.comboStartLocation.Name = "comboStartLocation";
            this.comboStartLocation.Size = new System.Drawing.Size(240, 21);
            this.comboStartLocation.TabIndex = 4;
            this.comboStartLocation.SelectedIndexChanged += new System.EventHandler(this.comboStartLocation_SelectedIndexChanged);
            // 
            // labelStartLocation
            // 
            this.labelStartLocation.AutoSize = true;
            this.labelStartLocation.Location = new System.Drawing.Point(15, 26);
            this.labelStartLocation.Name = "labelStartLocation";
            this.labelStartLocation.Size = new System.Drawing.Size(76, 13);
            this.labelStartLocation.TabIndex = 3;
            this.labelStartLocation.Text = "Start Location:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(110, 125);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(240, 60);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Text = "";
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 125);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 90);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 90);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(302, 223);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 4;
            this.butSave.Text = "Save";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butSaveAndNew
            // 
            this.butSaveAndNew.Location = new System.Drawing.Point(204, 223);
            this.butSaveAndNew.Name = "butSaveAndNew";
            this.butSaveAndNew.Size = new System.Drawing.Size(92, 23);
            this.butSaveAndNew.TabIndex = 3;
            this.butSaveAndNew.Text = "Save and New";
            this.butSaveAndNew.UseVisualStyleBackColor = true;
            this.butSaveAndNew.Click += new System.EventHandler(this.butSaveAndNew_Click);
            // 
            // frmEditSystemPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 258);
            this.Controls.Add(this.butSaveAndNew);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.groupBoxDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEditSystemPath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "System Path";
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butSaveAndNew;
        private System.Windows.Forms.ComboBox comboEndLocation;
        private System.Windows.Forms.ComboBox comboStartLocation;
        private System.Windows.Forms.Label labelStartLocation;
        private System.Windows.Forms.Label lblEndLocation;
    }
}