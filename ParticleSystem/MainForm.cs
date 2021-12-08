using ParticleSystem.Emitters;
using ParticleSystem.Points;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SunEmitter = ParticleSystem.Emitters.SunEmitter;

namespace ParticleSystem
{
    public partial class MainForm : Form
    {
        private readonly List<Emitter> _emitters = new();
        private readonly Emitter _emitter;
        private readonly Random _random = new();
        public MainForm()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            var particlesToCreate = _random.Next(0, 5);
            var orbitDiametr = _random.Next(25, 30);
            
            _emitter = new PlanetEmitter()
            {
                Direction = 0,
                Spreading = 1,
                RadiusMin = 2,
                RadiusMax = 4,
                GravitationX = 0,
                GravitationY = 0,
                SpeedMin = 1,
                SpeedMax = 1, 
                ParticlesToCreate = particlesToCreate,
                OrbitDiametr = orbitDiametr,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2
            };

            _emitters.Add(_emitter);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var g = Graphics.FromImage(picDisplay.Image);
            g.Clear(Color.Black);

            foreach (var emitter in _emitters)
            {
                if (emitter is SunEmitter sunEmitter)
                {
                    foreach (var planetEmitter in sunEmitter.Emmiters)
                    {
                        planetEmitter.UpdateState();
                        planetEmitter.Render(g);
                    }
                }
                emitter.UpdateState();
                emitter.Render(g);
            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            _emitter.MousePositionX = e.X;
            _emitter.MousePositionY = e.Y;
        }
    }
}
