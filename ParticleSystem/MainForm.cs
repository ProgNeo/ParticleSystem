using ParticleSystem.Emitters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ParticleSystem.Particles;
using ParticleSystem.Points;

namespace ParticleSystem
{
    public partial class MainForm : Form
    {
        private SunEmitter _sunEmitter = new();
        private bool _isOrbitsActive = true;
        private bool _isRangeOfOrbitsActive = false;

        private readonly Random _random = new();

        private List<TrackBar> _trackBars = new();

        public MainForm()
        {
            InitializeComponent();
            GenerateSytem();
            CreateTrackBars();
        }

        private void GenerateSytem()
        {
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            var planetsToCreate = _random.Next(2, 6);
            var orbitRadius = _random.Next(80, 120);

            _sunEmitter = new SunEmitter
            {
                Direction = 0,
                Spreading = 5,
                RadiusMin = 5,
                RadiusMax = 10,
                GravitationX = 0,
                GravitationY = 0,
                SpeedMin = 2,
                SpeedMax = 2,
                PlanetsToCreate = planetsToCreate,
                ParticlesPerTick = 1,
                OrbitRadius = orbitRadius,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
                SunPoint = new SunPoint
                {
                    Diametr = 900,
                    X = picDisplay.Width / 2f,
                    Y = picDisplay.Height / 2f,
                    Color = Color.FromArgb(200, Color.Yellow)
                }
            };

            _sunEmitter.Particles.Add(new Sun
            {
                X = picDisplay.Width /2f,
                Y = picDisplay.Height /2f,
                Radius = 40,
                Color = Color.FromArgb(255, 252, 186, 32),
                Speed = 0,
                SpeedX = 0,
                SpeedY = 0,
            });

            _sunEmitter.Particles[0].OnOverlap += (sun, particle1) =>
            {
                particle1.X = -100;
                particle1.Y = -100;
                particle1.SpeedX = 0;
                particle1.SpeedY = 0;
            };

            _sunEmitter.ImpactPoints.Add(_sunEmitter.SunPoint);

            _sunEmitter.CreatePlanets();
        }

        private void CreateTrackBars()
        {
            var space = 51;

            _trackBars = new List<TrackBar>();

            for (var i = 0; i < _sunEmitter.Particles.Count; i++)
            {
                if (_sunEmitter.Particles[i] is not Planet) continue;

                var trackBar = new TrackBar
                {
                    Name = i.ToString(),
                    Visible = true,
                    Location = new Point(1285, 27 + space),
                    Height = 45,
                    Width = 287,
                    Minimum = 0,
                    Maximum = 100,
                    Value = (int) _sunEmitter.Particles[i].Speed * 10
                };
                trackBar.Scroll += ChangePlanetSpeed!;
                this.Controls.Add(trackBar);
                space += 51;

                _trackBars.Add(trackBar);
            }
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

            if (_isRangeOfOrbitsActive)
            {
                _sunEmitter.RenderRangeOfImpactPoints(graphics);
            }

            //RenderSun(graphics);
            picDisplay.Invalidate();
        }

        private void changeOrbitsVision_Click(object sender, EventArgs e)
        {
            _isOrbitsActive = !_isOrbitsActive;
        }

        private void changeOrbitsRangeVision_Click(object sender, EventArgs e)
        {
            _isRangeOfOrbitsActive = !_isRangeOfOrbitsActive;
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            foreach (var track in _trackBars)
            {
                track.Dispose();
            }

            GenerateSytem();
            CreateTrackBars();
            trackBar1.Value = 10;
        }

        private void ChangePlanetSpeed(object sender, EventArgs e)
        {
            var track = sender as TrackBar;
            _sunEmitter.Particles[int.Parse(track!.Name)].Speed = track.Value / 10f;
        }

        private void RenderSun(Graphics graphics)
        {
            graphics.FillEllipse(
                new SolidBrush(Color.FromArgb(255, 252, 186, 32)),
                picDisplay.Width / 2 - 30,
                picDisplay.Height / 2 - 30,
                60,
                60
            );            
            graphics.FillEllipse(
                new SolidBrush(Color.FromArgb(155, 252, 186, 32)),
                picDisplay.Width / 2 - 35,
                picDisplay.Height / 2 - 35,
                70,
                70
            );
            graphics.FillEllipse(
                new SolidBrush(Color.FromArgb(100, 252, 186, 32)),
                picDisplay.Width / 2 - 40,
                picDisplay.Height / 2 - 40,
                80,
                80
            );
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _sunEmitter.SunPoint.Power = trackBar1.Value / 10f;
        }
    }
}
