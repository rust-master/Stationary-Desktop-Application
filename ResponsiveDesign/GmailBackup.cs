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
using System.Net.Mail;

namespace ResponsiveDesign
{
    public partial class GmailBackup : Form
    {
        String senderEmail = "sharpprogrammer1@gmail.com";
        String senderPass = "Sharpbnm,./55";
        public GmailBackup()
        {
            InitializeComponent();
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

      

        private void GmailBackup_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);
        }

        private void GmailBackup_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void GmailBackup_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void btnattach_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtattachment.Text = openFileDialog1.FileName.ToString();
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try // Its a good practice to write your code in a try catch block 
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Connection Object
                MailMessage message = new MailMessage(); // Email Object
                message.From = new MailAddress(txtreciever.Text); // Sender Email
                message.To.Add(txtreciever.Text); // Reciever emailid
                message.Body = txtbody.Text; // Body of the email
                message.Subject = txtsubject.Text; // Subject of the email
                client.UseDefaultCredentials = false;
                client.EnableSsl = true; // Enabling secured Connection
                if (txtattachment.Text != null)
                {
                    message.Attachments.Add(new Attachment(txtattachment.Text)); //Adding attachment
                }
                client.Credentials = new System.Net.NetworkCredential(senderEmail, senderPass); // Setting Credential of gmail account
                Cursor.Current = Cursors.WaitCursor;
                client.Send(message); //Sending Email
                MessageBox.Show("Email Sent!)");
                Cursor.Current = Cursors.Default;
                message = null; // Free the memory
            }
            catch (Exception ex) // Catching if any error occurs
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
