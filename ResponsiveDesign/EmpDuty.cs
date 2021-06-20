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
    public partial class EmpDuty : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;
        public EmpDuty()
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
            String query = "SELECT Emp_Duty_Table.Designation , Emp_Duty_Table.Duty_Type , Emp_Duty_Table.LeavesPerMonth,  Emp_Duty_Table.Duty_Timing , Emp_Duty_Table.Date , Emp_Duty_Table.Time, Emp_Profile_Table.Emp_Name, Emp_Profile_Table.Emp_ID  FROM Emp_Duty_Table INNER JOIN Emp_Profile_Table ON Emp_Duty_Table.FK_Emp_ID = Emp_Profile_Table.Emp_ID";
            command = new SqlCommand(query, con);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {

                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["Emp_ID"].ToString(), dataReader["Emp_Name"].ToString(), dataReader["Designation"].ToString(), dataReader["Duty_Type"].ToString(), dataReader["LeavesPerMonth"].ToString(), dataReader["Duty_Timing"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());

            }
            dataReader.Close();
            con.Close();


        }

        private void bTxtSearchEmployee_OnTextChange(object sender, EventArgs e)
        {
            int i = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();
            String query = "SELECT Emp_Duty_Table.Designation , Emp_Duty_Table.Duty_Type , Emp_Duty_Table.LeavesPerMonth,  Emp_Duty_Table.Duty_Timing , Emp_Duty_Table.Date , Emp_Duty_Table.Time, Emp_Profile_Table.Emp_Name, Emp_Profile_Table.Emp_ID  FROM Emp_Duty_Table INNER JOIN Emp_Profile_Table ON Emp_Duty_Table.FK_Emp_ID = Emp_Profile_Table.Emp_ID where Emp_Name like '"+ bTxtSearchEmployee.text+ "%'";
            command = new SqlCommand(query, con);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {

                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["Emp_ID"].ToString(), dataReader["Emp_Name"].ToString(), dataReader["Designation"].ToString(), dataReader["Duty_Type"].ToString(), dataReader["LeavesPerMonth"].ToString(), dataReader["Duty_Timing"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());

            }
            dataReader.Close();
            con.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            EmpDutyAdd empDutyAdd = new EmpDutyAdd(this);
            empDutyAdd.Show();
        }
    }
}
