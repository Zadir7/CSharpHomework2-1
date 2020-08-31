using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGame
{
    abstract class BaseObject : ICollision
    {
        internal Point Pos;
        internal Point Dir;
        internal Size Size;
        public BaseObject(Point pos, Point dir, Size size)
        {
            if (Pos.X < 0 ||
                Pos.Y < 0)
            {
                throw new GameException("Объект находится в другой галактике");
            } else
            {
                Pos = pos;
            }
            

            if (dir.X > 50 || dir.Y > 50)
            {
                throw new GameException("Объект перешел на гиперскорость, обсчет невозможен!");
            } else
            {
                Dir = dir;
            }
            if (size.Width < 0 || size.Height < 0)
            {
                throw new GameException("Размеры обьекта несуществующе малы!");
            } else
            {
                Size = size;
            }
        }

        public Rectangle HitBox => new Rectangle(Pos, Size);

        public bool Collision(ICollision obj) => obj.HitBox.IntersectsWith(this.HitBox);

        public abstract void Draw();
        public abstract void Update();
    }
}
