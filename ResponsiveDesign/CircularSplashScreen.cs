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
    public partial class CircularSplashScreen : Form
    {
        int id;
        public CircularSplashScreen(int iid)
        {
            InitializeComponent();
            id = iid;
            gunaProgressBar1.Value = 0;
    


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

        private void CircularSplashScreen_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_BLEND);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gunaProgressBar1.Value += 1;
        

            gunaProgressBar1.Text = gunaProgressBar1.Value.ToString() + "%";
    


            if(gunaProgressBar1.Value == 20)
            {
                bunifuCustomLabel2.Text = "Checking Database";
            }
            if (gunaProgressBar1.Value == 40)
            {
                bunifuCustomLabel2.Text = "Creating Session";
            }
            if (gunaProgressBar1.Value == 70)
            {
                bunifuCustomLabel2.Text = "Loading Dashboard";
            }


            if (gunaProgressBar1.Value >= 100)
            {
                timer1.Enabled = false;
                if (id == 1)
                {
                    new Form1().Show();
                    this.Hide();
                }
                else if(id == 2)
                {
                    new DashBoard_POS().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("BUG IS HERE");
                }

            }
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void CircularSplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
        }
    }
}
