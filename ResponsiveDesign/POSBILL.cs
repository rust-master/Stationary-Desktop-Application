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
    public partial class POSBILL : Form
    {

        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;

        public POSBILL()
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
            String query = "SELECT SaleMaster_Table.SaleMaster_ID , SaleMaster_Table.Net_Total , SaleMaster_Table.Discount , SaleMaster_Table.Net_Amount , SaleMaster_Table.Paid_Amount , SaleMaster_Table.Remaining_Balance , SaleMaster_Table.Date ,  SaleMaster_Table.Time , CustomerTable.Cust_Shop_Name  FROM SaleMaster_Table INNER JOIN CustomerTable ON SaleMaster_Table.FK_Cust_ID = CustomerTable.Cust_ID";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["SaleMaster_ID"].ToString(), dataReader["Cust_Shop_Name"].ToString(), dataReader["Net_Total"].ToString(), dataReader["Discount"].ToString(), dataReader["Net_Amount"].ToString(), dataReader["Paid_Amount"].ToString(), dataReader["Remaining_Balance"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();


        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            NEWBILLPOS nEWBILLPOS = new NEWBILLPOS(this);
            nEWBILLPOS.Show();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PosSaleDetail posSaleDetail = new PosSaleDetail();

            string colName = gunaDataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "View")
            {
                posSaleDetail.label1.Text = gunaDataGridView1[1, e.RowIndex].Value.ToString();

                posSaleDetail.Show();
            }
            if (colName == "Printer")
            {
               
                int id = int.Parse(gunaDataGridView1[1, e.RowIndex].Value.ToString());
                NewBillReport newBillReport = new NewBillReport(id);
                newBillReport.Show();

            }
        }

        private void bTxtBoxSearch_OnTextChange(object sender, EventArgs e)
        {

            int i = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();
            String query = "SELECT SaleMaster_Table.SaleMaster_ID , SaleMaster_Table.Net_Total , SaleMaster_Table.Discount , SaleMaster_Table.Net_Amount , SaleMaster_Table.Paid_Amount , SaleMaster_Table.Remaining_Balance , SaleMaster_Table.Date ,  SaleMaster_Table.Time , CustomerTable.Cust_Shop_Name  FROM SaleMaster_Table INNER JOIN CustomerTable ON SaleMaster_Table.FK_Cust_ID = CustomerTable.Cust_ID where Cust_Shop_Name like '"+ bTxtBoxSearch.text + "%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["SaleMaster_ID"].ToString(), dataReader["Cust_Shop_Name"].ToString(), dataReader["Net_Total"].ToString(), dataReader["Discount"].ToString(), dataReader["Net_Amount"].ToString(), dataReader["Paid_Amount"].ToString(), dataReader["Remaining_Balance"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }
    }
}
