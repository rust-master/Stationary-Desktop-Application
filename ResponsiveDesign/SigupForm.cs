using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ResponsiveDesign
{
    public partial class SigupForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True");
        SqlDataReader dr;
        SqlDataAdapter dataAdapter;

        AccountControl accountControl;
        public SigupForm(AccountControl accountControl)
        {
            InitializeComponent();
            this.accountControl = accountControl;
       
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


        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            String checkEmail = checkEmpEmail();

            if(bTxtBoxEmail.text == "" && bTxtBoxPass.text == "" && bTxtBoxConfirmPass.text == "" && bTxtBoxPhoneNo.text == "" && bTxtBoxAddress.text == "" && bTxtBoxCity.text == "")
            {
                labelError.Text = "All field are Empty";
            }
            else if( bTxtBoxEmail.text == "" )
            {
                labelError.Text = "Email is Empty";
            }
            else if (bTxtBoxPass.text == "")
            {
                labelError.Text = "Password is Empty";
            }
            else if (bTxtBoxConfirmPass.text == "")
            {
                labelError.Text = "Confirm Password is Empty";
            }
            else if (bTxtBoxConfirmPass.text != bTxtBoxPass.text )
            {
                labelError.Text = "Password Not Mached";
            }
            else if (bTxtBoxPhoneNo.text == "")
            {
                labelError.Text = "Phone Number is Empty";
            }
            else if (bTxtBoxAddress.text == "")
            {
                labelError.Text = "Address is Empty";
            }
            else if (bTxtBoxCity.text == "")
            {
                labelError.Text = "City is Empty";
            }
            else if(!cheAccept.Checked)
            {
                labelError.Text = "Accept Term and Conditions";
            }
            else if (checkEmail == bTxtBoxEmail.text)
            {
                MessageBox.Show("Account is already Created", "Account Module", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                registerData();



            }
        }

        private string checkEmpEmail()
        {
            con.Open();
            String selectQuery = "Select Email from Signup_Table where Email ='" + bTxtBoxEmail.text + "'";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            String comp_Name = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return comp_Name;
        }

        private int getEmpID()
        {

            con.Open();
            String selectQuery = "Select Emp_ID from EmpLogView where Emp_Name ='" + gunaComboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }
        private void registerData()
        {

            try
            {

                int id = getEmpID();

                string date = DateTime.Today.ToString("MM-dd-yyyy");
                string time = DateTime.Now.ToString("HH:mm:ss");



                con.Open();
                String queryInsert = "insert into Signup_Table(Email,Password,Date,Time,FK_Emp_ID) values('" + bTxtBoxEmail.text + "','" + bTxtBoxPass.text + "', '" + date + "', '" + time + "','" + id + "')";
               

                dataAdapter = new SqlDataAdapter();
                dataAdapter.InsertCommand = new SqlCommand(queryInsert, con);
                int i = dataAdapter.InsertCommand.ExecuteNonQuery();
                con.Close();

     
                if (i != 0)
                {

                    accountControl.LoadRecord();
                    new Alert("Account Creating Successfuly", AlertType.success).Show();
                    this.Hide(); 

                }
                else
                {
                    MessageBox.Show("Error");

                }
            }
            catch(Exception e)
            {
                con.Close();
                MessageBox.Show("Error" + e);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void SigupForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuTextbox3_OnTextChange(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox2_OnTextChange(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login");
        }

        private void SigupForm_Load(object sender, EventArgs e)
        {
         
            con.Open();
            String selectQuery = "Select Emp_Name from EmpLogView";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Emp_Name", typeof(string));
            dataTable.Load(reader);
            gunaComboBox1.ValueMember = "Emp_Name";
            gunaComboBox1.DataSource = dataTable;
            con.Close();
        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void SigupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void bunifuCustomLabel12_Click(object sender, EventArgs e)
        {

        }

        private void bTxtBoxCity_OnTextChange(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            con.Open();
            string str = "select * from EmpLogView where Emp_Name='" + gunaComboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                bTxtBoxEmail.text = dr["Email"].ToString();
                bTxtBoxPhoneNo.text = dr["WhatsApp"].ToString();
                bTxtBoxAddress.text = dr["Address"].ToString();
                bTxtBoxCity.text = dr["City"].ToString();
            }
            dr.Close();



            con.Close();
        }
    }
}
