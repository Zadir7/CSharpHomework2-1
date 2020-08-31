using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGame
{
    class Star : BaseObject
    {
        Image img;
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = Image.FromFile("../../Images/star.jpg");
        }
        public override void Draw()
        {
            GameBondarev.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
            //GameBondarev.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //GameBondarev.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = GameBondarev.Width + Size.Width;
        }
    }
}
