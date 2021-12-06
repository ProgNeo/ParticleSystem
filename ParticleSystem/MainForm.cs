using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParticleSystem
{
    public partial class MainForm : Form
    {
        private readonly List<Particle> _particles = new();
        private int _mousePositionX = 0;
        private int _mousePositionY = 0;
        public MainForm()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        }

        private void Render(Graphics g)
        {
            foreach (var particle in _particles)
            {
                particle.Draw(g);
            }
        }

        private void UpdateState()
        {
            foreach (var particle in _particles)
            {
                particle.Life -= 1;

                if (particle.Life < 0)
                {
                    particle.Life = 20 + Particle.Rand.Next(100); 
                    particle.X = _mousePositionX;
                    particle.Y = _mousePositionY;
                }
                else
                {
                    var directionInRadians = particle.Direction / 180 * Math.PI;
                    particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
                    particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians));
                }
            }

            for (var i = 0; i < 10; i++)
            {
                if (_particles.Count < 500)
                {
                    var particle = new ParticleColorful
                    {
                        FromColor = Color.Yellow,
                        ToColor = Color.FromArgb(0, Color.Magenta),
                        X = _mousePositionX,
                        Y = _mousePositionY
                    };

                    _particles.Add(particle);
                }
                else
                {
                    break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateState();

            var graphics = Graphics.FromImage(picDisplay.Image);
            graphics.Clear(Color.Black);
            Render(graphics);

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            _mousePositionX = e.X;
            _mousePositionY = e.Y;
        }
    }
}
