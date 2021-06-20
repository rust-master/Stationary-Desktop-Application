using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResponsiveDesign
{
    public partial class AddVendor : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True");
        SqlDataAdapter dataAdapter;
        Vendors vendors;
        public AddVendor(Vendors vendors)
        {
            InitializeComponent();
            this.vendors = vendors;

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
        private void bunifuSaveBtn_Click(object sender, EventArgs e)
        {
            String errorMsg;


            if (texBoxVendorName.Text == "" && texboxPerName.Text == "" && txtBoxEmailID.Text == "" && txtBoxWhatsAppNo.Text == "" && txtBoxAddress.Text == "")
            {
                errorMsg = "All field are Empty";

                errorMessage(errorMsg);
            }
            else if (texBoxVendorName.Text == "")
            {
                errorMsg = "Vendor Name is Empty. Please Fill Vendor Name TextBox";
                errorMessage(errorMsg);
            }
            else if (texboxPerName.Text == "")
            {
                errorMsg = "Person Name is Empty. Please Fill Person Name TextBox";
                errorMessage(errorMsg);
            }
            else if (txtBoxEmailID.Text == "")
            {
                errorMsg = "Email ID is Empty. Please Fill Email ID TextBox";
                errorMessage(errorMsg);
            }
            else if (txtBoxWhatsAppNo.Text == "")
            {
                errorMsg = "WhatsApp No is Empty. Please Fill WhatsApp No TextBox";
                errorMessage(errorMsg);
            }
            else if (txtBoxAddress.Text == "")
            {
                errorMsg = "Address is Empty. Please Fill Address TextBox";
                errorMessage(errorMsg);
            }
            else if (!this.txtBoxEmailID.Text.Contains('@') || !this.txtBoxEmailID.Text.Contains('.') || !this.txtBoxEmailID.Text.Contains("com"))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //bool b = IsValidEmail(txtBoxEmailID.Text);
                //if (b)
                //{
                    InsertData();
               // }
                //else
                //{
                //    MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }

           
        }
        //public bool IsValidEmail(string addy)
        //{
        //    try
        //    {
        //        MailAddress test = new MailAddress(addy);
        //        return true;
        //    }
        //    catch (Exception) { return false; }
        //}

        private void InsertData()
        {
            try
            {
                string date = DateTime.Today.ToString("MM-dd-yyyy");
                string time = DateTime.Now.ToString("HH:mm:ss");

              

                MessageBox.Show("Date : " + date + " Time : " + time );



                String queryInsert = "insert into Vendor_Table(Vendor_Comp_Name,Contact_Person_Name,Email,WhatsApp_No,Address,Date,Time) values('" + texBoxVendorName.Text + "','" + texboxPerName.Text + "','" + txtBoxEmailID.Text + "','" + txtBoxWhatsAppNo.Text + "', '" + txtBoxAddress.Text + "', '" + date + "','" + time + "')";
                con.Open();

                dataAdapter = new SqlDataAdapter();
                dataAdapter.InsertCommand = new SqlCommand(queryInsert, con);
                int i = dataAdapter.InsertCommand.ExecuteNonQuery();
                con.Close();

                if (i != 0)
                {
                    MessageBox.Show("Data Save");
                    vendors.LoadRecord();

                }
                else
                {
                    MessageBox.Show("Error");
                }

            }
            catch (Exception e)
            {
                con.Close();
                MessageBox.Show("Error : " + e);
            }

        }
        private void errorMessage(string errorMsg)
        {
            MessageBox.Show(" " + errorMsg);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to update this Vendor?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    String updateQuery = "Update Vendor_Table set Vendor_Comp_Name = @Vendor_Comp_Name , Contact_Person_Name = @Contact_Person_Name ,Email = @Email , WhatsApp_No = @WhatsApp_No , Address = @Address  where Vendor_ID like '" + label1.Text + "'";
                    SqlCommand cmdup = new SqlCommand(updateQuery, con);

                    cmdup.Parameters.AddWithValue("@Vendor_Comp_Name", texBoxVendorName.Text);
                    cmdup.Parameters.AddWithValue("@Contact_Person_Name", texboxPerName.Text);
                    cmdup.Parameters.AddWithValue("@Email", txtBoxEmailID.Text);
                    cmdup.Parameters.AddWithValue("@WhatsApp_No", txtBoxWhatsAppNo.Text);
                    cmdup.Parameters.AddWithValue("@Address", txtBoxAddress.Text);

                    cmdup.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Company has been Sucessfully updated.");
                    vendors.LoadRecord();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Error" + ex);
                }

            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddVendor_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);
        }

        private void AddVendor_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void bunifuSaveBtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuSaveBtn_Click(sender , e);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AddVendor_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtBoxWhatsAppNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {

            }
            else if (e.KeyChar == 8)
            {

            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57))
            {
                e.Handled = true;

            }
        }

        private void texBoxVendorName_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
