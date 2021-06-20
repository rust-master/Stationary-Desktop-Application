using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ResponsiveDesign
{
    public partial class LoginForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True");
        public LoginForm()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuCustomLabel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuCustomLabel5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
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
            else if (gunaComboBox1.Text == "")
            {
                error = "Account Type is not Selected";
                msgError(error);
            }
            if (!this.bTxtBoxEmail.Text.Contains('@') || !this.bTxtBoxEmail.Text.Contains('.') || !this.bTxtBoxEmail.Text.Contains("com"))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                checkAccType();
            }

            //this.Hide();
            //CircularSplashScreen circularProgressBar = new CircularSplashScreen();
            //circularProgressBar.Show();
        }

        private void msgError(string error)
        {
            MessageBox.Show(" " + error);
        }

        private void checkAccType()
        {
            if (gunaComboBox1.Text == "ADMIN")
            {
                MessageBox.Show("ADMIN Selected");

                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Admin_Login_Table WHERE Ad_Email='" + bTxtBoxEmail.Text + "' AND Password='" + bTxtBoxPass.Text + "'", con);
                /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    

                    /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                    new CircularSplashScreen(1).Show();

                    //new Alert("Login Success", AlertType.success).Show();
                    this.Hide();

                }
                else
                    MessageBox.Show("Invalid username or password");
            }
            else if (gunaComboBox1.Text == "EMPLOYEE")
            {
                MessageBox.Show("EMPLOYEE Selected");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Signup_Table WHERE Email='" + bTxtBoxEmail.Text + "' AND Password='" + bTxtBoxPass.Text + "'", con);
                /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                    new CircularSplashScreen(2).Show();
                    //new Alert("Login Success", AlertType.success).Show();
                    this.Hide();

                }
                else
                    MessageBox.Show("Invalid username or password");
            }
        }



        private void gunaImageCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            bTxtBoxPass.PasswordChar = gunaImageCheckBox1.Checked ? '\0' : '•';
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
            if (gunaComboBox1.Text == "")
            {
                String error = "Account Type is not Selected";
                msgError(error);
            }
            else
            {
                if (gunaComboBox1.Text == "ADMIN")
                {
                    this.Hide();
                    EmailVerify emailVerify = new EmailVerify(1);
                    emailVerify.Show();
                }
                else if (gunaComboBox1.Text == "EMPLOYEE")
                {
                    this.Hide();
                    EmailVerify emailVerify = new EmailVerify(2);
                    emailVerify.Show();
                }
            }


        }
    }
}
