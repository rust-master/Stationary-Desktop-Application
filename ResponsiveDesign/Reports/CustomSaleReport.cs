using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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

namespace ResponsiveDesign.Reports
{
    public partial class CustomSaleReport : Form
    {
        SqlConnection con;

        ReportDocument rprt = new ReportDocument();
        String Date1, Date2;
        public CustomSaleReport(String d1 , String d2)
        {
            InitializeComponent();
            String conStr = "Data Source=DESKTOP-2UBR8R3;Initial Catalog=testsql;Integrated Security=True";
            con = new SqlConnection(conStr);
            Date1 = d1;
            Date2 = d2;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void CustomSaleReport_Load(object sender, EventArgs e)
        {
            
            rprt.Load(@"C:\Users\Zaryab\source\repos\ResponsiveDesign\ResponsiveDesign\Reports\CustomSaleCrystalReport.rpt");
            String selctQRY = "Select * from DailSaleView where Date between '" + Date1 + "' and '" + Date2 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(selctQRY, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "DailSaleView");
            rprt.SetDataSource(ds.Tables["DailSaleView"]);

            TextObject date1 = (TextObject)rprt.ReportDefinition.Sections["Section1"].ReportObjects["Date1"];
            TextObject date2 = (TextObject)rprt.ReportDefinition.Sections["Section1"].ReportObjects["Date2"];
            date1.Text = Date1;
            date2.Text = Date2;

            customcrystalReportViewer1.ReportSource = rprt;
        }
    }
}
