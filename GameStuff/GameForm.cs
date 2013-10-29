using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStuff
{
    public abstract partial class GameForm : Form
    {
        protected GameForm()
        {
            InitializeComponent();
            base.DoubleBuffered = true;
            Timer timer = new Timer();
            timer.Interval = this.TimerInterval;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateGame();
            this.Refresh();
        }

        protected abstract int TimerInterval { get; }
        protected abstract void UpdateGame();
        protected abstract void Draw(Graphics g);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Draw(e.Graphics);
        }
    }
}
