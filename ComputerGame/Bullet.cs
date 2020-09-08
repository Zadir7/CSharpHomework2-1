using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGame
{
    class Bullet : BaseObject
    {
        Image img;

        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = Image.FromFile("../../Images/bullet.jpg");
        }
        public override void Draw()
        {
            GameBondarev.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X += Dir.X;
        }
    }
}
