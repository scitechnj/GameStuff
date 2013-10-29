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
    public partial class SimpleGame : GameForm
    {
        private List<Ball> balls = new List<Ball>(); 
        //private Ball b;
        private float _x = 0;
        private float _y = 0;
        private float _dx = 2.5f;
        private float _dy = .1f;
        private float _size = 20;
        public SimpleGame()
        {
            InitializeComponent();

            base.Size = new Size(700, 500);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            for (int i = 1; i <= 100; i++)
            {
                this.balls.Add(Ball.GetRandomBall(this.Size));
            }
        }

        protected override int TimerInterval
        {
            get { return 10; }
        }

        protected override void UpdateGame()
        {
            foreach (Ball b in this.balls)
            {
                b.Move(this.Size);    
            }
            
        }

        protected override void Draw(Graphics g)
        {
            foreach (Ball b in this.balls)
            {
                b.Draw(g);
            }
        }
    }
}
