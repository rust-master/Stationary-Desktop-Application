using ResponsiveDesign.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResponsiveDesign
{
    public partial class Products : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;
        public Products()
        {
            InitializeComponent();

            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);

            LoadRecord();
        }
        public void LoadRecord()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                con.Open();
                String query = "SELECT ProdStatic_Table.Prod_ID , ProdStatic_Table.Prod_Name , ProdStatic_Table.Prod_Description , ProdStatic_Table.Prod_Type, ProdStatic_Table.Price ,ProdStatic_Table.Sale_Price, ProdStatic_Table.Date , ProdStatic_Table.Time , Brand_Table.Brand_Name  FROM ProdStatic_Table INNER JOIN Brand_Table ON ProdStatic_Table.FK_Brand_ID = Brand_Table.Brand_ID";
                command = new SqlCommand(query, con);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    i += 1;
                    dataGridView1.Rows.Add(i, dataReader["Prod_ID"].ToString(), dataReader["Brand_Name"].ToString(), dataReader["Prod_Name"].ToString(), dataReader["Prod_Description"].ToString(), dataReader["Prod_Type"].ToString(), dataReader["Price"].ToString(), dataReader["Sale_Price"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
                }
                dataReader.Close();
                con.Close();
           }
           catch(Exception ex)
           {
                con.Close();
                MessageBox.Show("Notication of Error " + ex);
           }


       }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            AddProducts addProducts = new AddProducts(this);
            addProducts.bunifuFlatButton2.Enabled = false;
            addProducts.Show();
        }

        private void bTxtSearchBrand_OnTextChange(object sender, EventArgs e)
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            con.Open();
            String query = "SELECT ProdStatic_Table.Prod_ID , ProdStatic_Table.Prod_Name , ProdStatic_Table.Prod_Description , ProdStatic_Table.Prod_Type, ProdStatic_Table.Price, ProdStatic_Table.Sale_Price , ProdStatic_Table.Date , ProdStatic_Table.Time , Brand_Table.Brand_Name  FROM ProdStatic_Table INNER JOIN Brand_Table ON ProdStatic_Table.FK_Brand_ID = Brand_Table.Brand_ID where Prod_Name like '" + bTxtSearchBrand.text + "%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dataReader["Prod_ID"].ToString(), dataReader["Brand_Name"].ToString(), dataReader["Prod_Name"].ToString(), dataReader["Prod_Description"].ToString(), dataReader["Prod_Type"].ToString(), dataReader["Price"].ToString(), dataReader["Sale_Price"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AddProducts addProducts = new AddProducts(this);
            addProducts.bunifuSaveBtn.Enabled = false;
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                addProducts.label1.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                addProducts.texBoXProdName.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                addProducts.txtBoxProDesc.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                addProducts.texboxProType.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                addProducts.txtBoxProPrice.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                addProducts.txtBoxProSalePrice.Text = dataGridView1[7, e.RowIndex].Value.ToString();
                addProducts.Show();
            }

            if (colName == "Delete")
            {


                int ID = Convert.ToInt32(dataGridView1[1, e.RowIndex].Value.ToString());
                if (MessageBox.Show("Are you sure want to Delete this Product?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        String deleteQuery = "delete from ProdStatic_Table where Prod_ID = @Prod_ID";
                        SqlCommand cmdup = new SqlCommand(deleteQuery, con);

                        cmdup.Parameters.AddWithValue("@Prod_ID", ID);
                        cmdup.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Product has beenn Sucessfully Deleted.");
                        LoadRecord();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show("Error " + ex, "Error in Product Form");
                    }
                }
            }
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            ProductsReport productsReport = new ProductsReport();
            productsReport.Show();
        }

        private void Products_Load(object sender, EventArgs e)
        {
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

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

            int i = 0;
            dataGridView1.Rows.Clear();
            con.Open();
            String query = "SELECT ProdStatic_Table.Prod_ID , ProdStatic_Table.Prod_Name , ProdStatic_Table.Prod_Description , ProdStatic_Table.Prod_Type, ProdStatic_Table.Price, ProdStatic_Table.Sale_Price , ProdStatic_Table.Date , ProdStatic_Table.Time , Brand_Table.Brand_Name  FROM ProdStatic_Table INNER JOIN Brand_Table ON ProdStatic_Table.FK_Brand_ID = Brand_Table.Brand_ID where Brand_Name like '" + comboBox1.SelectedValue.ToString() + "%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dataReader["Prod_ID"].ToString(), dataReader["Brand_Name"].ToString(), dataReader["Prod_Name"].ToString(), dataReader["Prod_Description"].ToString(), dataReader["Prod_Type"].ToString(), dataReader["Price"].ToString(), dataReader["Sale_Price"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            LoadRecord();
        }
    }
}
