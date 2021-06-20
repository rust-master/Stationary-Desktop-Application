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
    public partial class EmpEducation : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;

        public EmpEducation()
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
            String query = "SELECT Emp_Education_table.Emp_Edu_ID , Emp_Education_table.DegreeTitle , Emp_Education_table.Year,  Emp_Education_table.Institute , Emp_Education_table.Date , Emp_Education_table.Time, Emp_Profile_Table.Emp_Name  FROM Emp_Education_table INNER JOIN Emp_Profile_Table ON Emp_Education_table.FK_Emp_ID = Emp_Profile_Table.Emp_ID";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dataReader["Emp_Edu_ID"].ToString(), dataReader["Emp_Name"].ToString(), dataReader["DegreeTitle"].ToString(), dataReader["Year"].ToString(), dataReader["Institute"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }

        private void EmpEducation_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            EmpEduAddUpdate eduAddUpdate = new EmpEduAddUpdate(this);
            eduAddUpdate.Show();
        }

        private void bTxtSearchEmployee_OnTextChange(object sender, EventArgs e)
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            con.Open();
            String query = "SELECT Emp_Education_table.Emp_Edu_ID , Emp_Education_table.DegreeTitle , Emp_Education_table.Year,  Emp_Education_table.Institute , Emp_Education_table.Date , Emp_Education_table.Time, Emp_Profile_Table.Emp_Name  FROM Emp_Education_table INNER JOIN Emp_Profile_Table ON Emp_Education_table.FK_Emp_ID = Emp_Profile_Table.Emp_ID where DegreeTitle like '" + bTxtSearchEmployee.text + "%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dataReader["Emp_Edu_ID"].ToString(), dataReader["Emp_Name"].ToString(), dataReader["DegreeTitle"].ToString(), dataReader["Year"].ToString(), dataReader["Institute"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }
    }
}
