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
        NotifyIcon icon;
        ConfManager configManager;
        bool CloseApp = false;
        Config configuration;
            
        public MainWindow()
        {
            InitializeComponent();
            icon = new NotifyIcon();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            SetUpNotificationIcon();
            string filePath = ConfigurationManager.AppSettings["ConfigFilePath"];
            LoadConfiguration(filePath);


            bindingSource1.DataSource = configuration; 
            bindingSource1.DataMember = "SCUSites";
          
            dgvSites.DataSource =bindingSource1 ;
            
            

        }
        private void LoadConfiguration(string filePath)
        {
            configManager = new ConfManager(filePath);
            configuration = configManager.GetConfiguration();
        }
        private void btnAddNewSite_Click(object sender, EventArgs e)
        {
            try
            {
               AddSiteForm addSiteForm = new AddSiteForm(bindingSource1);
               var res =  addSiteForm.ShowDialog();
               

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
        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
            if (FormWindowState.Normal == WindowState)
            {
                Show();
                notifyIcon1.Visible = false;
            }
        }
        private void Open_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
        private void SetUpNotificationIcon()
        {
            notifyIcon1.Icon = new Icon(@"icon.ico");
            notifyIcon1.ContextMenu = new ContextMenu();
            MenuItem open = new MenuItem("Open", Open_Click);
            MenuItem Quit = new MenuItem("Quit Application", Exit);
            notifyIcon1.ContextMenu.MenuItems.Add(open);
            notifyIcon1.ContextMenu.MenuItems.Add(Quit);


        }
        private void Exit(object sender, EventArgs args)
        {
            WindowState = FormWindowState.Normal;
            var res = MessageBox.Show("Are You Sure You Want To Quit ?", "Confirm App Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                CloseApp = true;
                notifyIcon1.Visible = false;
                Show();
                this.Close();
            }
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseApp)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var res =MessageBox.Show("Are You Sure You Want To Delete This Row" , "Confirm Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res==DialogResult.Yes)
            {
               var site =  (Site)dgvSites.SelectedRows[0].DataBoundItem;
                bindingSource1.Remove(site);
                configManager.Save();
               
                dgvSites.Update();
                dgvSites.Refresh();
            }
        }
    }
}
