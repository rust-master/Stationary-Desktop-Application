using CrystalDecisions.CrystalReports.Engine;
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
    public partial class CustomSale : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;
        public CustomSale()
        {
            InitializeComponent();
            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadRecord()
        {
            string date = DateTime.Today.ToString("MM-dd-yyyy");

            int i = 0;
            double _total = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();
            String query = "Select * from DailSaleView where Date between '" + gunaDateTimePicker1.Value + "' and '"+ gunaDateTimePicker2.Value+"'";
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

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            String Date1 = gunaDateTimePicker1.Value.ToString("MM-dd-yyyy");
            String Date2 = gunaDateTimePicker2.Value.ToString("MM-dd-yyyy");
            CustomSaleReport customSaleReport = new CustomSaleReport(Date1, Date2);
            customSaleReport.Show();
        }

        private void CustomSale_Load(object sender, EventArgs e)
        {

            LoadRecord();
        }

        private void gunaDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadRecord();
        }

        private void gunaDateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LoadRecord();
        }
    }
}
