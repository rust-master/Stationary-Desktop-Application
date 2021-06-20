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
    public partial class AccountControl : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;
        public AccountControl()
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
            String query = "SELECT Emp_Profile_Table.Emp_Name , Emp_Profile_Table.Emp_FatherName, Signup_Table.id, Signup_Table.Email , Signup_Table.Date , Signup_Table.Time  FROM Signup_Table INNER JOIN Emp_Profile_Table ON Signup_Table.FK_Emp_ID = Emp_Profile_Table.Emp_ID";
            command = new SqlCommand(query, con);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {

                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["id"].ToString(), dataReader["Emp_Name"].ToString(), dataReader["Emp_FatherName"].ToString(), dataReader["Email"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());

            }
            dataReader.Close();
            con.Close();


        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            SigupForm sigupForm = new SigupForm(this);
            sigupForm.Show();
        }

        private void AccountControl_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = gunaDataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {



                int ID = Convert.ToInt32(gunaDataGridView1[1, e.RowIndex].Value.ToString());
                if (MessageBox.Show("Are you sure want to delete this Account?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        String deleteQuery = "delete from Signup_Table where id =@id";
                        SqlCommand cmdup = new SqlCommand(deleteQuery, con);

                        cmdup.Parameters.AddWithValue("@id", ID);
                        cmdup.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Account has beenn Sucessfully deleted.");
                        LoadRecord();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show("Error " + ex, "Error in Account Form");
                    }

                }



            }
        }
    }
}
