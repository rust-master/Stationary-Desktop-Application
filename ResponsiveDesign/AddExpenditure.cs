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
    public partial class AddExpenditure : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True");
        SqlDataAdapter dataAdapter;

        Expenditures expenditures;
        public AddExpenditure(Expenditures expenditures)
        {
            InitializeComponent();
            this.expenditures = expenditures;
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


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            String errorMsg;


            if (texBoxExpenTitle.Text == "" && texBoxAmount.Text == "" && texBoxDesc.Text == "")
            {
                errorMsg = "All fields are Empty";
                errorMessage(errorMsg);
            }
            else if (texBoxExpenTitle.Text == "")
            {
                errorMsg = "Expense Title is Empty. Please Expense Title Degree TextBox";
                errorMessage(errorMsg);
            }
            else if (texBoxAmount.Text == "")
            {
                errorMsg = "Amount is Empty. Please Fill Amount TextBox";
                errorMessage(errorMsg);
            }
            else if (texBoxDesc.Text == "")
            {
                errorMsg = "Description is Empty. Please Fill Description TextBox";
                errorMessage(errorMsg);
            }
            else
            {
                InsertData();

            }
        }

        private void InsertData()
        {
            try
            {
                string date = DateTime.Today.ToString("MM-dd-yyyy");
                string time = DateTime.Now.ToString("HH:mm:ss");

          

                MessageBox.Show( "Date : " + date + " Time : " + time );



                String queryInsert = "insert into Exenditure_table(Exp_Title,Exp_Desc,Exp_Amount,Date,Time) values('" + texBoxExpenTitle.Text + "','" + texBoxDesc.Text + "', '" + texBoxAmount.Text + "', '" + date + "','" + time + "')";
                con.Open();

                dataAdapter = new SqlDataAdapter();
                dataAdapter.InsertCommand = new SqlCommand(queryInsert, con);
                int i = dataAdapter.InsertCommand.ExecuteNonQuery();
                con.Close();

                if (i != 0)
                {
                    MessageBox.Show("Data Save");
                    expenditures.LoadRecord();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error" + ex);
            }
        }


        private void errorMessage(string errorMsg)
        {
            MessageBox.Show(" " + errorMsg);
        }

        private void AddExpenditure_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);
        }

        private void AddExpenditure_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }


        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void AddExpenditure_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
