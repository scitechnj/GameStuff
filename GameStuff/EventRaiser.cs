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

namespace GameStuff
{
    public partial class EventRaiser : GameForm
    {
        [DllImport("kernel32")]
        public static extern void AllocConsole();

        private Ball ball = new Ball(50f, 50f, 2.5f, 3.5f, 25f, Color.OrangeRed);
        public EventRaiser()
        {
            AllocConsole();
            InitializeComponent();
            ball.BallBounced += ball_BallBounced;
        }

        void ball_BallBounced(object sender, BallBounceEventArgs e)
        {
            Console.WriteLine(e.BounceSide);
        }

        protected override int TimerInterval
        {
            get { return 10; }
        }

        protected override void UpdateGame()
        {
            ball.Move(new Size(this.ClientRectangle.Width, this.ClientRectangle.Height));
        }

        protected override void Draw(Graphics g)
        {
            ball.Draw(g);
        }
    }
}
