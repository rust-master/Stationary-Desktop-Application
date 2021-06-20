using ResponsiveDesign.Reports;
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
    public partial class PurchaseDetailDyanmic : Form
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader dataReader;

        public PurchaseDetailDyanmic()
        {
            InitializeComponent();

            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);
            gunaProgressBar1.Value = 0;
            
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


        public void LoadRecord()
        {
            int i = 0;
            gunaDataGridView1.Rows.Clear();
            con.Open();

            String query = "SELECT PurchaseDetail_Table.FK_Purhcase_ID  ,PurchaseDetail_Table.Stock_Status , PurchaseDetail_Table.Quantity , PurchaseDetail_Table.Total_Price , PurchaseDetail_Table.Date , PurchaseDetail_Table.Time , ProdStatic_Table.Prod_Name , ProdStatic_Table.Price  FROM PurchaseDetail_Table INNER JOIN ProdStatic_Table ON PurchaseDetail_Table.FK_Pro_ID = ProdStatic_Table.Prod_ID where FK_Purhcase_ID = '" + int.Parse(label1.Text) + "'";
            command = new SqlCommand(query, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i += 1;
                gunaDataGridView1.Rows.Add(i, dataReader["FK_Purhcase_ID"].ToString(), dataReader["Prod_Name"].ToString(), dataReader["Price"].ToString(), dataReader["Quantity"].ToString(), dataReader["Total_Price"].ToString(), dataReader["Stock_Status"].ToString(), Convert.ToDateTime(dataReader["Date"]).ToString("MM-dd-yyyy"), dataReader["Time"].ToString());
            }
            dataReader.Close();
            con.Close();
        }

        private void PurchaseDetailDyanmic_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);
            LoadRecord();
        }

  

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gunaProgressBar1.Value += 1;
            gunaProgressBar1.Text = gunaProgressBar1.Value.ToString() + "%";
            if (gunaProgressBar1.Value == 100)
            {
                timer1.Enabled = false;
              
            }
        }

        private void PurchaseDetailDyanmic_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void gunaProgressBar1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(label1.Text);
            PuchaseBillReport puchaseBillReport = new PuchaseBillReport(id);
            puchaseBillReport.Show();
        }
    }
}
