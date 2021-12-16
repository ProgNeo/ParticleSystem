using ParticleSystem.Emitters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ParticleSystem
{
    public partial class MainForm : Form
    {
        private SunEmitter _sunEmitter = new();
        private bool _isOrbitsActive = true;

        private readonly Random _random = new();

        public MainForm()
        {
            InitializeComponent();
            GenerateSytem();
        }

        private void GenerateSytem()
        {
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            var planetsToCreate = _random.Next(2, 6);
            var orbitRadius = _random.Next(150, 170);

            _sunEmitter = new SunEmitter()
            {
                Direction = 0,
                Spreading = 0,
                RadiusMin = 5,
                RadiusMax = 10,
                GravitationX = 0,
                GravitationY = 0,
                SpeedMin = 1,
                SpeedMax = 1,
                LifeMin = 10,
                LifeMax = 100,
                PlanetsToCreate = planetsToCreate,
                ParticlesPerTick = 1,
                OrbitRadius = orbitRadius,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2
            };

            _sunEmitter.CreatePlanets();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var graphics = Graphics.FromImage(picDisplay.Image);
            graphics.Clear(Color.Black);

            _sunEmitter.UpdateState();
            _sunEmitter.RenderParticles(graphics);
            if (_isOrbitsActive)
            {
                _sunEmitter.RenderImpactPoints(graphics);
            }

            RenderSun(graphics);
            picDisplay.Invalidate();
        }

        private void changeOrbitsVision_Click(object sender, EventArgs e)
        {
            _isOrbitsActive = !_isOrbitsActive;
        }

        private void RenderSun(Graphics graphics)
        {
            graphics.FillEllipse(
                new SolidBrush(Color.FromArgb(100, 252, 186, 32)),
                picDisplay.Width / 2 - 80,
                picDisplay.Height / 2 - 80,
                160,
                160
            );            
            graphics.FillEllipse(
                new SolidBrush(Color.FromArgb(155, 252, 186, 32)),
                picDisplay.Width / 2 - 70,
                picDisplay.Height / 2 - 70,
                140,
                140
            );
            graphics.FillEllipse(
                new SolidBrush(Color.FromArgb(255, 252, 186, 32)),
                picDisplay.Width / 2 - 60,
                picDisplay.Height / 2 - 60,
                120,
                120
            );
        }
    }
}
