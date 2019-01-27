namespace Horizon4.GFDataEditor
{
    partial class frmEditToken
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSystemToken = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.butSaveAndNew = new System.Windows.Forms.Button();
            this.checkBoxSystemToken = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxSystemToken);
            this.groupBox1.Controls.Add(this.lblSystemToken);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // lblSystemToken
            // 
            this.lblSystemToken.AutoSize = true;
            this.lblSystemToken.Location = new System.Drawing.Point(15, 136);
            this.lblSystemToken.Name = "lblSystemToken";
            this.lblSystemToken.Size = new System.Drawing.Size(78, 13);
            this.lblSystemToken.TabIndex = 3;
            this.lblSystemToken.Text = "System Token:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(110, 60);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(240, 60);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Text = "";
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 60);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(280, 186);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(99, 23);
            this.butSave.TabIndex = 4;
            this.butSave.Text = "Save and Close";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butSaveAndNew
            // 
            this.butSaveAndNew.Location = new System.Drawing.Point(182, 186);
            this.butSaveAndNew.Name = "butSaveAndNew";
            this.butSaveAndNew.Size = new System.Drawing.Size(92, 23);
            this.butSaveAndNew.TabIndex = 3;
            this.butSaveAndNew.Text = "Save and New";
            this.butSaveAndNew.UseVisualStyleBackColor = true;
            this.butSaveAndNew.Click += new System.EventHandler(this.butSaveAndNew_Click);
            // 
            // checkBoxSystemToken
            // 
            this.checkBoxSystemToken.AutoSize = true;
            this.checkBoxSystemToken.Location = new System.Drawing.Point(110, 136);
            this.checkBoxSystemToken.Name = "checkBoxSystemToken";
            this.checkBoxSystemToken.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSystemToken.TabIndex = 4;
            this.checkBoxSystemToken.UseVisualStyleBackColor = true;
            this.checkBoxSystemToken.CheckedChanged += new System.EventHandler(this.checkBoxSystemToken_CheckedChanged);
            // 
            // frmEditToken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 219);
            this.Controls.Add(this.butSaveAndNew);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEditToken";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Token";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butSaveAndNew;
        private System.Windows.Forms.Label lblSystemToken;
        private System.Windows.Forms.CheckBox checkBoxSystemToken;
    }
}