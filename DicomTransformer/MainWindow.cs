using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConfigManager;

namespace DicomTransformer
{
    public partial class MainWindow : Form
    {

        ConfManager configManager;


        public MainWindow()
        {
            InitializeComponent();
            string filePath = ConfigurationManager.AppSettings["ConfigFilePath"];
            LoadConfiguration(filePath);
        }

        private void LoadConfiguration(string filePath)
        {
            configManager = new ConfManager(filePath);
        }

        private void btnAddNewSite_Click(object sender, EventArgs e)
        {
            try
            {
                AddSite addSiteForm = new AddSite(configManager);
            }
            catch (SiteExistsExecption ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (SCPExsitsException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
