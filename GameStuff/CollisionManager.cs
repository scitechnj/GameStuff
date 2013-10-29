using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStuff
{
    public static class CollisionManager
    {
        public static void CheckBallPaddleCollision(Ball ball, Paddle paddle)
        {
            if (ball.BoundingBox.IntersectsWith(paddle.BoundingBox))
            {
                ball.FlipX();
            }
        }
    }
}
