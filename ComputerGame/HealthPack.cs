﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGame
{
    class HealthPack : BaseObject
    {
        Image img;
        public HealthPack(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = Image.FromFile("../../Images/healthpack.jpg");
        }
        public override void Draw()
        {
            GameBondarev.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Pos.X = GameBondarev.Width + Size.Width;
            if (Pos.Y < 0) Pos.Y = GameBondarev.Height - Size.Height;
            if (Pos.Y > GameBondarev.Height) Pos.Y = 0 + Size.Height;
        }
    }
}
