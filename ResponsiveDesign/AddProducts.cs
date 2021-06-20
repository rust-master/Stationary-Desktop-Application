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
    public partial class AddProducts : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True");
        SqlDataAdapter dataAdapter;

        Products products;
        public AddProducts(Products products)
        {
            InitializeComponent();
            this.products = products;
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

        private void AddProducts_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);
            con.Open();
            String selectQuery = "Select Brand_Name from Brand_Table";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Brand_Name", typeof(string));
            dataTable.Load(reader);
            comboBox1.ValueMember = "Brand_Name";
            comboBox1.DataSource = dataTable;
            con.Close();
        }

        private void bunifuSaveBtn_Click(object sender, EventArgs e)
        {
            String errorMsg;


            if (texBoXProdName.Text == "" && texboxProType.Text == "" && txtBoxProPrice.Text == "" && txtBoxProSalePrice.Text == ""  && txtBoxProDesc.Text == "")
            {
                errorMsg = "All field are Empty";

                errorMessage(errorMsg);
            }
            else if (texBoXProdName.Text == "")
            {
                errorMsg = "Product Name is Empty. Please Fill Product Name TextBox";
                errorMessage(errorMsg);
            }
            else if (texboxProType.Text == "")
            {
                errorMsg = "Type is Empty. Please Fill Type TextBox";
                errorMessage(errorMsg);
            }
            else if (txtBoxProPrice.Text == "")
            {
                errorMsg = "Price is Empty. Please Fill Price TextBox";
                errorMessage(errorMsg);
            }
            else if (txtBoxProSalePrice.Text == "")
            {
                errorMsg = "Sale Price is Empty. Please Fill Sale Price TextBox";
                errorMessage(errorMsg);
            }
            else if (txtBoxProDesc.Text == "")
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

                int ID = getBrandID();

                MessageBox.Show("Name: " + comboBox1.SelectedValue.ToString() + "Date : " + date + " Time : " + time + " ID : " + ID);



                String queryInsert = "insert into ProdStatic_Table(FK_Brand_ID,Prod_Name,Prod_Description,Prod_Type,Price,Sale_Price,Date,Time) values('" + ID + "','" + texBoXProdName.Text + "','" + txtBoxProDesc.Text + "','" + texboxProType.Text + "', '" + txtBoxProPrice.Text + "', '" + txtBoxProSalePrice.Text + "', '" + date + "','" + time + "')";
                con.Open();

                dataAdapter = new SqlDataAdapter();
                dataAdapter.InsertCommand = new SqlCommand(queryInsert, con);
                int i = dataAdapter.InsertCommand.ExecuteNonQuery();
                con.Close();

                if (i != 0)
                {
                    MessageBox.Show("Data Save");



                    products.LoadRecord();


                }
                else
                {
                    MessageBox.Show("Error");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error : " + e);
            }
        }

        private int getBrandID()
        {
            con.Open();
            String selectQuery = "Select Brand_ID from Brand_Table where Brand_Name ='" + comboBox1.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }

        private void errorMessage(string errorMsg)
        {
            MessageBox.Show(" " + errorMsg);
        }

        private void AddProducts_FormClosing(object sender, FormClosingEventArgs e)
        {

            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AddProducts_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to update this Product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int ID = getBrandID();

                try
                {


                    con.Open();
                    String updateQuery = "Update ProdStatic_Table set FK_Brand_ID = @FK_Brand_ID,  Prod_Name = @Prod_Name , Prod_Description = @Prod_Description ,  Prod_Type = @Prod_Type ,Price = @Price , Sale_Price = @Sale_Price  where Prod_ID like '" + label1.Text + "'";
                    SqlCommand cmdup = new SqlCommand(updateQuery, con);

                    cmdup.Parameters.AddWithValue("@FK_Brand_ID", ID);
                    cmdup.Parameters.AddWithValue("@Prod_Name", texBoXProdName.Text);
                    cmdup.Parameters.AddWithValue("@Prod_Description", txtBoxProDesc.Text);
                    cmdup.Parameters.AddWithValue("@Prod_Type", texboxProType.Text);
                    cmdup.Parameters.AddWithValue("@Price", txtBoxProPrice.Text);
                    cmdup.Parameters.AddWithValue("@Sale_Price", txtBoxProSalePrice.Text);

                    cmdup.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been Sucessfully updated.");
                    products.LoadRecord();
            }
                catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error : " + ex);
            }
        }
        }

        private void txtBoxProPrice_OnValueChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxProPrice.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtBoxProPrice.Text = txtBoxProPrice.Text.Remove(txtBoxProPrice.Text.Length - 1);
            }
        }

        private void txtBoxProSalePrice_OnValueChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxProSalePrice.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtBoxProSalePrice.Text = txtBoxProSalePrice.Text.Remove(txtBoxProSalePrice.Text.Length - 1);
            }
        }
    }
}
