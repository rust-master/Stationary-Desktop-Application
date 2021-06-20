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
    public partial class Stock : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;

        public Stock()
        {
            InitializeComponent();
            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);


            LoadRecord();
        }

        private void Stock_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            StockAddHandel stockAddHandel = new StockAddHandel(this);
            stockAddHandel.Show();
        }
        public void LoadRecord()
        {
            int i = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();
            String query = "SELECT Stock_Table.Stock_ID , Stock_Table.Pro_ID , Stock_Table.Quantity ,Stock_Table.StockInDate , Stock_Table.StockInBy ,ProdStatic_Table.Prod_Name  FROM Stock_Table INNER JOIN ProdStatic_Table ON Stock_Table.Pro_ID = ProdStatic_Table.Prod_ID";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["Stock_ID"].ToString(), dataReader["Prod_Name"].ToString(), dataReader["Pro_ID"].ToString(), dataReader["Quantity"].ToString(),  Convert.ToDateTime(dataReader["StockInDate"]).ToString("MM-dd-yyyy"), dataReader["StockInBy"].ToString());
            }
            dataReader.Close();
            con.Close();


        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            StockReport stockReport = new StockReport();
            stockReport.Show();
        }

        private void bTxtBoxSearch_OnTextChange(object sender, EventArgs e)
        {
            int i = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();
            String query = "SELECT Stock_Table.Stock_ID , Stock_Table.Pro_ID , Stock_Table.Quantity ,Stock_Table.StockInDate , Stock_Table.StockInBy ,ProdStatic_Table.Prod_Name  FROM Stock_Table INNER JOIN ProdStatic_Table ON Stock_Table.Pro_ID = ProdStatic_Table.Prod_ID where Prod_Name like '"+ bTxtBoxSearch.text + "%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["Stock_ID"].ToString(), dataReader["Prod_Name"].ToString(), dataReader["Pro_ID"].ToString(), dataReader["Quantity"].ToString(), Convert.ToDateTime(dataReader["StockInDate"]).ToString("MM-dd-yyyy"), dataReader["StockInBy"].ToString());
            }
            dataReader.Close();
            con.Close();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            StockViewChart stockViewChart = new StockViewChart();
            stockViewChart.Show();
        }
    }
}
