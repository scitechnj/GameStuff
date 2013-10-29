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
    public partial class UserInput : GameForm
    {
        private int x;
        private int y;
        private int moveAmount = 13;

        public UserInput()
        {
            InitializeComponent();
            this.KeyDown += UserInput_KeyDown;
        }

        void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                y+= moveAmount;
            }   
            else if (e.KeyCode == Keys.Up)
            {
                y-= moveAmount;
            }
            else if (e.KeyCode == Keys.Left)
            {
                x-= moveAmount;
            }
            else if (e.KeyCode == Keys.Right)
            {
                x+=moveAmount;
            }
        }

        protected override int TimerInterval
        {
            get { return 10; }
        }

        protected override void UpdateGame()
        {

        }

        protected override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Green, x, y, 30, 30);
        }
    }
}
