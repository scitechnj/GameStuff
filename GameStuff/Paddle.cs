using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStuff
{
    public class Paddle
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public Color Color { get; set; }

        public Paddle(float x, float y, float width, float height, Color c)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Color = c;
        }

        public void MoveUp(float amount)
        {
            this.Y += -amount;
            if (this.Y < 0)
            {
                this.Y = 0;
            }
        }

        public void MoveDown(float amount, int height)
        {
            this.Y += amount;
            if (this.Y + this.Height > height)
            {
                this.Y = height - Height;
            }
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(this.Color), X, Y, Width, Height);
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)this.X, (int)this.Y, (int)this.Width, (int)this.Height);
            }
        }
    }
}
