namespace Horizon4.GFDataEditor
{
    partial class frmTractionClassProfile
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
            this.groupProfiles = new System.Windows.Forms.GroupBox();
            this.listViewTractionProfiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.numericUpDownHP = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTE = new System.Windows.Forms.NumericUpDown();
            this.lblHorsePower = new System.Windows.Forms.Label();
            this.lblTractiveEffort = new System.Windows.Forms.Label();
            this.numericUpDownMaxSpeedLL = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblMaxSpeedLL = new System.Windows.Forms.Label();
            this.lblMaxSpeed = new System.Windows.Forms.Label();
            this.comboBoxPower = new System.Windows.Forms.ComboBox();
            this.lblPower = new System.Windows.Forms.Label();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripPath = new System.Windows.Forms.StatusStrip();
            this.toolStripProfileRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProfileStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupProfiles.SuspendLayout();
            this.groupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSpeedLL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSpeed)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.statusStripPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupProfiles
            // 
            this.groupProfiles.Controls.Add(this.listViewTractionProfiles);
            this.groupProfiles.Location = new System.Drawing.Point(12, 45);
            this.groupProfiles.Name = "groupProfiles";
            this.groupProfiles.Size = new System.Drawing.Size(665, 185);
            this.groupProfiles.TabIndex = 0;
            this.groupProfiles.TabStop = false;
            this.groupProfiles.Text = "Profiles";
            // 
            // listViewTractionProfiles
            // 
            this.listViewTractionProfiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewTractionProfiles.FullRowSelect = true;
            this.listViewTractionProfiles.HideSelection = false;
            this.listViewTractionProfiles.Location = new System.Drawing.Point(16, 31);
            this.listViewTractionProfiles.MultiSelect = false;
            this.listViewTractionProfiles.Name = "listViewTractionProfiles";
            this.listViewTractionProfiles.Size = new System.Drawing.Size(631, 138);
            this.listViewTractionProfiles.TabIndex = 0;
            this.listViewTractionProfiles.UseCompatibleStateImageBehavior = false;
            this.listViewTractionProfiles.View = System.Windows.Forms.View.Details;
            this.listViewTractionProfiles.SelectedIndexChanged += new System.EventHandler(this.listViewTractionProfiles_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Power:";
            this.columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Max Speed:";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Max Speed Light Loco:";
            this.columnHeader3.Width = 135;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tractive Effort:";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Horse Power:";
            this.columnHeader5.Width = 80;
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add(this.numericUpDownHP);
            this.groupDetails.Controls.Add(this.numericUpDownTE);
            this.groupDetails.Controls.Add(this.lblHorsePower);
            this.groupDetails.Controls.Add(this.lblTractiveEffort);
            this.groupDetails.Controls.Add(this.numericUpDownMaxSpeedLL);
            this.groupDetails.Controls.Add(this.numericUpDownMaxSpeed);
            this.groupDetails.Controls.Add(this.lblMaxSpeedLL);
            this.groupDetails.Controls.Add(this.lblMaxSpeed);
            this.groupDetails.Controls.Add(this.comboBoxPower);
            this.groupDetails.Controls.Add(this.lblPower);
            this.groupDetails.Location = new System.Drawing.Point(12, 248);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(665, 178);
            this.groupDetails.TabIndex = 1;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Details";
            // 
            // numericUpDownHP
            // 
            this.numericUpDownHP.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownHP.Location = new System.Drawing.Point(488, 138);
            this.numericUpDownHP.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.numericUpDownHP.Name = "numericUpDownHP";
            this.numericUpDownHP.Size = new System.Drawing.Size(85, 22);
            this.numericUpDownHP.TabIndex = 9;
            this.numericUpDownHP.ValueChanged += new System.EventHandler(this.numericUpDownHP_ValueChanged);
            // 
            // numericUpDownTE
            // 
            this.numericUpDownTE.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTE.Location = new System.Drawing.Point(488, 85);
            this.numericUpDownTE.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.numericUpDownTE.Name = "numericUpDownTE";
            this.numericUpDownTE.Size = new System.Drawing.Size(85, 22);
            this.numericUpDownTE.TabIndex = 8;
            this.numericUpDownTE.ValueChanged += new System.EventHandler(this.numericUpDownTE_ValueChanged);
            // 
            // lblHorsePower
            // 
            this.lblHorsePower.AutoSize = true;
            this.lblHorsePower.Location = new System.Drawing.Point(366, 140);
            this.lblHorsePower.Name = "lblHorsePower";
            this.lblHorsePower.Size = new System.Drawing.Size(88, 17);
            this.lblHorsePower.TabIndex = 7;
            this.lblHorsePower.Text = "Horsepower:";
            // 
            // lblTractiveEffort
            // 
            this.lblTractiveEffort.AutoSize = true;
            this.lblTractiveEffort.Location = new System.Drawing.Point(366, 87);
            this.lblTractiveEffort.Name = "lblTractiveEffort";
            this.lblTractiveEffort.Size = new System.Drawing.Size(101, 17);
            this.lblTractiveEffort.TabIndex = 6;
            this.lblTractiveEffort.Text = "Tractive Effort:";
            // 
            // numericUpDownMaxSpeedLL
            // 
            this.numericUpDownMaxSpeedLL.Location = new System.Drawing.Point(183, 140);
            this.numericUpDownMaxSpeedLL.Maximum = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.numericUpDownMaxSpeedLL.Name = "numericUpDownMaxSpeedLL";
            this.numericUpDownMaxSpeedLL.Size = new System.Drawing.Size(62, 22);
            this.numericUpDownMaxSpeedLL.TabIndex = 5;
            this.numericUpDownMaxSpeedLL.ValueChanged += new System.EventHandler(this.numericUpDownMaxSpeedLL_ValueChanged);
            // 
            // numericUpDownMaxSpeed
            // 
            this.numericUpDownMaxSpeed.Location = new System.Drawing.Point(183, 85);
            this.numericUpDownMaxSpeed.Maximum = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.numericUpDownMaxSpeed.Name = "numericUpDownMaxSpeed";
            this.numericUpDownMaxSpeed.Size = new System.Drawing.Size(62, 22);
            this.numericUpDownMaxSpeed.TabIndex = 4;
            this.numericUpDownMaxSpeed.ValueChanged += new System.EventHandler(this.numericUpDownMaxSpeed_ValueChanged);
            // 
            // lblMaxSpeedLL
            // 
            this.lblMaxSpeedLL.AutoSize = true;
            this.lblMaxSpeedLL.Location = new System.Drawing.Point(13, 140);
            this.lblMaxSpeedLL.Name = "lblMaxSpeedLL";
            this.lblMaxSpeedLL.Size = new System.Drawing.Size(152, 17);
            this.lblMaxSpeedLL.TabIndex = 3;
            this.lblMaxSpeedLL.Text = "Max Speed Light Loco:";
            // 
            // lblMaxSpeed
            // 
            this.lblMaxSpeed.AutoSize = true;
            this.lblMaxSpeed.Location = new System.Drawing.Point(13, 87);
            this.lblMaxSpeed.Name = "lblMaxSpeed";
            this.lblMaxSpeed.Size = new System.Drawing.Size(126, 17);
            this.lblMaxSpeed.TabIndex = 2;
            this.lblMaxSpeed.Text = "Max Speed (MPH):";
            // 
            // comboBoxPower
            // 
            this.comboBoxPower.FormattingEnabled = true;
            this.comboBoxPower.Location = new System.Drawing.Point(183, 37);
            this.comboBoxPower.Name = "comboBoxPower";
            this.comboBoxPower.Size = new System.Drawing.Size(165, 24);
            this.comboBoxPower.TabIndex = 1;
            this.comboBoxPower.SelectedIndexChanged += new System.EventHandler(this.comboBoxPower_SelectedIndexChanged);
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.Location = new System.Drawing.Point(13, 40);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(51, 17);
            this.lblPower.TabIndex = 0;
            this.lblPower.Text = "Power:";
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(689, 28);
            this.menuStripMain.TabIndex = 2;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newToolStripMenuItem.Text = "New..";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // statusStripPath
            // 
            this.statusStripPath.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripPath.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProfileRecord,
            this.toolStripProfileStatus});
            this.statusStripPath.Location = new System.Drawing.Point(0, 426);
            this.statusStripPath.Name = "statusStripPath";
            this.statusStripPath.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStripPath.Size = new System.Drawing.Size(689, 29);
            this.statusStripPath.TabIndex = 3;
            this.statusStripPath.Text = "statusStripProfile";
            // 
            // toolStripProfileRecord
            // 
            this.toolStripProfileRecord.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripProfileRecord.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripProfileRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripProfileRecord.Name = "toolStripProfileRecord";
            this.toolStripProfileRecord.Size = new System.Drawing.Size(110, 24);
            this.toolStripProfileRecord.Text = "None Selected";
            this.toolStripProfileRecord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProfileStatus
            // 
            this.toolStripProfileStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.toolStripProfileStatus.Image = global::Horizon4.GFDataEditor.Properties.Resources.tick;
            this.toolStripProfileStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripProfileStatus.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripProfileStatus.Name = "toolStripProfileStatus";
            this.toolStripProfileStatus.Size = new System.Drawing.Size(69, 24);
            this.toolStripProfileStatus.Text = "Status";
            this.toolStripProfileStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmTractionClassProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 455);
            this.Controls.Add(this.statusStripPath);
            this.Controls.Add(this.groupDetails);
            this.Controls.Add(this.groupProfiles);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTractionClassProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Traction Class Profiles";
            this.groupProfiles.ResumeLayout(false);
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSpeedLL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSpeed)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripPath.ResumeLayout(false);
            this.statusStripPath.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupProfiles;
        private System.Windows.Forms.ListView listViewTractionProfiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.ComboBox comboBoxPower;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.NumericUpDown numericUpDownHP;
        private System.Windows.Forms.NumericUpDown numericUpDownTE;
        private System.Windows.Forms.Label lblHorsePower;
        private System.Windows.Forms.Label lblTractiveEffort;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxSpeedLL;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxSpeed;
        private System.Windows.Forms.Label lblMaxSpeedLL;
        private System.Windows.Forms.Label lblMaxSpeed;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripPath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripProfileRecord;
        private System.Windows.Forms.ToolStripStatusLabel toolStripProfileStatus;
    }
}