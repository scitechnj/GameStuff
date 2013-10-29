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
    public partial class PongGame : GameForm
    {
        private Ball ball = new Ball(50, 50, 3.5f, 2.7f, 30, Color.Purple);
        private Paddle paddle = new Paddle(30, 300, 20, 80, Color.DarkSalmon);
        private int moveAmount = 5;
        public PongGame()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            this.Size = new Size(1000, 600);
            this.KeyDown += PongGame_KeyDown;
        }

        void PongGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                paddle.MoveDown(moveAmount, this.ClientRectangle.Height);
            }
            else if (e.KeyCode == Keys.Up)
            {
                paddle.MoveUp(moveAmount);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        protected override int TimerInterval
        {
            get { return 10; }
        }

        protected override void UpdateGame()
        {
            ball.Move(new Size(this.ClientRectangle.Width, this.ClientRectangle.Height));
            CollisionManager.CheckBallPaddleCollision(ball, paddle);
        }

        protected override void Draw(Graphics g)
        {
            DrawLineDownMiddle(g);
            ball.Draw(g);
            paddle.Draw(g);
        }

        private void DrawLineDownMiddle(Graphics g)
        {
            int lineWidth = 10;
            g.FillRectangle(new SolidBrush(Color.White), (this.Width / 2) - (lineWidth / 2), 0, lineWidth, this.Height);
        }
    }
}
