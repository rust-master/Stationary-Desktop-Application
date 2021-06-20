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
    public partial class EmpSkills : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;

        public EmpSkills()
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
            String query = "SELECT Emp_Skills_Table.Emp_Skills_ID , Emp_Skills_Table.Skill_Name , Emp_Skills_Table.Expertise_Level,  Emp_Skills_Table.DurationofExp , Emp_Skills_Table.Date , Emp_Skills_Table.Time, Emp_Profile_Table.Emp_Name  FROM Emp_Skills_Table INNER JOIN Emp_Profile_Table ON Emp_Skills_Table.FK_Emp_ID = Emp_Profile_Table.Emp_ID";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dataReader["Emp_Skills_ID"].ToString(), dataReader["Emp_Name"].ToString(), dataReader["Skill_Name"].ToString(), dataReader["Expertise_Level"].ToString(), dataReader["DurationofExp"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }


        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            EmpSkillAddUpdte empSkillAddUpdte = new EmpSkillAddUpdte(this);
            empSkillAddUpdte.Show();
        }

        private void bTxtSearchEmployee_OnTextChange(object sender, EventArgs e)
        {

        }
    }
}
