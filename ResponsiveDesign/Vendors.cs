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
    public partial class Vendors : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;

        public Vendors()
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
            String query = "Select * from Vendor_Table";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dataReader["Vendor_ID"].ToString(), dataReader["Vendor_Comp_Name"].ToString(), dataReader["Contact_Person_Name"].ToString(), dataReader["Email"].ToString(), dataReader["WhatsApp_No"].ToString(), dataReader["Address"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
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
            AddVendor addVendor = new AddVendor(this);
            addVendor.bunifuFlatButton2.Enabled = false;
            addVendor.Show();
        }

        private void bTxtSearchBrand_OnTextChange(object sender, EventArgs e)
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            con.Open();
            String query = "Select * from Vendor_Table where Vendor_Comp_Name like '" + bTxtSearchVendor.text + "%' or Contact_Person_Name like '"+ bTxtSearchVendor.text + "%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dataReader["Vendor_ID"].ToString(), dataReader["Vendor_Comp_Name"].ToString(), dataReader["Contact_Person_Name"].ToString(), dataReader["Email"].ToString(), dataReader["WhatsApp_No"].ToString(), dataReader["Address"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AddVendor addVendor = new AddVendor(this);
            addVendor.bunifuSaveBtn.Enabled = false;

            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                addVendor.label1.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                addVendor.texBoxVendorName.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                addVendor.texboxPerName.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                addVendor.txtBoxEmailID.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                addVendor.txtBoxWhatsAppNo.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                addVendor.txtBoxAddress.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                addVendor.Show();
            }


            if (colName == "Delete")
            {
                int ID = Convert.ToInt32(dataGridView1[1, e.RowIndex].Value.ToString());
                if (MessageBox.Show("Are you sure want to delete this Vendor?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        String deleteQuery = "delete from Vendor_Table where Vendor_ID =@Vendor_ID";
                        SqlCommand cmdup = new SqlCommand(deleteQuery, con);

                        cmdup.Parameters.AddWithValue("@Vendor_ID", ID);
                        cmdup.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Vendor has beenn Sucessfully deleted.");
                        LoadRecord();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show("Error " + ex, "Error in Vendor Form");
                    }

                }



            }
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            VendorReports vendorReports = new VendorReports();
            vendorReports.Show();
        }
    }
}
