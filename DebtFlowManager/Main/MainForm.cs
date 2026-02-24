using DebtFlowManager.About;
using DebtFlowManager.Analytics;
using DebtFlowManager.Customers;
using DebtFlowManager.Reports;
using DebtFlowManager.Settings;
using DebtFlowManager.Suppliers;
using DebtFlowManager.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DebtFlowManager.Main
{
    public partial class MainForm : Form
    {
        private bool isCollapsed = false;// this variable belong to btnHam Button

        public MainForm()
        {
            InitializeComponent();
        }

        

        

        private void btnHam_Click(object sender, EventArgs e)
        {
            isCollapsed = !isCollapsed;

            panelNavBar.Width = isCollapsed ? 70 : 200;
            ShowButtonText(!isCollapsed);
        }

        private void ShowButtonText(bool show)
        {
            btnMain.Text = show ? "Main" : "";
            btnSuppliers.Text = show ? "Suppliers" : "";
            btnCustomers.Text = show ? "Customers" : "";
            btnReports.Text = show ? "Reports" : "";
            btnAnalytics.Text = show ? "Analytics" : "";
            btnUsers.Text = show ? "Users" : "";
            btnSettings.Text = show ? "Settings" : "";
            btnAbout.Text = show ? "About" : "";
        }

        private void CollapseMenu(bool collapse)
        {
            panelNavBar.Width = collapse ? 70 : 220;

            foreach (Button btn in panelNavBar.Controls.OfType<Button>())
            {
                btn.Text = collapse ? "" : btn.Tag.ToString();
                btn.ImageAlign = collapse ? ContentAlignment.MiddleCenter
                                          : ContentAlignment.MiddleLeft;
                btn.TextAlign = ContentAlignment.MiddleRight;
            }
        }

        private void MoveIndicator(Button btn)
        {
            panelIndicator.Top = btn.Top;
            panelIndicator.Height = btn.Height;
        }

       

        private void btnMain_Click(object sender, EventArgs e)
        {
            UserControlHomePage page = new UserControlHomePage();
            LoadPage(page);
            MoveIndicator(btnMain);
        }


        private void LoadPage(UserControl Page)
        {
            try
            {
                panelContent.Controls.Clear();
                Page.Dock = DockStyle.Fill;
                panelContent.Controls.Add(Page);
            }
            catch { }
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            UserControlSuppliers page = new UserControlSuppliers();
            LoadPage(page);
            MoveIndicator(btnSuppliers);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            UserControlCustomers page = new UserControlCustomers();
            LoadPage(page);
            MoveIndicator(btnCustomers);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            UserControlReports page = new UserControlReports();
            LoadPage(page);
            MoveIndicator(btnReports);
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            UserControlAnalytics page = new UserControlAnalytics();
            LoadPage(page);
            MoveIndicator(btnAnalytics);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UserControlUsers page = new UserControlUsers();
            LoadPage(page);
            MoveIndicator(btnUsers);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            UserControlSettings page = new UserControlSettings();
            LoadPage(page);
            MoveIndicator(btnSettings);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            UserControlAbout page = new UserControlAbout();
            LoadPage(page);
            MoveIndicator(btnAbout);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnMain_Click(this, e);
        }





        //private void btnMiniMaxi_Click(object sender, EventArgs e)
        //{
        //    if (this.WindowState == FormWindowState.Maximized)
        //    {
        //        this.WindowState = FormWindowState.Normal;
        //        btnMiniMaxi.Image = Properties.Resources.maximize_32;   // شكل التكبير
        //    }
        //    else
        //    {
        //        this.WindowState = FormWindowState.Maximized;
        //        btnMiniMaxi.Image = Properties.Resources.minimize2_48; // شكل الرجوع
        //    }
        //}

        //private void btnMini_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Minimized;
        //}

        //private void btnExit_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}
    }
}
