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
    public partial class StockAddHandel : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;

        DataTable dt = new DataTable();

        Stock stock;
        public StockAddHandel(Stock stock)
        {
            InitializeComponent();
            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);

            LoadRecord();
            dt.Columns.Add("Sr");
            dt.Columns.Add("PurchID");
            dt.Columns.Add("ProID");
            dt.Columns.Add("ProName");
            dt.Columns.Add("PQTY");
            dt.Columns.Add("StInDate");
            dt.Columns.Add("StInBy");
            gunaDataGridView2.DataSource = dt;

            this.stock = stock;


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


        public void LoadRecord()
        {
            int i = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();

            String query = "SELECT PurchaseDetail_Table.PurDetail_ID ,PurchaseDetail_Table.Stock_Status , PurchaseDetail_Table.Quantity , PurchaseDetail_Table.Date , ProdStatic_Table.Prod_Name , ProdStatic_Table.Prod_ID  FROM PurchaseDetail_Table INNER JOIN ProdStatic_Table ON PurchaseDetail_Table.FK_Pro_ID = ProdStatic_Table.Prod_ID ";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["PurDetail_ID"].ToString(), dataReader["Prod_ID"].ToString(), dataReader["Prod_Name"].ToString(), dataReader["Quantity"].ToString(), dataReader["Stock_Status"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"));
            }
            dataReader.Close();
            con.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StockAddHandel_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);
        }

        private void StockAddHandel_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        Boolean bll = true;
        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string colName = gunaDataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Add")
            {
                if (MessageBox.Show("Are you sure want to Add this Item?", "Add To Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    String checkStatus = gunaDataGridView1[5, e.RowIndex].Value.ToString();
                    if(checkStatus == "false")
                    {   
                        String PurchID = gunaDataGridView1[1, e.RowIndex].Value.ToString();
                        String ProID = gunaDataGridView1[2, e.RowIndex].Value.ToString();
                        String ProName = gunaDataGridView1[3, e.RowIndex].Value.ToString();
                        String ProQTY = gunaDataGridView1[4, e.RowIndex].Value.ToString();
                        for (int i = 0; i < gunaDataGridView2.Rows.Count; i++)
                        {
                            String checkProID = gunaDataGridView2[1, i].Value.ToString();
                            if(checkProID == PurchID)
                            {
                                MessageBox.Show("Purchase Product Already Add In Stock ", "Stock Added", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                bll = false;
                                break;
                            }
                        }

                        if(bll)
                        {
                            addToDataGrid2(ProID, ProName, ProQTY , PurchID);
                        }
                        else
                        {
                            MessageBox.Show("Already Added", "Failed", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            bll = true;
                        }
                      
                    }
                    else
                    {
                        MessageBox.Show("Purchase Product Already Add In Stock ", "Stock Status True", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }
                }
               
            }
        }
        int i = 1;
        private void addToDataGrid2(String pid , String PrName , String PrQTY ,  String PurchID)
        {
            string date = DateTime.Today.ToString("MM-dd-yyyy");

            DataRow dr;
            dr = dt.NewRow();
            dr["Sr"] = i;
            dr["PurchID"] = PurchID;
            dr["ProID"] = pid;
            dr["ProName"] = PrName;
            dr["PQTY"] = PrQTY;
            dr["StInDate"] = date;
            dr["StInBy"] = gunaLineTextBox2.Text;
            dt.Rows.Add(dr);
            gunaDataGridView2.DataSource = dt;
            i++;
        }

        private void bTxtBoxSearch_OnTextChange(object sender, EventArgs e)
        {
            int i = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();

            String query = "SELECT PurchaseDetail_Table.FK_Purhcase_ID ,PurchaseDetail_Table.Stock_Status , PurchaseDetail_Table.Quantity , PurchaseDetail_Table.Date , ProdStatic_Table.Prod_Name , ProdStatic_Table.Prod_ID  FROM PurchaseDetail_Table INNER JOIN ProdStatic_Table ON PurchaseDetail_Table.FK_Pro_ID = ProdStatic_Table.Prod_ID where Prod_Name like '" + bTxtBoxSearch.text + "%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["FK_Purhcase_ID"].ToString(), dataReader["Prod_ID"].ToString(), dataReader["Prod_Name"].ToString(), dataReader["Quantity"].ToString(), dataReader["Stock_Status"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"));
            }
            dataReader.Close();
            con.Close();
        }

        private void gunaDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
             
            for (int i = 0 ; i < gunaDataGridView2.Rows.Count; i++)
            {
                con.Open();
                String selctQRY = "Select Pro_ID from Stock_Table where  Pro_ID = '"+ gunaDataGridView2.Rows[i].Cells["ProID"].Value + "'";
                SqlCommand cmd = new SqlCommand(selctQRY, con);
                int id = Convert.ToInt32(cmd.ExecuteScalar());
               int qty =  getQTY(i);
                if(id ==  Convert.ToInt32(gunaDataGridView2.Rows[i].Cells["ProID"].Value))
                {
                    con.Close();
                    MessageBox.Show("SAME ID");
                    int grdGTY = Convert.ToInt32(gunaDataGridView2.Rows[i].Cells["PQTY"].Value);
                    int mainQTy = grdGTY + qty;
                    con.Open();
                    String updateQuery = "Update Stock_Table set Quantity = @Quantity , StockInDate =@StockInDate  where Pro_ID = '" + Convert.ToInt32(gunaDataGridView2.Rows[i].Cells["ProID"].Value) + "'";
                    SqlCommand cmdup = new SqlCommand(updateQuery, con);
                    cmdup.Parameters.AddWithValue("@Quantity", mainQTy);
                    cmdup.Parameters.AddWithValue("@StockInDate", gunaDataGridView2.Rows[i].Cells["StInDate"].Value);

                    cmdup.ExecuteNonQuery();
                    MessageBox.Show("Quantity has been Sucessfully updated.");
                    con.Close();

                    updateStockStatu(i);



                }
                else
                {
                    con.Close();
                    MessageBox.Show("Different ID");
                    string StrQuery = "INSERT INTO Stock_Table(FK_PurchDetailID,Pro_ID,Quantity,StockInDate,StockInBy) VALUES ('" + gunaDataGridView2.Rows[i].Cells["PurchID"].Value + "','" + gunaDataGridView2.Rows[i].Cells["ProID"].Value + "','" + gunaDataGridView2.Rows[i].Cells["PQTY"].Value + "','" + gunaDataGridView2.Rows[i].Cells["StInDate"].Value + "','" + gunaDataGridView2.Rows[i].Cells["StInBy"].Value + "')";

                    try
                    {

                        con.Open();

                        using (SqlCommand comm = new SqlCommand(StrQuery, con))
                        {
                            comm.ExecuteNonQuery();
                        }

                        con.Close();
                        updateStockStatu(i);


                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show("Error" + ex);
                    }
                }
                con.Close();
                

            }
            stock.LoadRecord();
        }

        private void updateStockStatu(int y)
        {
            con.Open();
            String updateQuery = "Update PurchaseDetail_Table set Stock_Status = @Stock_Status  where PurDetail_ID = '" + Convert.ToInt32(gunaDataGridView2.Rows[y].Cells["PurchID"].Value) + "'";
            SqlCommand cmdup = new SqlCommand(updateQuery, con);
            cmdup.Parameters.AddWithValue("@Stock_Status", label2.Text);
            cmdup.ExecuteNonQuery();
        }

        private int getQTY(int k)
        {
            con.Close();
            con.Open();
            String selctQRY = "Select Quantity from Stock_Table where  Pro_ID = '" + gunaDataGridView2.Rows[k].Cells["ProID"].Value + "'";
            SqlCommand cmd = new SqlCommand(selctQRY, con);
            int qty = Convert.ToInt32(cmd.ExecuteScalar());
            return qty;
        }
    }
}
