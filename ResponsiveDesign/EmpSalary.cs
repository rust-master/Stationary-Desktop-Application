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
    public partial class EmpSalary : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;

        public EmpSalary()
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
            String query = "SELECT Emp_SalaryTable.Emp_Sal_ID , Emp_SalaryTable.Salary_Amount , Emp_SalaryTable.Date , Emp_SalaryTable.Time , Emp_Profile_Table.Emp_Name  FROM Emp_SalaryTable INNER JOIN Emp_Profile_Table ON Emp_SalaryTable.FK_Emp_ID = Emp_Profile_Table.Emp_ID";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dataReader["Emp_Sal_ID"].ToString(), dataReader["Emp_Name"].ToString(), dataReader["Salary_Amount"].ToString(),Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            EmpSalaryAddUp empSalaryAddUp = new EmpSalaryAddUp(this);
            empSalaryAddUp.Show();
        }
    }
}
