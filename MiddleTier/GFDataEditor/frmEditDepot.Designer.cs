namespace Horizon4.GFDataEditor
{
    partial class frmEditDepot
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
            this.listViewDepots = new System.Windows.Forms.ListView();
            this.columnHeaderCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStartYMDV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEndYMDV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStripDepot = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripDepot = new System.Windows.Forms.StatusStrip();
            this.toolStripDepotRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDepotStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxDepotDetails = new System.Windows.Forms.GroupBox();
            this.checkBoxWater = new System.Windows.Forms.CheckBox();
            this.lblWater = new System.Windows.Forms.Label();
            this.checkBoxFuel = new System.Windows.Forms.CheckBox();
            this.checkBoxCoal = new System.Windows.Forms.CheckBox();
            this.lblCoal = new System.Windows.Forms.Label();
            this.checkBoxWheelLathe = new System.Windows.Forms.CheckBox();
            this.lblFuel = new System.Windows.Forms.Label();
            this.lblWheelLathe = new System.Windows.Forms.Label();
            this.numericUpDownPercVisible = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownEaseofAccess = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblDepotActiveTo = new System.Windows.Forms.Label();
            this.dateTimeDepotActiveFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimeDepotActiveTo = new System.Windows.Forms.DateTimePicker();
            this.lbDepotActiveFrom = new System.Windows.Forms.Label();
            this.groupBoxExams = new System.Windows.Forms.GroupBox();
            this.checkBoxFExam = new System.Windows.Forms.CheckBox();
            this.lblFExam = new System.Windows.Forms.Label();
            this.checkBoxEExam = new System.Windows.Forms.CheckBox();
            this.lblEExam = new System.Windows.Forms.Label();
            this.checkBoxDExam = new System.Windows.Forms.CheckBox();
            this.lblDExam = new System.Windows.Forms.Label();
            this.checkBoxCExam = new System.Windows.Forms.CheckBox();
            this.lblCExam = new System.Windows.Forms.Label();
            this.checkBoxBExam = new System.Windows.Forms.CheckBox();
            this.lblBExam = new System.Windows.Forms.Label();
            this.checkBoxAExam = new System.Windows.Forms.CheckBox();
            this.lblAExam = new System.Windows.Forms.Label();
            this.groupBoxExamPower = new System.Windows.Forms.GroupBox();
            this.checkBoxExamPower3rdRail = new System.Windows.Forms.CheckBox();
            this.lblExamPower3rdRail = new System.Windows.Forms.Label();
            this.checkBoxExamPowerOverhead = new System.Windows.Forms.CheckBox();
            this.lblExamPowerOverhead = new System.Windows.Forms.Label();
            this.checkBoxExamPowerDiesel = new System.Windows.Forms.CheckBox();
            this.lblExamPowerDiesel = new System.Windows.Forms.Label();
            this.groupBoxExamTraction = new System.Windows.Forms.GroupBox();
            this.checkBoxTractionWagon = new System.Windows.Forms.CheckBox();
            this.lblExamTractionWagon = new System.Windows.Forms.Label();
            this.checkBoxTractionCarriage = new System.Windows.Forms.CheckBox();
            this.lblExamTractionCarriage = new System.Windows.Forms.Label();
            this.checkBoxTractionDEMU = new System.Windows.Forms.CheckBox();
            this.lblExamTractionDEMU = new System.Windows.Forms.Label();
            this.checkBoxTractionDMU = new System.Windows.Forms.CheckBox();
            this.lblExamTractionDMU = new System.Windows.Forms.Label();
            this.checkBoxTractionEMU = new System.Windows.Forms.CheckBox();
            this.lblExamTractionEMU = new System.Windows.Forms.Label();
            this.checkBoxTractionLoco = new System.Windows.Forms.CheckBox();
            this.lblExamTractionLoco = new System.Windows.Forms.Label();
            this.menuStripDepot.SuspendLayout();
            this.statusStripDepot.SuspendLayout();
            this.groupBoxDepotDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercVisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEaseofAccess)).BeginInit();
            this.groupBoxExams.SuspendLayout();
            this.groupBoxExamPower.SuspendLayout();
            this.groupBoxExamTraction.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewDepots
            // 
            this.listViewDepots.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCode,
            this.columnHeaderStartYMDV,
            this.columnHeaderEndYMDV});
            this.listViewDepots.FullRowSelect = true;
            this.listViewDepots.HideSelection = false;
            this.listViewDepots.Location = new System.Drawing.Point(12, 41);
            this.listViewDepots.MultiSelect = false;
            this.listViewDepots.Name = "listViewDepots";
            this.listViewDepots.Size = new System.Drawing.Size(246, 246);
            this.listViewDepots.TabIndex = 0;
            this.listViewDepots.UseCompatibleStateImageBehavior = false;
            this.listViewDepots.View = System.Windows.Forms.View.Details;
            this.listViewDepots.SelectedIndexChanged += new System.EventHandler(this.listViewDepots_SelectedIndexChanged);
            // 
            // columnHeaderCode
            // 
            this.columnHeaderCode.Text = "Code:";
            // 
            // columnHeaderStartYMDV
            // 
            this.columnHeaderStartYMDV.Text = "Start Date:";
            this.columnHeaderStartYMDV.Width = 80;
            // 
            // columnHeaderEndYMDV
            // 
            this.columnHeaderEndYMDV.Text = "End:";
            this.columnHeaderEndYMDV.Width = 80;
            // 
            // menuStripDepot
            // 
            this.menuStripDepot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripDepot.Location = new System.Drawing.Point(0, 0);
            this.menuStripDepot.Name = "menuStripDepot";
            this.menuStripDepot.Size = new System.Drawing.Size(805, 24);
            this.menuStripDepot.TabIndex = 1;
            this.menuStripDepot.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "&New..";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(139, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // statusStripDepot
            // 
            this.statusStripDepot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDepotRecord,
            this.toolStripDepotStatus});
            this.statusStripDepot.Location = new System.Drawing.Point(0, 303);
            this.statusStripDepot.Name = "statusStripDepot";
            this.statusStripDepot.Size = new System.Drawing.Size(805, 22);
            this.statusStripDepot.TabIndex = 2;
            this.statusStripDepot.Text = "statusStripDepot";
            // 
            // toolStripDepotRecord
            // 
            this.toolStripDepotRecord.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripDepotRecord.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripDepotRecord.Name = "toolStripDepotRecord";
            this.toolStripDepotRecord.Size = new System.Drawing.Size(80, 17);
            this.toolStripDepotRecord.Text = "None Selected";
            this.toolStripDepotRecord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripDepotStatus
            // 
            this.toolStripDepotStatus.Image = global::Horizon4.GFDataEditor.Properties.Resources.tick;
            this.toolStripDepotStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripDepotStatus.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripDepotStatus.Name = "toolStripDepotStatus";
            this.toolStripDepotStatus.Size = new System.Drawing.Size(54, 17);
            this.toolStripDepotStatus.Text = "Status";
            this.toolStripDepotStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxDepotDetails
            // 
            this.groupBoxDepotDetails.Controls.Add(this.checkBoxWater);
            this.groupBoxDepotDetails.Controls.Add(this.lblWater);
            this.groupBoxDepotDetails.Controls.Add(this.checkBoxFuel);
            this.groupBoxDepotDetails.Controls.Add(this.checkBoxCoal);
            this.groupBoxDepotDetails.Controls.Add(this.lblCoal);
            this.groupBoxDepotDetails.Controls.Add(this.checkBoxWheelLathe);
            this.groupBoxDepotDetails.Controls.Add(this.lblFuel);
            this.groupBoxDepotDetails.Controls.Add(this.lblWheelLathe);
            this.groupBoxDepotDetails.Controls.Add(this.numericUpDownPercVisible);
            this.groupBoxDepotDetails.Controls.Add(this.label2);
            this.groupBoxDepotDetails.Controls.Add(this.numericUpDownEaseofAccess);
            this.groupBoxDepotDetails.Controls.Add(this.label1);
            this.groupBoxDepotDetails.Controls.Add(this.txtBoxCode);
            this.groupBoxDepotDetails.Controls.Add(this.lblCode);
            this.groupBoxDepotDetails.Controls.Add(this.lblDepotActiveTo);
            this.groupBoxDepotDetails.Controls.Add(this.dateTimeDepotActiveFrom);
            this.groupBoxDepotDetails.Controls.Add(this.dateTimeDepotActiveTo);
            this.groupBoxDepotDetails.Controls.Add(this.lbDepotActiveFrom);
            this.groupBoxDepotDetails.Location = new System.Drawing.Point(275, 41);
            this.groupBoxDepotDetails.Name = "groupBoxDepotDetails";
            this.groupBoxDepotDetails.Size = new System.Drawing.Size(518, 92);
            this.groupBoxDepotDetails.TabIndex = 3;
            this.groupBoxDepotDetails.TabStop = false;
            this.groupBoxDepotDetails.Text = "Details";
            // 
            // checkBoxWater
            // 
            this.checkBoxWater.AutoSize = true;
            this.checkBoxWater.Location = new System.Drawing.Point(489, 61);
            this.checkBoxWater.Name = "checkBoxWater";
            this.checkBoxWater.Size = new System.Drawing.Size(15, 14);
            this.checkBoxWater.TabIndex = 88;
            this.checkBoxWater.Tag = "512";
            this.checkBoxWater.UseVisualStyleBackColor = true;
            this.checkBoxWater.CheckedChanged += new System.EventHandler(this.checkBoxWater_CheckedChanged);
            // 
            // lblWater
            // 
            this.lblWater.AutoSize = true;
            this.lblWater.Location = new System.Drawing.Point(448, 61);
            this.lblWater.Name = "lblWater";
            this.lblWater.Size = new System.Drawing.Size(39, 13);
            this.lblWater.TabIndex = 87;
            this.lblWater.Text = "Water:";
            // 
            // checkBoxFuel
            // 
            this.checkBoxFuel.AutoSize = true;
            this.checkBoxFuel.Location = new System.Drawing.Point(421, 60);
            this.checkBoxFuel.Name = "checkBoxFuel";
            this.checkBoxFuel.Size = new System.Drawing.Size(15, 14);
            this.checkBoxFuel.TabIndex = 86;
            this.checkBoxFuel.Tag = "128";
            this.checkBoxFuel.UseVisualStyleBackColor = true;
            this.checkBoxFuel.CheckedChanged += new System.EventHandler(this.checkBoxFuel_CheckedChanged);
            // 
            // checkBoxCoal
            // 
            this.checkBoxCoal.AutoSize = true;
            this.checkBoxCoal.Location = new System.Drawing.Point(489, 29);
            this.checkBoxCoal.Name = "checkBoxCoal";
            this.checkBoxCoal.Size = new System.Drawing.Size(15, 14);
            this.checkBoxCoal.TabIndex = 85;
            this.checkBoxCoal.Tag = "256";
            this.checkBoxCoal.UseVisualStyleBackColor = true;
            this.checkBoxCoal.CheckedChanged += new System.EventHandler(this.checkBoxCoal_CheckedChanged);
            // 
            // lblCoal
            // 
            this.lblCoal.AutoSize = true;
            this.lblCoal.Location = new System.Drawing.Point(448, 29);
            this.lblCoal.Name = "lblCoal";
            this.lblCoal.Size = new System.Drawing.Size(31, 13);
            this.lblCoal.TabIndex = 84;
            this.lblCoal.Text = "Coal:";
            // 
            // checkBoxWheelLathe
            // 
            this.checkBoxWheelLathe.AutoSize = true;
            this.checkBoxWheelLathe.Location = new System.Drawing.Point(421, 29);
            this.checkBoxWheelLathe.Name = "checkBoxWheelLathe";
            this.checkBoxWheelLathe.Size = new System.Drawing.Size(15, 14);
            this.checkBoxWheelLathe.TabIndex = 83;
            this.checkBoxWheelLathe.Tag = "64";
            this.checkBoxWheelLathe.UseVisualStyleBackColor = true;
            this.checkBoxWheelLathe.CheckedChanged += new System.EventHandler(this.checkBoxWheelLathe_CheckedChanged);
            // 
            // lblFuel
            // 
            this.lblFuel.AutoSize = true;
            this.lblFuel.Location = new System.Drawing.Point(377, 61);
            this.lblFuel.Name = "lblFuel";
            this.lblFuel.Size = new System.Drawing.Size(30, 13);
            this.lblFuel.TabIndex = 82;
            this.lblFuel.Text = "Fuel:";
            // 
            // lblWheelLathe
            // 
            this.lblWheelLathe.AutoSize = true;
            this.lblWheelLathe.Location = new System.Drawing.Point(377, 29);
            this.lblWheelLathe.Name = "lblWheelLathe";
            this.lblWheelLathe.Size = new System.Drawing.Size(37, 13);
            this.lblWheelLathe.TabIndex = 81;
            this.lblWheelLathe.Text = "Lathe:";
            // 
            // numericUpDownPercVisible
            // 
            this.numericUpDownPercVisible.DecimalPlaces = 1;
            this.numericUpDownPercVisible.Location = new System.Drawing.Point(312, 58);
            this.numericUpDownPercVisible.Name = "numericUpDownPercVisible";
            this.numericUpDownPercVisible.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownPercVisible.TabIndex = 80;
            this.numericUpDownPercVisible.ValueChanged += new System.EventHandler(this.numericUpDownPercVisible_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "% Visible:";
            // 
            // numericUpDownEaseofAccess
            // 
            this.numericUpDownEaseofAccess.Location = new System.Drawing.Point(193, 58);
            this.numericUpDownEaseofAccess.Name = "numericUpDownEaseofAccess";
            this.numericUpDownEaseofAccess.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownEaseofAccess.TabIndex = 78;
            this.numericUpDownEaseofAccess.ValueChanged += new System.EventHandler(this.numericUpDownEaseofAccess_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "Ease of Access:";
            // 
            // txtBoxCode
            // 
            this.txtBoxCode.Location = new System.Drawing.Point(57, 58);
            this.txtBoxCode.MaxLength = 3;
            this.txtBoxCode.Name = "txtBoxCode";
            this.txtBoxCode.Size = new System.Drawing.Size(35, 20);
            this.txtBoxCode.TabIndex = 76;
            this.txtBoxCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxCode_Validating);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(16, 61);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(35, 13);
            this.lblCode.TabIndex = 75;
            this.lblCode.Text = "Code:";
            // 
            // lblDepotActiveTo
            // 
            this.lblDepotActiveTo.AutoSize = true;
            this.lblDepotActiveTo.Location = new System.Drawing.Point(239, 29);
            this.lblDepotActiveTo.Name = "lblDepotActiveTo";
            this.lblDepotActiveTo.Size = new System.Drawing.Size(19, 13);
            this.lblDepotActiveTo.TabIndex = 74;
            this.lblDepotActiveTo.Text = "to:";
            // 
            // dateTimeDepotActiveFrom
            // 
            this.dateTimeDepotActiveFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDepotActiveFrom.Location = new System.Drawing.Point(131, 25);
            this.dateTimeDepotActiveFrom.Name = "dateTimeDepotActiveFrom";
            this.dateTimeDepotActiveFrom.Size = new System.Drawing.Size(100, 20);
            this.dateTimeDepotActiveFrom.TabIndex = 71;
            // 
            // dateTimeDepotActiveTo
            // 
            this.dateTimeDepotActiveTo.Enabled = false;
            this.dateTimeDepotActiveTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDepotActiveTo.Location = new System.Drawing.Point(262, 25);
            this.dateTimeDepotActiveTo.Name = "dateTimeDepotActiveTo";
            this.dateTimeDepotActiveTo.ShowCheckBox = true;
            this.dateTimeDepotActiveTo.Size = new System.Drawing.Size(100, 20);
            this.dateTimeDepotActiveTo.TabIndex = 73;
            // 
            // lbDepotActiveFrom
            // 
            this.lbDepotActiveFrom.AutoSize = true;
            this.lbDepotActiveFrom.Location = new System.Drawing.Point(16, 29);
            this.lbDepotActiveFrom.Name = "lbDepotActiveFrom";
            this.lbDepotActiveFrom.Size = new System.Drawing.Size(98, 13);
            this.lbDepotActiveFrom.TabIndex = 72;
            this.lbDepotActiveFrom.Text = "Depot Active From:";
            // 
            // groupBoxExams
            // 
            this.groupBoxExams.Controls.Add(this.checkBoxFExam);
            this.groupBoxExams.Controls.Add(this.lblFExam);
            this.groupBoxExams.Controls.Add(this.checkBoxEExam);
            this.groupBoxExams.Controls.Add(this.lblEExam);
            this.groupBoxExams.Controls.Add(this.checkBoxDExam);
            this.groupBoxExams.Controls.Add(this.lblDExam);
            this.groupBoxExams.Controls.Add(this.checkBoxCExam);
            this.groupBoxExams.Controls.Add(this.lblCExam);
            this.groupBoxExams.Controls.Add(this.checkBoxBExam);
            this.groupBoxExams.Controls.Add(this.lblBExam);
            this.groupBoxExams.Controls.Add(this.checkBoxAExam);
            this.groupBoxExams.Controls.Add(this.lblAExam);
            this.groupBoxExams.Location = new System.Drawing.Point(275, 150);
            this.groupBoxExams.Name = "groupBoxExams";
            this.groupBoxExams.Size = new System.Drawing.Size(127, 137);
            this.groupBoxExams.TabIndex = 4;
            this.groupBoxExams.TabStop = false;
            this.groupBoxExams.Text = "Exams";
            // 
            // checkBoxFExam
            // 
            this.checkBoxFExam.AutoSize = true;
            this.checkBoxFExam.Location = new System.Drawing.Point(90, 52);
            this.checkBoxFExam.Name = "checkBoxFExam";
            this.checkBoxFExam.Size = new System.Drawing.Size(15, 14);
            this.checkBoxFExam.TabIndex = 11;
            this.checkBoxFExam.Tag = "32";
            this.checkBoxFExam.UseVisualStyleBackColor = true;
            this.checkBoxFExam.CheckedChanged += new System.EventHandler(this.checkBoxFExam_CheckedChanged);
            // 
            // lblFExam
            // 
            this.lblFExam.AutoSize = true;
            this.lblFExam.Location = new System.Drawing.Point(67, 52);
            this.lblFExam.Name = "lblFExam";
            this.lblFExam.Size = new System.Drawing.Size(16, 13);
            this.lblFExam.TabIndex = 10;
            this.lblFExam.Text = "F:";
            // 
            // checkBoxEExam
            // 
            this.checkBoxEExam.AutoSize = true;
            this.checkBoxEExam.Location = new System.Drawing.Point(90, 22);
            this.checkBoxEExam.Name = "checkBoxEExam";
            this.checkBoxEExam.Size = new System.Drawing.Size(15, 14);
            this.checkBoxEExam.TabIndex = 9;
            this.checkBoxEExam.Tag = "16";
            this.checkBoxEExam.UseVisualStyleBackColor = true;
            this.checkBoxEExam.CheckedChanged += new System.EventHandler(this.checkBoxEExam_CheckedChanged);
            // 
            // lblEExam
            // 
            this.lblEExam.AutoSize = true;
            this.lblEExam.Location = new System.Drawing.Point(67, 22);
            this.lblEExam.Name = "lblEExam";
            this.lblEExam.Size = new System.Drawing.Size(17, 13);
            this.lblEExam.TabIndex = 8;
            this.lblEExam.Text = "E:";
            // 
            // checkBoxDExam
            // 
            this.checkBoxDExam.AutoSize = true;
            this.checkBoxDExam.Location = new System.Drawing.Point(39, 112);
            this.checkBoxDExam.Name = "checkBoxDExam";
            this.checkBoxDExam.Size = new System.Drawing.Size(15, 14);
            this.checkBoxDExam.TabIndex = 7;
            this.checkBoxDExam.Tag = "8";
            this.checkBoxDExam.UseVisualStyleBackColor = true;
            this.checkBoxDExam.CheckedChanged += new System.EventHandler(this.checkBoxDExam_CheckedChanged);
            // 
            // lblDExam
            // 
            this.lblDExam.AutoSize = true;
            this.lblDExam.Location = new System.Drawing.Point(16, 112);
            this.lblDExam.Name = "lblDExam";
            this.lblDExam.Size = new System.Drawing.Size(18, 13);
            this.lblDExam.TabIndex = 6;
            this.lblDExam.Text = "D:";
            // 
            // checkBoxCExam
            // 
            this.checkBoxCExam.AutoSize = true;
            this.checkBoxCExam.Location = new System.Drawing.Point(39, 82);
            this.checkBoxCExam.Name = "checkBoxCExam";
            this.checkBoxCExam.Size = new System.Drawing.Size(15, 14);
            this.checkBoxCExam.TabIndex = 5;
            this.checkBoxCExam.Tag = "4";
            this.checkBoxCExam.UseVisualStyleBackColor = true;
            this.checkBoxCExam.CheckedChanged += new System.EventHandler(this.checkBoxCExam_CheckedChanged);
            // 
            // lblCExam
            // 
            this.lblCExam.AutoSize = true;
            this.lblCExam.Location = new System.Drawing.Point(16, 82);
            this.lblCExam.Name = "lblCExam";
            this.lblCExam.Size = new System.Drawing.Size(17, 13);
            this.lblCExam.TabIndex = 4;
            this.lblCExam.Text = "C:";
            // 
            // checkBoxBExam
            // 
            this.checkBoxBExam.AutoSize = true;
            this.checkBoxBExam.Location = new System.Drawing.Point(39, 52);
            this.checkBoxBExam.Name = "checkBoxBExam";
            this.checkBoxBExam.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBExam.TabIndex = 3;
            this.checkBoxBExam.Tag = "2";
            this.checkBoxBExam.UseVisualStyleBackColor = true;
            this.checkBoxBExam.CheckedChanged += new System.EventHandler(this.checkBoxBExam_CheckedChanged);
            // 
            // lblBExam
            // 
            this.lblBExam.AutoSize = true;
            this.lblBExam.Location = new System.Drawing.Point(16, 52);
            this.lblBExam.Name = "lblBExam";
            this.lblBExam.Size = new System.Drawing.Size(17, 13);
            this.lblBExam.TabIndex = 2;
            this.lblBExam.Text = "B:";
            // 
            // checkBoxAExam
            // 
            this.checkBoxAExam.AutoSize = true;
            this.checkBoxAExam.Location = new System.Drawing.Point(39, 22);
            this.checkBoxAExam.Name = "checkBoxAExam";
            this.checkBoxAExam.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAExam.TabIndex = 1;
            this.checkBoxAExam.Tag = "1";
            this.checkBoxAExam.UseVisualStyleBackColor = true;
            this.checkBoxAExam.CheckedChanged += new System.EventHandler(this.checkBoxAExam_CheckedChanged);
            // 
            // lblAExam
            // 
            this.lblAExam.AutoSize = true;
            this.lblAExam.Location = new System.Drawing.Point(16, 22);
            this.lblAExam.Name = "lblAExam";
            this.lblAExam.Size = new System.Drawing.Size(17, 13);
            this.lblAExam.TabIndex = 0;
            this.lblAExam.Text = "A:";
            // 
            // groupBoxExamPower
            // 
            this.groupBoxExamPower.Controls.Add(this.checkBoxExamPower3rdRail);
            this.groupBoxExamPower.Controls.Add(this.lblExamPower3rdRail);
            this.groupBoxExamPower.Controls.Add(this.checkBoxExamPowerOverhead);
            this.groupBoxExamPower.Controls.Add(this.lblExamPowerOverhead);
            this.groupBoxExamPower.Controls.Add(this.checkBoxExamPowerDiesel);
            this.groupBoxExamPower.Controls.Add(this.lblExamPowerDiesel);
            this.groupBoxExamPower.Location = new System.Drawing.Point(417, 150);
            this.groupBoxExamPower.Name = "groupBoxExamPower";
            this.groupBoxExamPower.Size = new System.Drawing.Size(127, 137);
            this.groupBoxExamPower.TabIndex = 12;
            this.groupBoxExamPower.TabStop = false;
            this.groupBoxExamPower.Text = "Exam Power";
            // 
            // checkBoxExamPower3rdRail
            // 
            this.checkBoxExamPower3rdRail.AutoSize = true;
            this.checkBoxExamPower3rdRail.Location = new System.Drawing.Point(86, 82);
            this.checkBoxExamPower3rdRail.Name = "checkBoxExamPower3rdRail";
            this.checkBoxExamPower3rdRail.Size = new System.Drawing.Size(15, 14);
            this.checkBoxExamPower3rdRail.TabIndex = 15;
            this.checkBoxExamPower3rdRail.Tag = "8196";
            this.checkBoxExamPower3rdRail.UseVisualStyleBackColor = true;
            this.checkBoxExamPower3rdRail.CheckedChanged += new System.EventHandler(this.checkBoxExamPower3rdRail_CheckedChanged);
            // 
            // lblExamPower3rdRail
            // 
            this.lblExamPower3rdRail.AutoSize = true;
            this.lblExamPower3rdRail.Location = new System.Drawing.Point(16, 82);
            this.lblExamPower3rdRail.Name = "lblExamPower3rdRail";
            this.lblExamPower3rdRail.Size = new System.Drawing.Size(46, 13);
            this.lblExamPower3rdRail.TabIndex = 14;
            this.lblExamPower3rdRail.Text = "3rd Rail:";
            // 
            // checkBoxExamPowerOverhead
            // 
            this.checkBoxExamPowerOverhead.AutoSize = true;
            this.checkBoxExamPowerOverhead.Location = new System.Drawing.Point(86, 51);
            this.checkBoxExamPowerOverhead.Name = "checkBoxExamPowerOverhead";
            this.checkBoxExamPowerOverhead.Size = new System.Drawing.Size(15, 14);
            this.checkBoxExamPowerOverhead.TabIndex = 13;
            this.checkBoxExamPowerOverhead.Tag = "2048";
            this.checkBoxExamPowerOverhead.UseVisualStyleBackColor = true;
            this.checkBoxExamPowerOverhead.CheckedChanged += new System.EventHandler(this.checkBoxExamPowerOverhead_CheckedChanged);
            // 
            // lblExamPowerOverhead
            // 
            this.lblExamPowerOverhead.AutoSize = true;
            this.lblExamPowerOverhead.Location = new System.Drawing.Point(16, 52);
            this.lblExamPowerOverhead.Name = "lblExamPowerOverhead";
            this.lblExamPowerOverhead.Size = new System.Drawing.Size(57, 13);
            this.lblExamPowerOverhead.TabIndex = 12;
            this.lblExamPowerOverhead.Text = "Overhead:";
            // 
            // checkBoxExamPowerDiesel
            // 
            this.checkBoxExamPowerDiesel.AutoSize = true;
            this.checkBoxExamPowerDiesel.Location = new System.Drawing.Point(86, 22);
            this.checkBoxExamPowerDiesel.Name = "checkBoxExamPowerDiesel";
            this.checkBoxExamPowerDiesel.Size = new System.Drawing.Size(15, 14);
            this.checkBoxExamPowerDiesel.TabIndex = 9;
            this.checkBoxExamPowerDiesel.Tag = "1024";
            this.checkBoxExamPowerDiesel.UseVisualStyleBackColor = true;
            this.checkBoxExamPowerDiesel.CheckedChanged += new System.EventHandler(this.checkBoxExamPowerDiesel_CheckedChanged);
            // 
            // lblExamPowerDiesel
            // 
            this.lblExamPowerDiesel.AutoSize = true;
            this.lblExamPowerDiesel.Location = new System.Drawing.Point(16, 22);
            this.lblExamPowerDiesel.Name = "lblExamPowerDiesel";
            this.lblExamPowerDiesel.Size = new System.Drawing.Size(39, 13);
            this.lblExamPowerDiesel.TabIndex = 8;
            this.lblExamPowerDiesel.Text = "Diesel:";
            // 
            // groupBoxExamTraction
            // 
            this.groupBoxExamTraction.Controls.Add(this.checkBoxTractionWagon);
            this.groupBoxExamTraction.Controls.Add(this.lblExamTractionWagon);
            this.groupBoxExamTraction.Controls.Add(this.checkBoxTractionCarriage);
            this.groupBoxExamTraction.Controls.Add(this.lblExamTractionCarriage);
            this.groupBoxExamTraction.Controls.Add(this.checkBoxTractionDEMU);
            this.groupBoxExamTraction.Controls.Add(this.lblExamTractionDEMU);
            this.groupBoxExamTraction.Controls.Add(this.checkBoxTractionDMU);
            this.groupBoxExamTraction.Controls.Add(this.lblExamTractionDMU);
            this.groupBoxExamTraction.Controls.Add(this.checkBoxTractionEMU);
            this.groupBoxExamTraction.Controls.Add(this.lblExamTractionEMU);
            this.groupBoxExamTraction.Controls.Add(this.checkBoxTractionLoco);
            this.groupBoxExamTraction.Controls.Add(this.lblExamTractionLoco);
            this.groupBoxExamTraction.Location = new System.Drawing.Point(559, 150);
            this.groupBoxExamTraction.Name = "groupBoxExamTraction";
            this.groupBoxExamTraction.Size = new System.Drawing.Size(234, 137);
            this.groupBoxExamTraction.TabIndex = 16;
            this.groupBoxExamTraction.TabStop = false;
            this.groupBoxExamTraction.Text = "Exam Traction";
            // 
            // checkBoxTractionWagon
            // 
            this.checkBoxTractionWagon.AutoSize = true;
            this.checkBoxTractionWagon.Location = new System.Drawing.Point(193, 52);
            this.checkBoxTractionWagon.Name = "checkBoxTractionWagon";
            this.checkBoxTractionWagon.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTractionWagon.TabIndex = 21;
            this.checkBoxTractionWagon.Tag = "262144";
            this.checkBoxTractionWagon.UseVisualStyleBackColor = true;
            this.checkBoxTractionWagon.CheckedChanged += new System.EventHandler(this.checkBoxTractionWagon_CheckedChanged);
            // 
            // lblExamTractionWagon
            // 
            this.lblExamTractionWagon.AutoSize = true;
            this.lblExamTractionWagon.Location = new System.Drawing.Point(122, 51);
            this.lblExamTractionWagon.Name = "lblExamTractionWagon";
            this.lblExamTractionWagon.Size = new System.Drawing.Size(45, 13);
            this.lblExamTractionWagon.TabIndex = 20;
            this.lblExamTractionWagon.Text = "Wagon:";
            // 
            // checkBoxTractionCarriage
            // 
            this.checkBoxTractionCarriage.AutoSize = true;
            this.checkBoxTractionCarriage.Location = new System.Drawing.Point(193, 23);
            this.checkBoxTractionCarriage.Name = "checkBoxTractionCarriage";
            this.checkBoxTractionCarriage.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTractionCarriage.TabIndex = 19;
            this.checkBoxTractionCarriage.Tag = "131072";
            this.checkBoxTractionCarriage.UseVisualStyleBackColor = true;
            this.checkBoxTractionCarriage.CheckedChanged += new System.EventHandler(this.checkBoxTractionCarriage_CheckedChanged);
            // 
            // lblExamTractionCarriage
            // 
            this.lblExamTractionCarriage.AutoSize = true;
            this.lblExamTractionCarriage.Location = new System.Drawing.Point(122, 23);
            this.lblExamTractionCarriage.Name = "lblExamTractionCarriage";
            this.lblExamTractionCarriage.Size = new System.Drawing.Size(49, 13);
            this.lblExamTractionCarriage.TabIndex = 18;
            this.lblExamTractionCarriage.Text = "Carriage:";
            // 
            // checkBoxTractionDEMU
            // 
            this.checkBoxTractionDEMU.AutoSize = true;
            this.checkBoxTractionDEMU.Location = new System.Drawing.Point(86, 112);
            this.checkBoxTractionDEMU.Name = "checkBoxTractionDEMU";
            this.checkBoxTractionDEMU.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTractionDEMU.TabIndex = 17;
            this.checkBoxTractionDEMU.Tag = "65536";
            this.checkBoxTractionDEMU.UseVisualStyleBackColor = true;
            this.checkBoxTractionDEMU.CheckedChanged += new System.EventHandler(this.checkBoxTractionDEMU_CheckedChanged);
            // 
            // lblExamTractionDEMU
            // 
            this.lblExamTractionDEMU.AutoSize = true;
            this.lblExamTractionDEMU.Location = new System.Drawing.Point(16, 112);
            this.lblExamTractionDEMU.Name = "lblExamTractionDEMU";
            this.lblExamTractionDEMU.Size = new System.Drawing.Size(42, 13);
            this.lblExamTractionDEMU.TabIndex = 16;
            this.lblExamTractionDEMU.Text = "DEMU:";
            // 
            // checkBoxTractionDMU
            // 
            this.checkBoxTractionDMU.AutoSize = true;
            this.checkBoxTractionDMU.Location = new System.Drawing.Point(86, 82);
            this.checkBoxTractionDMU.Name = "checkBoxTractionDMU";
            this.checkBoxTractionDMU.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTractionDMU.TabIndex = 15;
            this.checkBoxTractionDMU.Tag = "32768";
            this.checkBoxTractionDMU.UseVisualStyleBackColor = true;
            this.checkBoxTractionDMU.CheckedChanged += new System.EventHandler(this.checkBoxTractionDMU_CheckedChanged);
            // 
            // lblExamTractionDMU
            // 
            this.lblExamTractionDMU.AutoSize = true;
            this.lblExamTractionDMU.Location = new System.Drawing.Point(16, 82);
            this.lblExamTractionDMU.Name = "lblExamTractionDMU";
            this.lblExamTractionDMU.Size = new System.Drawing.Size(35, 13);
            this.lblExamTractionDMU.TabIndex = 14;
            this.lblExamTractionDMU.Text = "DMU:";
            // 
            // checkBoxTractionEMU
            // 
            this.checkBoxTractionEMU.AutoSize = true;
            this.checkBoxTractionEMU.Location = new System.Drawing.Point(86, 51);
            this.checkBoxTractionEMU.Name = "checkBoxTractionEMU";
            this.checkBoxTractionEMU.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTractionEMU.TabIndex = 13;
            this.checkBoxTractionEMU.Tag = "16384";
            this.checkBoxTractionEMU.UseVisualStyleBackColor = true;
            this.checkBoxTractionEMU.CheckedChanged += new System.EventHandler(this.checkBoxTractionEMU_CheckedChanged);
            // 
            // lblExamTractionEMU
            // 
            this.lblExamTractionEMU.AutoSize = true;
            this.lblExamTractionEMU.Location = new System.Drawing.Point(16, 52);
            this.lblExamTractionEMU.Name = "lblExamTractionEMU";
            this.lblExamTractionEMU.Size = new System.Drawing.Size(34, 13);
            this.lblExamTractionEMU.TabIndex = 12;
            this.lblExamTractionEMU.Text = "EMU:";
            // 
            // checkBoxTractionLoco
            // 
            this.checkBoxTractionLoco.AutoSize = true;
            this.checkBoxTractionLoco.Location = new System.Drawing.Point(86, 22);
            this.checkBoxTractionLoco.Name = "checkBoxTractionLoco";
            this.checkBoxTractionLoco.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTractionLoco.TabIndex = 9;
            this.checkBoxTractionLoco.Tag = "8192";
            this.checkBoxTractionLoco.UseVisualStyleBackColor = true;
            this.checkBoxTractionLoco.CheckedChanged += new System.EventHandler(this.checkBoxTractionLoco_CheckedChanged);
            // 
            // lblExamTractionLoco
            // 
            this.lblExamTractionLoco.AutoSize = true;
            this.lblExamTractionLoco.Location = new System.Drawing.Point(16, 22);
            this.lblExamTractionLoco.Name = "lblExamTractionLoco";
            this.lblExamTractionLoco.Size = new System.Drawing.Size(34, 13);
            this.lblExamTractionLoco.TabIndex = 8;
            this.lblExamTractionLoco.Text = "Loco:";
            // 
            // frmEditDepot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 325);
            this.Controls.Add(this.groupBoxExamTraction);
            this.Controls.Add(this.groupBoxExamPower);
            this.Controls.Add(this.groupBoxExams);
            this.Controls.Add(this.groupBoxDepotDetails);
            this.Controls.Add(this.statusStripDepot);
            this.Controls.Add(this.listViewDepots);
            this.Controls.Add(this.menuStripDepot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripDepot;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditDepot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Depot Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditDepot_FormClosing);
            this.menuStripDepot.ResumeLayout(false);
            this.menuStripDepot.PerformLayout();
            this.statusStripDepot.ResumeLayout(false);
            this.statusStripDepot.PerformLayout();
            this.groupBoxDepotDetails.ResumeLayout(false);
            this.groupBoxDepotDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercVisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEaseofAccess)).EndInit();
            this.groupBoxExams.ResumeLayout(false);
            this.groupBoxExams.PerformLayout();
            this.groupBoxExamPower.ResumeLayout(false);
            this.groupBoxExamPower.PerformLayout();
            this.groupBoxExamTraction.ResumeLayout(false);
            this.groupBoxExamTraction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewDepots;
        private System.Windows.Forms.MenuStrip menuStripDepot;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripDepot;
        private System.Windows.Forms.ColumnHeader columnHeaderStartYMDV;
        private System.Windows.Forms.ColumnHeader columnHeaderEndYMDV;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDepotRecord;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDepotStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderCode;
        private System.Windows.Forms.GroupBox groupBoxDepotDetails;
        private System.Windows.Forms.Label lblDepotActiveTo;
        private System.Windows.Forms.DateTimePicker dateTimeDepotActiveFrom;
        private System.Windows.Forms.DateTimePicker dateTimeDepotActiveTo;
        private System.Windows.Forms.Label lbDepotActiveFrom;
        private System.Windows.Forms.TextBox txtBoxCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.NumericUpDown numericUpDownPercVisible;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownEaseofAccess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxExams;
        private System.Windows.Forms.CheckBox checkBoxAExam;
        private System.Windows.Forms.Label lblAExam;
        private System.Windows.Forms.CheckBox checkBoxDExam;
        private System.Windows.Forms.Label lblDExam;
        private System.Windows.Forms.CheckBox checkBoxCExam;
        private System.Windows.Forms.Label lblCExam;
        private System.Windows.Forms.CheckBox checkBoxBExam;
        private System.Windows.Forms.Label lblBExam;
        private System.Windows.Forms.CheckBox checkBoxFExam;
        private System.Windows.Forms.Label lblFExam;
        private System.Windows.Forms.CheckBox checkBoxEExam;
        private System.Windows.Forms.Label lblEExam;
        private System.Windows.Forms.GroupBox groupBoxExamPower;
        private System.Windows.Forms.CheckBox checkBoxExamPowerDiesel;
        private System.Windows.Forms.Label lblExamPowerDiesel;
        private System.Windows.Forms.CheckBox checkBoxExamPowerOverhead;
        private System.Windows.Forms.Label lblExamPowerOverhead;
        private System.Windows.Forms.CheckBox checkBoxExamPower3rdRail;
        private System.Windows.Forms.Label lblExamPower3rdRail;
        private System.Windows.Forms.GroupBox groupBoxExamTraction;
        private System.Windows.Forms.CheckBox checkBoxTractionDMU;
        private System.Windows.Forms.Label lblExamTractionDMU;
        private System.Windows.Forms.CheckBox checkBoxTractionEMU;
        private System.Windows.Forms.Label lblExamTractionEMU;
        private System.Windows.Forms.CheckBox checkBoxTractionLoco;
        private System.Windows.Forms.Label lblExamTractionLoco;
        private System.Windows.Forms.Label lblExamTractionDEMU;
        private System.Windows.Forms.CheckBox checkBoxTractionDEMU;
        private System.Windows.Forms.CheckBox checkBoxTractionWagon;
        private System.Windows.Forms.Label lblExamTractionWagon;
        private System.Windows.Forms.CheckBox checkBoxTractionCarriage;
        private System.Windows.Forms.Label lblExamTractionCarriage;
        private System.Windows.Forms.CheckBox checkBoxWheelLathe;
        private System.Windows.Forms.Label lblFuel;
        private System.Windows.Forms.Label lblWheelLathe;
        private System.Windows.Forms.CheckBox checkBoxWater;
        private System.Windows.Forms.Label lblWater;
        private System.Windows.Forms.CheckBox checkBoxFuel;
        private System.Windows.Forms.CheckBox checkBoxCoal;
        private System.Windows.Forms.Label lblCoal;
    }
}