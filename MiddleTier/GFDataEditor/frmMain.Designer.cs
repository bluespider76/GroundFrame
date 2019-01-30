namespace Horizon4.GFDataEditor
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageLogical = new System.Windows.Forms.TabPage();
            this.groupBoxSectorCodes = new System.Windows.Forms.GroupBox();
            this.linkLogicalEditSystemSector = new System.Windows.Forms.LinkLabel();
            this.linkLogicalNewSystemSector = new System.Windows.Forms.LinkLabel();
            this.groupBoxLogicalSectorDetails = new System.Windows.Forms.GroupBox();
            this.butLogicalSectorNew = new System.Windows.Forms.Button();
            this.txtLogicalSectorDescription = new System.Windows.Forms.RichTextBox();
            this.butLogicalSectorSave = new System.Windows.Forms.Button();
            this.lblLogicalSectorDescription = new System.Windows.Forms.Label();
            this.lblLogicalSectorActiveTo = new System.Windows.Forms.Label();
            this.dateTimeLogicalSectorStartYMDV = new System.Windows.Forms.DateTimePicker();
            this.dateTimeLogicalSectorEndYMDV = new System.Windows.Forms.DateTimePicker();
            this.lblLogicalSectorActiveFrom = new System.Windows.Forms.Label();
            this.listViewSectors = new System.Windows.Forms.ListView();
            this.columnSectorDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSectorStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSectorEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblLogicalSectorCodeLabel = new System.Windows.Forms.Label();
            this.comboLogicalSystemSectors = new System.Windows.Forms.ComboBox();
            this.groupBoxRegions = new System.Windows.Forms.GroupBox();
            this.groupBoxRegionsDetails = new System.Windows.Forms.GroupBox();
            this.butLogicalRegionNew = new System.Windows.Forms.Button();
            this.butLogicalRegionSave = new System.Windows.Forms.Button();
            this.lblLogicalRegionActiveTo = new System.Windows.Forms.Label();
            this.dateTimeLogicalRegionEndYMDV = new System.Windows.Forms.DateTimePicker();
            this.lblLogicalRegionActiveFrom = new System.Windows.Forms.Label();
            this.dateTimeLogicalRegionStartYMDV = new System.Windows.Forms.DateTimePicker();
            this.txtLogicalRegionDescription = new System.Windows.Forms.RichTextBox();
            this.lblLogicalRegionDescription = new System.Windows.Forms.Label();
            this.txtLogicalRegionName = new System.Windows.Forms.TextBox();
            this.lblLogicalRegionName = new System.Windows.Forms.Label();
            this.listViewRegions = new System.Windows.Forms.ListView();
            this.columnHeaderRegionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStartYMDV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEndYMDV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageLocation = new System.Windows.Forms.TabPage();
            this.groupBoxLocations = new System.Windows.Forms.GroupBox();
            this.linkDepotDetails = new System.Windows.Forms.LinkLabel();
            this.linkLocationEditToken = new System.Windows.Forms.LinkLabel();
            this.linkLocationNewToken = new System.Windows.Forms.LinkLabel();
            this.groupBoxLocationOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxLocationOptionCannotSurrenderToken = new System.Windows.Forms.CheckBox();
            this.labelLocationOptionCannotSurrenderToken = new System.Windows.Forms.Label();
            this.checkBoxLocationOptionPassengerTrainCannotStop = new System.Windows.Forms.CheckBox();
            this.checkBoxLocationOptionOnlyStopIfReversing = new System.Windows.Forms.CheckBox();
            this.lblLocationOptionPassengerTrainsCannotStop = new System.Windows.Forms.Label();
            this.lblLocationOptionOnlyStopIfReversing = new System.Windows.Forms.Label();
            this.checkBoxLocationOptionCannotStop = new System.Windows.Forms.CheckBox();
            this.lblLocationOptionCannotStop = new System.Windows.Forms.Label();
            this.checkBoxLocationOptionCallOn = new System.Windows.Forms.CheckBox();
            this.labelLocationOptionCallOn = new System.Windows.Forms.Label();
            this.groupBoxLocationPower = new System.Windows.Forms.GroupBox();
            this.checkBoxLocationPowerBattery = new System.Windows.Forms.CheckBox();
            this.checkBoxLocationPowerOHead25 = new System.Windows.Forms.CheckBox();
            this.checkBoxLocationPowerOH625 = new System.Windows.Forms.CheckBox();
            this.checkBoxLocationPowerOH1500 = new System.Windows.Forms.CheckBox();
            this.checkBoxLocationPower3rd1500 = new System.Windows.Forms.CheckBox();
            this.checkBoxLocationPower3rd750 = new System.Windows.Forms.CheckBox();
            this.checkBoxLocationPower4th600 = new System.Windows.Forms.CheckBox();
            this.checkBoxLocationPowerDiesel = new System.Windows.Forms.CheckBox();
            this.checkBoxLocationPowerSteam = new System.Windows.Forms.CheckBox();
            this.labelLocationPowerBattery = new System.Windows.Forms.Label();
            this.labelLocationPowerOH25 = new System.Windows.Forms.Label();
            this.labelLocationPowerOH625 = new System.Windows.Forms.Label();
            this.labelLocationPowerOH1500 = new System.Windows.Forms.Label();
            this.labelLocationPower3rd1500 = new System.Windows.Forms.Label();
            this.labelLocationPower3rd750 = new System.Windows.Forms.Label();
            this.labelLocationPower4th600 = new System.Windows.Forms.Label();
            this.labelLocationPowerDiesel = new System.Windows.Forms.Label();
            this.labelLocationPowerSteam = new System.Windows.Forms.Label();
            this.numericUpDownLocationScore = new System.Windows.Forms.NumericUpDown();
            this.labelLocationScore = new System.Windows.Forms.Label();
            this.checkBoxLocationUseAsTimingPoint = new System.Windows.Forms.CheckBox();
            this.lblLocationUseAsTimingPoint = new System.Windows.Forms.Label();
            this.checkBoxLocationTOPSOffice = new System.Windows.Forms.CheckBox();
            this.labelLocationTOPSOffice = new System.Windows.Forms.Label();
            this.checkBoxLocationDisembarkPassengers = new System.Windows.Forms.CheckBox();
            this.lblLocationDisembarkPassengers = new System.Windows.Forms.Label();
            this.checkBoxLocationEmbarkPassengers = new System.Windows.Forms.CheckBox();
            this.lblLocationEmbarkPassengers = new System.Windows.Forms.Label();
            this.checkBoxLocationFreightOnly = new System.Windows.Forms.CheckBox();
            this.lblLocationFreightOnly = new System.Windows.Forms.Label();
            this.checkBoxLocationSingleTrainWorking = new System.Windows.Forms.CheckBox();
            this.labelLocationSingleTrainWorking = new System.Windows.Forms.Label();
            this.comboLocationToken = new System.Windows.Forms.ComboBox();
            this.comboLocationDirections = new System.Windows.Forms.ComboBox();
            this.lblLocationDirection = new System.Windows.Forms.Label();
            this.lblLocationBerths = new System.Windows.Forms.Label();
            this.numericUpDownLocationBerths = new System.Windows.Forms.NumericUpDown();
            this.lblLocationToken = new System.Windows.Forms.Label();
            this.lblLengthMeters = new System.Windows.Forms.Label();
            this.txtLocationLength = new System.Windows.Forms.TextBox();
            this.lblLocationLength = new System.Windows.Forms.Label();
            this.txtLocationLongitude = new System.Windows.Forms.TextBox();
            this.lblLocationLongitude = new System.Windows.Forms.Label();
            this.txtLocationLatitude = new System.Windows.Forms.TextBox();
            this.lblLocationLatitude = new System.Windows.Forms.Label();
            this.comboLocationType = new System.Windows.Forms.ComboBox();
            this.lblLocationType = new System.Windows.Forms.Label();
            this.txtLocationNLC = new System.Windows.Forms.TextBox();
            this.lblLocationNLC = new System.Windows.Forms.Label();
            this.txtLocationSTANME = new System.Windows.Forms.TextBox();
            this.lblLocationSTANME = new System.Windows.Forms.Label();
            this.txtLocationSTANOX = new System.Windows.Forms.TextBox();
            this.lblLocationSTANOX = new System.Windows.Forms.Label();
            this.txtLocationTIPLOC = new System.Windows.Forms.TextBox();
            this.lblLocationTIPLOC = new System.Windows.Forms.Label();
            this.lblLocationActiveTo = new System.Windows.Forms.Label();
            this.dateTimeLocationActiveFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimeLocationActiveTo = new System.Windows.Forms.DateTimePicker();
            this.lblLocationActiveFrom = new System.Windows.Forms.Label();
            this.txtLocationName = new System.Windows.Forms.TextBox();
            this.lblLocationName = new System.Windows.Forms.Label();
            this.treeViewLocations = new System.Windows.Forms.TreeView();
            this.contextMenuStripLocationTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newChildLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLocationEdit = new System.Windows.Forms.LinkLabel();
            this.linkLocationNew = new System.Windows.Forms.LinkLabel();
            this.lblLocationLocation = new System.Windows.Forms.Label();
            this.comboLocationLocation = new System.Windows.Forms.ComboBox();
            this.tabPageTraction = new System.Windows.Forms.TabPage();
            this.groupBoxTractionClass = new System.Windows.Forms.GroupBox();
            this.panelTractionClassDetails = new System.Windows.Forms.Panel();
            this.numericUpDownTractionTractionClassRA = new System.Windows.Forms.NumericUpDown();
            this.lblTractionTractionClassRA = new System.Windows.Forms.Label();
            this.numericUpDownTractionTractionClassLength = new System.Windows.Forms.NumericUpDown();
            this.lblTractionTractionClassLength = new System.Windows.Forms.Label();
            this.lblTractionTractionClassParent = new System.Windows.Forms.Label();
            this.comboTractionTractionClassType = new System.Windows.Forms.ComboBox();
            this.lblTractionTractionClassType = new System.Windows.Forms.Label();
            this.txtTractionTractionClassDescription = new System.Windows.Forms.RichTextBox();
            this.lblTractionTractionClassDescription = new System.Windows.Forms.Label();
            this.txtTractionTractionClassName = new System.Windows.Forms.TextBox();
            this.lblTractionTractionClassName = new System.Windows.Forms.Label();
            this.dateTimeTractionTractionClassEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblTractionTractionClassInServiceEndDate = new System.Windows.Forms.Label();
            this.dateTimeTractionTractionClassStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblTractionTractionClassInServiceStartDate = new System.Windows.Forms.Label();
            this.listViewTractionClasses = new System.Windows.Forms.ListView();
            this.columnHeaderClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderClassRA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderClassStartYMDV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderClassEndYMDV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboTractionType = new System.Windows.Forms.ComboBox();
            this.lblTractionType = new System.Windows.Forms.Label();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripTab = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.ToolStripLocationFile = new System.Windows.Forms.ToolStripMenuItem();
            this.newLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripTractionFile = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tractionClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tractionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveTractionClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripLocationLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.editPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripTractionTraction = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain.SuspendLayout();
            this.tabPageLogical.SuspendLayout();
            this.groupBoxSectorCodes.SuspendLayout();
            this.groupBoxLogicalSectorDetails.SuspendLayout();
            this.groupBoxRegions.SuspendLayout();
            this.groupBoxRegionsDetails.SuspendLayout();
            this.tabPageLocation.SuspendLayout();
            this.groupBoxLocations.SuspendLayout();
            this.groupBoxLocationOptions.SuspendLayout();
            this.groupBoxLocationPower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLocationScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLocationBerths)).BeginInit();
            this.contextMenuStripLocationTreeView.SuspendLayout();
            this.tabPageTraction.SuspendLayout();
            this.groupBoxTractionClass.SuspendLayout();
            this.panelTractionClassDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTractionTractionClassRA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTractionTractionClassLength)).BeginInit();
            this.statusStripMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageLogical);
            this.tabControlMain.Controls.Add(this.tabPageLocation);
            this.tabControlMain.Controls.Add(this.tabPageTraction);
            this.tabControlMain.Location = new System.Drawing.Point(16, 46);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1560, 619);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageLogical
            // 
            this.tabPageLogical.Controls.Add(this.groupBoxSectorCodes);
            this.tabPageLogical.Controls.Add(this.groupBoxRegions);
            this.tabPageLogical.Location = new System.Drawing.Point(4, 25);
            this.tabPageLogical.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageLogical.Name = "tabPageLogical";
            this.tabPageLogical.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageLogical.Size = new System.Drawing.Size(1552, 590);
            this.tabPageLogical.TabIndex = 0;
            this.tabPageLogical.Text = "Logical";
            this.tabPageLogical.UseVisualStyleBackColor = true;
            // 
            // groupBoxSectorCodes
            // 
            this.groupBoxSectorCodes.Controls.Add(this.linkLogicalEditSystemSector);
            this.groupBoxSectorCodes.Controls.Add(this.linkLogicalNewSystemSector);
            this.groupBoxSectorCodes.Controls.Add(this.groupBoxLogicalSectorDetails);
            this.groupBoxSectorCodes.Controls.Add(this.listViewSectors);
            this.groupBoxSectorCodes.Controls.Add(this.lblLogicalSectorCodeLabel);
            this.groupBoxSectorCodes.Controls.Add(this.comboLogicalSystemSectors);
            this.groupBoxSectorCodes.Location = new System.Drawing.Point(672, 15);
            this.groupBoxSectorCodes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSectorCodes.Name = "groupBoxSectorCodes";
            this.groupBoxSectorCodes.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSectorCodes.Size = new System.Drawing.Size(860, 554);
            this.groupBoxSectorCodes.TabIndex = 1;
            this.groupBoxSectorCodes.TabStop = false;
            this.groupBoxSectorCodes.Text = "Sector Codes";
            // 
            // linkLogicalEditSystemSector
            // 
            this.linkLogicalEditSystemSector.AutoSize = true;
            this.linkLogicalEditSystemSector.Location = new System.Drawing.Point(323, 34);
            this.linkLogicalEditSystemSector.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLogicalEditSystemSector.Name = "linkLogicalEditSystemSector";
            this.linkLogicalEditSystemSector.Size = new System.Drawing.Size(40, 17);
            this.linkLogicalEditSystemSector.TabIndex = 5;
            this.linkLogicalEditSystemSector.TabStop = true;
            this.linkLogicalEditSystemSector.Text = "Edit..";
            this.linkLogicalEditSystemSector.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogicalEditSystemSector_LinkClicked);
            // 
            // linkLogicalNewSystemSector
            // 
            this.linkLogicalNewSystemSector.AutoSize = true;
            this.linkLogicalNewSystemSector.Location = new System.Drawing.Point(372, 34);
            this.linkLogicalNewSystemSector.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLogicalNewSystemSector.Name = "linkLogicalNewSystemSector";
            this.linkLogicalNewSystemSector.Size = new System.Drawing.Size(43, 17);
            this.linkLogicalNewSystemSector.TabIndex = 4;
            this.linkLogicalNewSystemSector.TabStop = true;
            this.linkLogicalNewSystemSector.Text = "New..";
            this.linkLogicalNewSystemSector.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogicalNewSystemSector_LinkClicked);
            // 
            // groupBoxLogicalSectorDetails
            // 
            this.groupBoxLogicalSectorDetails.Controls.Add(this.butLogicalSectorNew);
            this.groupBoxLogicalSectorDetails.Controls.Add(this.txtLogicalSectorDescription);
            this.groupBoxLogicalSectorDetails.Controls.Add(this.butLogicalSectorSave);
            this.groupBoxLogicalSectorDetails.Controls.Add(this.lblLogicalSectorDescription);
            this.groupBoxLogicalSectorDetails.Controls.Add(this.lblLogicalSectorActiveTo);
            this.groupBoxLogicalSectorDetails.Controls.Add(this.dateTimeLogicalSectorStartYMDV);
            this.groupBoxLogicalSectorDetails.Controls.Add(this.dateTimeLogicalSectorEndYMDV);
            this.groupBoxLogicalSectorDetails.Controls.Add(this.lblLogicalSectorActiveFrom);
            this.groupBoxLogicalSectorDetails.Location = new System.Drawing.Point(20, 268);
            this.groupBoxLogicalSectorDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLogicalSectorDetails.Name = "groupBoxLogicalSectorDetails";
            this.groupBoxLogicalSectorDetails.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLogicalSectorDetails.Size = new System.Drawing.Size(820, 267);
            this.groupBoxLogicalSectorDetails.TabIndex = 3;
            this.groupBoxLogicalSectorDetails.TabStop = false;
            this.groupBoxLogicalSectorDetails.Text = "Details";
            // 
            // butLogicalSectorNew
            // 
            this.butLogicalSectorNew.Location = new System.Drawing.Point(644, 218);
            this.butLogicalSectorNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butLogicalSectorNew.Name = "butLogicalSectorNew";
            this.butLogicalSectorNew.Size = new System.Drawing.Size(71, 28);
            this.butLogicalSectorNew.TabIndex = 17;
            this.butLogicalSectorNew.Text = "New..";
            this.butLogicalSectorNew.UseVisualStyleBackColor = true;
            // 
            // txtLogicalSectorDescription
            // 
            this.txtLogicalSectorDescription.Location = new System.Drawing.Point(167, 33);
            this.txtLogicalSectorDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLogicalSectorDescription.Name = "txtLogicalSectorDescription";
            this.txtLogicalSectorDescription.Size = new System.Drawing.Size(625, 120);
            this.txtLogicalSectorDescription.TabIndex = 11;
            this.txtLogicalSectorDescription.Text = "";
            this.txtLogicalSectorDescription.TextChanged += new System.EventHandler(this.txtLogicalSectorDescription_TextChanged);
            // 
            // butLogicalSectorSave
            // 
            this.butLogicalSectorSave.Location = new System.Drawing.Point(723, 218);
            this.butLogicalSectorSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butLogicalSectorSave.Name = "butLogicalSectorSave";
            this.butLogicalSectorSave.Size = new System.Drawing.Size(71, 28);
            this.butLogicalSectorSave.TabIndex = 16;
            this.butLogicalSectorSave.Text = "Save..";
            this.butLogicalSectorSave.UseVisualStyleBackColor = true;
            this.butLogicalSectorSave.Click += new System.EventHandler(this.butLogicalSectorSave_Click);
            // 
            // lblLogicalSectorDescription
            // 
            this.lblLogicalSectorDescription.AutoSize = true;
            this.lblLogicalSectorDescription.Location = new System.Drawing.Point(13, 33);
            this.lblLogicalSectorDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogicalSectorDescription.Name = "lblLogicalSectorDescription";
            this.lblLogicalSectorDescription.Size = new System.Drawing.Size(83, 17);
            this.lblLogicalSectorDescription.TabIndex = 10;
            this.lblLogicalSectorDescription.Text = "Description:";
            // 
            // lblLogicalSectorActiveTo
            // 
            this.lblLogicalSectorActiveTo.AutoSize = true;
            this.lblLogicalSectorActiveTo.Location = new System.Drawing.Point(311, 178);
            this.lblLogicalSectorActiveTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogicalSectorActiveTo.Name = "lblLogicalSectorActiveTo";
            this.lblLogicalSectorActiveTo.Size = new System.Drawing.Size(24, 17);
            this.lblLogicalSectorActiveTo.TabIndex = 15;
            this.lblLogicalSectorActiveTo.Text = "to:";
            // 
            // dateTimeLogicalSectorStartYMDV
            // 
            this.dateTimeLogicalSectorStartYMDV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeLogicalSectorStartYMDV.Location = new System.Drawing.Point(167, 174);
            this.dateTimeLogicalSectorStartYMDV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimeLogicalSectorStartYMDV.Name = "dateTimeLogicalSectorStartYMDV";
            this.dateTimeLogicalSectorStartYMDV.Size = new System.Drawing.Size(132, 22);
            this.dateTimeLogicalSectorStartYMDV.TabIndex = 12;
            this.dateTimeLogicalSectorStartYMDV.ValueChanged += new System.EventHandler(this.dateTimeLogicalSectorStartYMDV_ValueChanged);
            // 
            // dateTimeLogicalSectorEndYMDV
            // 
            this.dateTimeLogicalSectorEndYMDV.Enabled = false;
            this.dateTimeLogicalSectorEndYMDV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeLogicalSectorEndYMDV.Location = new System.Drawing.Point(341, 174);
            this.dateTimeLogicalSectorEndYMDV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimeLogicalSectorEndYMDV.Name = "dateTimeLogicalSectorEndYMDV";
            this.dateTimeLogicalSectorEndYMDV.ShowCheckBox = true;
            this.dateTimeLogicalSectorEndYMDV.Size = new System.Drawing.Size(132, 22);
            this.dateTimeLogicalSectorEndYMDV.TabIndex = 14;
            this.dateTimeLogicalSectorEndYMDV.ValueChanged += new System.EventHandler(this.dateTimeLogicalSectorEndYMDV_ValueChanged);
            // 
            // lblLogicalSectorActiveFrom
            // 
            this.lblLogicalSectorActiveFrom.AutoSize = true;
            this.lblLogicalSectorActiveFrom.Location = new System.Drawing.Point(13, 178);
            this.lblLogicalSectorActiveFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogicalSectorActiveFrom.Name = "lblLogicalSectorActiveFrom";
            this.lblLogicalSectorActiveFrom.Size = new System.Drawing.Size(131, 17);
            this.lblLogicalSectorActiveFrom.TabIndex = 13;
            this.lblLogicalSectorActiveFrom.Text = "Sector Active From:";
            // 
            // listViewSectors
            // 
            this.listViewSectors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSectorDescription,
            this.columnSectorStart,
            this.columnSectorEnd});
            this.listViewSectors.FullRowSelect = true;
            this.listViewSectors.HideSelection = false;
            this.listViewSectors.Location = new System.Drawing.Point(20, 76);
            this.listViewSectors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewSectors.Name = "listViewSectors";
            this.listViewSectors.Size = new System.Drawing.Size(819, 184);
            this.listViewSectors.TabIndex = 2;
            this.listViewSectors.UseCompatibleStateImageBehavior = false;
            this.listViewSectors.View = System.Windows.Forms.View.Details;
            this.listViewSectors.SelectedIndexChanged += new System.EventHandler(this.listViewSectors_SelectedIndexChanged);
            // 
            // columnSectorDescription
            // 
            this.columnSectorDescription.Text = "Description";
            this.columnSectorDescription.Width = 400;
            // 
            // columnSectorStart
            // 
            this.columnSectorStart.Text = "Start";
            this.columnSectorStart.Width = 90;
            // 
            // columnSectorEnd
            // 
            this.columnSectorEnd.Text = "End";
            this.columnSectorEnd.Width = 90;
            // 
            // lblLogicalSectorCodeLabel
            // 
            this.lblLogicalSectorCodeLabel.AutoSize = true;
            this.lblLogicalSectorCodeLabel.Location = new System.Drawing.Point(20, 34);
            this.lblLogicalSectorCodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogicalSectorCodeLabel.Name = "lblLogicalSectorCodeLabel";
            this.lblLogicalSectorCodeLabel.Size = new System.Drawing.Size(45, 17);
            this.lblLogicalSectorCodeLabel.TabIndex = 1;
            this.lblLogicalSectorCodeLabel.Text = "Code:";
            // 
            // comboLogicalSystemSectors
            // 
            this.comboLogicalSystemSectors.FormattingEnabled = true;
            this.comboLogicalSystemSectors.Location = new System.Drawing.Point(120, 31);
            this.comboLogicalSystemSectors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboLogicalSystemSectors.Name = "comboLogicalSystemSectors";
            this.comboLogicalSystemSectors.Size = new System.Drawing.Size(192, 24);
            this.comboLogicalSystemSectors.TabIndex = 0;
            this.comboLogicalSystemSectors.SelectedIndexChanged += new System.EventHandler(this.comboLogicalSystemSectors_SelectedIndexChanged);
            // 
            // groupBoxRegions
            // 
            this.groupBoxRegions.Controls.Add(this.groupBoxRegionsDetails);
            this.groupBoxRegions.Controls.Add(this.listViewRegions);
            this.groupBoxRegions.Location = new System.Drawing.Point(16, 15);
            this.groupBoxRegions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxRegions.Name = "groupBoxRegions";
            this.groupBoxRegions.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxRegions.Size = new System.Drawing.Size(640, 554);
            this.groupBoxRegions.TabIndex = 0;
            this.groupBoxRegions.TabStop = false;
            this.groupBoxRegions.Text = "Regions";
            // 
            // groupBoxRegionsDetails
            // 
            this.groupBoxRegionsDetails.Controls.Add(this.butLogicalRegionNew);
            this.groupBoxRegionsDetails.Controls.Add(this.butLogicalRegionSave);
            this.groupBoxRegionsDetails.Controls.Add(this.lblLogicalRegionActiveTo);
            this.groupBoxRegionsDetails.Controls.Add(this.dateTimeLogicalRegionEndYMDV);
            this.groupBoxRegionsDetails.Controls.Add(this.lblLogicalRegionActiveFrom);
            this.groupBoxRegionsDetails.Controls.Add(this.dateTimeLogicalRegionStartYMDV);
            this.groupBoxRegionsDetails.Controls.Add(this.txtLogicalRegionDescription);
            this.groupBoxRegionsDetails.Controls.Add(this.lblLogicalRegionDescription);
            this.groupBoxRegionsDetails.Controls.Add(this.txtLogicalRegionName);
            this.groupBoxRegionsDetails.Controls.Add(this.lblLogicalRegionName);
            this.groupBoxRegionsDetails.Location = new System.Drawing.Point(20, 234);
            this.groupBoxRegionsDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxRegionsDetails.Name = "groupBoxRegionsDetails";
            this.groupBoxRegionsDetails.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxRegionsDetails.Size = new System.Drawing.Size(600, 302);
            this.groupBoxRegionsDetails.TabIndex = 1;
            this.groupBoxRegionsDetails.TabStop = false;
            this.groupBoxRegionsDetails.Text = "Details";
            // 
            // butLogicalRegionNew
            // 
            this.butLogicalRegionNew.Location = new System.Drawing.Point(428, 252);
            this.butLogicalRegionNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butLogicalRegionNew.Name = "butLogicalRegionNew";
            this.butLogicalRegionNew.Size = new System.Drawing.Size(71, 28);
            this.butLogicalRegionNew.TabIndex = 9;
            this.butLogicalRegionNew.Text = "New..";
            this.butLogicalRegionNew.UseVisualStyleBackColor = true;
            this.butLogicalRegionNew.Click += new System.EventHandler(this.butLogicalRegionNew_Click);
            // 
            // butLogicalRegionSave
            // 
            this.butLogicalRegionSave.Location = new System.Drawing.Point(507, 252);
            this.butLogicalRegionSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butLogicalRegionSave.Name = "butLogicalRegionSave";
            this.butLogicalRegionSave.Size = new System.Drawing.Size(71, 28);
            this.butLogicalRegionSave.TabIndex = 8;
            this.butLogicalRegionSave.Text = "Save..";
            this.butLogicalRegionSave.UseVisualStyleBackColor = true;
            this.butLogicalRegionSave.Click += new System.EventHandler(this.butLogicalRegionSave_Click);
            // 
            // lblLogicalRegionActiveTo
            // 
            this.lblLogicalRegionActiveTo.AutoSize = true;
            this.lblLogicalRegionActiveTo.Location = new System.Drawing.Point(317, 213);
            this.lblLogicalRegionActiveTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogicalRegionActiveTo.Name = "lblLogicalRegionActiveTo";
            this.lblLogicalRegionActiveTo.Size = new System.Drawing.Size(24, 17);
            this.lblLogicalRegionActiveTo.TabIndex = 7;
            this.lblLogicalRegionActiveTo.Text = "to:";
            // 
            // dateTimeLogicalRegionEndYMDV
            // 
            this.dateTimeLogicalRegionEndYMDV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeLogicalRegionEndYMDV.Location = new System.Drawing.Point(348, 208);
            this.dateTimeLogicalRegionEndYMDV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimeLogicalRegionEndYMDV.Name = "dateTimeLogicalRegionEndYMDV";
            this.dateTimeLogicalRegionEndYMDV.ShowCheckBox = true;
            this.dateTimeLogicalRegionEndYMDV.Size = new System.Drawing.Size(132, 22);
            this.dateTimeLogicalRegionEndYMDV.TabIndex = 6;
            this.dateTimeLogicalRegionEndYMDV.ValueChanged += new System.EventHandler(this.dateTimeLogicalRegionEndYMDV_ValueChanged);
            // 
            // lblLogicalRegionActiveFrom
            // 
            this.lblLogicalRegionActiveFrom.AutoSize = true;
            this.lblLogicalRegionActiveFrom.Location = new System.Drawing.Point(20, 213);
            this.lblLogicalRegionActiveFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogicalRegionActiveFrom.Name = "lblLogicalRegionActiveFrom";
            this.lblLogicalRegionActiveFrom.Size = new System.Drawing.Size(135, 17);
            this.lblLogicalRegionActiveFrom.TabIndex = 5;
            this.lblLogicalRegionActiveFrom.Text = "Region Active From:";
            // 
            // dateTimeLogicalRegionStartYMDV
            // 
            this.dateTimeLogicalRegionStartYMDV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeLogicalRegionStartYMDV.Location = new System.Drawing.Point(173, 208);
            this.dateTimeLogicalRegionStartYMDV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimeLogicalRegionStartYMDV.Name = "dateTimeLogicalRegionStartYMDV";
            this.dateTimeLogicalRegionStartYMDV.Size = new System.Drawing.Size(132, 22);
            this.dateTimeLogicalRegionStartYMDV.TabIndex = 4;
            this.dateTimeLogicalRegionStartYMDV.ValueChanged += new System.EventHandler(this.dateTimeLogicalRegionStartYMDV_ValueChanged);
            // 
            // txtLogicalRegionDescription
            // 
            this.txtLogicalRegionDescription.Location = new System.Drawing.Point(173, 68);
            this.txtLogicalRegionDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLogicalRegionDescription.Name = "txtLogicalRegionDescription";
            this.txtLogicalRegionDescription.Size = new System.Drawing.Size(403, 120);
            this.txtLogicalRegionDescription.TabIndex = 3;
            this.txtLogicalRegionDescription.Text = "";
            this.txtLogicalRegionDescription.TextChanged += new System.EventHandler(this.txtLogicalRegionDescription_TextChanged);
            // 
            // lblLogicalRegionDescription
            // 
            this.lblLogicalRegionDescription.AutoSize = true;
            this.lblLogicalRegionDescription.Location = new System.Drawing.Point(20, 68);
            this.lblLogicalRegionDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogicalRegionDescription.Name = "lblLogicalRegionDescription";
            this.lblLogicalRegionDescription.Size = new System.Drawing.Size(83, 17);
            this.lblLogicalRegionDescription.TabIndex = 2;
            this.lblLogicalRegionDescription.Text = "Description:";
            // 
            // txtLogicalRegionName
            // 
            this.txtLogicalRegionName.Location = new System.Drawing.Point(173, 27);
            this.txtLogicalRegionName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLogicalRegionName.Name = "txtLogicalRegionName";
            this.txtLogicalRegionName.Size = new System.Drawing.Size(403, 22);
            this.txtLogicalRegionName.TabIndex = 1;
            this.txtLogicalRegionName.TextChanged += new System.EventHandler(this.txtLogicalRegionName_TextChanged);
            // 
            // lblLogicalRegionName
            // 
            this.lblLogicalRegionName.AutoSize = true;
            this.lblLogicalRegionName.Location = new System.Drawing.Point(20, 31);
            this.lblLogicalRegionName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogicalRegionName.Name = "lblLogicalRegionName";
            this.lblLogicalRegionName.Size = new System.Drawing.Size(49, 17);
            this.lblLogicalRegionName.TabIndex = 0;
            this.lblLogicalRegionName.Text = "Name:";
            // 
            // listViewRegions
            // 
            this.listViewRegions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderRegionName,
            this.columnHeaderStartYMDV,
            this.columnHeaderEndYMDV});
            this.listViewRegions.FullRowSelect = true;
            this.listViewRegions.HideSelection = false;
            this.listViewRegions.Location = new System.Drawing.Point(20, 31);
            this.listViewRegions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewRegions.Name = "listViewRegions";
            this.listViewRegions.Size = new System.Drawing.Size(599, 184);
            this.listViewRegions.TabIndex = 0;
            this.listViewRegions.UseCompatibleStateImageBehavior = false;
            this.listViewRegions.View = System.Windows.Forms.View.Details;
            this.listViewRegions.SelectedIndexChanged += new System.EventHandler(this.listViewRegions_SelectedIndexChanged);
            // 
            // columnHeaderRegionName
            // 
            this.columnHeaderRegionName.Text = "Region";
            this.columnHeaderRegionName.Width = 240;
            // 
            // columnHeaderStartYMDV
            // 
            this.columnHeaderStartYMDV.Text = "Start";
            this.columnHeaderStartYMDV.Width = 90;
            // 
            // columnHeaderEndYMDV
            // 
            this.columnHeaderEndYMDV.Text = "End";
            this.columnHeaderEndYMDV.Width = 90;
            // 
            // tabPageLocation
            // 
            this.tabPageLocation.Controls.Add(this.groupBoxLocations);
            this.tabPageLocation.Location = new System.Drawing.Point(4, 25);
            this.tabPageLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageLocation.Name = "tabPageLocation";
            this.tabPageLocation.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageLocation.Size = new System.Drawing.Size(1552, 590);
            this.tabPageLocation.TabIndex = 1;
            this.tabPageLocation.Text = "Location";
            this.tabPageLocation.UseVisualStyleBackColor = true;
            // 
            // groupBoxLocations
            // 
            this.groupBoxLocations.Controls.Add(this.linkDepotDetails);
            this.groupBoxLocations.Controls.Add(this.linkLocationEditToken);
            this.groupBoxLocations.Controls.Add(this.linkLocationNewToken);
            this.groupBoxLocations.Controls.Add(this.groupBoxLocationOptions);
            this.groupBoxLocations.Controls.Add(this.groupBoxLocationPower);
            this.groupBoxLocations.Controls.Add(this.numericUpDownLocationScore);
            this.groupBoxLocations.Controls.Add(this.labelLocationScore);
            this.groupBoxLocations.Controls.Add(this.checkBoxLocationUseAsTimingPoint);
            this.groupBoxLocations.Controls.Add(this.lblLocationUseAsTimingPoint);
            this.groupBoxLocations.Controls.Add(this.checkBoxLocationTOPSOffice);
            this.groupBoxLocations.Controls.Add(this.labelLocationTOPSOffice);
            this.groupBoxLocations.Controls.Add(this.checkBoxLocationDisembarkPassengers);
            this.groupBoxLocations.Controls.Add(this.lblLocationDisembarkPassengers);
            this.groupBoxLocations.Controls.Add(this.checkBoxLocationEmbarkPassengers);
            this.groupBoxLocations.Controls.Add(this.lblLocationEmbarkPassengers);
            this.groupBoxLocations.Controls.Add(this.checkBoxLocationFreightOnly);
            this.groupBoxLocations.Controls.Add(this.lblLocationFreightOnly);
            this.groupBoxLocations.Controls.Add(this.checkBoxLocationSingleTrainWorking);
            this.groupBoxLocations.Controls.Add(this.labelLocationSingleTrainWorking);
            this.groupBoxLocations.Controls.Add(this.comboLocationToken);
            this.groupBoxLocations.Controls.Add(this.comboLocationDirections);
            this.groupBoxLocations.Controls.Add(this.lblLocationDirection);
            this.groupBoxLocations.Controls.Add(this.lblLocationBerths);
            this.groupBoxLocations.Controls.Add(this.numericUpDownLocationBerths);
            this.groupBoxLocations.Controls.Add(this.lblLocationToken);
            this.groupBoxLocations.Controls.Add(this.lblLengthMeters);
            this.groupBoxLocations.Controls.Add(this.txtLocationLength);
            this.groupBoxLocations.Controls.Add(this.lblLocationLength);
            this.groupBoxLocations.Controls.Add(this.txtLocationLongitude);
            this.groupBoxLocations.Controls.Add(this.lblLocationLongitude);
            this.groupBoxLocations.Controls.Add(this.txtLocationLatitude);
            this.groupBoxLocations.Controls.Add(this.lblLocationLatitude);
            this.groupBoxLocations.Controls.Add(this.comboLocationType);
            this.groupBoxLocations.Controls.Add(this.lblLocationType);
            this.groupBoxLocations.Controls.Add(this.txtLocationNLC);
            this.groupBoxLocations.Controls.Add(this.lblLocationNLC);
            this.groupBoxLocations.Controls.Add(this.txtLocationSTANME);
            this.groupBoxLocations.Controls.Add(this.lblLocationSTANME);
            this.groupBoxLocations.Controls.Add(this.txtLocationSTANOX);
            this.groupBoxLocations.Controls.Add(this.lblLocationSTANOX);
            this.groupBoxLocations.Controls.Add(this.txtLocationTIPLOC);
            this.groupBoxLocations.Controls.Add(this.lblLocationTIPLOC);
            this.groupBoxLocations.Controls.Add(this.lblLocationActiveTo);
            this.groupBoxLocations.Controls.Add(this.dateTimeLocationActiveFrom);
            this.groupBoxLocations.Controls.Add(this.dateTimeLocationActiveTo);
            this.groupBoxLocations.Controls.Add(this.lblLocationActiveFrom);
            this.groupBoxLocations.Controls.Add(this.txtLocationName);
            this.groupBoxLocations.Controls.Add(this.lblLocationName);
            this.groupBoxLocations.Controls.Add(this.treeViewLocations);
            this.groupBoxLocations.Controls.Add(this.linkLocationEdit);
            this.groupBoxLocations.Controls.Add(this.linkLocationNew);
            this.groupBoxLocations.Controls.Add(this.lblLocationLocation);
            this.groupBoxLocations.Controls.Add(this.comboLocationLocation);
            this.groupBoxLocations.Location = new System.Drawing.Point(16, 15);
            this.groupBoxLocations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLocations.Name = "groupBoxLocations";
            this.groupBoxLocations.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLocations.Size = new System.Drawing.Size(1513, 554);
            this.groupBoxLocations.TabIndex = 0;
            this.groupBoxLocations.TabStop = false;
            this.groupBoxLocations.Text = "Locations";
            // 
            // linkDepotDetails
            // 
            this.linkDepotDetails.AutoSize = true;
            this.linkDepotDetails.Location = new System.Drawing.Point(855, 126);
            this.linkDepotDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkDepotDetails.Name = "linkDepotDetails";
            this.linkDepotDetails.Size = new System.Drawing.Size(101, 17);
            this.linkDepotDetails.TabIndex = 61;
            this.linkDepotDetails.TabStop = true;
            this.linkDepotDetails.Text = "Depot Details..";
            this.linkDepotDetails.Click += new System.EventHandler(this.linkDepotDetails_Click);
            // 
            // linkLocationEditToken
            // 
            this.linkLocationEditToken.AutoSize = true;
            this.linkLocationEditToken.Location = new System.Drawing.Point(997, 220);
            this.linkLocationEditToken.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLocationEditToken.Name = "linkLocationEditToken";
            this.linkLocationEditToken.Size = new System.Drawing.Size(40, 17);
            this.linkLocationEditToken.TabIndex = 60;
            this.linkLocationEditToken.TabStop = true;
            this.linkLocationEditToken.Text = "Edit..";
            this.linkLocationEditToken.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLocationEditToken_LinkClicked);
            // 
            // linkLocationNewToken
            // 
            this.linkLocationNewToken.AutoSize = true;
            this.linkLocationNewToken.Location = new System.Drawing.Point(1047, 220);
            this.linkLocationNewToken.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLocationNewToken.Name = "linkLocationNewToken";
            this.linkLocationNewToken.Size = new System.Drawing.Size(43, 17);
            this.linkLocationNewToken.TabIndex = 59;
            this.linkLocationNewToken.TabStop = true;
            this.linkLocationNewToken.Text = "New..";
            this.linkLocationNewToken.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLocationNewToken_LinkClicked);
            // 
            // groupBoxLocationOptions
            // 
            this.groupBoxLocationOptions.Controls.Add(this.checkBoxLocationOptionCannotSurrenderToken);
            this.groupBoxLocationOptions.Controls.Add(this.labelLocationOptionCannotSurrenderToken);
            this.groupBoxLocationOptions.Controls.Add(this.checkBoxLocationOptionPassengerTrainCannotStop);
            this.groupBoxLocationOptions.Controls.Add(this.checkBoxLocationOptionOnlyStopIfReversing);
            this.groupBoxLocationOptions.Controls.Add(this.lblLocationOptionPassengerTrainsCannotStop);
            this.groupBoxLocationOptions.Controls.Add(this.lblLocationOptionOnlyStopIfReversing);
            this.groupBoxLocationOptions.Controls.Add(this.checkBoxLocationOptionCannotStop);
            this.groupBoxLocationOptions.Controls.Add(this.lblLocationOptionCannotStop);
            this.groupBoxLocationOptions.Controls.Add(this.checkBoxLocationOptionCallOn);
            this.groupBoxLocationOptions.Controls.Add(this.labelLocationOptionCallOn);
            this.groupBoxLocationOptions.Location = new System.Drawing.Point(1067, 352);
            this.groupBoxLocationOptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLocationOptions.Name = "groupBoxLocationOptions";
            this.groupBoxLocationOptions.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLocationOptions.Size = new System.Drawing.Size(425, 178);
            this.groupBoxLocationOptions.TabIndex = 58;
            this.groupBoxLocationOptions.TabStop = false;
            this.groupBoxLocationOptions.Text = "Options:";
            // 
            // checkBoxLocationOptionCannotSurrenderToken
            // 
            this.checkBoxLocationOptionCannotSurrenderToken.AutoSize = true;
            this.checkBoxLocationOptionCannotSurrenderToken.Location = new System.Drawing.Point(320, 80);
            this.checkBoxLocationOptionCannotSurrenderToken.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationOptionCannotSurrenderToken.Name = "checkBoxLocationOptionCannotSurrenderToken";
            this.checkBoxLocationOptionCannotSurrenderToken.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationOptionCannotSurrenderToken.TabIndex = 73;
            this.checkBoxLocationOptionCannotSurrenderToken.Tag = "16";
            this.checkBoxLocationOptionCannotSurrenderToken.UseVisualStyleBackColor = true;
            this.checkBoxLocationOptionCannotSurrenderToken.CheckedChanged += new System.EventHandler(this.checkBoxLocationOptionCannotSurrenderToken_CheckedChanged);
            // 
            // labelLocationOptionCannotSurrenderToken
            // 
            this.labelLocationOptionCannotSurrenderToken.Location = new System.Drawing.Point(169, 80);
            this.labelLocationOptionCannotSurrenderToken.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationOptionCannotSurrenderToken.Name = "labelLocationOptionCannotSurrenderToken";
            this.labelLocationOptionCannotSurrenderToken.Size = new System.Drawing.Size(143, 44);
            this.labelLocationOptionCannotSurrenderToken.TabIndex = 72;
            this.labelLocationOptionCannotSurrenderToken.Text = "Cannot Surrender Token?";
            // 
            // checkBoxLocationOptionPassengerTrainCannotStop
            // 
            this.checkBoxLocationOptionPassengerTrainCannotStop.AutoSize = true;
            this.checkBoxLocationOptionPassengerTrainCannotStop.Location = new System.Drawing.Point(140, 126);
            this.checkBoxLocationOptionPassengerTrainCannotStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationOptionPassengerTrainCannotStop.Name = "checkBoxLocationOptionPassengerTrainCannotStop";
            this.checkBoxLocationOptionPassengerTrainCannotStop.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationOptionPassengerTrainCannotStop.TabIndex = 71;
            this.checkBoxLocationOptionPassengerTrainCannotStop.Tag = "4";
            this.checkBoxLocationOptionPassengerTrainCannotStop.UseVisualStyleBackColor = true;
            this.checkBoxLocationOptionPassengerTrainCannotStop.CheckedChanged += new System.EventHandler(this.checkBoxLocationOptionPassengerTrainCannotStop_CheckedChanged);
            // 
            // checkBoxLocationOptionOnlyStopIfReversing
            // 
            this.checkBoxLocationOptionOnlyStopIfReversing.AutoSize = true;
            this.checkBoxLocationOptionOnlyStopIfReversing.Location = new System.Drawing.Point(141, 80);
            this.checkBoxLocationOptionOnlyStopIfReversing.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationOptionOnlyStopIfReversing.Name = "checkBoxLocationOptionOnlyStopIfReversing";
            this.checkBoxLocationOptionOnlyStopIfReversing.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationOptionOnlyStopIfReversing.TabIndex = 70;
            this.checkBoxLocationOptionOnlyStopIfReversing.Tag = "2";
            this.checkBoxLocationOptionOnlyStopIfReversing.UseVisualStyleBackColor = true;
            this.checkBoxLocationOptionOnlyStopIfReversing.CheckedChanged += new System.EventHandler(this.checkBoxLocationOptionOnlyStopIfReversing_CheckedChanged);
            // 
            // lblLocationOptionPassengerTrainsCannotStop
            // 
            this.lblLocationOptionPassengerTrainsCannotStop.Location = new System.Drawing.Point(19, 124);
            this.lblLocationOptionPassengerTrainsCannotStop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationOptionPassengerTrainsCannotStop.Name = "lblLocationOptionPassengerTrainsCannotStop";
            this.lblLocationOptionPassengerTrainsCannotStop.Size = new System.Drawing.Size(116, 38);
            this.lblLocationOptionPassengerTrainsCannotStop.TabIndex = 69;
            this.lblLocationOptionPassengerTrainsCannotStop.Text = "Passenger Train Cannot Stop?";
            // 
            // lblLocationOptionOnlyStopIfReversing
            // 
            this.lblLocationOptionOnlyStopIfReversing.Location = new System.Drawing.Point(19, 80);
            this.lblLocationOptionOnlyStopIfReversing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationOptionOnlyStopIfReversing.Name = "lblLocationOptionOnlyStopIfReversing";
            this.lblLocationOptionOnlyStopIfReversing.Size = new System.Drawing.Size(96, 44);
            this.lblLocationOptionOnlyStopIfReversing.TabIndex = 68;
            this.lblLocationOptionOnlyStopIfReversing.Text = "Only Stop If Reversing?";
            // 
            // checkBoxLocationOptionCannotStop
            // 
            this.checkBoxLocationOptionCannotStop.AutoSize = true;
            this.checkBoxLocationOptionCannotStop.Location = new System.Drawing.Point(141, 33);
            this.checkBoxLocationOptionCannotStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationOptionCannotStop.Name = "checkBoxLocationOptionCannotStop";
            this.checkBoxLocationOptionCannotStop.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationOptionCannotStop.TabIndex = 67;
            this.checkBoxLocationOptionCannotStop.Tag = "1";
            this.checkBoxLocationOptionCannotStop.UseVisualStyleBackColor = true;
            this.checkBoxLocationOptionCannotStop.CheckedChanged += new System.EventHandler(this.checkBoxLocationOptionCannotStop_CheckedChanged);
            // 
            // lblLocationOptionCannotStop
            // 
            this.lblLocationOptionCannotStop.AutoSize = true;
            this.lblLocationOptionCannotStop.Location = new System.Drawing.Point(19, 32);
            this.lblLocationOptionCannotStop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationOptionCannotStop.Name = "lblLocationOptionCannotStop";
            this.lblLocationOptionCannotStop.Size = new System.Drawing.Size(94, 17);
            this.lblLocationOptionCannotStop.TabIndex = 66;
            this.lblLocationOptionCannotStop.Text = "Cannot Stop?";
            // 
            // checkBoxLocationOptionCallOn
            // 
            this.checkBoxLocationOptionCallOn.AutoSize = true;
            this.checkBoxLocationOptionCallOn.Location = new System.Drawing.Point(320, 33);
            this.checkBoxLocationOptionCallOn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationOptionCallOn.Name = "checkBoxLocationOptionCallOn";
            this.checkBoxLocationOptionCallOn.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationOptionCallOn.TabIndex = 65;
            this.checkBoxLocationOptionCallOn.Tag = "8";
            this.checkBoxLocationOptionCallOn.UseVisualStyleBackColor = true;
            this.checkBoxLocationOptionCallOn.CheckedChanged += new System.EventHandler(this.checkBoxLocationOptionCallOn_CheckedChanged);
            // 
            // labelLocationOptionCallOn
            // 
            this.labelLocationOptionCallOn.AutoSize = true;
            this.labelLocationOptionCallOn.Location = new System.Drawing.Point(169, 32);
            this.labelLocationOptionCallOn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationOptionCallOn.Name = "labelLocationOptionCallOn";
            this.labelLocationOptionCallOn.Size = new System.Drawing.Size(91, 17);
            this.labelLocationOptionCallOn.TabIndex = 64;
            this.labelLocationOptionCallOn.Text = "Has Call On?";
            // 
            // groupBoxLocationPower
            // 
            this.groupBoxLocationPower.Controls.Add(this.checkBoxLocationPowerBattery);
            this.groupBoxLocationPower.Controls.Add(this.checkBoxLocationPowerOHead25);
            this.groupBoxLocationPower.Controls.Add(this.checkBoxLocationPowerOH625);
            this.groupBoxLocationPower.Controls.Add(this.checkBoxLocationPowerOH1500);
            this.groupBoxLocationPower.Controls.Add(this.checkBoxLocationPower3rd1500);
            this.groupBoxLocationPower.Controls.Add(this.checkBoxLocationPower3rd750);
            this.groupBoxLocationPower.Controls.Add(this.checkBoxLocationPower4th600);
            this.groupBoxLocationPower.Controls.Add(this.checkBoxLocationPowerDiesel);
            this.groupBoxLocationPower.Controls.Add(this.checkBoxLocationPowerSteam);
            this.groupBoxLocationPower.Controls.Add(this.labelLocationPowerBattery);
            this.groupBoxLocationPower.Controls.Add(this.labelLocationPowerOH25);
            this.groupBoxLocationPower.Controls.Add(this.labelLocationPowerOH625);
            this.groupBoxLocationPower.Controls.Add(this.labelLocationPowerOH1500);
            this.groupBoxLocationPower.Controls.Add(this.labelLocationPower3rd1500);
            this.groupBoxLocationPower.Controls.Add(this.labelLocationPower3rd750);
            this.groupBoxLocationPower.Controls.Add(this.labelLocationPower4th600);
            this.groupBoxLocationPower.Controls.Add(this.labelLocationPowerDiesel);
            this.groupBoxLocationPower.Controls.Add(this.labelLocationPowerSteam);
            this.groupBoxLocationPower.Location = new System.Drawing.Point(551, 352);
            this.groupBoxLocationPower.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLocationPower.Name = "groupBoxLocationPower";
            this.groupBoxLocationPower.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLocationPower.Size = new System.Drawing.Size(499, 178);
            this.groupBoxLocationPower.TabIndex = 57;
            this.groupBoxLocationPower.TabStop = false;
            this.groupBoxLocationPower.Text = "Power:";
            // 
            // checkBoxLocationPowerBattery
            // 
            this.checkBoxLocationPowerBattery.AutoSize = true;
            this.checkBoxLocationPowerBattery.Location = new System.Drawing.Point(468, 124);
            this.checkBoxLocationPowerBattery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationPowerBattery.Name = "checkBoxLocationPowerBattery";
            this.checkBoxLocationPowerBattery.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationPowerBattery.TabIndex = 65;
            this.checkBoxLocationPowerBattery.Tag = "256";
            this.checkBoxLocationPowerBattery.UseVisualStyleBackColor = true;
            this.checkBoxLocationPowerBattery.CheckedChanged += new System.EventHandler(this.checkBoxLocationPowerBattery_CheckedChanged);
            // 
            // checkBoxLocationPowerOHead25
            // 
            this.checkBoxLocationPowerOHead25.AutoSize = true;
            this.checkBoxLocationPowerOHead25.Location = new System.Drawing.Point(468, 79);
            this.checkBoxLocationPowerOHead25.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationPowerOHead25.Name = "checkBoxLocationPowerOHead25";
            this.checkBoxLocationPowerOHead25.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationPowerOHead25.TabIndex = 64;
            this.checkBoxLocationPowerOHead25.Tag = "128";
            this.checkBoxLocationPowerOHead25.UseVisualStyleBackColor = true;
            this.checkBoxLocationPowerOHead25.CheckedChanged += new System.EventHandler(this.checkBoxLocationPowerOHead25_CheckedChanged);
            // 
            // checkBoxLocationPowerOH625
            // 
            this.checkBoxLocationPowerOH625.AutoSize = true;
            this.checkBoxLocationPowerOH625.Location = new System.Drawing.Point(468, 32);
            this.checkBoxLocationPowerOH625.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationPowerOH625.Name = "checkBoxLocationPowerOH625";
            this.checkBoxLocationPowerOH625.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationPowerOH625.TabIndex = 63;
            this.checkBoxLocationPowerOH625.Tag = "64";
            this.checkBoxLocationPowerOH625.UseVisualStyleBackColor = true;
            this.checkBoxLocationPowerOH625.CheckedChanged += new System.EventHandler(this.checkBoxLocationPowerOH625_CheckedChanged);
            // 
            // checkBoxLocationPowerOH1500
            // 
            this.checkBoxLocationPowerOH1500.AutoSize = true;
            this.checkBoxLocationPowerOH1500.Location = new System.Drawing.Point(308, 126);
            this.checkBoxLocationPowerOH1500.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationPowerOH1500.Name = "checkBoxLocationPowerOH1500";
            this.checkBoxLocationPowerOH1500.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationPowerOH1500.TabIndex = 62;
            this.checkBoxLocationPowerOH1500.Tag = "32";
            this.checkBoxLocationPowerOH1500.UseVisualStyleBackColor = true;
            this.checkBoxLocationPowerOH1500.CheckedChanged += new System.EventHandler(this.checkBoxLocationPowerOH1500_CheckedChanged);
            // 
            // checkBoxLocationPower3rd1500
            // 
            this.checkBoxLocationPower3rd1500.AutoSize = true;
            this.checkBoxLocationPower3rd1500.Location = new System.Drawing.Point(308, 79);
            this.checkBoxLocationPower3rd1500.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationPower3rd1500.Name = "checkBoxLocationPower3rd1500";
            this.checkBoxLocationPower3rd1500.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationPower3rd1500.TabIndex = 61;
            this.checkBoxLocationPower3rd1500.Tag = "16";
            this.checkBoxLocationPower3rd1500.UseVisualStyleBackColor = true;
            this.checkBoxLocationPower3rd1500.CheckedChanged += new System.EventHandler(this.checkBoxLocationPower3rd1500_CheckedChanged);
            // 
            // checkBoxLocationPower3rd750
            // 
            this.checkBoxLocationPower3rd750.AutoSize = true;
            this.checkBoxLocationPower3rd750.Location = new System.Drawing.Point(308, 32);
            this.checkBoxLocationPower3rd750.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationPower3rd750.Name = "checkBoxLocationPower3rd750";
            this.checkBoxLocationPower3rd750.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationPower3rd750.TabIndex = 60;
            this.checkBoxLocationPower3rd750.Tag = "8";
            this.checkBoxLocationPower3rd750.UseVisualStyleBackColor = true;
            this.checkBoxLocationPower3rd750.CheckedChanged += new System.EventHandler(this.checkBoxLocationPower3rd750_CheckedChanged);
            // 
            // checkBoxLocationPower4th600
            // 
            this.checkBoxLocationPower4th600.AutoSize = true;
            this.checkBoxLocationPower4th600.Location = new System.Drawing.Point(127, 124);
            this.checkBoxLocationPower4th600.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationPower4th600.Name = "checkBoxLocationPower4th600";
            this.checkBoxLocationPower4th600.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationPower4th600.TabIndex = 59;
            this.checkBoxLocationPower4th600.Tag = "4";
            this.checkBoxLocationPower4th600.UseVisualStyleBackColor = true;
            this.checkBoxLocationPower4th600.CheckedChanged += new System.EventHandler(this.checkBoxLocationPower4th600_CheckedChanged);
            // 
            // checkBoxLocationPowerDiesel
            // 
            this.checkBoxLocationPowerDiesel.AutoSize = true;
            this.checkBoxLocationPowerDiesel.Location = new System.Drawing.Point(127, 79);
            this.checkBoxLocationPowerDiesel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationPowerDiesel.Name = "checkBoxLocationPowerDiesel";
            this.checkBoxLocationPowerDiesel.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationPowerDiesel.TabIndex = 58;
            this.checkBoxLocationPowerDiesel.Tag = "2";
            this.checkBoxLocationPowerDiesel.UseVisualStyleBackColor = true;
            this.checkBoxLocationPowerDiesel.CheckedChanged += new System.EventHandler(this.checkBoxLocationPowerDiesel_CheckedChanged);
            // 
            // checkBoxLocationPowerSteam
            // 
            this.checkBoxLocationPowerSteam.AutoSize = true;
            this.checkBoxLocationPowerSteam.Location = new System.Drawing.Point(127, 31);
            this.checkBoxLocationPowerSteam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationPowerSteam.Name = "checkBoxLocationPowerSteam";
            this.checkBoxLocationPowerSteam.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationPowerSteam.TabIndex = 57;
            this.checkBoxLocationPowerSteam.Tag = "1";
            this.checkBoxLocationPowerSteam.UseVisualStyleBackColor = true;
            this.checkBoxLocationPowerSteam.CheckedChanged += new System.EventHandler(this.checkBoxLocationPowerSteam_CheckedChanged);
            // 
            // labelLocationPowerBattery
            // 
            this.labelLocationPowerBattery.AutoSize = true;
            this.labelLocationPowerBattery.Location = new System.Drawing.Point(403, 124);
            this.labelLocationPowerBattery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationPowerBattery.Name = "labelLocationPowerBattery";
            this.labelLocationPowerBattery.Size = new System.Drawing.Size(57, 17);
            this.labelLocationPowerBattery.TabIndex = 56;
            this.labelLocationPowerBattery.Text = "Battery:";
            // 
            // labelLocationPowerOH25
            // 
            this.labelLocationPowerOH25.AutoSize = true;
            this.labelLocationPowerOH25.Location = new System.Drawing.Point(357, 80);
            this.labelLocationPowerOH25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationPowerOH25.Name = "labelLocationPowerOH25";
            this.labelLocationPowerOH25.Size = new System.Drawing.Size(97, 17);
            this.labelLocationPowerOH25.TabIndex = 55;
            this.labelLocationPowerOH25.Text = "O/Head 25kV:";
            // 
            // labelLocationPowerOH625
            // 
            this.labelLocationPowerOH625.AutoSize = true;
            this.labelLocationPowerOH625.Location = new System.Drawing.Point(345, 31);
            this.labelLocationPowerOH625.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationPowerOH625.Name = "labelLocationPowerOH625";
            this.labelLocationPowerOH625.Size = new System.Drawing.Size(109, 17);
            this.labelLocationPowerOH625.TabIndex = 54;
            this.labelLocationPowerOH625.Text = "O/Head 6.25kV:";
            // 
            // labelLocationPowerOH1500
            // 
            this.labelLocationPowerOH1500.AutoSize = true;
            this.labelLocationPowerOH1500.Location = new System.Drawing.Point(169, 126);
            this.labelLocationPowerOH1500.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationPowerOH1500.Name = "labelLocationPowerOH1500";
            this.labelLocationPowerOH1500.Size = new System.Drawing.Size(129, 17);
            this.labelLocationPowerOH1500.TabIndex = 53;
            this.labelLocationPowerOH1500.Text = "O/Head 1500V DC:";
            // 
            // labelLocationPower3rd1500
            // 
            this.labelLocationPower3rd1500.AutoSize = true;
            this.labelLocationPower3rd1500.Location = new System.Drawing.Point(197, 80);
            this.labelLocationPower3rd1500.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationPower3rd1500.Name = "labelLocationPower3rd1500";
            this.labelLocationPower3rd1500.Size = new System.Drawing.Size(106, 17);
            this.labelLocationPower3rd1500.TabIndex = 52;
            this.labelLocationPower3rd1500.Text = "3rd Rail 1500V:";
            // 
            // labelLocationPower3rd750
            // 
            this.labelLocationPower3rd750.AutoSize = true;
            this.labelLocationPower3rd750.Location = new System.Drawing.Point(205, 32);
            this.labelLocationPower3rd750.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationPower3rd750.Name = "labelLocationPower3rd750";
            this.labelLocationPower3rd750.Size = new System.Drawing.Size(98, 17);
            this.labelLocationPower3rd750.TabIndex = 51;
            this.labelLocationPower3rd750.Text = "3rd Rail 750V:";
            // 
            // labelLocationPower4th600
            // 
            this.labelLocationPower4th600.AutoSize = true;
            this.labelLocationPower4th600.Location = new System.Drawing.Point(20, 124);
            this.labelLocationPower4th600.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationPower4th600.Name = "labelLocationPower4th600";
            this.labelLocationPower4th600.Size = new System.Drawing.Size(97, 17);
            this.labelLocationPower4th600.TabIndex = 50;
            this.labelLocationPower4th600.Text = "4th Rail 600V:";
            // 
            // labelLocationPowerDiesel
            // 
            this.labelLocationPowerDiesel.AutoSize = true;
            this.labelLocationPowerDiesel.Location = new System.Drawing.Point(67, 79);
            this.labelLocationPowerDiesel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationPowerDiesel.Name = "labelLocationPowerDiesel";
            this.labelLocationPowerDiesel.Size = new System.Drawing.Size(51, 17);
            this.labelLocationPowerDiesel.TabIndex = 49;
            this.labelLocationPowerDiesel.Text = "Diesel:";
            // 
            // labelLocationPowerSteam
            // 
            this.labelLocationPowerSteam.AutoSize = true;
            this.labelLocationPowerSteam.Location = new System.Drawing.Point(65, 32);
            this.labelLocationPowerSteam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationPowerSteam.Name = "labelLocationPowerSteam";
            this.labelLocationPowerSteam.Size = new System.Drawing.Size(52, 17);
            this.labelLocationPowerSteam.TabIndex = 48;
            this.labelLocationPowerSteam.Text = "Steam:";
            // 
            // numericUpDownLocationScore
            // 
            this.numericUpDownLocationScore.Location = new System.Drawing.Point(1067, 310);
            this.numericUpDownLocationScore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownLocationScore.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownLocationScore.Name = "numericUpDownLocationScore";
            this.numericUpDownLocationScore.Size = new System.Drawing.Size(72, 22);
            this.numericUpDownLocationScore.TabIndex = 56;
            this.numericUpDownLocationScore.ValueChanged += new System.EventHandler(this.numericUpDownLocationScore_ValueChanged);
            // 
            // labelLocationScore
            // 
            this.labelLocationScore.AutoSize = true;
            this.labelLocationScore.Location = new System.Drawing.Point(985, 313);
            this.labelLocationScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationScore.Name = "labelLocationScore";
            this.labelLocationScore.Size = new System.Drawing.Size(49, 17);
            this.labelLocationScore.TabIndex = 55;
            this.labelLocationScore.Text = "Score:";
            // 
            // checkBoxLocationUseAsTimingPoint
            // 
            this.checkBoxLocationUseAsTimingPoint.AutoSize = true;
            this.checkBoxLocationUseAsTimingPoint.Location = new System.Drawing.Point(1067, 265);
            this.checkBoxLocationUseAsTimingPoint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationUseAsTimingPoint.Name = "checkBoxLocationUseAsTimingPoint";
            this.checkBoxLocationUseAsTimingPoint.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationUseAsTimingPoint.TabIndex = 54;
            this.checkBoxLocationUseAsTimingPoint.UseVisualStyleBackColor = true;
            this.checkBoxLocationUseAsTimingPoint.CheckedChanged += new System.EventHandler(this.checkBoxLocationUseAsTimingPoint_CheckedChanged);
            // 
            // lblLocationUseAsTimingPoint
            // 
            this.lblLocationUseAsTimingPoint.AutoSize = true;
            this.lblLocationUseAsTimingPoint.Location = new System.Drawing.Point(919, 266);
            this.lblLocationUseAsTimingPoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationUseAsTimingPoint.Name = "lblLocationUseAsTimingPoint";
            this.lblLocationUseAsTimingPoint.Size = new System.Drawing.Size(139, 17);
            this.lblLocationUseAsTimingPoint.TabIndex = 53;
            this.lblLocationUseAsTimingPoint.Text = "Use As Timing Point:";
            // 
            // checkBoxLocationTOPSOffice
            // 
            this.checkBoxLocationTOPSOffice.AutoSize = true;
            this.checkBoxLocationTOPSOffice.Location = new System.Drawing.Point(1284, 267);
            this.checkBoxLocationTOPSOffice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationTOPSOffice.Name = "checkBoxLocationTOPSOffice";
            this.checkBoxLocationTOPSOffice.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationTOPSOffice.TabIndex = 52;
            this.checkBoxLocationTOPSOffice.UseVisualStyleBackColor = true;
            this.checkBoxLocationTOPSOffice.CheckedChanged += new System.EventHandler(this.checkBoxLocationTOPSOffice_CheckedChanged);
            // 
            // labelLocationTOPSOffice
            // 
            this.labelLocationTOPSOffice.AutoSize = true;
            this.labelLocationTOPSOffice.Location = new System.Drawing.Point(1185, 270);
            this.labelLocationTOPSOffice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationTOPSOffice.Name = "labelLocationTOPSOffice";
            this.labelLocationTOPSOffice.Size = new System.Drawing.Size(91, 17);
            this.labelLocationTOPSOffice.TabIndex = 51;
            this.labelLocationTOPSOffice.Text = "TOPS Office:";
            // 
            // checkBoxLocationDisembarkPassengers
            // 
            this.checkBoxLocationDisembarkPassengers.AutoSize = true;
            this.checkBoxLocationDisembarkPassengers.Location = new System.Drawing.Point(847, 313);
            this.checkBoxLocationDisembarkPassengers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationDisembarkPassengers.Name = "checkBoxLocationDisembarkPassengers";
            this.checkBoxLocationDisembarkPassengers.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationDisembarkPassengers.TabIndex = 50;
            this.checkBoxLocationDisembarkPassengers.UseVisualStyleBackColor = true;
            this.checkBoxLocationDisembarkPassengers.CheckedChanged += new System.EventHandler(this.checkBoxLocationDisembarkPassengers_CheckedChanged);
            // 
            // lblLocationDisembarkPassengers
            // 
            this.lblLocationDisembarkPassengers.AutoSize = true;
            this.lblLocationDisembarkPassengers.Location = new System.Drawing.Point(685, 313);
            this.lblLocationDisembarkPassengers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationDisembarkPassengers.Name = "lblLocationDisembarkPassengers";
            this.lblLocationDisembarkPassengers.Size = new System.Drawing.Size(158, 17);
            this.lblLocationDisembarkPassengers.TabIndex = 49;
            this.lblLocationDisembarkPassengers.Text = "Disembark Passengers:";
            // 
            // checkBoxLocationEmbarkPassengers
            // 
            this.checkBoxLocationEmbarkPassengers.AutoSize = true;
            this.checkBoxLocationEmbarkPassengers.Location = new System.Drawing.Point(847, 266);
            this.checkBoxLocationEmbarkPassengers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationEmbarkPassengers.Name = "checkBoxLocationEmbarkPassengers";
            this.checkBoxLocationEmbarkPassengers.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationEmbarkPassengers.TabIndex = 48;
            this.checkBoxLocationEmbarkPassengers.UseVisualStyleBackColor = true;
            this.checkBoxLocationEmbarkPassengers.CheckedChanged += new System.EventHandler(this.checkBoxLocationEmbarkPassengers_CheckedChanged);
            // 
            // lblLocationEmbarkPassengers
            // 
            this.lblLocationEmbarkPassengers.AutoSize = true;
            this.lblLocationEmbarkPassengers.Location = new System.Drawing.Point(704, 266);
            this.lblLocationEmbarkPassengers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationEmbarkPassengers.Name = "lblLocationEmbarkPassengers";
            this.lblLocationEmbarkPassengers.Size = new System.Drawing.Size(139, 17);
            this.lblLocationEmbarkPassengers.TabIndex = 47;
            this.lblLocationEmbarkPassengers.Text = "Embark Passengers:";
            // 
            // checkBoxLocationFreightOnly
            // 
            this.checkBoxLocationFreightOnly.AutoSize = true;
            this.checkBoxLocationFreightOnly.Location = new System.Drawing.Point(643, 266);
            this.checkBoxLocationFreightOnly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationFreightOnly.Name = "checkBoxLocationFreightOnly";
            this.checkBoxLocationFreightOnly.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationFreightOnly.TabIndex = 46;
            this.checkBoxLocationFreightOnly.UseVisualStyleBackColor = true;
            this.checkBoxLocationFreightOnly.CheckedChanged += new System.EventHandler(this.checkBoxLocationFreightOnly_CheckedChanged);
            // 
            // lblLocationFreightOnly
            // 
            this.lblLocationFreightOnly.AutoSize = true;
            this.lblLocationFreightOnly.Location = new System.Drawing.Point(547, 266);
            this.lblLocationFreightOnly.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationFreightOnly.Name = "lblLocationFreightOnly";
            this.lblLocationFreightOnly.Size = new System.Drawing.Size(89, 17);
            this.lblLocationFreightOnly.TabIndex = 45;
            this.lblLocationFreightOnly.Text = "Freight Only:";
            // 
            // checkBoxLocationSingleTrainWorking
            // 
            this.checkBoxLocationSingleTrainWorking.AutoSize = true;
            this.checkBoxLocationSingleTrainWorking.Location = new System.Drawing.Point(1284, 219);
            this.checkBoxLocationSingleTrainWorking.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLocationSingleTrainWorking.Name = "checkBoxLocationSingleTrainWorking";
            this.checkBoxLocationSingleTrainWorking.Size = new System.Drawing.Size(18, 17);
            this.checkBoxLocationSingleTrainWorking.TabIndex = 44;
            this.checkBoxLocationSingleTrainWorking.UseVisualStyleBackColor = true;
            this.checkBoxLocationSingleTrainWorking.CheckedChanged += new System.EventHandler(this.checkBoxLocationSingleTrainWorking_CheckedChanged);
            // 
            // labelLocationSingleTrainWorking
            // 
            this.labelLocationSingleTrainWorking.AutoSize = true;
            this.labelLocationSingleTrainWorking.Location = new System.Drawing.Point(1131, 219);
            this.labelLocationSingleTrainWorking.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocationSingleTrainWorking.Name = "labelLocationSingleTrainWorking";
            this.labelLocationSingleTrainWorking.Size = new System.Drawing.Size(144, 17);
            this.labelLocationSingleTrainWorking.TabIndex = 43;
            this.labelLocationSingleTrainWorking.Text = "Single Train Working:";
            // 
            // comboLocationToken
            // 
            this.comboLocationToken.FormattingEnabled = true;
            this.comboLocationToken.Location = new System.Drawing.Point(643, 215);
            this.comboLocationToken.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboLocationToken.Name = "comboLocationToken";
            this.comboLocationToken.Size = new System.Drawing.Size(341, 24);
            this.comboLocationToken.TabIndex = 42;
            this.comboLocationToken.SelectedIndexChanged += new System.EventHandler(this.comboBoxToken_SelectedIndexChanged);
            // 
            // comboLocationDirections
            // 
            this.comboLocationDirections.FormattingEnabled = true;
            this.comboLocationDirections.Location = new System.Drawing.Point(1284, 167);
            this.comboLocationDirections.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboLocationDirections.Name = "comboLocationDirections";
            this.comboLocationDirections.Size = new System.Drawing.Size(207, 24);
            this.comboLocationDirections.TabIndex = 41;
            this.comboLocationDirections.SelectedIndexChanged += new System.EventHandler(this.comboLocationDirections_SelectedIndexChanged);
            // 
            // lblLocationDirection
            // 
            this.lblLocationDirection.AutoSize = true;
            this.lblLocationDirection.Location = new System.Drawing.Point(1203, 172);
            this.lblLocationDirection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationDirection.Name = "lblLocationDirection";
            this.lblLocationDirection.Size = new System.Drawing.Size(75, 17);
            this.lblLocationDirection.TabIndex = 40;
            this.lblLocationDirection.Text = "Directions:";
            // 
            // lblLocationBerths
            // 
            this.lblLocationBerths.AutoSize = true;
            this.lblLocationBerths.Location = new System.Drawing.Point(985, 177);
            this.lblLocationBerths.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationBerths.Name = "lblLocationBerths";
            this.lblLocationBerths.Size = new System.Drawing.Size(53, 17);
            this.lblLocationBerths.TabIndex = 39;
            this.lblLocationBerths.Text = "Berths:";
            // 
            // numericUpDownLocationBerths
            // 
            this.numericUpDownLocationBerths.Location = new System.Drawing.Point(1067, 172);
            this.numericUpDownLocationBerths.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownLocationBerths.Name = "numericUpDownLocationBerths";
            this.numericUpDownLocationBerths.Size = new System.Drawing.Size(72, 22);
            this.numericUpDownLocationBerths.TabIndex = 38;
            this.numericUpDownLocationBerths.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLocationBerths.ValueChanged += new System.EventHandler(this.numericUpDownLocationBerths_ValueChanged);
            // 
            // lblLocationToken
            // 
            this.lblLocationToken.AutoSize = true;
            this.lblLocationToken.Location = new System.Drawing.Point(547, 219);
            this.lblLocationToken.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationToken.Name = "lblLocationToken";
            this.lblLocationToken.Size = new System.Drawing.Size(52, 17);
            this.lblLocationToken.TabIndex = 37;
            this.lblLocationToken.Text = "Token:";
            // 
            // lblLengthMeters
            // 
            this.lblLengthMeters.AutoSize = true;
            this.lblLengthMeters.Location = new System.Drawing.Point(748, 172);
            this.lblLengthMeters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLengthMeters.Name = "lblLengthMeters";
            this.lblLengthMeters.Size = new System.Drawing.Size(51, 17);
            this.lblLengthMeters.TabIndex = 36;
            this.lblLengthMeters.Text = "meters";
            // 
            // txtLocationLength
            // 
            this.txtLocationLength.Location = new System.Drawing.Point(643, 169);
            this.txtLocationLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLocationLength.Name = "txtLocationLength";
            this.txtLocationLength.Size = new System.Drawing.Size(96, 22);
            this.txtLocationLength.TabIndex = 35;
            this.txtLocationLength.TextChanged += new System.EventHandler(this.txtLocationLength_TextChanged);
            // 
            // lblLocationLength
            // 
            this.lblLocationLength.AutoSize = true;
            this.lblLocationLength.Location = new System.Drawing.Point(547, 172);
            this.lblLocationLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationLength.Name = "lblLocationLength";
            this.lblLocationLength.Size = new System.Drawing.Size(56, 17);
            this.lblLocationLength.TabIndex = 34;
            this.lblLocationLength.Text = "Length:";
            // 
            // txtLocationLongitude
            // 
            this.txtLocationLongitude.Location = new System.Drawing.Point(1284, 122);
            this.txtLocationLongitude.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLocationLongitude.Name = "txtLocationLongitude";
            this.txtLocationLongitude.Size = new System.Drawing.Size(96, 22);
            this.txtLocationLongitude.TabIndex = 33;
            this.txtLocationLongitude.TextChanged += new System.EventHandler(this.txtLocationLongitude_TextChanged);
            // 
            // lblLocationLongitude
            // 
            this.lblLocationLongitude.AutoSize = true;
            this.lblLocationLongitude.Location = new System.Drawing.Point(1203, 126);
            this.lblLocationLongitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationLongitude.Name = "lblLocationLongitude";
            this.lblLocationLongitude.Size = new System.Drawing.Size(75, 17);
            this.lblLocationLongitude.TabIndex = 32;
            this.lblLocationLongitude.Text = "Longitude:";
            // 
            // txtLocationLatitude
            // 
            this.txtLocationLatitude.Location = new System.Drawing.Point(1067, 122);
            this.txtLocationLatitude.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLocationLatitude.Name = "txtLocationLatitude";
            this.txtLocationLatitude.Size = new System.Drawing.Size(96, 22);
            this.txtLocationLatitude.TabIndex = 31;
            this.txtLocationLatitude.TextChanged += new System.EventHandler(this.txtLocationLatitude_TextChanged);
            // 
            // lblLocationLatitude
            // 
            this.lblLocationLatitude.AutoSize = true;
            this.lblLocationLatitude.Location = new System.Drawing.Point(985, 126);
            this.lblLocationLatitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationLatitude.Name = "lblLocationLatitude";
            this.lblLocationLatitude.Size = new System.Drawing.Size(63, 17);
            this.lblLocationLatitude.TabIndex = 30;
            this.lblLocationLatitude.Text = "Latitude:";
            // 
            // comboLocationType
            // 
            this.comboLocationType.FormattingEnabled = true;
            this.comboLocationType.Location = new System.Drawing.Point(643, 122);
            this.comboLocationType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboLocationType.Name = "comboLocationType";
            this.comboLocationType.Size = new System.Drawing.Size(199, 24);
            this.comboLocationType.TabIndex = 29;
            this.comboLocationType.SelectedIndexChanged += new System.EventHandler(this.comboLocationType_SelectedIndexChanged);
            // 
            // lblLocationType
            // 
            this.lblLocationType.AutoSize = true;
            this.lblLocationType.Location = new System.Drawing.Point(547, 126);
            this.lblLocationType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationType.Name = "lblLocationType";
            this.lblLocationType.Size = new System.Drawing.Size(44, 17);
            this.lblLocationType.TabIndex = 28;
            this.lblLocationType.Text = "Type:";
            // 
            // txtLocationNLC
            // 
            this.txtLocationNLC.Location = new System.Drawing.Point(1284, 75);
            this.txtLocationNLC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLocationNLC.Name = "txtLocationNLC";
            this.txtLocationNLC.Size = new System.Drawing.Size(96, 22);
            this.txtLocationNLC.TabIndex = 27;
            this.txtLocationNLC.TextChanged += new System.EventHandler(this.txtLocationNLC_TextChanged);
            // 
            // lblLocationNLC
            // 
            this.lblLocationNLC.AutoSize = true;
            this.lblLocationNLC.Location = new System.Drawing.Point(1203, 79);
            this.lblLocationNLC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationNLC.Name = "lblLocationNLC";
            this.lblLocationNLC.Size = new System.Drawing.Size(39, 17);
            this.lblLocationNLC.TabIndex = 26;
            this.lblLocationNLC.Text = "NLC:";
            // 
            // txtLocationSTANME
            // 
            this.txtLocationSTANME.Location = new System.Drawing.Point(1067, 75);
            this.txtLocationSTANME.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLocationSTANME.Name = "txtLocationSTANME";
            this.txtLocationSTANME.Size = new System.Drawing.Size(96, 22);
            this.txtLocationSTANME.TabIndex = 25;
            this.txtLocationSTANME.TextChanged += new System.EventHandler(this.txtLocationSTANME_TextChanged);
            // 
            // lblLocationSTANME
            // 
            this.lblLocationSTANME.AutoSize = true;
            this.lblLocationSTANME.Location = new System.Drawing.Point(985, 79);
            this.lblLocationSTANME.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationSTANME.Name = "lblLocationSTANME";
            this.lblLocationSTANME.Size = new System.Drawing.Size(69, 17);
            this.lblLocationSTANME.TabIndex = 24;
            this.lblLocationSTANME.Text = "STANME:";
            // 
            // txtLocationSTANOX
            // 
            this.txtLocationSTANOX.Location = new System.Drawing.Point(852, 75);
            this.txtLocationSTANOX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLocationSTANOX.Name = "txtLocationSTANOX";
            this.txtLocationSTANOX.Size = new System.Drawing.Size(96, 22);
            this.txtLocationSTANOX.TabIndex = 23;
            this.txtLocationSTANOX.TextChanged += new System.EventHandler(this.txtLocationSTANOX_TextChanged);
            // 
            // lblLocationSTANOX
            // 
            this.lblLocationSTANOX.AutoSize = true;
            this.lblLocationSTANOX.Location = new System.Drawing.Point(771, 79);
            this.lblLocationSTANOX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationSTANOX.Name = "lblLocationSTANOX";
            this.lblLocationSTANOX.Size = new System.Drawing.Size(69, 17);
            this.lblLocationSTANOX.TabIndex = 22;
            this.lblLocationSTANOX.Text = "STANOX:";
            // 
            // txtLocationTIPLOC
            // 
            this.txtLocationTIPLOC.Location = new System.Drawing.Point(643, 75);
            this.txtLocationTIPLOC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLocationTIPLOC.Name = "txtLocationTIPLOC";
            this.txtLocationTIPLOC.Size = new System.Drawing.Size(96, 22);
            this.txtLocationTIPLOC.TabIndex = 21;
            this.txtLocationTIPLOC.TextChanged += new System.EventHandler(this.txtLocationTIPLOC_TextChanged);
            // 
            // lblLocationTIPLOC
            // 
            this.lblLocationTIPLOC.AutoSize = true;
            this.lblLocationTIPLOC.Location = new System.Drawing.Point(547, 79);
            this.lblLocationTIPLOC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationTIPLOC.Name = "lblLocationTIPLOC";
            this.lblLocationTIPLOC.Size = new System.Drawing.Size(61, 17);
            this.lblLocationTIPLOC.TabIndex = 20;
            this.lblLocationTIPLOC.Text = "TIPLOC:";
            // 
            // lblLocationActiveTo
            // 
            this.lblLocationActiveTo.AutoSize = true;
            this.lblLocationActiveTo.Location = new System.Drawing.Point(1328, 32);
            this.lblLocationActiveTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationActiveTo.Name = "lblLocationActiveTo";
            this.lblLocationActiveTo.Size = new System.Drawing.Size(24, 17);
            this.lblLocationActiveTo.TabIndex = 19;
            this.lblLocationActiveTo.Text = "to:";
            // 
            // dateTimeLocationActiveFrom
            // 
            this.dateTimeLocationActiveFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeLocationActiveFrom.Location = new System.Drawing.Point(1184, 27);
            this.dateTimeLocationActiveFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimeLocationActiveFrom.Name = "dateTimeLocationActiveFrom";
            this.dateTimeLocationActiveFrom.Size = new System.Drawing.Size(132, 22);
            this.dateTimeLocationActiveFrom.TabIndex = 16;
            this.dateTimeLocationActiveFrom.ValueChanged += new System.EventHandler(this.dateTimeLocationActiveFrom_ValueChanged);
            // 
            // dateTimeLocationActiveTo
            // 
            this.dateTimeLocationActiveTo.Enabled = false;
            this.dateTimeLocationActiveTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeLocationActiveTo.Location = new System.Drawing.Point(1359, 27);
            this.dateTimeLocationActiveTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimeLocationActiveTo.Name = "dateTimeLocationActiveTo";
            this.dateTimeLocationActiveTo.ShowCheckBox = true;
            this.dateTimeLocationActiveTo.Size = new System.Drawing.Size(132, 22);
            this.dateTimeLocationActiveTo.TabIndex = 18;
            // 
            // lblLocationActiveFrom
            // 
            this.lblLocationActiveFrom.AutoSize = true;
            this.lblLocationActiveFrom.Location = new System.Drawing.Point(1031, 32);
            this.lblLocationActiveFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationActiveFrom.Name = "lblLocationActiveFrom";
            this.lblLocationActiveFrom.Size = new System.Drawing.Size(144, 17);
            this.lblLocationActiveFrom.TabIndex = 17;
            this.lblLocationActiveFrom.Text = "Location Active From:";
            // 
            // txtLocationName
            // 
            this.txtLocationName.Location = new System.Drawing.Point(643, 28);
            this.txtLocationName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Size = new System.Drawing.Size(341, 22);
            this.txtLocationName.TabIndex = 12;
            this.txtLocationName.TextChanged += new System.EventHandler(this.txtLocationName_TextChanged);
            // 
            // lblLocationName
            // 
            this.lblLocationName.AutoSize = true;
            this.lblLocationName.Location = new System.Drawing.Point(547, 32);
            this.lblLocationName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationName.Name = "lblLocationName";
            this.lblLocationName.Size = new System.Drawing.Size(49, 17);
            this.lblLocationName.TabIndex = 11;
            this.lblLocationName.Text = "Name:";
            // 
            // treeViewLocations
            // 
            this.treeViewLocations.ContextMenuStrip = this.contextMenuStripLocationTreeView;
            this.treeViewLocations.HideSelection = false;
            this.treeViewLocations.Location = new System.Drawing.Point(25, 79);
            this.treeViewLocations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeViewLocations.Name = "treeViewLocations";
            this.treeViewLocations.Size = new System.Drawing.Size(499, 451);
            this.treeViewLocations.TabIndex = 10;
            this.treeViewLocations.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewLocations_AfterSelect);
            this.treeViewLocations.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewLocations_MouseUp);
            // 
            // contextMenuStripLocationTreeView
            // 
            this.contextMenuStripLocationTreeView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripLocationTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newChildLocationToolStripMenuItem});
            this.contextMenuStripLocationTreeView.Name = "contextMenuStripLocationTreeView";
            this.contextMenuStripLocationTreeView.Size = new System.Drawing.Size(214, 28);
            // 
            // newChildLocationToolStripMenuItem
            // 
            this.newChildLocationToolStripMenuItem.Name = "newChildLocationToolStripMenuItem";
            this.newChildLocationToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.newChildLocationToolStripMenuItem.Text = "New Child Location..";
            this.newChildLocationToolStripMenuItem.Click += new System.EventHandler(this.newChildLocationToolStripMenuItem_Click);
            // 
            // linkLocationEdit
            // 
            this.linkLocationEdit.AutoSize = true;
            this.linkLocationEdit.Location = new System.Drawing.Point(429, 32);
            this.linkLocationEdit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLocationEdit.Name = "linkLocationEdit";
            this.linkLocationEdit.Size = new System.Drawing.Size(40, 17);
            this.linkLocationEdit.TabIndex = 9;
            this.linkLocationEdit.TabStop = true;
            this.linkLocationEdit.Text = "Edit..";
            this.linkLocationEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLocationEdit_LinkClicked);
            // 
            // linkLocationNew
            // 
            this.linkLocationNew.AutoSize = true;
            this.linkLocationNew.Location = new System.Drawing.Point(479, 32);
            this.linkLocationNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLocationNew.Name = "linkLocationNew";
            this.linkLocationNew.Size = new System.Drawing.Size(43, 17);
            this.linkLocationNew.TabIndex = 8;
            this.linkLocationNew.TabStop = true;
            this.linkLocationNew.Text = "New..";
            this.linkLocationNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLocationNew_LinkClicked);
            // 
            // lblLocationLocation
            // 
            this.lblLocationLocation.AutoSize = true;
            this.lblLocationLocation.Location = new System.Drawing.Point(21, 32);
            this.lblLocationLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationLocation.Name = "lblLocationLocation";
            this.lblLocationLocation.Size = new System.Drawing.Size(66, 17);
            this.lblLocationLocation.TabIndex = 7;
            this.lblLocationLocation.Text = "Location:";
            // 
            // comboLocationLocation
            // 
            this.comboLocationLocation.FormattingEnabled = true;
            this.comboLocationLocation.Location = new System.Drawing.Point(121, 28);
            this.comboLocationLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboLocationLocation.Name = "comboLocationLocation";
            this.comboLocationLocation.Size = new System.Drawing.Size(299, 24);
            this.comboLocationLocation.TabIndex = 6;
            this.comboLocationLocation.SelectedIndexChanged += new System.EventHandler(this.comboLocationLocation_SelectedIndexChanged);
            // 
            // tabPageTraction
            // 
            this.tabPageTraction.Controls.Add(this.groupBoxTractionClass);
            this.tabPageTraction.Location = new System.Drawing.Point(4, 25);
            this.tabPageTraction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageTraction.Name = "tabPageTraction";
            this.tabPageTraction.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageTraction.Size = new System.Drawing.Size(1552, 590);
            this.tabPageTraction.TabIndex = 2;
            this.tabPageTraction.Text = "Traction";
            this.tabPageTraction.UseVisualStyleBackColor = true;
            // 
            // groupBoxTractionClass
            // 
            this.groupBoxTractionClass.Controls.Add(this.panelTractionClassDetails);
            this.groupBoxTractionClass.Controls.Add(this.listViewTractionClasses);
            this.groupBoxTractionClass.Controls.Add(this.comboTractionType);
            this.groupBoxTractionClass.Controls.Add(this.lblTractionType);
            this.groupBoxTractionClass.Location = new System.Drawing.Point(16, 15);
            this.groupBoxTractionClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTractionClass.Name = "groupBoxTractionClass";
            this.groupBoxTractionClass.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTractionClass.Size = new System.Drawing.Size(525, 550);
            this.groupBoxTractionClass.TabIndex = 0;
            this.groupBoxTractionClass.TabStop = false;
            this.groupBoxTractionClass.Text = "Class";
            // 
            // panelTractionClassDetails
            // 
            this.panelTractionClassDetails.Controls.Add(this.numericUpDownTractionTractionClassRA);
            this.panelTractionClassDetails.Controls.Add(this.lblTractionTractionClassRA);
            this.panelTractionClassDetails.Controls.Add(this.numericUpDownTractionTractionClassLength);
            this.panelTractionClassDetails.Controls.Add(this.lblTractionTractionClassLength);
            this.panelTractionClassDetails.Controls.Add(this.lblTractionTractionClassParent);
            this.panelTractionClassDetails.Controls.Add(this.comboTractionTractionClassType);
            this.panelTractionClassDetails.Controls.Add(this.lblTractionTractionClassType);
            this.panelTractionClassDetails.Controls.Add(this.txtTractionTractionClassDescription);
            this.panelTractionClassDetails.Controls.Add(this.lblTractionTractionClassDescription);
            this.panelTractionClassDetails.Controls.Add(this.txtTractionTractionClassName);
            this.panelTractionClassDetails.Controls.Add(this.lblTractionTractionClassName);
            this.panelTractionClassDetails.Controls.Add(this.dateTimeTractionTractionClassEndDate);
            this.panelTractionClassDetails.Controls.Add(this.lblTractionTractionClassInServiceEndDate);
            this.panelTractionClassDetails.Controls.Add(this.dateTimeTractionTractionClassStartDate);
            this.panelTractionClassDetails.Controls.Add(this.lblTractionTractionClassInServiceStartDate);
            this.panelTractionClassDetails.Location = new System.Drawing.Point(8, 203);
            this.panelTractionClassDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTractionClassDetails.Name = "panelTractionClassDetails";
            this.panelTractionClassDetails.Size = new System.Drawing.Size(509, 340);
            this.panelTractionClassDetails.TabIndex = 3;
            // 
            // numericUpDownTractionTractionClassRA
            // 
            this.numericUpDownTractionTractionClassRA.Location = new System.Drawing.Point(440, 278);
            this.numericUpDownTractionTractionClassRA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownTractionTractionClassRA.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownTractionTractionClassRA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTractionTractionClassRA.Name = "numericUpDownTractionTractionClassRA";
            this.numericUpDownTractionTractionClassRA.Size = new System.Drawing.Size(57, 22);
            this.numericUpDownTractionTractionClassRA.TabIndex = 32;
            this.numericUpDownTractionTractionClassRA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTractionTractionClassRA
            // 
            this.lblTractionTractionClassRA.AutoSize = true;
            this.lblTractionTractionClassRA.Location = new System.Drawing.Point(295, 281);
            this.lblTractionTractionClassRA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTractionTractionClassRA.Name = "lblTractionTractionClassRA";
            this.lblTractionTractionClassRA.Size = new System.Drawing.Size(120, 17);
            this.lblTractionTractionClassRA.TabIndex = 31;
            this.lblTractionTractionClassRA.Text = "Route Availability:";
            // 
            // numericUpDownTractionTractionClassLength
            // 
            this.numericUpDownTractionTractionClassLength.DecimalPlaces = 2;
            this.numericUpDownTractionTractionClassLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownTractionTractionClassLength.Location = new System.Drawing.Point(133, 278);
            this.numericUpDownTractionTractionClassLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownTractionTractionClassLength.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownTractionTractionClassLength.Name = "numericUpDownTractionTractionClassLength";
            this.numericUpDownTractionTractionClassLength.Size = new System.Drawing.Size(88, 22);
            this.numericUpDownTractionTractionClassLength.TabIndex = 30;
            // 
            // lblTractionTractionClassLength
            // 
            this.lblTractionTractionClassLength.AutoSize = true;
            this.lblTractionTractionClassLength.Location = new System.Drawing.Point(16, 281);
            this.lblTractionTractionClassLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTractionTractionClassLength.Name = "lblTractionTractionClassLength";
            this.lblTractionTractionClassLength.Size = new System.Drawing.Size(56, 17);
            this.lblTractionTractionClassLength.TabIndex = 29;
            this.lblTractionTractionClassLength.Text = "Length:";
            // 
            // lblTractionTractionClassParent
            // 
            this.lblTractionTractionClassParent.AutoSize = true;
            this.lblTractionTractionClassParent.Location = new System.Drawing.Point(16, 318);
            this.lblTractionTractionClassParent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTractionTractionClassParent.Name = "lblTractionTractionClassParent";
            this.lblTractionTractionClassParent.Size = new System.Drawing.Size(50, 17);
            this.lblTractionTractionClassParent.TabIndex = 28;
            this.lblTractionTractionClassParent.Text = "Parent";
            // 
            // comboTractionTractionClassType
            // 
            this.comboTractionTractionClassType.FormattingEnabled = true;
            this.comboTractionTractionClassType.Location = new System.Drawing.Point(133, 239);
            this.comboTractionTractionClassType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboTractionTractionClassType.Name = "comboTractionTractionClassType";
            this.comboTractionTractionClassType.Size = new System.Drawing.Size(160, 24);
            this.comboTractionTractionClassType.TabIndex = 27;
            this.comboTractionTractionClassType.SelectedIndexChanged += new System.EventHandler(this.comboTractionTractionClassType_SelectedIndexChanged);
            // 
            // lblTractionTractionClassType
            // 
            this.lblTractionTractionClassType.AutoSize = true;
            this.lblTractionTractionClassType.Location = new System.Drawing.Point(13, 242);
            this.lblTractionTractionClassType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTractionTractionClassType.Name = "lblTractionTractionClassType";
            this.lblTractionTractionClassType.Size = new System.Drawing.Size(44, 17);
            this.lblTractionTractionClassType.TabIndex = 26;
            this.lblTractionTractionClassType.Text = "Type:";
            // 
            // txtTractionTractionClassDescription
            // 
            this.txtTractionTractionClassDescription.Location = new System.Drawing.Point(136, 52);
            this.txtTractionTractionClassDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTractionTractionClassDescription.Name = "txtTractionTractionClassDescription";
            this.txtTractionTractionClassDescription.Size = new System.Drawing.Size(360, 120);
            this.txtTractionTractionClassDescription.TabIndex = 25;
            this.txtTractionTractionClassDescription.Text = "";
            this.txtTractionTractionClassDescription.TextChanged += new System.EventHandler(this.txtTractionTractionClassDescription_TextChanged);
            // 
            // lblTractionTractionClassDescription
            // 
            this.lblTractionTractionClassDescription.AutoSize = true;
            this.lblTractionTractionClassDescription.Location = new System.Drawing.Point(16, 48);
            this.lblTractionTractionClassDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTractionTractionClassDescription.Name = "lblTractionTractionClassDescription";
            this.lblTractionTractionClassDescription.Size = new System.Drawing.Size(83, 17);
            this.lblTractionTractionClassDescription.TabIndex = 24;
            this.lblTractionTractionClassDescription.Text = "Description:";
            // 
            // txtTractionTractionClassName
            // 
            this.txtTractionTractionClassName.Location = new System.Drawing.Point(136, 7);
            this.txtTractionTractionClassName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTractionTractionClassName.Name = "txtTractionTractionClassName";
            this.txtTractionTractionClassName.Size = new System.Drawing.Size(181, 22);
            this.txtTractionTractionClassName.TabIndex = 23;
            this.txtTractionTractionClassName.TextChanged += new System.EventHandler(this.txtTractionTractionClassName_TextChanged);
            this.txtTractionTractionClassName.Validating += new System.ComponentModel.CancelEventHandler(this.txtTractionTractionClassName_Validating);
            // 
            // lblTractionTractionClassName
            // 
            this.lblTractionTractionClassName.AutoSize = true;
            this.lblTractionTractionClassName.Location = new System.Drawing.Point(16, 11);
            this.lblTractionTractionClassName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTractionTractionClassName.Name = "lblTractionTractionClassName";
            this.lblTractionTractionClassName.Size = new System.Drawing.Size(49, 17);
            this.lblTractionTractionClassName.TabIndex = 22;
            this.lblTractionTractionClassName.Text = "Name:";
            // 
            // dateTimeTractionTractionClassEndDate
            // 
            this.dateTimeTractionTractionClassEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeTractionTractionClassEndDate.Location = new System.Drawing.Point(360, 191);
            this.dateTimeTractionTractionClassEndDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimeTractionTractionClassEndDate.Name = "dateTimeTractionTractionClassEndDate";
            this.dateTimeTractionTractionClassEndDate.ShowCheckBox = true;
            this.dateTimeTractionTractionClassEndDate.Size = new System.Drawing.Size(136, 22);
            this.dateTimeTractionTractionClassEndDate.TabIndex = 21;
            this.dateTimeTractionTractionClassEndDate.ValueChanged += new System.EventHandler(this.dateTimeTractionTractionClassEndDate_ValueChanged);
            this.dateTimeTractionTractionClassEndDate.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimeTractionTractionClassEndDate_Validating);
            // 
            // lblTractionTractionClassInServiceEndDate
            // 
            this.lblTractionTractionClassInServiceEndDate.AutoSize = true;
            this.lblTractionTractionClassInServiceEndDate.Location = new System.Drawing.Point(295, 198);
            this.lblTractionTractionClassInServiceEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTractionTractionClassInServiceEndDate.Name = "lblTractionTractionClassInServiceEndDate";
            this.lblTractionTractionClassInServiceEndDate.Size = new System.Drawing.Size(37, 17);
            this.lblTractionTractionClassInServiceEndDate.TabIndex = 20;
            this.lblTractionTractionClassInServiceEndDate.Text = "End:";
            // 
            // dateTimeTractionTractionClassStartDate
            // 
            this.dateTimeTractionTractionClassStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeTractionTractionClassStartDate.Location = new System.Drawing.Point(133, 191);
            this.dateTimeTractionTractionClassStartDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimeTractionTractionClassStartDate.Name = "dateTimeTractionTractionClassStartDate";
            this.dateTimeTractionTractionClassStartDate.Size = new System.Drawing.Size(136, 22);
            this.dateTimeTractionTractionClassStartDate.TabIndex = 19;
            this.dateTimeTractionTractionClassStartDate.ValueChanged += new System.EventHandler(this.dateTimeTractionTractionClassStartDate_ValueChanged);
            this.dateTimeTractionTractionClassStartDate.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimeTractionTractionClassStartDate_Validating);
            // 
            // lblTractionTractionClassInServiceStartDate
            // 
            this.lblTractionTractionClassInServiceStartDate.AutoSize = true;
            this.lblTractionTractionClassInServiceStartDate.Location = new System.Drawing.Point(13, 198);
            this.lblTractionTractionClassInServiceStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTractionTractionClassInServiceStartDate.Name = "lblTractionTractionClassInServiceStartDate";
            this.lblTractionTractionClassInServiceStartDate.Size = new System.Drawing.Size(108, 17);
            this.lblTractionTractionClassInServiceStartDate.TabIndex = 18;
            this.lblTractionTractionClassInServiceStartDate.Text = "In Service Start:";
            // 
            // listViewTractionClasses
            // 
            this.listViewTractionClasses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderClass,
            this.columnHeaderClassRA,
            this.columnHeaderClassStartYMDV,
            this.columnHeaderClassEndYMDV});
            this.listViewTractionClasses.FullRowSelect = true;
            this.listViewTractionClasses.HideSelection = false;
            this.listViewTractionClasses.Location = new System.Drawing.Point(25, 79);
            this.listViewTractionClasses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewTractionClasses.MultiSelect = false;
            this.listViewTractionClasses.Name = "listViewTractionClasses";
            this.listViewTractionClasses.Size = new System.Drawing.Size(476, 116);
            this.listViewTractionClasses.TabIndex = 2;
            this.listViewTractionClasses.UseCompatibleStateImageBehavior = false;
            this.listViewTractionClasses.View = System.Windows.Forms.View.Details;
            this.listViewTractionClasses.SelectedIndexChanged += new System.EventHandler(this.listViewTractionClasses_SelectedIndexChanged);
            // 
            // columnHeaderClass
            // 
            this.columnHeaderClass.Text = "Class";
            this.columnHeaderClass.Width = 100;
            // 
            // columnHeaderClassRA
            // 
            this.columnHeaderClassRA.Text = "RA:";
            this.columnHeaderClassRA.Width = 50;
            // 
            // columnHeaderClassStartYMDV
            // 
            this.columnHeaderClassStartYMDV.Text = "Start:";
            this.columnHeaderClassStartYMDV.Width = 90;
            // 
            // columnHeaderClassEndYMDV
            // 
            this.columnHeaderClassEndYMDV.Text = "End:";
            this.columnHeaderClassEndYMDV.Width = 90;
            // 
            // comboTractionType
            // 
            this.comboTractionType.FormattingEnabled = true;
            this.comboTractionType.Location = new System.Drawing.Point(115, 28);
            this.comboTractionType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboTractionType.Name = "comboTractionType";
            this.comboTractionType.Size = new System.Drawing.Size(160, 24);
            this.comboTractionType.TabIndex = 1;
            this.comboTractionType.SelectedIndexChanged += new System.EventHandler(this.comboTractionType_SelectedIndexChanged);
            // 
            // lblTractionType
            // 
            this.lblTractionType.AutoSize = true;
            this.lblTractionType.Location = new System.Drawing.Point(21, 32);
            this.lblTractionType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTractionType.Name = "lblTractionType";
            this.lblTractionType.Size = new System.Drawing.Size(44, 17);
            this.lblTractionType.TabIndex = 0;
            this.lblTractionType.Text = "Type:";
            // 
            // statusStripMain
            // 
            this.statusStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTab,
            this.toolStripRecord,
            this.toolStripStatus});
            this.statusStripMain.Location = new System.Drawing.Point(0, 679);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStripMain.Size = new System.Drawing.Size(1592, 29);
            this.statusStripMain.SizingGrip = false;
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "Status Bar";
            // 
            // toolStripTab
            // 
            this.toolStripTab.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripTab.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripTab.Name = "toolStripTab";
            this.toolStripTab.Size = new System.Drawing.Size(61, 24);
            this.toolStripTab.Text = "Logical";
            this.toolStripTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripRecord
            // 
            this.toolStripRecord.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripRecord.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripRecord.Name = "toolStripRecord";
            this.toolStripRecord.Size = new System.Drawing.Size(110, 24);
            this.toolStripRecord.Text = "None Selected";
            this.toolStripRecord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatus.Image")));
            this.toolStripStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatus.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(1401, 24);
            this.toolStripStatus.Spring = true;
            this.toolStripStatus.Text = "Status";
            this.toolStripStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLocationFile,
            this.ToolStripTractionFile,
            this.ToolStripLocationLocation,
            this.ToolStripTractionTraction});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(1592, 28);
            this.menuStripMain.TabIndex = 2;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // ToolStripLocationFile
            // 
            this.ToolStripLocationFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLocationToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveLocationToolStripMenuItem});
            this.ToolStripLocationFile.Name = "ToolStripLocationFile";
            this.ToolStripLocationFile.Size = new System.Drawing.Size(44, 24);
            this.ToolStripLocationFile.Text = "&File";
            // 
            // newLocationToolStripMenuItem
            // 
            this.newLocationToolStripMenuItem.Name = "newLocationToolStripMenuItem";
            this.newLocationToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.newLocationToolStripMenuItem.Text = "New Location..";
            this.newLocationToolStripMenuItem.Click += new System.EventHandler(this.newLocationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(229, 6);
            // 
            // saveLocationToolStripMenuItem
            // 
            this.saveLocationToolStripMenuItem.Name = "saveLocationToolStripMenuItem";
            this.saveLocationToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.saveLocationToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.saveLocationToolStripMenuItem.Text = "Save Location..";
            this.saveLocationToolStripMenuItem.Click += new System.EventHandler(this.saveLocationToolStripMenuItem_Click);
            // 
            // ToolStripTractionFile
            // 
            this.ToolStripTractionFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveTractionClassToolStripMenuItem});
            this.ToolStripTractionFile.Name = "ToolStripTractionFile";
            this.ToolStripTractionFile.Size = new System.Drawing.Size(44, 24);
            this.ToolStripTractionFile.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tractionClassToolStripMenuItem,
            this.tractionToolStripMenuItem1});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.newToolStripMenuItem.Text = "New..";
            // 
            // tractionClassToolStripMenuItem
            // 
            this.tractionClassToolStripMenuItem.Name = "tractionClassToolStripMenuItem";
            this.tractionClassToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.tractionClassToolStripMenuItem.Text = "Traction Class..";
            // 
            // tractionToolStripMenuItem1
            // 
            this.tractionToolStripMenuItem1.Name = "tractionToolStripMenuItem1";
            this.tractionToolStripMenuItem1.Size = new System.Drawing.Size(180, 26);
            this.tractionToolStripMenuItem1.Text = "Traction";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(262, 6);
            // 
            // saveTractionClassToolStripMenuItem
            // 
            this.saveTractionClassToolStripMenuItem.Name = "saveTractionClassToolStripMenuItem";
            this.saveTractionClassToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveTractionClassToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.saveTractionClassToolStripMenuItem.Text = "Save Traction Class..";
            // 
            // ToolStripLocationLocation
            // 
            this.ToolStripLocationLocation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editPathsToolStripMenuItem});
            this.ToolStripLocationLocation.Name = "ToolStripLocationLocation";
            this.ToolStripLocationLocation.Size = new System.Drawing.Size(78, 24);
            this.ToolStripLocationLocation.Text = "Location";
            // 
            // editPathsToolStripMenuItem
            // 
            this.editPathsToolStripMenuItem.Name = "editPathsToolStripMenuItem";
            this.editPathsToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.editPathsToolStripMenuItem.Text = "Edit Paths..";
            this.editPathsToolStripMenuItem.Click += new System.EventHandler(this.editPathsToolStripMenuItem_Click);
            // 
            // ToolStripTractionTraction
            // 
            this.ToolStripTractionTraction.Name = "ToolStripTractionTraction";
            this.ToolStripTractionTraction.Size = new System.Drawing.Size(74, 24);
            this.ToolStripTractionTraction.Text = "Traction";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1592, 708);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GroundFrame Data Editor";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageLogical.ResumeLayout(false);
            this.groupBoxSectorCodes.ResumeLayout(false);
            this.groupBoxSectorCodes.PerformLayout();
            this.groupBoxLogicalSectorDetails.ResumeLayout(false);
            this.groupBoxLogicalSectorDetails.PerformLayout();
            this.groupBoxRegions.ResumeLayout(false);
            this.groupBoxRegionsDetails.ResumeLayout(false);
            this.groupBoxRegionsDetails.PerformLayout();
            this.tabPageLocation.ResumeLayout(false);
            this.groupBoxLocations.ResumeLayout(false);
            this.groupBoxLocations.PerformLayout();
            this.groupBoxLocationOptions.ResumeLayout(false);
            this.groupBoxLocationOptions.PerformLayout();
            this.groupBoxLocationPower.ResumeLayout(false);
            this.groupBoxLocationPower.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLocationScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLocationBerths)).EndInit();
            this.contextMenuStripLocationTreeView.ResumeLayout(false);
            this.tabPageTraction.ResumeLayout(false);
            this.groupBoxTractionClass.ResumeLayout(false);
            this.groupBoxTractionClass.PerformLayout();
            this.panelTractionClassDetails.ResumeLayout(false);
            this.panelTractionClassDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTractionTractionClassRA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTractionTractionClassLength)).EndInit();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageLogical;
        private System.Windows.Forms.TabPage tabPageLocation;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTab;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem ToolStripLocationFile;
        private System.Windows.Forms.GroupBox groupBoxRegions;
        private System.Windows.Forms.ListView listViewRegions;
        private System.Windows.Forms.ColumnHeader columnHeaderRegionName;
        private System.Windows.Forms.ColumnHeader columnHeaderStartYMDV;
        private System.Windows.Forms.ColumnHeader columnHeaderEndYMDV;
        private System.Windows.Forms.GroupBox groupBoxRegionsDetails;
        private System.Windows.Forms.TextBox txtLogicalRegionName;
        private System.Windows.Forms.Label lblLogicalRegionName;
        private System.Windows.Forms.Label lblLogicalRegionActiveTo;
        private System.Windows.Forms.DateTimePicker dateTimeLogicalRegionEndYMDV;
        private System.Windows.Forms.Label lblLogicalRegionActiveFrom;
        private System.Windows.Forms.DateTimePicker dateTimeLogicalRegionStartYMDV;
        private System.Windows.Forms.RichTextBox txtLogicalRegionDescription;
        private System.Windows.Forms.Label lblLogicalRegionDescription;
        private System.Windows.Forms.Button butLogicalRegionNew;
        private System.Windows.Forms.Button butLogicalRegionSave;
        private System.Windows.Forms.ToolStripStatusLabel toolStripRecord;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.GroupBox groupBoxSectorCodes;
        private System.Windows.Forms.Label lblLogicalSectorCodeLabel;
        private System.Windows.Forms.ComboBox comboLogicalSystemSectors;
        private System.Windows.Forms.ListView listViewSectors;
        private System.Windows.Forms.ColumnHeader columnSectorDescription;
        private System.Windows.Forms.ColumnHeader columnSectorStart;
        private System.Windows.Forms.ColumnHeader columnSectorEnd;
        private System.Windows.Forms.GroupBox groupBoxLogicalSectorDetails;
        private System.Windows.Forms.Button butLogicalSectorNew;
        private System.Windows.Forms.RichTextBox txtLogicalSectorDescription;
        private System.Windows.Forms.Button butLogicalSectorSave;
        private System.Windows.Forms.Label lblLogicalSectorDescription;
        private System.Windows.Forms.Label lblLogicalSectorActiveTo;
        private System.Windows.Forms.DateTimePicker dateTimeLogicalSectorStartYMDV;
        private System.Windows.Forms.DateTimePicker dateTimeLogicalSectorEndYMDV;
        private System.Windows.Forms.Label lblLogicalSectorActiveFrom;
        private System.Windows.Forms.LinkLabel linkLogicalNewSystemSector;
        private System.Windows.Forms.LinkLabel linkLogicalEditSystemSector;
        private System.Windows.Forms.GroupBox groupBoxLocations;
        private System.Windows.Forms.LinkLabel linkLocationEdit;
        private System.Windows.Forms.LinkLabel linkLocationNew;
        private System.Windows.Forms.Label lblLocationLocation;
        private System.Windows.Forms.ComboBox comboLocationLocation;
        private System.Windows.Forms.TreeView treeViewLocations;
        private System.Windows.Forms.TextBox txtLocationName;
        private System.Windows.Forms.Label lblLocationName;
        private System.Windows.Forms.Label lblLocationActiveTo;
        private System.Windows.Forms.DateTimePicker dateTimeLocationActiveFrom;
        private System.Windows.Forms.DateTimePicker dateTimeLocationActiveTo;
        private System.Windows.Forms.Label lblLocationActiveFrom;
        private System.Windows.Forms.TextBox txtLocationTIPLOC;
        private System.Windows.Forms.Label lblLocationTIPLOC;
        private System.Windows.Forms.TextBox txtLocationNLC;
        private System.Windows.Forms.Label lblLocationNLC;
        private System.Windows.Forms.TextBox txtLocationSTANME;
        private System.Windows.Forms.Label lblLocationSTANME;
        private System.Windows.Forms.TextBox txtLocationSTANOX;
        private System.Windows.Forms.Label lblLocationSTANOX;
        private System.Windows.Forms.ComboBox comboLocationType;
        private System.Windows.Forms.Label lblLocationType;
        private System.Windows.Forms.TextBox txtLocationLongitude;
        private System.Windows.Forms.Label lblLocationLongitude;
        private System.Windows.Forms.TextBox txtLocationLatitude;
        private System.Windows.Forms.Label lblLocationLatitude;
        private System.Windows.Forms.Label lblLengthMeters;
        private System.Windows.Forms.TextBox txtLocationLength;
        private System.Windows.Forms.Label lblLocationLength;
        private System.Windows.Forms.Label lblLocationToken;
        private System.Windows.Forms.Label lblLocationBerths;
        private System.Windows.Forms.NumericUpDown numericUpDownLocationBerths;
        private System.Windows.Forms.ComboBox comboLocationDirections;
        private System.Windows.Forms.Label lblLocationDirection;
        private System.Windows.Forms.ComboBox comboLocationToken;
        private System.Windows.Forms.CheckBox checkBoxLocationSingleTrainWorking;
        private System.Windows.Forms.Label labelLocationSingleTrainWorking;
        private System.Windows.Forms.CheckBox checkBoxLocationFreightOnly;
        private System.Windows.Forms.Label lblLocationFreightOnly;
        private System.Windows.Forms.CheckBox checkBoxLocationDisembarkPassengers;
        private System.Windows.Forms.Label lblLocationDisembarkPassengers;
        private System.Windows.Forms.CheckBox checkBoxLocationEmbarkPassengers;
        private System.Windows.Forms.Label lblLocationEmbarkPassengers;
        private System.Windows.Forms.CheckBox checkBoxLocationTOPSOffice;
        private System.Windows.Forms.Label labelLocationTOPSOffice;
        private System.Windows.Forms.CheckBox checkBoxLocationUseAsTimingPoint;
        private System.Windows.Forms.Label lblLocationUseAsTimingPoint;
        private System.Windows.Forms.GroupBox groupBoxLocationOptions;
        private System.Windows.Forms.GroupBox groupBoxLocationPower;
        private System.Windows.Forms.NumericUpDown numericUpDownLocationScore;
        private System.Windows.Forms.Label labelLocationScore;
        private System.Windows.Forms.Label labelLocationPowerSteam;
        private System.Windows.Forms.CheckBox checkBoxLocationPowerBattery;
        private System.Windows.Forms.CheckBox checkBoxLocationPowerOHead25;
        private System.Windows.Forms.CheckBox checkBoxLocationPowerOH625;
        private System.Windows.Forms.CheckBox checkBoxLocationPowerOH1500;
        private System.Windows.Forms.CheckBox checkBoxLocationPower3rd1500;
        private System.Windows.Forms.CheckBox checkBoxLocationPower3rd750;
        private System.Windows.Forms.CheckBox checkBoxLocationPower4th600;
        private System.Windows.Forms.CheckBox checkBoxLocationPowerDiesel;
        private System.Windows.Forms.CheckBox checkBoxLocationPowerSteam;
        private System.Windows.Forms.Label labelLocationPowerBattery;
        private System.Windows.Forms.Label labelLocationPowerOH25;
        private System.Windows.Forms.Label labelLocationPowerOH625;
        private System.Windows.Forms.Label labelLocationPowerOH1500;
        private System.Windows.Forms.Label labelLocationPower3rd1500;
        private System.Windows.Forms.Label labelLocationPower3rd750;
        private System.Windows.Forms.Label labelLocationPower4th600;
        private System.Windows.Forms.Label labelLocationPowerDiesel;
        private System.Windows.Forms.ToolStripMenuItem newLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveLocationToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLocationTreeView;
        private System.Windows.Forms.ToolStripMenuItem newChildLocationToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxLocationOptionCallOn;
        private System.Windows.Forms.Label labelLocationOptionCallOn;
        private System.Windows.Forms.CheckBox checkBoxLocationOptionCannotStop;
        private System.Windows.Forms.Label lblLocationOptionCannotStop;
        private System.Windows.Forms.Label lblLocationOptionPassengerTrainsCannotStop;
        private System.Windows.Forms.Label lblLocationOptionOnlyStopIfReversing;
        private System.Windows.Forms.CheckBox checkBoxLocationOptionPassengerTrainCannotStop;
        private System.Windows.Forms.CheckBox checkBoxLocationOptionOnlyStopIfReversing;
        private System.Windows.Forms.LinkLabel linkLocationEditToken;
        private System.Windows.Forms.LinkLabel linkLocationNewToken;
        private System.Windows.Forms.ToolStripMenuItem ToolStripLocationLocation;
        private System.Windows.Forms.ToolStripMenuItem editPathsToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxLocationOptionCannotSurrenderToken;
        private System.Windows.Forms.Label labelLocationOptionCannotSurrenderToken;
        private System.Windows.Forms.LinkLabel linkDepotDetails;
        private System.Windows.Forms.TabPage tabPageTraction;
        private System.Windows.Forms.GroupBox groupBoxTractionClass;
        private System.Windows.Forms.Label lblTractionType;
        private System.Windows.Forms.ComboBox comboTractionType;
        private System.Windows.Forms.Panel panelTractionClassDetails;
        private System.Windows.Forms.NumericUpDown numericUpDownTractionTractionClassRA;
        private System.Windows.Forms.Label lblTractionTractionClassRA;
        private System.Windows.Forms.NumericUpDown numericUpDownTractionTractionClassLength;
        private System.Windows.Forms.Label lblTractionTractionClassLength;
        private System.Windows.Forms.Label lblTractionTractionClassParent;
        private System.Windows.Forms.ComboBox comboTractionTractionClassType;
        private System.Windows.Forms.Label lblTractionTractionClassType;
        private System.Windows.Forms.RichTextBox txtTractionTractionClassDescription;
        private System.Windows.Forms.Label lblTractionTractionClassDescription;
        private System.Windows.Forms.TextBox txtTractionTractionClassName;
        private System.Windows.Forms.Label lblTractionTractionClassName;
        private System.Windows.Forms.DateTimePicker dateTimeTractionTractionClassEndDate;
        private System.Windows.Forms.Label lblTractionTractionClassInServiceEndDate;
        private System.Windows.Forms.DateTimePicker dateTimeTractionTractionClassStartDate;
        private System.Windows.Forms.Label lblTractionTractionClassInServiceStartDate;
        private System.Windows.Forms.ListView listViewTractionClasses;
        private System.Windows.Forms.ColumnHeader columnHeaderClass;
        private System.Windows.Forms.ColumnHeader columnHeaderClassRA;
        private System.Windows.Forms.ColumnHeader columnHeaderClassStartYMDV;
        private System.Windows.Forms.ColumnHeader columnHeaderClassEndYMDV;
        private System.Windows.Forms.ToolStripMenuItem ToolStripTractionFile;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tractionClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tractionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveTractionClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripTractionTraction;
    }
}

