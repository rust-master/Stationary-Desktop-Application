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
    public partial class POSaddupCustomer : Form
    {
        SqlConnection con;
        SqlDataAdapter dataAdapter;

        POSaddCustomers POSadd;
        public POSaddupCustomer(POSaddCustomers POSadd)
        {
            InitializeComponent();
            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);

            this.POSadd = POSadd;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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


        private void texBoxExpenTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void texBoxDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void texBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            String errorMsg;
            String cheeckName = CheckCustomerShop();

            if (texBoxShop.Text == "" && texBoxPerNm.Text == "" && texBoxCity.Text == "" && txtboxAddress.Text == "" )
            {
                errorMsg = "All field are Empty";

                errorMessage(errorMsg);
            }
            else if (texBoxShop.Text == "")
            {
                errorMsg = "Shop Name is Empty. Please Fill Shop Name TextBox";
                errorMessage(errorMsg);
            }
            else if (texBoxPerNm.Text == "")
            {
                errorMsg = "Person Name is Empty. Please Fill Person Name TextBox";
                errorMessage(errorMsg);
            }
            else if (texBoxCity.Text == "")
            {
                errorMsg = "City No is Empty. Please Fill City TextBox";
                errorMessage(errorMsg);
            }
            else if (txtboxAddress.Text == "")
            {
                errorMsg = "Address is Empty. Please Fill Address TextBox";
                errorMessage(errorMsg);
            }
            else
            {
              
                InsertData();

            }
        }

        private void errorMessage(string errorMsg)
        {
            MessageBox.Show(" " + errorMsg);
        }

        private void InsertData()
        {
            try
            {
                
                string date = DateTime.Today.ToString("MM-dd-yyyy");
                string time = DateTime.Now.ToString("HH:mm:ss");
               

                MessageBox.Show("" + date + "Time" + time);

                String queryInsert = "insert into CustomerTable(Cust_Shop_Name,Cust_Name,Cust_City,Cust_Address,Date,Time) values('" + texBoxShop.Text + "','" + texBoxPerNm.Text + "','" + texBoxCity.Text + "','" + txtboxAddress.Text +  "', '" + date + "','" + time + "')";
                con.Open();

                dataAdapter = new SqlDataAdapter();
                dataAdapter.InsertCommand = new SqlCommand(queryInsert, con);
                int i = dataAdapter.InsertCommand.ExecuteNonQuery();
                con.Close();

                if (i != 0)
                {
                    MessageBox.Show("Data Save");
                    POSadd.LoadRecord();
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

        private string CheckCustomerShop()
        {
            return "S";
        }

        private void POSaddupCustomer_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);
        }

        private void POSaddupCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void POSaddupCustomer_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void texBoxCity_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtboxAddress_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
