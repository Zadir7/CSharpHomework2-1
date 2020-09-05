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
        public static BaseObject[] _meteors;
        public static BaseObject[] _hps;
        public static Bullet _bullet;
        static Random r = new Random();
        private static Timer timer = new Timer { Interval = 100 };
        public static int Score { get; set; }

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
            if (form.Width < 0 || 
                form.Width > 1000 || 
                form.Height < 0 || 
                form.Height > 1000)
            {
                throw new ArgumentOutOfRangeException();
            } else
            {
                Width = form.ClientSize.Width;
                Height = form.ClientSize.Height;
            }
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Score = 0;
            form.KeyDown += Form_KeyDown;
            
            timer.Start();
            timer.Tick += Timer_Tick;
            Ship.DyingMessage += Finish;
        }
        private static Ship _ship = new Ship(new Point(10, 400), new Point(7, 7), new Size(40, 40));

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (var hp in _hps)
            {
                hp?.Draw();
            }
            foreach (var obj in _objs)
            {
                obj.Draw();
            }
            foreach (var meteor in _meteors)
            {
                meteor?.Draw();
            }
            _bullet?.Draw();
            _ship?.Draw();
            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.Aquamarine, 0, 0);
                Buffer.Graphics.DrawString("Score:" + Score, SystemFonts.DefaultFont, Brushes.Lime, 0, 20);
            }
            Buffer.Render();
        }
        public static void Load()
        {
            _objs = new BaseObject[20];
            _meteors = new BaseObject[20];
            _hps = new BaseObject[1];
            for (int i = 0; i < _hps.Length; i++)
            {
                new HealthPack(new Point(720, 0), new Point(r.Next(7,14), r.Next(7, 14)), new Size(25, 25));
            }
            for (int i = 0; i < 3; i++)
            {
                _meteors[i] = new Meteor(new Point(750, i * 20), new Point(2*i+7, 2*i+7), new Size(15 + i, 15 + i));
            }
            for (int i = 3; i < _meteors.Length; i++)
            {
                _meteors[i] = new Meteor(new Point(750, i * 20), new Point(r.Next(i / 2, i), r.Next(-i / 2, i)), new Size(15 + i, 15 + i));
            }
            
            for (int i = 0; i < _objs.Length; i++)
            {
                _objs[i] = new Star(new Point(700, i * 30), new Point(r.Next(i/3,i), 0), new Size(7,7));
            }
            
        }
        public static void Update()
        {
            foreach (var obj in _objs)
            {
                obj.Update();
            }
            _bullet?.Update();
            for (int i = 0; i < _meteors.Length; i++)
            {
                if (_meteors[i] == null) _meteors[i] = new Meteor(new Point(750, i * 20), new Point(r.Next(i / 2, i), r.Next(i / 2, i)), new Size(3 + i, 3 + i));
                _meteors[i].Update();
                if (_bullet != null && _bullet.Collision(_meteors[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    Score += 3;
                    _meteors[i] = null;
                    _bullet = null;
                    continue;
                }
                if (!_ship.Collision(_meteors[i])) continue;
                _ship?.EnergyDrain(r.Next(3, 15));
                _meteors[i] = null;
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship.Die();
            }
            for (int i = 0; i < _hps.Length; i++)
            {
                if (_hps[i] == null) _hps[i] = new HealthPack(new Point(750, 0), new Point(7 + r.Next(1, 14), 7 + r.Next(1, 14)), new Size(35, 35));
                _hps[i].Update();
                if (_ship.Energy <= 0 || !_ship.Collision(_hps[i])) continue;
                _ship?.EnergyRestore(r.Next(1,10));
                Score += 1;
                System.Media.SystemSounds.Hand.Play();
                _hps[i] = null;
            }
              
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.ControlKey) _bullet = new Bullet(new Point(_ship.Pos.X + 10, _ship.Pos.Y + 15), new Point(25, 0), new Size(15, 6));
            if (e.KeyCode == Keys.Up) _ship.MoveUp();
            if (e.KeyCode == Keys.Down) _ship.MoveDown();
        }

        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End. Score: " +Score, new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.Red, 150, 200);
            Buffer.Render();
        }
    }
}
