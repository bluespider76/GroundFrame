namespace Horizon4.GFDataEditor
{
    partial class frmDistanceCalculator
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
            this.groupDistance = new System.Windows.Forms.GroupBox();
            this.numericUpDownEndChains = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEndMiles = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStartChains = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStartMiles = new System.Windows.Forms.NumericUpDown();
            this.lblEndChains = new System.Windows.Forms.Label();
            this.lblEndMiles = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStartChains = new System.Windows.Forms.Label();
            this.lblStartMiles = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.lblMeters = new System.Windows.Forms.Label();
            this.txtResultMeters = new System.Windows.Forms.TextBox();
            this.groupDistance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndChains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndMiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartChains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartMiles)).BeginInit();
            this.groupBoxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDistance
            // 
            this.groupDistance.Controls.Add(this.numericUpDownEndChains);
            this.groupDistance.Controls.Add(this.numericUpDownEndMiles);
            this.groupDistance.Controls.Add(this.numericUpDownStartChains);
            this.groupDistance.Controls.Add(this.numericUpDownStartMiles);
            this.groupDistance.Controls.Add(this.lblEndChains);
            this.groupDistance.Controls.Add(this.lblEndMiles);
            this.groupDistance.Controls.Add(this.lblEnd);
            this.groupDistance.Controls.Add(this.lblStartChains);
            this.groupDistance.Controls.Add(this.lblStartMiles);
            this.groupDistance.Controls.Add(this.label1);
            this.groupDistance.Location = new System.Drawing.Point(12, 12);
            this.groupDistance.Name = "groupDistance";
            this.groupDistance.Size = new System.Drawing.Size(293, 93);
            this.groupDistance.TabIndex = 0;
            this.groupDistance.TabStop = false;
            this.groupDistance.Text = "Distance";
            // 
            // numericUpDownEndChains
            // 
            this.numericUpDownEndChains.Location = new System.Drawing.Point(178, 57);
            this.numericUpDownEndChains.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numericUpDownEndChains.Name = "numericUpDownEndChains";
            this.numericUpDownEndChains.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownEndChains.TabIndex = 13;
            this.numericUpDownEndChains.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownEndChains.ValueChanged += new System.EventHandler(this.numericUpDownEndChains_ValueChanged);
            // 
            // numericUpDownEndMiles
            // 
            this.numericUpDownEndMiles.Location = new System.Drawing.Point(69, 57);
            this.numericUpDownEndMiles.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownEndMiles.Name = "numericUpDownEndMiles";
            this.numericUpDownEndMiles.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownEndMiles.TabIndex = 12;
            this.numericUpDownEndMiles.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownEndMiles.ValueChanged += new System.EventHandler(this.numericUpDownEndMiles_ValueChanged);
            // 
            // numericUpDownStartChains
            // 
            this.numericUpDownStartChains.Location = new System.Drawing.Point(178, 23);
            this.numericUpDownStartChains.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numericUpDownStartChains.Name = "numericUpDownStartChains";
            this.numericUpDownStartChains.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownStartChains.TabIndex = 11;
            this.numericUpDownStartChains.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownStartChains.ValueChanged += new System.EventHandler(this.numericUpDownStartChains_ValueChanged);
            // 
            // numericUpDownStartMiles
            // 
            this.numericUpDownStartMiles.Location = new System.Drawing.Point(69, 23);
            this.numericUpDownStartMiles.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownStartMiles.Name = "numericUpDownStartMiles";
            this.numericUpDownStartMiles.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownStartMiles.TabIndex = 10;
            this.numericUpDownStartMiles.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownStartMiles.ValueChanged += new System.EventHandler(this.numericUpDownStartMiles_ValueChanged);
            // 
            // lblEndChains
            // 
            this.lblEndChains.AutoSize = true;
            this.lblEndChains.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblEndChains.Location = new System.Drawing.Point(238, 59);
            this.lblEndChains.Name = "lblEndChains";
            this.lblEndChains.Size = new System.Drawing.Size(39, 13);
            this.lblEndChains.TabIndex = 9;
            this.lblEndChains.Text = "Chains";
            // 
            // lblEndMiles
            // 
            this.lblEndMiles.AutoSize = true;
            this.lblEndMiles.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblEndMiles.Location = new System.Drawing.Point(130, 59);
            this.lblEndMiles.Name = "lblEndMiles";
            this.lblEndMiles.Size = new System.Drawing.Size(31, 13);
            this.lblEndMiles.TabIndex = 7;
            this.lblEndMiles.Text = "Miles";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(18, 59);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(29, 13);
            this.lblEnd.TabIndex = 5;
            this.lblEnd.Text = "End:";
            // 
            // lblStartChains
            // 
            this.lblStartChains.AutoSize = true;
            this.lblStartChains.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblStartChains.Location = new System.Drawing.Point(238, 25);
            this.lblStartChains.Name = "lblStartChains";
            this.lblStartChains.Size = new System.Drawing.Size(39, 13);
            this.lblStartChains.TabIndex = 4;
            this.lblStartChains.Text = "Chains";
            // 
            // lblStartMiles
            // 
            this.lblStartMiles.AutoSize = true;
            this.lblStartMiles.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblStartMiles.Location = new System.Drawing.Point(130, 25);
            this.lblStartMiles.Name = "lblStartMiles";
            this.lblStartMiles.Size = new System.Drawing.Size(31, 13);
            this.lblStartMiles.TabIndex = 2;
            this.lblStartMiles.Text = "Miles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start:";
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.lblMeters);
            this.groupBoxResult.Controls.Add(this.txtResultMeters);
            this.groupBoxResult.Location = new System.Drawing.Point(12, 120);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(293, 67);
            this.groupBoxResult.TabIndex = 1;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Result";
            // 
            // lblMeters
            // 
            this.lblMeters.AutoSize = true;
            this.lblMeters.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblMeters.Location = new System.Drawing.Point(130, 22);
            this.lblMeters.Name = "lblMeters";
            this.lblMeters.Size = new System.Drawing.Size(39, 13);
            this.lblMeters.TabIndex = 14;
            this.lblMeters.Text = "Meters";
            // 
            // txtResultMeters
            // 
            this.txtResultMeters.Location = new System.Drawing.Point(21, 19);
            this.txtResultMeters.Name = "txtResultMeters";
            this.txtResultMeters.Size = new System.Drawing.Size(100, 20);
            this.txtResultMeters.TabIndex = 2;
            // 
            // frmDistanceCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 199);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupDistance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDistanceCalculator";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Distance Calculator";
            this.groupDistance.ResumeLayout(false);
            this.groupDistance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndChains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndMiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartChains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartMiles)).EndInit();
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDistance;
        private System.Windows.Forms.Label lblStartChains;
        private System.Windows.Forms.Label lblStartMiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEndChains;
        private System.Windows.Forms.Label lblEndMiles;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.NumericUpDown numericUpDownStartChains;
        private System.Windows.Forms.NumericUpDown numericUpDownStartMiles;
        private System.Windows.Forms.NumericUpDown numericUpDownEndChains;
        private System.Windows.Forms.NumericUpDown numericUpDownEndMiles;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.Label lblMeters;
        private System.Windows.Forms.TextBox txtResultMeters;
    }
}