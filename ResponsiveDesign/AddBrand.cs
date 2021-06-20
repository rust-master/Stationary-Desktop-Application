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
    public partial class AddBrand : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True");
        SqlDataAdapter dataAdapter;

        Brands brands;
        public AddBrand(Brands brands)
        {
            InitializeComponent();
            this.brands = brands;
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


        private void AddBrand_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);

            con.Open();
            String selectQuery = "Select Comp_Name from Company_Table";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Comp_Name", typeof(string));
            dataTable.Load(reader);
            comboBox1.ValueMember = "Comp_Name";
            comboBox1.DataSource = dataTable;
            con.Close();

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBrand_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void bunifuSaveBtn_Click(object sender, EventArgs e)
        {
            String errorMsg;


            if (texBoXBrandName.Text == "" && txtBoxBrandDesc.Text == "")
            {
                errorMsg = "All field are Empty";

                errorMessage(errorMsg);
            }
            else if (texBoXBrandName.Text == "")
            {
                errorMsg = "Brand Name is Empty. Please Fill Brand Name TextBox";
                errorMessage(errorMsg);
            }
            else if (txtBoxBrandDesc.Text == "")
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

                int ID = getCompID();

                MessageBox.Show("Name: " + comboBox1.SelectedValue.ToString() + "Date : " + date + " Time : " + time + " ID : " + ID);



                String queryInsert = "insert into Brand_Table(FK_Comp_ID,Brand_Name,Brand_Description,Date,Time) values('" + ID + "','" + texBoXBrandName.Text + "','" + txtBoxBrandDesc.Text + "', '" + date + "','" + time + "')";
                con.Open();

                dataAdapter = new SqlDataAdapter();
                dataAdapter.InsertCommand = new SqlCommand(queryInsert, con);
                int i = dataAdapter.InsertCommand.ExecuteNonQuery();
                con.Close();

                if (i != 0)
                {
                    MessageBox.Show("Data Save");



                    brands.LoadRecord();


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
        private int getCompID()
        {

            con.Open();
            String selectQuery = "Select Comp_ID from Company_Table where Comp_Name ='" + comboBox1.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }

        private void errorMessage(string errorMsg)
        {
            MessageBox.Show(" " + errorMsg);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to update this Brand?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               
                try
                {
                    int ID = getCompID();

                    con.Open();
                    String updateQuery = "Update Brand_Table set FK_Comp_ID = @FK_Comp_ID,  Brand_Name = @Brand_Name , Brand_Description = @Brand_Description  where Brand_ID like '" + label1.Text + "'";
                    SqlCommand cmdup = new SqlCommand(updateQuery, con);

                    cmdup.Parameters.AddWithValue("@FK_Comp_ID", ID);
                    cmdup.Parameters.AddWithValue("@Brand_Name", texBoXBrandName.Text);
                    cmdup.Parameters.AddWithValue("@Brand_Description", txtBoxBrandDesc.Text);

                    cmdup.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Brand has been Sucessfully updated.");
                    brands.LoadRecord();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Error" + ex);
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AddBrand_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void texBoXBrandName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
