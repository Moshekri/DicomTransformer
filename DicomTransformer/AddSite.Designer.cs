namespace DicomTransformer
{
    partial class AddSiteForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.txtAETitle = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtSiteNumber = new System.Windows.Forms.TextBox();
            this.btnAddSite = new System.Windows.Forms.Button();
            this.txtMoreInformation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Site Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "AE Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Site Number";
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(110, 22);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(131, 20);
            this.txtSiteName.TabIndex = 0;
            // 
            // txtAETitle
            // 
            this.txtAETitle.Location = new System.Drawing.Point(110, 51);
            this.txtAETitle.Name = "txtAETitle";
            this.txtAETitle.Size = new System.Drawing.Size(131, 20);
            this.txtAETitle.TabIndex = 1;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(110, 80);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(131, 20);
            this.txtPort.TabIndex = 2;
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSiteNumber_KeyPress);
            // 
            // txtSiteNumber
            // 
            this.txtSiteNumber.Location = new System.Drawing.Point(110, 109);
            this.txtSiteNumber.Name = "txtSiteNumber";
            this.txtSiteNumber.Size = new System.Drawing.Size(131, 20);
            this.txtSiteNumber.TabIndex = 3;
            this.txtSiteNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSiteNumber_KeyPress);
            // 
            // btnAddSite
            // 
            this.btnAddSite.Location = new System.Drawing.Point(29, 323);
            this.btnAddSite.Name = "btnAddSite";
            this.btnAddSite.Size = new System.Drawing.Size(75, 23);
            this.btnAddSite.TabIndex = 5;
            this.btnAddSite.Text = "Add";
            this.btnAddSite.UseVisualStyleBackColor = true;
            this.btnAddSite.Click += new System.EventHandler(this.btnAddSite_Click);
            // 
            // txtMoreInformation
            // 
            this.txtMoreInformation.Location = new System.Drawing.Point(29, 180);
            this.txtMoreInformation.Multiline = true;
            this.txtMoreInformation.Name = "txtMoreInformation";
            this.txtMoreInformation.Size = new System.Drawing.Size(212, 122);
            this.txtMoreInformation.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Comments";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(166, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddSiteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 370);
            this.Controls.Add(this.txtMoreInformation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddSite);
            this.Controls.Add(this.txtSiteNumber);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtAETitle);
            this.Controls.Add(this.txtSiteName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AddSiteForm";
            this.Text = "Add SCU Site";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.TextBox txtAETitle;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtSiteNumber;
        private System.Windows.Forms.Button btnAddSite;
        private System.Windows.Forms.TextBox txtMoreInformation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        
    }
}