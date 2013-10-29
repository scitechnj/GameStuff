using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStuff
{
    public class Ball
    {
        public Ball(float x, float y, float dx, float dy, float size, Color color)
        {
            Color = color;
            Size = size;
            DY = dy;
            DX = dx;
            Y = y;
            X = x;
        }

        public float X { get; private set; }
        public float Y { get; private set; }
        public float DX { get; private set; }
        public float DY { get; private set; }

        public float Size { get; private set; }

        public Color Color { get; private set; }

        public void FlipX()
        {
            this.DX = -DX;
        }

        public void FlipY()
        {
            this.DY = -DY;
        }

        public void Move(Size formSize)
        {
            X += DX;
            Y += DY;

            if (Y > formSize.Height - Size)
            {
                RaiseBallBouncedEvent(BallBounceSide.Bottom);
                FlipY();
            }
            else if (Y < 0)
            {
                RaiseBallBouncedEvent(BallBounceSide.Top);
                FlipY();
            }

            if (X  > formSize.Width - Size)
            {
                RaiseBallBouncedEvent(BallBounceSide.Right);
                FlipX();
            }
            else if (X < 0)
            {
                RaiseBallBouncedEvent(BallBounceSide.Left);
                FlipX();
            }
        }

        private void RaiseBallBouncedEvent(BallBounceSide side)
        {
            if (this.BallBounced != null)
            {
                BallBounceEventArgs eventArgs = new BallBounceEventArgs();
                eventArgs.BounceSide = side;
                BallBounced.Invoke(this, eventArgs);
            }
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(this.Color), X, Y, Size, Size);
        }

        public event BallBouncedHandler BallBounced;

        public Rectangle BoundingBox
        {
            get { return new Rectangle((int)this.X, (int)this.Y, (int)this.Size, (int)this.Size); }
        }

        private static Random rnd = new Random();
        public static Ball GetRandomBall(Size formSize)
        {
            Ball result = new Ball(rnd.Next(formSize.Width),
                rnd.Next(formSize.Height), (float)(rnd.NextDouble() * 10),
                (float)(rnd.NextDouble() * 10), rnd.Next(30),
                Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
            return result;
        }
    }

    public class BallBounceEventArgs : EventArgs
    {
        public BallBounceSide BounceSide { get; set; }
    }

    public enum BallBounceSide
    {
        Left,
        Right,
        Top,
        Bottom
    }

    public delegate void BallBouncedHandler(object sender, BallBounceEventArgs e);
}
