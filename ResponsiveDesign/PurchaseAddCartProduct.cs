using ResponsiveDesign.Reports;
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
    public partial class PurchaseAddCartProduct : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True");
        SqlDataAdapter dataAdapter;
        SqlDataReader dr;

        DataTable dt = new DataTable();
        int NetTotal=0;

        Purchase purchase;
        public PurchaseAddCartProduct(Purchase purchase)
        {
            InitializeComponent();

            this.purchase = purchase;

            dt.Columns.Add("Pro ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantiy");
            dt.Columns.Add("Total Price");
            dt.Columns.Add("Date");
            dt.Columns.Add("Time");
            gunaDataGridView1.DataSource = dt;


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

        private void PurchaseAddCartProduct_Load(object sender, EventArgs e)
        {


            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);

            try
            {
                con.Open();
                String selectQuery = "Select Vendor_Comp_Name from Vendor_Table";
                SqlCommand cmd = new SqlCommand(selectQuery, con);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Vendor_Comp_Name", typeof(string));
                dataTable.Load(reader);
                gunaComboBox1.ValueMember = "Vendor_Comp_Name";
                gunaComboBox1.DataSource = dataTable;
                con.Close();

                LoadProducts();

            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show("Error : " + ex);
            }


        }

        private void LoadProducts()
        {
            try
            {
                con.Open();
                String selectQuery = "Select Prod_Name from ProdStatic_Table";
                SqlCommand cmd = new SqlCommand(selectQuery, con);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Prod_Name", typeof(string));
                dataTable.Load(reader);
                gunaComboBox2.ValueMember = "Prod_Name";
                gunaComboBox2.DataSource = dataTable;
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error : " + ex);
            }

        }

        private void PurchaseAddCartProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void PurchaseAddCartProduct_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaImageButton2_Click(object sender, EventArgs e)
        {

            try
            {
                gunaDataGridView1.Rows.Remove(gunaDataGridView1.CurrentRow);
                calculteTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DataGridView is Empty "+ ex);
            }

            
        }
     

      

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            String errorMsg;


            if (gunaLineTextBox1.Text == "" && gunaLineTextBox2.Text == "" && gunaLineTextBox3.Text == "" && texBoxQnty.Text == "")
            {
                errorMsg = "All field are Empty";

                errorMessage(errorMsg);
            }
            else if (gunaLineTextBox1.Text == "")
            {
                errorMsg = "Total Bill is Empty. Please Fill Total Bill TextBox";
                errorMessage(errorMsg);
            }
            else if (gunaLineTextBox2.Text == "")
            {
                errorMsg = "Paid Amount is Empty. Please Fill Paid Amount TextBox";
                errorMessage(errorMsg);
            }
            else if (gunaLineTextBox3.Text == "")
            {
                errorMsg = "Remaining Balance is Empty. Please Fill Remaining Balance TextBox";
                errorMessage(errorMsg);
            }

            else
            {
                InsertData();

            }
        }

        private void InsertData()
        {
            try
            {
                string date = DateTime.Today.ToString("MM-dd-yyyy");
                string time = DateTime.Now.ToString("HH:mm:ss");

                int ID = getVendorID();

                MessageBox.Show("Vendor Name: " + gunaComboBox1.SelectedValue.ToString() + "Date : " + date + " Time : " + time + " ID : " + ID + " Status = " + label1.Text);



                String queryInsert = "insert into Purchase_Tbl(FK_Vendor_ID,Total_Bill,Paid_Amount,Remaing_Amount,Date,Time) values('" + ID + "','" + gunaLineTextBox1.Text + "','" + gunaLineTextBox2.Text +"','" + gunaLineTextBox3.Text + "', '" + date + "','" + time + "')";
                con.Open();

                dataAdapter = new SqlDataAdapter();
                dataAdapter.InsertCommand = new SqlCommand(queryInsert, con);
                int j = dataAdapter.InsertCommand.ExecuteNonQuery();
                con.Close();

                if (j != 0)
                {
                    int PurchID = getPurchID();
                    MessageBox.Show("ID: " + PurchID);
                    MessageBox.Show("Purchase Data Save Done");

                    for (int i = 0; i < gunaDataGridView1.Rows.Count; i++)
                    {
                        string StrQuery = "INSERT INTO PurchaseDetail_Table(FK_Purhcase_ID,FK_Pro_ID,Quantity,Total_Price,Date,Time,Stock_Status) VALUES ('" + PurchID+"','" + gunaDataGridView1.Rows[i].Cells["Pro ID"].Value + "','" + gunaDataGridView1.Rows[i].Cells["Quantiy"].Value +"','" + gunaDataGridView1.Rows[i].Cells["Total Price"].Value + "','" + gunaDataGridView1.Rows[i].Cells["Date"].Value +"','" + gunaDataGridView1.Rows[i].Cells["Time"].Value + "','" + label1.Text + "')";

                        try
                        {

                            con.Open();

                            using (SqlCommand comm = new SqlCommand(StrQuery, con))
                            {
                                comm.ExecuteNonQuery();
                            }
                            con.Close();

                           

                        }
                        catch (Exception ex)
                        {
                            con.Close();
                            MessageBox.Show("Error" + ex);
                        }
                    }
                    MessageBox.Show("Purchase Detail Data Save Done");


                    purchase.LoadRecord();


                    int id = getPurchID();
                    PuchaseBillReport puchaseBillReport = new PuchaseBillReport(id);
                    puchaseBillReport.Show();

                    ClearALL();

                }
                else
                {
                    MessageBox.Show("Error");

                }
               
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error" + ex);
            }
        }

        private void ClearALL()
        {
            gunaComboBox1.Enabled = true;
            gunaComboBox2.Text = "";
            texBoxTltPrice.Text = "";
            texBoxQnty.Text = "";
            texBoxPrice.Text = "";
            gunaLineTextBox1.Text = "";
            gunaLineTextBox2.Text = "";
            gunaLineTextBox3.Text = "";
            gunaDataGridView1.DataSource = null;
            gunaDataGridView1.Refresh();
        }

        private int getPurchID()
        {
            con.Open();
            String selectQuery = "Select MAX(Purhcase_ID) AS LastPurchID from Purchase_Tbl";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }

        private int getVendorID()
        {

            con.Open();
            String selectQuery = "Select Vendor_ID from Vendor_Table where Vendor_Comp_Name ='" + gunaComboBox1.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }

        private void errorMessage(string errorMsg)
        {
            MessageBox.Show(" " + errorMsg);
        }

        private void gunaComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            con.Close();
            con.Open();

            string str = "select * from ProdStatic_Table where Prod_Name='" + gunaComboBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                texBoxPrice.Text = dr["Price"].ToString();
            }
            dr.Close();



            con.Close();

        }
        public void Multiply()
        {
            int a, b;

            bool isAValid = int.TryParse(texBoxQnty.Text, out a);
            bool isBValid = int.TryParse(texBoxPrice.Text, out b);

            if (isAValid && isBValid)
                texBoxTltPrice.Text = (a * b).ToString();

            else
                texBoxTltPrice.Text = "Invalid input";
        }
        private void texBoxQnty_OnValueChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(texBoxQnty.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                texBoxQnty.Text = texBoxQnty.Text.Remove(texBoxQnty.Text.Length - 1);
            }
            Multiply();
        }

        Boolean bll = true;

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            if (texBoxQnty.Text == "")
            {
                MessageBox.Show("Quantity is Required");
            }
            else if(texBoxTltPrice.Text =="" || texBoxTltPrice.Text == "Invalid input")
            {
                MessageBox.Show("Total Price is Required");
            }
            else
            {
                int ID = getProductID();
                string date = DateTime.Today.ToString("MM-dd-yyyy");
                string time = DateTime.Now.ToString("HH:mm:ss");

                String[] temp = new String[7];
                temp[0] = Convert.ToString(ID);
                temp[1] = gunaComboBox2.SelectedValue.ToString();
                temp[2] = texBoxPrice.Text;
                temp[3] = texBoxQnty.Text;
                temp[4] = texBoxTltPrice.Text;
                temp[5] = date;
                temp[6] = time;

                for (int i = 0; i < gunaDataGridView1.Rows.Count; i++)
                {
                    String checkProID = gunaDataGridView1[0, i].Value.ToString();
                    if (checkProID == temp[0])
                    {
                        MessageBox.Show("Product Already In Cart", "Cart Added", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        bll = false;
                        break;
                    }
                }
                if (bll)
                {
                    cart(temp);
                    calculteTotal();
                    gunaComboBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Already Added In Cart", "Failed", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    bll = true;
                }

            }

          

           

        }


        public void cart(String[] c)
        {

            DataRow dr;
            dr = dt.NewRow();
            dr["Pro ID"] = c[0];
            dr["Name"] = c[1];
            dr["Price"] = c[2];
            dr["Quantiy"] = c[3];
            dr["Total Price"] = c[4];
            dr["Date"] = c[5];
            dr["Time"] = c[6];
            dt.Rows.Add(dr);
            gunaDataGridView1.DataSource = dt;

            texBoxQnty.Text = "";
            texBoxTltPrice.Text = "";

        }
       
        private void calculteTotal()
        {
            int sum = 0;
            for (int i = 0; i < gunaDataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(gunaDataGridView1.Rows[i].Cells["Total Price"].Value);
            }
            gunaLineTextBox1.Text = sum.ToString();



        }

        private int getProductID()
        {
            con.Open();
            String selectQuery = "Select Prod_ID from ProdStatic_Table where Prod_Name = '" +gunaComboBox2.SelectedValue.ToString()+"'";
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }

        private void gunaLineTextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(gunaLineTextBox2.Text == "")
                {
                    // MessageBox.Show("Paid Amount is Null. Plesae Add Paid Amount");

                    gunaLineTextBox3.Text = "";
                }
                else
                {
                    int PaidAmount = Convert.ToInt32(gunaLineTextBox2.Text);
                    int Total = Convert.ToInt32(gunaLineTextBox1.Text);
                    int RemainAmount = Total - PaidAmount;
                    

                    gunaLineTextBox3.Text = Convert.ToString(RemainAmount);
                    int check = Convert.ToInt32(gunaLineTextBox3.Text);
                    if(check < 0)
                    {
                        MessageBox.Show("Remaining Amount not less then Zero");
                        gunaLineTextBox3.Text = "";
                        gunaLineTextBox2.Text = "";
                    }
                }

            }
           catch(Exception ex)
            {
                MessageBox.Show("ERROR " + ex);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            ClearALL();
        }
    }
}
