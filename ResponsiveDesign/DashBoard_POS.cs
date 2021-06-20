using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResponsiveDesign
{
    public partial class DashBoard_POS : Form
    {
        SqlConnection con;
        public DashBoard_POS()
        {
            InitializeComponent();
            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);

            customizeDesign();
        }

        [DllImport("user32.dll")]
        static extern bool AnimateWindow(IntPtr hWnd, int time, AnimateWindowFlags flags);

        [Flags]
        enum AnimateWindowFlags
        {
            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,
            AW_CENTER = 0x00000010,
            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void customizeDesign()
        {
            mediaSubMenuPanel.Visible = false;

            toolsSubMenuPanel.Visible = false;

        }

        private void hideSubMenu()
        {
            if (mediaSubMenuPanel.Visible == true)
            {
                mediaSubMenuPanel.Visible = false;
            }
            if (toolsSubMenuPanel.Visible == true)
            {
                toolsSubMenuPanel.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            showSubMenu(mediaSubMenuPanel);
           // showActiveLabel(btnDash);
        }

     

        private void btnTools_Click(object sender, EventArgs e)
        {
            showSubMenu(toolsSubMenuPanel);
            //showActiveLabel(btnTools);
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            openChildForm(new POSBILL());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new POSaddCustomers());
        }

        private void DashBoard_POS_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void DashBoard_POS_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);

            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();


            SaleByYearChart.DataSource = GetData();
            SaleByYearChart.Series["SaleYear"].XValueMember = "Year";

            SaleByYearChart.Series["SaleYear"].YValueMembers = "Sales";
            con.Close(); 
            int noOfCustomer =  getNoofCustomers();
            lblnoofCusotmer.Text = Convert.ToString(noOfCustomer);

            int totalSale = getTotalSale();
            lblTotalSale.Text = Convert.ToString(totalSale);


        }

        private int getTotalSale()
        {

            con.Open();
            String selectQuery = "Select sum(Net_Amount) from SaleMaster_Table ";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }

        private int getNoofCustomers()
        {
            
            con.Open();
            String selectQuery = "Select count(*) from CustomerTable ";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }


        private DataTable GetData()
        {
            con.Open();
            DataTable dtData = new DataTable();
            SqlCommand cmd = new SqlCommand("new", con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            dtData.Load(reader);
            return dtData;
           
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelChildForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelPlayer_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DeveloperTeam developerTeam = new DeveloperTeam();
            developerTeam.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://web.facebook.com/Zaryab.Programmer");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/zaryab.programmer/");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }

        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            EmployeeToAdmin employeeToAdmin = new EmployeeToAdmin(this);
            employeeToAdmin.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            openChildForm(new DailySale());
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpEmployee help = new HelpEmployee();
            help.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomSale());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new POSViewStock());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            GmailBackup gmailBackup = new GmailBackup();
            gmailBackup.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://micro-it-industry.firebaseapp.com/");
        }
    }
}
