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
        private bool _isRangeOfOrbitsActive = false;

        private readonly Random _random = new();

        private TrackBar[] _trackBars;

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

            _sunEmitter = new SunEmitter()
            {
                Direction = 0,
                Spreading = 5,
                RadiusMin = 5,
                RadiusMax = 10,
                GravitationX = 0,
                GravitationY = 0,
                SpeedMin = 1,
                SpeedMax = 1,
                PlanetsToCreate = planetsToCreate,
                ParticlesPerTick = 1,
                OrbitRadius = orbitRadius,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2
            };

            _sunEmitter.CreatePlanets();
        }

        private void CreateTrackBars()
        {
            var space = 51;
            _trackBars = new TrackBar[_sunEmitter.PlanetOrbitPoints.Count];

            for (var i = 0; i < _trackBars.Length; i++)
            {
                _trackBars[i] = new TrackBar()
                {
                    Name = i.ToString(),
                    Visible = true,
                    Location = new Point(1285, 27 + space),
                    Height = 45,
                    Width = 287,
                    Minimum = 0,
                    Maximum = 1000,
                    Value = (int)_sunEmitter.PlanetOrbitPoints[i].Diametr
                };
                _trackBars[i].Scroll += ChangeOrbitDiametr!;
                this.Controls.Add(_trackBars[i]);
                space += 51;
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

            RenderSun(graphics);
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
            _trackBars = Array.Empty<TrackBar>();
            GenerateSytem();
            CreateTrackBars();
        }

        private void ChangeOrbitDiametr(object sender, EventArgs e)
        {
            var track = sender as TrackBar;
            _sunEmitter.PlanetOrbitPoints[int.Parse(track!.Name)].Diametr = track.Value;
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
    }
}
