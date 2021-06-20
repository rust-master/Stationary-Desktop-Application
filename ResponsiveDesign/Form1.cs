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
using Tulpep.NotificationWindow;

namespace ResponsiveDesign
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
            customizeDesign();

            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);
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
            playlistSubMenuPanel.Visible = false;
            toolsSubMenuPanel.Visible = false;

        }
        private void hideSubMenu()
        {
            if(mediaSubMenuPanel.Visible == true)
            {
                mediaSubMenuPanel.Visible = false;
            }
            if (playlistSubMenuPanel.Visible == true)
            {
                playlistSubMenuPanel.Visible = false;
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

        private void showActiveLabel(Button btnName)
        {
            if (btnName == btnDash)
            {
                btnName.BackColor = Color.Green;
                btnPlaylist.BackColor = Color.FromArgb(11, 7, 17);
                btnEqa.BackColor = Color.FromArgb(11, 7, 17);
                btnTools.BackColor = Color.FromArgb(11, 7, 17);
                btnLoginAdmin.BackColor = Color.FromArgb(11, 7, 17);
                btnLogout.BackColor = Color.FromArgb(11, 7, 17);
                btnEmployee.BackColor = Color.FromArgb(11, 7, 17);
                btnExpenditure.BackColor = Color.FromArgb(11, 7, 17);
                btnSettings.BackColor = Color.FromArgb(11, 7, 17);
                btnAbout.BackColor = Color.FromArgb(11, 7, 17);
                btnHelp.BackColor = Color.FromArgb(11, 7, 17);
            }
            else if(btnName == btnPlaylist)
            {
                btnName.BackColor = Color.Green;
                btnDash.BackColor = Color.FromArgb(11, 7, 17);
                btnEqa.BackColor = Color.FromArgb(11, 7, 17);
                btnTools.BackColor = Color.FromArgb(11, 7, 17);
                btnLoginAdmin.BackColor = Color.FromArgb(11, 7, 17);
                btnLogout.BackColor = Color.FromArgb(11, 7, 17);
                btnEmployee.BackColor = Color.FromArgb(11, 7, 17);
                btnExpenditure.BackColor = Color.FromArgb(11, 7, 17);
                btnSettings.BackColor = Color.FromArgb(11, 7, 17);
                btnAbout.BackColor = Color.FromArgb(11, 7, 17);
                btnHelp.BackColor = Color.FromArgb(11, 7, 17);
            }
            else if (btnName == btnEqa)
            {
                btnName.BackColor = Color.Green;
                btnDash.BackColor = Color.FromArgb(11, 7, 17);
                btnPlaylist.BackColor = Color.FromArgb(11, 7, 17);
                btnTools.BackColor = Color.FromArgb(11, 7, 17);
                btnLoginAdmin.BackColor = Color.FromArgb(11, 7, 17);
                btnLogout.BackColor = Color.FromArgb(11, 7, 17);
                btnEmployee.BackColor = Color.FromArgb(11, 7, 17);
                btnExpenditure.BackColor = Color.FromArgb(11, 7, 17);
                btnSettings.BackColor = Color.FromArgb(11, 7, 17);
                btnAbout.BackColor = Color.FromArgb(11, 7, 17);
                btnHelp.BackColor = Color.FromArgb(11, 7, 17);
            }
            else if (btnName == btnTools)
            {
                btnName.BackColor = Color.Green;
                btnPlaylist.BackColor = Color.FromArgb(11, 7, 17);
                btnEqa.BackColor = Color.FromArgb(11, 7, 17);
                btnDash.BackColor = Color.FromArgb(11, 7, 17);
                btnLoginAdmin.BackColor = Color.FromArgb(11, 7, 17);
                btnLogout.BackColor = Color.FromArgb(11, 7, 17);
                btnEmployee.BackColor = Color.FromArgb(11, 7, 17);
                btnExpenditure.BackColor = Color.FromArgb(11, 7, 17);
                btnSettings.BackColor = Color.FromArgb(11, 7, 17);
                btnAbout.BackColor = Color.FromArgb(11, 7, 17);
                btnHelp.BackColor = Color.FromArgb(11, 7, 17);
            }
            else if (btnName == btnLoginAdmin)
            {
                btnName.BackColor = Color.Green;
                btnPlaylist.BackColor = Color.FromArgb(11, 7, 17);
                btnEqa.BackColor = Color.FromArgb(11, 7, 17);
                btnDash.BackColor = Color.FromArgb(11, 7, 17);
                btnTools.BackColor = Color.FromArgb(11, 7, 17);
                btnLogout.BackColor = Color.FromArgb(11, 7, 17);
                btnEmployee.BackColor = Color.FromArgb(11, 7, 17);
                btnExpenditure.BackColor = Color.FromArgb(11, 7, 17);
                btnSettings.BackColor = Color.FromArgb(11, 7, 17);
                btnAbout.BackColor = Color.FromArgb(11, 7, 17);
                btnHelp.BackColor = Color.FromArgb(11, 7, 17);
            }
            else if (btnName == btnLogout)
            {
                btnName.BackColor = Color.Green;
                btnPlaylist.BackColor = Color.FromArgb(11, 7, 17);
                btnEqa.BackColor = Color.FromArgb(11, 7, 17);
                btnDash.BackColor = Color.FromArgb(11, 7, 17);
                btnTools.BackColor = Color.FromArgb(11, 7, 17);
                btnLoginAdmin.BackColor = Color.FromArgb(11, 7, 17);
                btnEmployee.BackColor = Color.FromArgb(11, 7, 17);
                btnExpenditure.BackColor = Color.FromArgb(11, 7, 17);
                btnSettings.BackColor = Color.FromArgb(11, 7, 17);
                btnAbout.BackColor = Color.FromArgb(11, 7, 17);
                btnHelp.BackColor = Color.FromArgb(11, 7, 17);
            }
            else if (btnName == btnEmployee)
            {
                btnName.BackColor = Color.Green;
                btnPlaylist.BackColor = Color.FromArgb(11, 7, 17);
                btnEqa.BackColor = Color.FromArgb(11, 7, 17);
                btnDash.BackColor = Color.FromArgb(11, 7, 17);
                btnTools.BackColor = Color.FromArgb(11, 7, 17);
                btnLogout.BackColor = Color.FromArgb(11, 7, 17);
                btnLoginAdmin.BackColor = Color.FromArgb(11, 7, 17);
                btnExpenditure.BackColor = Color.FromArgb(11, 7, 17);
                btnSettings.BackColor = Color.FromArgb(11, 7, 17);
                btnAbout.BackColor = Color.FromArgb(11, 7, 17);
                btnHelp.BackColor = Color.FromArgb(11, 7, 17);
            }
            else if (btnName == btnExpenditure)
            {
                btnName.BackColor = Color.Green;
                btnPlaylist.BackColor = Color.FromArgb(11, 7, 17);
                btnEqa.BackColor = Color.FromArgb(11, 7, 17);
                btnDash.BackColor = Color.FromArgb(11, 7, 17);
                btnTools.BackColor = Color.FromArgb(11, 7, 17);
                btnLogout.BackColor = Color.FromArgb(11, 7, 17);
                btnEmployee.BackColor = Color.FromArgb(11, 7, 17);
                btnLoginAdmin.BackColor = Color.FromArgb(11, 7, 17);
                btnSettings.BackColor = Color.FromArgb(11, 7, 17);
                btnAbout.BackColor = Color.FromArgb(11, 7, 17);
                btnHelp.BackColor = Color.FromArgb(11, 7, 17);
            }
            else if (btnName == btnSettings)
            {
                btnName.BackColor = Color.Green;
                btnPlaylist.BackColor = Color.FromArgb(11, 7, 17);
                btnEqa.BackColor = Color.FromArgb(11, 7, 17);
                btnDash.BackColor = Color.FromArgb(11, 7, 17);
                btnTools.BackColor = Color.FromArgb(11, 7, 17);
                btnLogout.BackColor = Color.FromArgb(11, 7, 17);
                btnEmployee.BackColor = Color.FromArgb(11, 7, 17);
                btnLoginAdmin.BackColor = Color.FromArgb(11, 7, 17);
                btnExpenditure.BackColor = Color.FromArgb(11, 7, 17);
                btnAbout.BackColor = Color.FromArgb(11, 7, 17);
                btnHelp.BackColor = Color.FromArgb(11, 7, 17);

            }
            else if (btnName == btnAbout)
            {
                btnName.BackColor = Color.Green;
                btnPlaylist.BackColor = Color.FromArgb(11, 7, 17);
                btnEqa.BackColor = Color.FromArgb(11, 7, 17);
                btnDash.BackColor = Color.FromArgb(11, 7, 17);
                btnTools.BackColor = Color.FromArgb(11, 7, 17);
                btnLogout.BackColor = Color.FromArgb(11, 7, 17);
                btnEmployee.BackColor = Color.FromArgb(11, 7, 17);
                btnLoginAdmin.BackColor = Color.FromArgb(11, 7, 17);
                btnExpenditure.BackColor = Color.FromArgb(11, 7, 17);
                btnSettings.BackColor = Color.FromArgb(11, 7, 17);
                btnHelp.BackColor = Color.FromArgb(11, 7, 17);
            }
            else if (btnName == btnHelp)
            {
                btnName.BackColor = Color.Green;
                btnPlaylist.BackColor = Color.FromArgb(11, 7, 17);
                btnEqa.BackColor = Color.FromArgb(11, 7, 17);
                btnDash.BackColor = Color.FromArgb(11, 7, 17);
                btnTools.BackColor = Color.FromArgb(11, 7, 17);
                btnLogout.BackColor = Color.FromArgb(11, 7, 17);
                btnEmployee.BackColor = Color.FromArgb(11, 7, 17);
                btnLoginAdmin.BackColor = Color.FromArgb(11, 7, 17);
                btnExpenditure.BackColor = Color.FromArgb(11, 7, 17);
                btnSettings.BackColor = Color.FromArgb(11, 7, 17);
                btnAbout.BackColor = Color.FromArgb(11, 7, 17);
            }
            else
            {
                btnName.BackColor = Color.FromArgb(11, 7, 17);
                btnPlaylist.BackColor = Color.FromArgb(11, 7, 17);
                btnEqa.BackColor = Color.FromArgb(11, 7, 17);
                btnDash.BackColor = Color.FromArgb(11, 7, 17);
                btnTools.BackColor = Color.FromArgb(11, 7, 17);
                btnLogout.BackColor = Color.FromArgb(11, 7, 17);
                btnLoginAdmin.BackColor = Color.FromArgb(11, 7, 17);
                btnExpenditure.BackColor = Color.FromArgb(11, 7, 17);
                btnSettings.BackColor = Color.FromArgb(11, 7, 17);
                btnAbout.BackColor = Color.FromArgb(11, 7, 17);
                btnHelp.BackColor = Color.FromArgb(11, 7, 17);
            }

        }
        #region 
        private void btnMedia_Click(object sender, EventArgs e)
        {
            showSubMenu(mediaSubMenuPanel);
            showActiveLabel(btnDash);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());
            // code here
            hideSubMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // code here
            openChildForm(new Brands());
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // code here
            openChildForm(new Products());
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // code here
            openChildForm(new Vendors());
            hideSubMenu();
        }
#endregion
        #region PlaylistSubMenu
        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            SaleByYearChart.DataSource = GetData();
            SaleByYearChart.Series["PurchaseYear"].XValueMember = "Year";

            SaleByYearChart.Series["PurchaseYear"].YValueMembers = "Sales"; // Sales as Purcashe correct it
            con.Close();
            showSubMenu(playlistSubMenuPanel);
            showActiveLabel(btnPlaylist);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openChildForm(new Purchase());
            // code here
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // code here
            openChildForm(new Stock());
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // code here
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // code here
            hideSubMenu();
        }
