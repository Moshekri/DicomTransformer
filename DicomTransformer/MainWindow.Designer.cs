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
            this.btnAddNewSite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddNewSite
            // 
            this.btnAddNewSite.Location = new System.Drawing.Point(44, 338);
            this.btnAddNewSite.Name = "btnAddNewSite";
            this.btnAddNewSite.Size = new System.Drawing.Size(91, 23);
            this.btnAddNewSite.TabIndex = 0;
            this.btnAddNewSite.Text = "Add New Site";
            this.btnAddNewSite.UseVisualStyleBackColor = true;
            this.btnAddNewSite.Click += new System.EventHandler(this.btnAddNewSite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddNewSite);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewSite;
    }
}

