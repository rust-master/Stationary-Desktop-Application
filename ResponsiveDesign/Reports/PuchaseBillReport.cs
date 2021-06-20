using CrystalDecisions.CrystalReports.Engine;
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

namespace ResponsiveDesign.Reports
{
    public partial class PuchaseBillReport : Form
    {
        SqlConnection con;
        SqlDataAdapter SqlDataAdapter;

        ReportDocument rprt = new ReportDocument();

        int mainId;
        public PuchaseBillReport(int id)
        {
            InitializeComponent();
            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);

            mainId = id;


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


        private void PuchaseBillReport_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);


            rprt.Load(@"C:\Users\Zaryab\source\repos\ResponsiveDesign\ResponsiveDesign\Reports\PurchaseBillCrystalReport.rpt");
            String selctQRY = "Select * from Purchase_View where  Purhcase_ID = '" + mainId + "'";
            SqlDataAdapter sda = new SqlDataAdapter(selctQRY, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Purchase_View");
            rprt.SetDataSource(ds.Tables["Purchase_View"]);
            companycrystalReportViewer1.ReportSource = rprt;

        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PuchaseBillReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
