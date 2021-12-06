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
        public MainForm()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            for(var i = 0; i < 500; i++)
            {
                _particles.Add(new Particle(
                    picDisplay.Image.Width / 2, 
                    picDisplay.Image.Height / 2)
                );
            }
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
                    particle.X = picDisplay.Image.Width / 2;
                    particle.Y = picDisplay.Image.Height / 2;
                }
                else
                {
                    var directionInRadians = particle.Direction / 180 * Math.PI;
                    particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
                    particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians));
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateState();

            var graphics = Graphics.FromImage(picDisplay.Image);
            graphics.Clear(Color.White);
            Render(graphics);

            picDisplay.Invalidate();
        }
    }
}
