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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnQuit = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dgvSites = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddNewSite = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnResetCounter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewCounterValue = new System.Windows.Forms.TextBox();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRestartService = new System.Windows.Forms.Button();
            this.lblServiceStatus = new System.Windows.Forms.Label();
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnStopService = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCurrentCounter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSites)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Dicom Transformer";
            this.notifyIcon1.Text = "Dicom Transformer";
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(634, 470);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(121, 28);
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.Exit);
            // 
            // dgvSites
            // 
            this.dgvSites.AllowUserToAddRows = false;
            this.dgvSites.AllowUserToDeleteRows = false;
            this.dgvSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSites.Location = new System.Drawing.Point(0, 0);
            this.dgvSites.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSites.Name = "dgvSites";
            this.dgvSites.RowTemplate.Height = 24;
            this.dgvSites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSites.Size = new System.Drawing.Size(736, 225);
            this.dgvSites.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSites);
            this.panel1.Location = new System.Drawing.Point(19, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 225);
            this.panel1.TabIndex = 3;
            // 
            // btnAddNewSite
            // 
            this.btnAddNewSite.Location = new System.Drawing.Point(505, 259);
            this.btnAddNewSite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddNewSite.Name = "btnAddNewSite";
            this.btnAddNewSite.Size = new System.Drawing.Size(105, 53);
            this.btnAddNewSite.TabIndex = 4;
            this.btnAddNewSite.Text = "Add New Site";
            this.btnAddNewSite.UseVisualStyleBackColor = true;
            this.btnAddNewSite.Click += new System.EventHandler(this.btnAddNewSite_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(644, 259);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 53);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete Selected Site";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnResetCounter
            // 
            this.btnResetCounter.Location = new System.Drawing.Point(205, 71);
            this.btnResetCounter.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetCounter.Name = "btnResetCounter";
            this.btnResetCounter.Size = new System.Drawing.Size(172, 49);
            this.btnResetCounter.TabIndex = 6;
            this.btnResetCounter.Text = "Set Counter";
            this.btnResetCounter.UseVisualStyleBackColor = true;
            this.btnResetCounter.Click += new System.EventHandler(this.btnResetCounter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "New Counter Value";
            // 
            // txtNewCounterValue
            // 
            this.txtNewCounterValue.Location = new System.Drawing.Point(205, 31);
            this.txtNewCounterValue.Name = "txtNewCounterValue";
            this.txtNewCounterValue.Size = new System.Drawing.Size(172, 22);
            this.txtNewCounterValue.TabIndex = 8;
            this.txtNewCounterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewCounterValue_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCurrentCounter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnResetCounter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNewCounterValue);
            this.groupBox1.Location = new System.Drawing.Point(33, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 142);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accession Number Counter Control";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRestartService);
            this.groupBox2.Controls.Add(this.lblServiceStatus);
            this.groupBox2.Controls.Add(this.btnStartService);
            this.groupBox2.Controls.Add(this.btnStopService);
            this.groupBox2.Location = new System.Drawing.Point(33, 420);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 78);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Service Status";
            // 
            // btnRestartService
            // 
            this.btnRestartService.Location = new System.Drawing.Point(455, 15);
            this.btnRestartService.Name = "btnRestartService";
            this.btnRestartService.Size = new System.Drawing.Size(93, 51);
            this.btnRestartService.TabIndex = 13;
            this.btnRestartService.Text = "Restart Service";
            this.btnRestartService.UseVisualStyleBackColor = true;
            this.btnRestartService.Click += new System.EventHandler(this.btnRestartService_Click_1);
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.AutoSize = true;
            this.lblServiceStatus.Location = new System.Drawing.Point(26, 33);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(0, 17);
            this.lblServiceStatus.TabIndex = 10;
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(313, 16);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(93, 51);
            this.btnStartService.TabIndex = 12;
            this.btnStartService.Text = "Start Service";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(171, 15);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(93, 51);
            this.btnStopService.TabIndex = 11;
            this.btnStopService.Text = "Stop Service";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Current Counter";
            // 
            // lblCurrentCounter
            // 
            this.lblCurrentCounter.AutoSize = true;
            this.lblCurrentCounter.Location = new System.Drawing.Point(22, 102);
            this.lblCurrentCounter.Name = "lblCurrentCounter";
            this.lblCurrentCounter.Size = new System.Drawing.Size(0, 17);
            this.lblCurrentCounter.TabIndex = 10;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 521);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddNewSite);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnQuit);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSites)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dgvSites;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddNewSite;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnResetCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewCounterValue;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblServiceStatus;
        private System.Windows.Forms.Button btnRestartService;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Label lblCurrentCounter;
        private System.Windows.Forms.Label label2;
    }
}

