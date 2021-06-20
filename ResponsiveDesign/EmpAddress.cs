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
    public partial class EmpAddress : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;
        public EmpAddress()
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
            String query = "SELECT Emp_Address_Table.Emp_Add_ID , Emp_Address_Table.Country , Emp_Address_Table.City,  Emp_Address_Table.Email , Emp_Address_Table.Date , Emp_Address_Table.Time, Emp_Address_Table.Address, Emp_Address_Table.WhatsApp,  Emp_Profile_Table.Emp_Name  FROM Emp_Address_Table INNER JOIN Emp_Profile_Table ON Emp_Address_Table.FK_Emp_ID = Emp_Profile_Table.Emp_ID";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dataReader["Emp_Add_ID"].ToString(), dataReader["Emp_Name"].ToString(), dataReader["Country"].ToString(), dataReader["City"].ToString(), dataReader["WhatsApp"].ToString(), dataReader["Email"].ToString(), dataReader["Address"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }

        private void EmpAddress_Load(object sender, EventArgs e)
        {
           
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            EmpAddressAddUpd empAddress = new EmpAddressAddUpd(this);
            empAddress.Show();
        }

        private void bTxtSearchEmployee_OnTextChange(object sender, EventArgs e)
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            con.Open();
            String query = "SELECT Emp_Address_Table.Emp_Add_ID , Emp_Address_Table.Country , Emp_Address_Table.City,  Emp_Address_Table.Email , Emp_Address_Table.Date , Emp_Address_Table.Time, Emp_Address_Table.Address, Emp_Address_Table.WhatsApp,  Emp_Profile_Table.Emp_Name  FROM Emp_Address_Table INNER JOIN Emp_Profile_Table ON Emp_Address_Table.FK_Emp_ID = Emp_Profile_Table.Emp_ID where Address like '" + bTxtSearchEmployee.text + "%'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dataReader["Emp_Add_ID"].ToString(), dataReader["Emp_Name"].ToString(), dataReader["Country"].ToString(), dataReader["City"].ToString(), dataReader["WhatsApp"].ToString(), dataReader["Email"].ToString(), dataReader["Address"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }
    }
}
