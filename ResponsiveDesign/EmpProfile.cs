using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResponsiveDesign
{
    public partial class EmpProfile : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;

        public EmpProfile()
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
            String query = "Select Emp_ID , Emp_Name ,Emp_FatherName,Emp_CNIC,Gender,Date,Time  from Emp_Profile_Table";
            command = new SqlCommand(query, con);
            
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {

                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["Emp_ID"].ToString(), dataReader["Emp_Name"].ToString(), dataReader["Emp_FatherName"].ToString(), dataReader["Emp_CNIC"].ToString(), dataReader["Gender"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());

            }
            dataReader.Close();
            con.Close();


        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            EmpProfileAddUpdate empProfileAdd = new EmpProfileAddUpdate(this);
            empProfileAdd.Show();

        }

        private void bTxtSearchEmployee_OnTextChange(object sender, EventArgs e)
        {
            int i = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();
            String query = "Select * from Emp_Profile_Table where Emp_Name like '" + bTxtSearchEmployee.text + "%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["Emp_ID"].ToString(), dataReader["Emp_Name"].ToString(), dataReader["Emp_FatherName"].ToString(), dataReader["Emp_CNIC"].ToString(), dataReader["Gender"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
