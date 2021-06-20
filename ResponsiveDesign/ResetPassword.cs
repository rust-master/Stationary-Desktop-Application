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
    public partial class ResetPassword : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True");
        String em;
        int ctx;
        public ResetPassword(String em , int ctx)
        {
            InitializeComponent();
            this.em = em;
            this.ctx = ctx;
            label1.Text = em;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ResetPassword_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuCustomLabel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(bTxtPass.Text != txtConfrmPass.Text)
            {
                MessageBox.Show("Please Enter A Same Password", "Password Not Matched", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(bTxtPass.Text == "" || txtConfrmPass.Text == "")
            {
                MessageBox.Show("Please Enter the Password", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                updatePassWord();
            }
        }

        private void updatePassWord()
        {
            try
            {
                if (ctx == 1)
                {
                    con.Open();
                    String updateQuery = "Update Admin_Login_Table set Password = @Password where Ad_Email = '" + label1.Text + "'";
                    SqlCommand cmdup = new SqlCommand(updateQuery, con);

                    cmdup.Parameters.AddWithValue("@Password", txtConfrmPass.Text);


                    int i = cmdup.ExecuteNonQuery();
                    con.Close();
                    if (i != 0)
                    {
                        MessageBox.Show("Admin Password Change Successfully");
                        this.Hide();
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();

                    }
                    else
                    {
                        MessageBox.Show("Password not change. Please Try Again");
                    }
                }
                else if(ctx == 2)
                {
                    con.Open();
                    String updateQuery = "Update Signup_Table set Password = @Password where Email = '" + label1.Text + "'";
                    SqlCommand cmdup = new SqlCommand(updateQuery, con);

                    cmdup.Parameters.AddWithValue("@Password", txtConfrmPass.Text);


                    int i = cmdup.ExecuteNonQuery();
                    con.Close();
                    if (i != 0)
                    {
                        MessageBox.Show("Password Change Successfully");
                        this.Hide();
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();

                    }
                    else
                    {
                        MessageBox.Show("Password not change. Please Try Again");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
