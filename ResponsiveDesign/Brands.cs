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

    public partial class Brands : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;

        public Brands()
        {
            InitializeComponent();

            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);

            LoadRecord();

        }

        public void LoadRecord()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            con.Open();
            String query = "SELECT Brand_Table.Brand_ID , Brand_Table.Brand_Name , Brand_Table.Brand_Description , Brand_Table.Date , Brand_Table.Time , Company_Table.Comp_Name  FROM Brand_Table INNER JOIN Company_Table ON Brand_Table.FK_Comp_ID = Company_Table.Comp_ID";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dataReader["Brand_ID"].ToString(), dataReader["Comp_Name"].ToString(), dataReader["Brand_Name"].ToString(), dataReader["Brand_Description"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            AddBrand addBrand = new AddBrand(this);
            addBrand.bunifuFlatButton2.Enabled = false;
            addBrand.Show();
        }

        private void bTxtSearchBrand_OnTextChange(object sender, EventArgs e)
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            con.Open();
            String query = "SELECT Brand_Table.Brand_ID , Brand_Table.Brand_Name , Brand_Table.Brand_Description , Brand_Table.Date , Brand_Table.Time , Company_Table.Comp_Name  FROM Brand_Table INNER JOIN Company_Table ON Brand_Table.FK_Comp_ID = Company_Table.Comp_ID where Brand_Name like '" + bTxtSearchBrand.text + "%'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dR = cmd.ExecuteReader();
            while (dR.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dR["Brand_ID"].ToString(), dR["Comp_Name"].ToString(), dR["Brand_Name"].ToString(), dR["Brand_Description"].ToString(), Convert.ToDateTime(dR["Date"]).ToString("MM-dd-yyyy"), dR["Time"].ToString());
            }
            dR.Close();
            con.Close();
        }

        private void Brands_Load(object sender, EventArgs e)
        {
            con.Open();
            String selectQuery = "Select Comp_Name from Company_Table";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    bunifuDropdown1.AddItem(reader.GetString(0));
            //}
            //con.Close();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Comp_Name", typeof(string));
            dataTable.Load(reader);
            comboBox1.ValueMember = "Comp_Name";
            comboBox1.DataSource = dataTable;
            con.Close();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True");
            int i = 0;
            dataGridView1.Rows.Clear();
            conn.Open();
            String query = "SELECT Brand_Table.Brand_ID , Brand_Table.Brand_Name , Brand_Table.Brand_Description , Brand_Table.Date , Brand_Table.Time , Company_Table.Comp_Name  FROM Brand_Table INNER JOIN Company_Table ON Brand_Table.FK_Comp_ID = Company_Table.Comp_ID where Comp_Name like '" + comboBox1.SelectedValue.ToString() + "%'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dR = cmd.ExecuteReader();
            while (dR.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dR["Brand_ID"].ToString(), dR["Comp_Name"].ToString(), dR["Brand_Name"].ToString(), dR["Brand_Description"].ToString(), Convert.ToDateTime(dR["Date"]).ToString("MM-dd-yyyy"), dR["Time"].ToString());
            }
            dR.Close();
            conn.Close();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            LoadRecord();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AddBrand addBrand = new AddBrand(this);
            addBrand.bunifuSaveBtn.Enabled = false;
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                addBrand.label1.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                addBrand.texBoXBrandName.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                addBrand.txtBoxBrandDesc.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                addBrand.Show();
            }
            if (colName == "Delete")
            {


                int ID = Convert.ToInt32(dataGridView1[1, e.RowIndex].Value.ToString());
                if (MessageBox.Show("Are you sure want to Delete this Brand?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        String deleteQuery = "delete from Brand_Table where Brand_ID = @Brand_ID";
                        SqlCommand cmdup = new SqlCommand(deleteQuery, con);

                        cmdup.Parameters.AddWithValue("@Brand_ID", ID);
                        cmdup.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Brand has beenn Sucessfully Deleted.");
                        LoadRecord();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show("Error " + ex, "Error in Brand Form");
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            BrandsReport brandsReport = new BrandsReport();
            brandsReport.Show();
        }
    }
    
}
