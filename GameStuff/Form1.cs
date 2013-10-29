using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStuff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Timer t = new Timer();
            t.Interval = 1000;
            t.Tick += Foobar;
            t.Start();
        }

        private void Foobar(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToLongTimeString();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            base.OnPaint(e);

            
            e.Graphics.FillRectangle(Brushes.Red,150,50,100,200);
        }
    }
}
