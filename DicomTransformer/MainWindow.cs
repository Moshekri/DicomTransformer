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
using System.Threading;

namespace DicomTransformer
{
    public partial class MainWindow : Form
    {
        NotifyIcon icon;
        ConfManager configManager;
        bool CloseApp = false;
        Config configuration;
        Binding b;
        System.Timers.Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            icon = new NotifyIcon();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer(10000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();


            
            SetUpNotificationIcon();
            string filePath = ConfigurationManager.AppSettings["ConfigFilePath"];
            LoadConfiguration(filePath);


            bindingSource1.DataSource = configuration; 
            bindingSource1.DataMember = "SCUSites";
          
            dgvSites.DataSource =bindingSource1 ;
            dgvSites.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSites.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            serviceController1.ServiceName = "MuseDicomTransformer";
            SetServiceStatus();
             b = new Binding("Text", configuration, "Counter");
            lblCurrentCounter.DataBindings.Add(b);
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

          configuration =  configManager.RefreshData();
            UpdateCurrentCounter(configuration.Counter); 
        }

        private void UpdateCurrentCounter(int counter)
        {
            if (lblCurrentCounter.InvokeRequired)
            {
                lblCurrentCounter.Invoke(new Action(() => { UpdateCurrentCounter(counter); }));
            }
            else
            {
                lblCurrentCounter.Text = configuration.Counter.ToString();
            }
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
               DialogResult res =  addSiteForm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    configuration.SCUSites = (bindingSource1.DataSource as Config).SCUSites;
                    
                    configManager.Save(configuration);
                    btnStopService_Click(null, null);
                    configuration = configManager.RefreshData();
                    btnStartService_Click(null, null);
                }
       

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
           // notifyIcon1.Icon = new Icon(@"icon.ico");
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
            configManager.Save();
        }

        private void btnResetCounter_Click(object sender, EventArgs e)
        {
            SetCounter(int.Parse(txtNewCounterValue.Text));
            
        }
        private void SetCounter(int num)
        {
            var res = MessageBox.Show($"Are you sure you want to set the counter to {num}? \r\n This Action Cannot be undone !!",
                "Caution !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            int oldCounter = configuration.Counter; ;
            if (res == DialogResult.Yes)
            {
                configuration.Counter = num;
                configManager.Save();
                configuration =   configManager.GetConfiguration();
                MessageBox.Show($"Counter was reset it was :{oldCounter} now its {num}");
            }
           
        }
        private void txtNewCounterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
        }
        private void btnRestartService_Click(object sender, EventArgs e)
        {
            if (serviceController1.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
            {
                serviceController1.Stop();
            }
            
            SetServiceStatus();

            while (serviceController1.Status == System.ServiceProcess.ServiceControllerStatus.StopPending || serviceController1.Status == System.ServiceProcess.ServiceControllerStatus.Running)
            {
                Thread.Sleep(2000);
            }

            serviceController1.Start();
            SetServiceStatus();

        }
        private void SetServiceStatus()
        {
            lblServiceStatus.Text = serviceController1.Status.ToString();
        }
        private void btnStopService_Click(object sender, EventArgs e)
        {
            serviceController1.Refresh();
            if (serviceController1.Status == System.ServiceProcess.ServiceControllerStatus.Running)
            {
                serviceController1.Stop();
                serviceController1.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped);
            }
            serviceController1.Refresh();
            lblServiceStatus.Text = serviceController1.Status.ToString();
            
        }
        private void btnStartService_Click(object sender, EventArgs e)
        {
            serviceController1.Refresh();
            if (serviceController1.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
            {
                serviceController1.Start();
                serviceController1.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.StartPending);
                serviceController1.Refresh();
                lblServiceStatus.Text = serviceController1.Status.ToString();
                Thread.Sleep(3000);
                serviceController1.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);

            }
            serviceController1.Refresh();
            lblServiceStatus.Text = serviceController1.Status.ToString();
        }
        private void btnRestartService_Click_1(object sender, EventArgs e)
        {
            btnStopService_Click(null, null);
            Thread.Sleep(5000);
            btnStartService_Click(null, null);
        }
    }
}
