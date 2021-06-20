using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResponsiveDesign
{
    public partial class EmpProfileAddUpdate : Form
    {
        SqlConnection con;
        SqlDataAdapter dataAdapter;
        String imageLocation;

        EmpProfile empProfile;
        public EmpProfileAddUpdate(EmpProfile empProfile)
        {
            InitializeComponent();
            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);
            this.empProfile = empProfile;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

     



        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imageLocation;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void EmpProfileAddUpdate_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            String errorMsg;


            if (texBoxEmploye.Text == "" && texBoxFname.Text == "" && texBoxCNIC.Text == ""  )
            {
                errorMsg = "All field are Empty";

                errorMessage(errorMsg);
            }
            else if (texBoxEmploye.Text == "")
            {
                errorMsg = "Employee Name is Empty. Please Fill Employee Name TextBox!";
                errorMessage(errorMsg);
            }
            else if (texBoxFname.Text == "")
            {
                errorMsg = "Father Name is Empty. Please Fill Father Name TextBox!";
                errorMessage(errorMsg);
            }
            else if (texBoxCNIC.Text == "")
            {
                errorMsg = "CNIC is Empty. Please Fill CNIC TextBox!";
                errorMessage(errorMsg);
            }
            else if (!radioBtnMale.Checked && !radioBtnFemale.Checked)
            {
             
                errorMsg = "Select Your Gender";
                errorMessage(errorMsg);
            }
            else
            {
                InsertData();

            }
        }
        private void InsertData()
        {
            try
            {
                String Gender = "Null";
                if (!radioBtnMale.Checked)
                {
                    Gender = radioBtnFemale.Text;
                }
                else if (!radioBtnFemale.Checked)
                {
                    Gender = radioBtnMale.Text;
                }
                else
                {
                  String  errorMsg = "Select Your Gender";
                    errorMessage(errorMsg);

                }

                string date = DateTime.Today.ToString("MM-dd-yyyy");
                string time = DateTime.Now.ToString("HH:mm:ss");
               
                MessageBox.Show( "Date" + date + "Time" + time);

                String imgLoc = pictureBox1.ImageLocation;
                byte[] images = null;
                FileStream stream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(stream);
                images = binaryReader.ReadBytes((int)stream.Length);
                SqlCommand cmd;
                con.Open();
               String queryInsert = "insert into Emp_Profile_Table(Profile_Image,Emp_Name,Emp_FatherName,Emp_CNIC,Gender,Date,Time) values('"+images + "','" + texBoxEmploye.Text + "','" + texBoxFname.Text + "','" + texBoxCNIC.Text + "','"+ Gender + "', '" + date + "','" + time + "')";
                //cmd = new SqlCommand(queryInsert,con);
                //cmd.Parameters.Add(new SqlParameter("@Profile_Image", images));
                //int i = cmd.ExecuteNonQuery();
                dataAdapter = new SqlDataAdapter();
                dataAdapter.InsertCommand = new SqlCommand(queryInsert, con);
                int i = dataAdapter.InsertCommand.ExecuteNonQuery();
                con.Close();

                if (i != 0)
                {
                    MessageBox.Show("Data Save");

                    empProfile.LoadRecord();


                }
                else
                {
                    MessageBox.Show("Error");

                }
            }
            catch (Exception e)
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

        }
    }
}
