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
    public partial class BackupAndRestore : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True");
        public BackupAndRestore()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.SelectedPath;
                BackupButton.Enabled = true;
            }
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            try
            {
                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("please enter backup file location");
                }
                else
                {
                    string cmd = "BACKUP DATABASE [" + database + "] TO DISK='" + textBox1.Text + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";

                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        command.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("database backup done successefully");
                        BackupButton.Enabled = false;
                    }
                }

            }
            catch
            {

            }
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
