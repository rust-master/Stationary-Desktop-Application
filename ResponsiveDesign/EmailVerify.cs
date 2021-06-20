using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace ResponsiveDesign
{
    public partial class EmailVerify : Form
    {
        string randomCode;
        public static string to;
        int ctx;
        public EmailVerify(int ctx)
        {
            InitializeComponent();
            this.ctx = ctx;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(!this.bTxtBoxEmail.Text.Contains('@') || !this.bTxtBoxEmail.Text.Contains('.') || !this.bTxtBoxEmail.Text.Contains("com"))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string from, pass, messageBody;
                Random rand = new Random();
                randomCode = (rand.Next(999999)).ToString();
                MailMessage message = new MailMessage();
                to = (bTxtBoxEmail.Text).ToString();
                from = "sharpprogrammer1@gmail.com";
                pass = "Sharpbnm,./55";
                messageBody = "Your reset code is " + randomCode;
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messageBody;
                message.Subject = "Password Reseting Code by Micro IT Industry";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("Code Send Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (randomCode == (txtVerCode.Text).ToString())
            {
                to = bTxtBoxEmail.Text;
                ResetPassword rp = new ResetPassword(to , ctx);
                this.Hide();
                rp.Show();
                //MessageBox.Show("Right code");
            }
            else
            {
                MessageBox.Show("Wrong code");
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EmailVerify_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
