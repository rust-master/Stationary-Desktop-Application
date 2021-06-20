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
    public partial class AddComany : Form
    {
        SqlConnection con;
        SqlDataAdapter dataAdapter;
        Form2 forms2;
        public AddComany(Form2 form2)
        {
            InitializeComponent();
            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);

            forms2 = form2;
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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.CloseForm();
        }

        private void CloseForm()
        {
            Close();
        }

        private void AddComany_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);
        }

        private void AddComany_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }




        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            String errorMsg;
           // String cheeckName = CheckCompany();

            if (texBoXCompName.Text == "" && texBoXCompEmail.Text == "" && texBoXComContactNo.Text == "" && texBoXComCity.Text == "" && txtBoxCompAddress.Text == "")
            {
                errorMsg = "All field are Empty";

                errorMessage(errorMsg);
            }
            else if (texBoXCompName.Text == "")
            {
                errorMsg = "Company Name is Empty. Please Fill Company Name TextBox!";
                errorMessage(errorMsg);
            }
            else if (texBoXCompEmail.Text == "")
            {
                errorMsg = "Email is Empty. Please Fill Email TextBox!";
                errorMessage(errorMsg);
            }
            else if (texBoXComContactNo.Text == "")
            {
                errorMsg = "Contact No is Empty. Please Fill Email TextBox!";
                errorMessage(errorMsg);
            }
            else if (texBoXComCity.Text == "")
            {
                errorMsg = "City is Empty. Please Fill City TextBox!";
                errorMessage(errorMsg);
            }
            else if (txtBoxCompAddress.Text == "")
            {
                errorMsg = "Address is Empty. Please Fill Address TextBox!";
                errorMessage(errorMsg);
            }
            //else if(cheeckName == texBoXCompName.Text)
            //{
            //    errorMsg = "Compnay is Allready Added";
            //    errorMessage(errorMsg);
            //}
            else if (!this.texBoXCompEmail.Text.Contains('@') || !this.texBoXCompEmail.Text.Contains('.') || !this.texBoXCompEmail.Text.Contains("com"))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);

                //if (e.KeyChar == 46)
                //{

                //}
                //else if (e.KeyChar == 8)
                //{

                //}
                //else if ((e.KeyChar < 48) || (e.KeyChar > 57))
                //{
                //    e.Handled = true;

                //}
                InsertData();

            }
        }

        private string CheckCompany()
        {
            
                con.Open();
                String selectQuery = "Select Comp_Name from Company_Table where Comp_Name ='" + texBoXCompName.Text + "'";
                SqlCommand cmd = new SqlCommand(selectQuery, con);
                String comp_Name = Convert.ToString(cmd.ExecuteScalar());
                con.Close();
                return comp_Name;
            

        }

        private void InsertData()
        {
            try
            {

             string date = DateTime.Today.ToString("MM-dd-yyyy");
            string time = DateTime.Now.ToString("HH:mm:ss");
            //DateTime time = DateTime.Now; 

            MessageBox.Show("" + date + "Time" + time);



            // String queryInsert = "insert into Company_Table(Comp_Name,Comp_Email,Comp_ContactNo,Comp_Address,Comp_City,Date,Time) values(@Comp_Name,@Comp_Email,@Comp_ContactNo,@Comp_Address,@Comp_City,@Date,@Time)";
            String queryInsert = "insert into Company_Table(Comp_Name,Comp_Email,Comp_ContactNo,Comp_Address,Comp_City,Date,Time) values('" + texBoXCompName.Text + "','" + texBoXCompEmail.Text + "','" + texBoXComContactNo.Text + "','" + txtBoxCompAddress.Text + "','" + texBoXComCity.Text + "', '" + date + "','" + time + "')";
            con.Open();

            dataAdapter = new SqlDataAdapter();
            dataAdapter.InsertCommand = new SqlCommand(queryInsert, con);
            int i = dataAdapter.InsertCommand.ExecuteNonQuery();
            con.Close();

            // SqlCommand command = new SqlCommand(queryInsert, con);
            //command.Parameters.Add("@Comp_Name", texBoXCompName.Text);
            //command.Parameters.Add("@Comp_Email", texBoXCompEmail.Text);
            //command.Parameters.Add("@Comp_ContactNo", texBoXComContactNo.Text);
            //command.Parameters.Add("@Comp_Address", txtBoxCompAddress.Text);
            //command.Parameters.Add("@Comp_City", texBoXComCity.Text);
            //command.Parameters.Add("@Date", Todayc);
            //command.Parameters.Add("@Time", Nowc);

            //int i = command.ExecuteNonQuery();

            if (i != 0)
            {
                MessageBox.Show("Data Save");

                forms2.LoadRecord();


            }
            else
            {
                MessageBox.Show("Error");
            }
            }
            catch(Exception e)
            {
                con.Close();
                MessageBox.Show("Error : " + e);
            }
        }

        private void errorMessage(string errorMsg)
        {
            MessageBox.Show(" " + errorMsg);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure want to update this Company?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    String updateQuery = "Update Company_Table set Comp_Name = @Comp_Name , Comp_Email = @Comp_Email ,Comp_ContactNo = @Comp_ContactNo , Comp_Address = @Comp_Address , Comp_City = @Comp_City  where Comp_ID like '" + label1.Text + "'";
                    SqlCommand cmdup = new SqlCommand(updateQuery, con);

                    cmdup.Parameters.AddWithValue("@Comp_Name", texBoXCompName.Text);
                    cmdup.Parameters.AddWithValue("@Comp_Email", texBoXCompEmail.Text);
                    cmdup.Parameters.AddWithValue("@Comp_ContactNo", texBoXComContactNo.Text);
                    cmdup.Parameters.AddWithValue("@Comp_Address", txtBoxCompAddress.Text);
                    cmdup.Parameters.AddWithValue("@Comp_City", texBoXComCity.Text);

                    cmdup.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Company has been Sucessfully updated.");
                    forms2.LoadRecord();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Error" + ex);
                }

            }
        
            
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AddComany_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void texBoXComContactNo_OnValueChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(texBoXComContactNo.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                texBoXComContactNo.Text = texBoXComContactNo.Text.Remove(texBoXComContactNo.Text.Length - 1);
            }
        }

        private void texBoXCompName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void texBoXCompEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void texBoXComCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void texBoXComContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {

            }
            else if (e.KeyChar == 8)
            {

            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57))
            {
                e.Handled = true;

            }
        }

        private void texBoXCompName_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void texBoXCompEmail_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
