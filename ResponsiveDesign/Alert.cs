using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResponsiveDesign
{
    public partial class Alert : Form
    {
        public Alert(String Meassage, AlertType type)
        {
            InitializeComponent();
            gunaProgressBar1.Value = 0;

            switch (type)
            {
                case AlertType.success:
                    this.BackColor = Color.FromArgb(53, 183, 41);
                    bunifuCustomLabel1.Text = Meassage;
                    break;
                case AlertType.info:
                    this.BackColor = Color.Gray;
                    bunifuCustomLabel1.Text = Meassage;
                    break;
                case AlertType.warning:
                    this.BackColor = Color.Crimson;
                    bunifuCustomLabel1.Text = Meassage;
                    break;
                case AlertType.error:
                    this.BackColor = Color.FromArgb(255, 128, 0);
                    bunifuCustomLabel1.Text = Meassage;
                    break;
            }
        }

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




 
        private void Alert_Load(object sender, EventArgs e)
        {
            this.Top = 100;
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 60;
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);
            
        }

        private void Alert_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gunaProgressBar1.Value += 1;

            gunaProgressBar1.Text = gunaProgressBar1.Value.ToString() + "%";

            if (gunaProgressBar1.Value == 100)
            {
                timer1.Enabled = false;
              //new Form1().Show();
                this.Hide();
            }
        }
    }
    public enum AlertType
    {
        success, info, warning, error
    }
}
