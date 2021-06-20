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
    public partial class POSaddCustomers : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;

        public POSaddCustomers()
        {
            InitializeComponent();

            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);

            LoadRecord();
        }


        public void LoadRecord()
        {
            int i = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();
            String query = "Select * from CustomerTable";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["Cust_ID"].ToString(), dataReader["Cust_Shop_Name"].ToString(), dataReader["Cust_Name"].ToString(), dataReader["Cust_City"].ToString(), dataReader["Cust_Address"].ToString(),  Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            POSaddupCustomer pOSaddup = new POSaddupCustomer(this);
            pOSaddup.Show();
        }

        private void bTxtBoxSearch_OnTextChange(object sender, EventArgs e)
        {

            int i = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();
            String query = "Select * from CustomerTable where Cust_Shop_Name like '" + bTxtBoxSearch.text + "%' or Cust_Name like '" + bTxtBoxSearch.text + "%' or Cust_City like '"+ bTxtBoxSearch.text + "%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["Cust_ID"].ToString(), dataReader["Cust_Shop_Name"].ToString(), dataReader["Cust_Name"].ToString(), dataReader["Cust_City"].ToString(), dataReader["Cust_Address"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }
    }
}
