using ResponsiveDesign.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResponsiveDesign
{
    public partial class Employee : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True");

        //SqlCommand cmd;


        public Employee()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            openChildForm(new EmpSkills());
        }

        private void lblProfile_MouseLeave(object sender, EventArgs e)
        {
            lblProfile.ForeColor = Color.FromArgb(53, 183, 41);
        }

        private void lblProfile_MouseEnter(object sender, EventArgs e)
        {
            lblProfile.ForeColor = Color.FromArgb(255, 206, 68);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(255, 206, 68);
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.FromArgb(255, 206, 68);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(53, 183, 41);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.FromArgb(53, 183, 41);
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.FromArgb(255, 206, 68);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.FromArgb(53, 183, 41);
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.FromArgb(255, 206, 68);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.FromArgb(53, 183, 41);
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.FromArgb(255, 206, 68);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.FromArgb(53, 183, 41);
        }

        private void lblProfile_Click(object sender, EventArgs e)
        {
            openChildForm(new EmpProfile());
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

        private void label2_Click(object sender, EventArgs e)
        {
            openChildForm(new EmpAddress());
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            //con.Open();

            //cmd = new SqlCommand("select Profile_Image from Emp_Profile_Table where Emp_ID=1", con);

            //SqlDataAdapter da = new SqlDataAdapter(cmd);

            //DataSet ds = new DataSet();

            //da.Fill(ds);

            //if (ds.Tables[0].Rows.Count > 0)

            //{

            //    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Profile_Image"]);

            //    pictureBox1.Image = new Bitmap(ms);

            //}
        }

        private void label3_Click(object sender, EventArgs e)
        {
            openChildForm(new EmpEducation());
        }

        private void label5_Click(object sender, EventArgs e)
        {
            openChildForm(new EmpSalary());
        }

        private void label6_Click(object sender, EventArgs e)
        {
            openChildForm(new EmpDuty());
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            EmployeeReport employeeReport = new EmployeeReport();
            employeeReport.Show();

        }
    }
}
