using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGame
{
    class Ship : BaseObject
    {
        public static event Message DyingMessage;
        Image img;
        private int _energy = 100;
        public int Energy => _energy;

        public void EnergyDrain(int rate)
        {
            _energy -= rate;
        }
        public void EnergyRestore(int rate)
        {
            if (_energy + rate > 100)
            {
                _energy = 100;
            } else { _energy += rate; }
        }
        public Ship(Point pos, Point dir, Size size) : base(pos,dir,size)
        {
            img = Image.FromFile("../../Images/ship.jpg");
        }
        public override void Draw()
        {
            GameBondarev.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
        }
        public void MoveUp()
        {
            if (Pos.Y > 0) Pos.Y -= Dir.Y;
        }
        public void MoveDown()
        {
            if (Pos.Y < GameBondarev.Height) Pos.Y += Dir.Y;
        }
        public void Die()
        {
            DyingMessage?.Invoke();
        }
    }
}
