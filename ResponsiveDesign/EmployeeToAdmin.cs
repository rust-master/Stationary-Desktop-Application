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
    public partial class EmployeeToAdmin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True");
        DashBoard_POS dash;
        public EmployeeToAdmin(DashBoard_POS dash)
        {
            InitializeComponent();
            this.dash = dash;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

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


        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaImageCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            bTxtBoxPass.PasswordChar = gunaImageCheckBox1.Checked ? '\0' : '•';
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void checkAccType()
        {

            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Admin_Login_Table WHERE Ad_Email='" + bTxtBoxEmail.Text + "' AND Password='" + bTxtBoxPass.Text + "'", con);
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                new CircularSplashScreen(1).Show();
                //new Alert("Login Success", AlertType.success).Show();
                dash.Hide();
                this.Hide();

            }
            else
                MessageBox.Show("Invalid username or password");
        }

        private void msgError(string error)
        {
            MessageBox.Show(" " + error);
        }

        private void EmployeeToAdmin_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);
        }

        private void EmployeeToAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void gunaGradient2Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            String error;
            if (bTxtBoxEmail.Text == "" && bTxtBoxPass.Text == "")
            {
                error = "All Fields are Empty";
                msgError(error);
            }
            else if (bTxtBoxEmail.Text == "")
            {
                error = "Email is Empty";
                msgError(error);
            }
            else if (bTxtBoxPass.Text == "")
            {
                error = "Password is Empty";
                msgError(error);
            }
            else
            {
                checkAccType();
            }
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
