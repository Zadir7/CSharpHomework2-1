using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGame
{
    static class GameBondarev
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        static Random r = new Random();

        public static int Width { get; set; }
        public static int Height { get; set; }
        static GameBondarev()
        {

        }
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (var obj in _objs)
            {
                obj.Draw();
            }
            Buffer.Render();
        }
        public static void Load()
        {
            _objs = new BaseObject[40];
            for (int i = 0; i < _objs.Length / 4; i++)
            {
                _objs[i] = new Meteor(new Point(30, 300 + i * 20), new Point(r.Next(i + 2 / 2, i + 2 * 2), r.Next(i / 4, i)), new Size(15 + i, 15 + i));
            }
            for (int i = _objs.Length / 4; i < _objs.Length / 2; i++)
            {
                _objs[i] = new Meteor(new Point(750, i * 20), new Point(r.Next(i / 2, i * 2), r.Next(i / 4, i)), new Size(3 + i, 3 + i));
            }
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
            {
                _objs[i] = new Star(new Point(700, (i- _objs.Length / 2) * 30), new Point(r.Next(i/3,i), 0), new Size(7,7));
            }
        }
        public static void Update()
        {
            foreach (var obj in _objs)
            {
                obj.Update();
            }
        }
    }
}
