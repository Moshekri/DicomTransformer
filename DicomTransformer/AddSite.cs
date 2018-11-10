using Common;
using ConfigManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DicomTransformer
{
    public partial class AddSiteForm : Form
    {
        ConfManager _configManager;
        Timer t;
        public AddSiteForm()
        {
            InitializeComponent();

        }
        public AddSiteForm(ConfManager configManger) : this()
        {
            _configManager = configManger;
            t = new Timer();
            t.Interval = 100;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            btnAddSite.Enabled = txtAETitle.Text != string.Empty &&
                                   txtPort.Text != string.Empty &&
                                   txtSiteName.Text != string.Empty &&
                                   txtSiteNumber.Text != string.Empty;
        }

        private void btnAddSite_Click(object sender, EventArgs e)
        {

            var aeTitle = txtAETitle.Text;
            var comments = txtMoreInformation.Text;
            var port = int.Parse(txtPort.Text);
            var siteName = txtSiteName.Text;
            var sitenumber = int.Parse(txtSiteNumber.Text);
            _configManager.AddSite(siteName, aeTitle, port, sitenumber, comments);
            this.DialogResult = DialogResult.OK;
            t.Stop();
            this.Close();
        }

        private void AddBtnStatus()
        {
            btnAddSite.Enabled = txtAETitle.Text != string.Empty &&
                                 txtPort.Text != string.Empty &&
                                 txtSiteName.Text != string.Empty &&
                                 txtSiteNumber.Text != string.Empty;
        }


        private void txtSiteNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            t.Stop();
            this.Close();
        }
    }
}
