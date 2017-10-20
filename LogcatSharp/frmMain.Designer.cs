namespace LogcatSharp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.outputAdb = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.deviceSelect = new System.Windows.Forms.ToolStripComboBox();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtFilter = new System.Windows.Forms.ToolStripTextBox();
            this.regSelect = new System.Windows.Forms.ToolStripComboBox();
            this.levelSelect = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputAdb
            // 
            this.outputAdb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.outputAdb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputAdb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.outputAdb.Location = new System.Drawing.Point(0, 25);
            this.outputAdb.Name = "outputAdb";
            this.outputAdb.ReadOnly = true;
            this.outputAdb.Size = new System.Drawing.Size(667, 324);
            this.outputAdb.TabIndex = 0;
            this.outputAdb.Text = "";
            this.outputAdb.WordWrap = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deviceSelect,
            this.btnStart,
            this.toolStripButtonStop,
            this.toolStripSeparator2,
            this.btnClear,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtFilter,
            this.regSelect,
            this.levelSelect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(667, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // deviceSelect
            // 
            this.deviceSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceSelect.Name = "deviceSelect";
            this.deviceSelect.Size = new System.Drawing.Size(105, 25);
            // 
            // btnStart
            // 
            this.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(23, 22);
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStop.Enabled = false;
            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStop.Text = "Stop";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(58, 22);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Filter:";
            // 
            // txtFilter
            // 
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 25);
            // 
            // regSelect
            // 
            this.regSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regSelect.Items.AddRange(new object[] {
            "Simple",
            "Regex"});
            this.regSelect.Name = "regSelect";
            this.regSelect.Size = new System.Drawing.Size(75, 25);
            // 
            // levelSelect
            // 
            this.levelSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelSelect.Items.AddRange(new object[] {
            "Verbose",
            "Debug",
            "Info",
            "Warn",
            "Error",
            "Assert"});
            this.levelSelect.Name = "levelSelect";
            this.levelSelect.Size = new System.Drawing.Size(75, 25);
            this.levelSelect.SelectedIndexChanged += new System.EventHandler(this.levelSelect_IndexChange);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 349);
            this.Controls.Add(this.outputAdb);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "Logcat #";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.RichTextBox outputAdb;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnClear;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox txtFilter;
		private System.Windows.Forms.ToolStripComboBox regSelect;
		private System.Windows.Forms.ToolStripButton btnStart;
		private System.Windows.Forms.ToolStripButton toolStripButtonStop;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox deviceSelect;
        private System.Windows.Forms.ToolStripComboBox levelSelect;
	}
}

