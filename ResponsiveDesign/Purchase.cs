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
    public partial class Purchase : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;

        public Purchase()
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
            String query = "SELECT Purchase_Tbl.Purhcase_ID , Purchase_Tbl.Total_Bill , Purchase_Tbl.Paid_Amount , Purchase_Tbl.Remaing_Amount , Purchase_Tbl.Date , Purchase_Tbl.Time , Vendor_Table.Vendor_Comp_Name  FROM Purchase_Tbl INNER JOIN Vendor_Table ON Purchase_Tbl.FK_Vendor_ID = Vendor_Table.Vendor_ID";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["Purhcase_ID"].ToString(), dataReader["Vendor_Comp_Name"].ToString(), dataReader["Total_Bill"].ToString(), dataReader["Paid_Amount"].ToString(), dataReader["Remaing_Amount"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();


        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            PurchaseAddCartProduct purchaseAddCart = new PurchaseAddCartProduct(this);
            purchaseAddCart.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PurchaseDetailDyanmic purchaseDetailDyanmic = new PurchaseDetailDyanmic();

            string colName = gunaDataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "View")
            {
                purchaseDetailDyanmic.label1.Text = gunaDataGridView1[1, e.RowIndex].Value.ToString();
            
                purchaseDetailDyanmic.Show();
            }

            if (colName == "Printer")
            {

                int id = int.Parse(gunaDataGridView1[1, e.RowIndex].Value.ToString());
                PuchaseBillReport puchaseBillReport = new PuchaseBillReport(id);
                puchaseBillReport.Show();

            }
        }

        private void bTxtBoxSearch_OnTextChange(object sender, EventArgs e)
        {
            int i = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();
            String query = "SELECT Purchase_Tbl.Purhcase_ID , Purchase_Tbl.Total_Bill , Purchase_Tbl.Paid_Amount , Purchase_Tbl.Remaing_Amount , Purchase_Tbl.Date , Purchase_Tbl.Time , Vendor_Table.Vendor_Comp_Name  FROM Purchase_Tbl INNER JOIN Vendor_Table ON Purchase_Tbl.FK_Vendor_ID = Vendor_Table.Vendor_ID where Vendor_Comp_Name like '" + bTxtBoxSearch.text + "%' or Purhcase_ID like '"+ bTxtBoxSearch.text + "%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["Purhcase_ID"].ToString(), dataReader["Vendor_Comp_Name"].ToString(), dataReader["Total_Bill"].ToString(), dataReader["Paid_Amount"].ToString(), dataReader["Remaing_Amount"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }
    }
}
