using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGame
{
    class Meteor : BaseObject
    {
        public Meteor(Point pos, Point dir, Size size) : base(pos,dir,size)
        {

        }
        public override void Draw()
        {
            Image img = Image.FromFile("meteor.jpg");
            GameBondarev.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
            //GameBondarev.Buffer.Graphics.FillEllipse(Brushes.PaleGoldenrod, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.X < 0) Pos.X = GameBondarev.Width + Size.Width;
            if (Pos.Y < 0) Pos.Y = GameBondarev.Height - Size.Height;
            if (Pos.Y > GameBondarev.Height) Pos.Y = 0 + Size.Height;
        }
    }
}
