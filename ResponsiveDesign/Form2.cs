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
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;

        public Form2()
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
            String query = "Select * from Company_Table";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dataReader["Comp_ID"].ToString(), dataReader["Comp_Name"].ToString(), dataReader["Comp_Email"].ToString(), dataReader["Comp_ContactNo"].ToString(), dataReader["Comp_Address"].ToString(), dataReader["Comp_City"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            AddComany addComany = new AddComany(this);
            addComany.bunifuFlatButton2.Enabled = false;
            addComany.Show();

        }

        private void bTxtBoxPhoneNo_OnTextChange(object sender, EventArgs e)
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            con.Open();
            String query = "Select * from Company_Table where Comp_Name like '"+ bTxtBoxSearch.text +"%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dataReader["Comp_ID"].ToString(), dataReader["Comp_Name"].ToString(), dataReader["Comp_Email"].ToString(), dataReader["Comp_ContactNo"].ToString(), dataReader["Comp_Address"].ToString(), dataReader["Comp_City"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AddComany addComany = new AddComany(this);
            addComany.bunifuFlatButton1.Enabled = false;

            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if( colName == "Edit")
            {
                addComany.label1.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                addComany.texBoXCompName.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                addComany.texBoXCompEmail.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                addComany.texBoXComContactNo.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                addComany.txtBoxCompAddress.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                addComany.texBoXComCity.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                addComany.Show();
            }

            if( colName == "Delete")
            {

                

                    int ID = Convert.ToInt32(dataGridView1[1, e.RowIndex].Value.ToString());
                    if (MessageBox.Show("Are you sure want to delete this Company?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                     try
                     {
                        con.Open();
                        String deleteQuery = "delete from Company_Table where Comp_ID =@Comp_ID";
                        SqlCommand cmdup = new SqlCommand(deleteQuery, con);

                        cmdup.Parameters.AddWithValue("@Comp_ID", ID);
                        cmdup.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Company has beenn Sucessfully deleted.");
                        LoadRecord();
                     }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show("Error " + ex, "Error in Compnay Form");
                    }

                }
               
                

            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            CompanyReport companyReport = new CompanyReport();
            companyReport.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
