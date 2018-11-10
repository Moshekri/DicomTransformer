namespace DicomTransformer
{
    partial class MainWindow
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
            this.btnAddNewSite = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnQuit = new System.Windows.Forms.Button();
            this.dgvSites = new System.Windows.Forms.DataGridView();
            this.configBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sCUSitesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.siteNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aETitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siteNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.informationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCUSitesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNewSite
            // 
            this.btnAddNewSite.Location = new System.Drawing.Point(27, 199);
            this.btnAddNewSite.Name = "btnAddNewSite";
            this.btnAddNewSite.Size = new System.Drawing.Size(91, 23);
            this.btnAddNewSite.TabIndex = 0;
            this.btnAddNewSite.Text = "Add New Site";
            this.btnAddNewSite.UseVisualStyleBackColor = true;
            this.btnAddNewSite.Click += new System.EventHandler(this.btnAddNewSite_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Dicom Transformer";
            this.notifyIcon1.Text = "Dicom Transformer";
            this.notifyIcon1.Visible = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(409, 373);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(91, 23);
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // dgvSites
            // 
            this.dgvSites.AutoGenerateColumns = false;
            this.dgvSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSites.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.siteNameDataGridViewTextBoxColumn,
            this.aETitleDataGridViewTextBoxColumn,
            this.portDataGridViewTextBoxColumn,
            this.siteNumberDataGridViewTextBoxColumn,
            this.informationDataGridViewTextBoxColumn});
            this.dgvSites.DataSource = this.sCUSitesBindingSource;
            this.dgvSites.Location = new System.Drawing.Point(27, 37);
            this.dgvSites.Name = "dgvSites";
            this.dgvSites.Size = new System.Drawing.Size(600, 147);
            this.dgvSites.TabIndex = 1;
            // 
            // configBindingSource
            // 
            this.configBindingSource.DataSource = typeof(Common.Config);
            // 
            // sCUSitesBindingSource
            // 
            this.sCUSitesBindingSource.DataMember = "SCUSites";
            this.sCUSitesBindingSource.DataSource = this.configBindingSource;
            // 
            // siteNameDataGridViewTextBoxColumn
            // 
            this.siteNameDataGridViewTextBoxColumn.DataPropertyName = "SiteName";
            this.siteNameDataGridViewTextBoxColumn.HeaderText = "SiteName";
            this.siteNameDataGridViewTextBoxColumn.Name = "siteNameDataGridViewTextBoxColumn";
            // 
            // aETitleDataGridViewTextBoxColumn
            // 
            this.aETitleDataGridViewTextBoxColumn.DataPropertyName = "AETitle";
            this.aETitleDataGridViewTextBoxColumn.HeaderText = "AETitle";
            this.aETitleDataGridViewTextBoxColumn.Name = "aETitleDataGridViewTextBoxColumn";
            // 
            // portDataGridViewTextBoxColumn
            // 
            this.portDataGridViewTextBoxColumn.DataPropertyName = "Port";
            this.portDataGridViewTextBoxColumn.HeaderText = "Port";
            this.portDataGridViewTextBoxColumn.Name = "portDataGridViewTextBoxColumn";
            // 
            // siteNumberDataGridViewTextBoxColumn
            // 
            this.siteNumberDataGridViewTextBoxColumn.DataPropertyName = "SiteNumber";
            this.siteNumberDataGridViewTextBoxColumn.HeaderText = "SiteNumber";
            this.siteNumberDataGridViewTextBoxColumn.Name = "siteNumberDataGridViewTextBoxColumn";
            this.siteNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // informationDataGridViewTextBoxColumn
            // 
            this.informationDataGridViewTextBoxColumn.DataPropertyName = "Information";
            this.informationDataGridViewTextBoxColumn.HeaderText = "Information";
            this.informationDataGridViewTextBoxColumn.Name = "informationDataGridViewTextBoxColumn";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 423);
            this.Controls.Add(this.dgvSites);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnAddNewSite);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCUSitesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewSite;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.DataGridView dgvSites;
        private System.Windows.Forms.DataGridViewTextBoxColumn siteNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aETitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siteNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn informationDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sCUSitesBindingSource;
        private System.Windows.Forms.BindingSource configBindingSource;
    }
}