#endregion
        private void btnEqa_Click(object sender, EventArgs e)
        {
            // openChildForm(new BackupAndRestore());
            // code here
            GmailBackup gmailBackup = new GmailBackup();
            gmailBackup.Show();
            hideSubMenu();
            showActiveLabel(btnEqa);
        }
        #region ToolSubMenu
        private void btnTools_Click(object sender, EventArgs e)
        {
            showSubMenu(toolsSubMenuPanel);
            showActiveLabel(btnTools);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            openChildForm(new BackupAndRestore());
            // code here
            hideSubMenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openChildForm(new RestoreAndBackUp());
            // code here
            hideSubMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // code here
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // code here
            hideSubMenu();
        }
        #endregion
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // code here
            hideSubMenu();
            showActiveLabel(btnLoginAdmin);

            GOTOCHECKDSHPOS gOTOCHECKDSHPOS = new GOTOCHECKDSHPOS(this);
            gOTOCHECKDSHPOS.Show();

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
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

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelSideMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // code here
            //hideSubMenu();
            //showActiveLabel(btnLogout);
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);
            // chart2.Series["Salary"].Points.AddXY("Zaryab", 10000);
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();



            SaleByYearChart.DataSource = GetData();
            SaleByYearChart.Series["PurchaseYear"].XValueMember = "Year";

            SaleByYearChart.Series["PurchaseYear"].YValueMembers = "Sales"; // Sales as Purcashe correct it


            con.Close();
            int noOfProducts = getNoofProducts();
            lblProducts.Text = Convert.ToString(noOfProducts);

            int noOfVendor = getNoofVendor();
            lblVendor.Text = Convert.ToString(noOfVendor);

            int totalPurchase = getTotalPurchase();
            lblTotalPurchase.Text = Convert.ToString(totalPurchase);
            NotifyProductQuantity();

        }



        public void NotifyProductQuantity()
        {
            string critical = "";
            int i = 0;

            con.Open();
            String query = "SELECT Stock_Table.Stock_ID , Stock_Table.Pro_ID , Stock_Table.Quantity , ProdStatic_Table.Prod_Name  FROM Stock_Table INNER JOIN ProdStatic_Table ON Stock_Table.Pro_ID = ProdStatic_Table.Prod_ID where Quantity = '0'";
            command = new SqlCommand(query, con);
            dr = command.ExecuteReader();
            while(dr.Read())
            {
                i++;
                critical += i+". " + dr["Prod_Name"].ToString() + " | "+ dr["Quantity"].ToString() + Environment.NewLine;
            }


            PopupNotifier popup = new PopupNotifier();
            
            popup.TitleText = "CRITICAL ITEMS";
            popup.ContentText = critical;
            popup.Popup();

        }

        private int getNoofVendor()
        {
            con.Open();
            String selectQuery = "Select count(*) from Vendor_Table ";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }

        private DataTable GetData()
        {
            con.Close();
            con.Open();
            DataTable dtData = new DataTable();
            SqlCommand cmd = new SqlCommand("newPurcash", con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            dtData.Load(reader);
            return dtData;

        }

        private int getTotalPurchase()
        {

            con.Open();
            String selectQuery = "Select sum(Total_Bill) from Purchase_Tbl ";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }
        private int getNoofProducts()
        {

            con.Open();
            String selectQuery = "Select count(*) from ProdStatic_Table ";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // code here
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // code here
            hideSubMenu();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            openChildForm(new Employee());
            // code here
            hideSubMenu();
            showActiveLabel(btnEmployee);
        }

   

        private void btnExpenditure_Click(object sender, EventArgs e)
        {
            openChildForm(new Expenditures());
            hideSubMenu();
            showActiveLabel(btnExpenditure);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            showActiveLabel(btnSettings);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            openChildForm(new AccountControl());
            hideSubMenu();
            showActiveLabel(btnAbout);
        }

        private void btnHelp_Click_1(object sender, EventArgs e)
        {
            HelpEmployee help = new HelpEmployee();
            help.Show();
            hideSubMenu();
            showActiveLabel(btnHelp);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://web.facebook.com/Zaryab.Programmer");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/zaryab.programmer/");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DeveloperTeam developerTeam = new DeveloperTeam();
            developerTeam.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://micro-it-industry.firebaseapp.com/");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradient2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
