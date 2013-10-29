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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32")]
        public static extern void AllocConsole();
        private Keys[] _lastThreeKeys = new Keys[3];
        
        public Form1()
        {
            InitializeComponent();
            AllocConsole();
            this.KeyDown += Form1_KeyDown;

            this.GodModeEntered += Form1_GodModeEntered;

            //Rectangle rec = new Rectangle(40, 40, 100, 400);
            //Console.WriteLine(rec.Left);
            //Console.WriteLine(rec.Right);
            //Console.WriteLine(rec.Top);
            //Console.WriteLine(rec.Bottom);
        }

        void Form1_GodModeEntered(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _lastThreeKeys[0] = _lastThreeKeys[1];
            _lastThreeKeys[1] = _lastThreeKeys[2];
            _lastThreeKeys[2] = e.KeyCode;

            if (_lastThreeKeys[0] == Keys.G && _lastThreeKeys[1] == Keys.O
                && _lastThreeKeys[2] == Keys.D)
            {
                if (GodModeEntered != null)
                {
                    GodModeEntered(this, EventArgs.Empty);
                }

            }
        }

        public event GodModeEnteredHandler GodModeEntered;
    }

    public delegate void GodModeEnteredHandler(object sender, EventArgs e);
}
