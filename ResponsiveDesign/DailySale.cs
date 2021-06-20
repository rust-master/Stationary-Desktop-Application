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
    public partial class DailySale : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;
        public DailySale()
        {
            InitializeComponent();
            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);

            LoadRecord();
        }

        public void LoadRecord()
        {
            string date = DateTime.Today.ToString("MM-dd-yyyy");

            int i = 0;
            double _total = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();
            String query = "Select * from DailSaleView where Date = '" + date + "'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                _total += double.Parse(dataReader["Total_Price"].ToString());
                gunaDataGridView1.Rows.Add(i, dataReader["Prod_Name"].ToString(), dataReader["Sale_Price"].ToString(), dataReader["Quantity"].ToString(), dataReader["Total_Price"].ToString());
            }
            dataReader.Close();
            con.Close();
            label7.Text = _total.ToString("0.00");

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bTxtBoxSearch_OnTextChange(object sender, EventArgs e)
        {
            string date = DateTime.Today.ToString("MM-dd-yyyy");

            int i = 0;
        
            gunaDataGridView1.Rows.Clear();
            con.Open();
            String query = "Select * from DailSaleView where Date = '" +date + "' and Prod_Name like '" + bTxtBoxSearch.text + "%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
           
                gunaDataGridView1.Rows.Add(i, dataReader["Prod_Name"].ToString(), dataReader["Sale_Price"].ToString(), dataReader["Quantity"].ToString(), dataReader["Total_Price"].ToString());
            }
            dataReader.Close();
            con.Close();
          

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            DailySaleReport dailySaleReport = new DailySaleReport();
            dailySaleReport.Show();
        }
    }
}
