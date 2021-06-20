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
    public partial class POSViewStock : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;
        public POSViewStock()
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
            String query = "SELECT Stock_Table.Stock_ID , Stock_Table.Pro_ID , Stock_Table.Quantity ,ProdStatic_Table.Prod_Name  FROM Stock_Table INNER JOIN ProdStatic_Table ON Stock_Table.Pro_ID = ProdStatic_Table.Prod_ID";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["Prod_Name"].ToString(), dataReader["Quantity"].ToString());
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
            StockViewChart stockViewChart = new StockViewChart();
            stockViewChart.Show();
        }

        private void bTxtBoxSearch_OnTextChange(object sender, EventArgs e)
        {
            int i = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();
            String query = "SELECT Stock_Table.Stock_ID , Stock_Table.Pro_ID , Stock_Table.Quantity ,ProdStatic_Table.Prod_Name  FROM Stock_Table INNER JOIN ProdStatic_Table ON Stock_Table.Pro_ID = ProdStatic_Table.Prod_ID where Prod_Name like '" + bTxtBoxSearch.text + "%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["Prod_Name"].ToString(), dataReader["Quantity"].ToString());
            }
            dataReader.Close();
            con.Close();
        }
    }
}
