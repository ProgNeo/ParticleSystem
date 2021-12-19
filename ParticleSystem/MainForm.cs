using ParticleSystem.Emitters;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ParticleSystem.Particles;
using ParticleSystem.Points;

namespace ParticleSystem
{
    public partial class MainForm : Form
    {
        private SunEmitter _sunEmitter = new();

        private bool _isAttractionVisible = true;

        private readonly Random _random = new();
        private Particle? _selectedParticle = null;

        public MainForm()
        {
            InitializeComponent();
            GenerateSytem();
        }

        private void GenerateSytem()
        {
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            var planetsToCreate = _random.Next(2, 4);

            _sunEmitter = new SunEmitter
            {
                Direction = 0,
                Spreading = 5,
                RadiusMin = 10,
                RadiusMax = 16,
                GravitationX = 0,
                GravitationY = 0,
                SpeedMin = 2,
                SpeedMax = 2,
                PlanetsToCreate = planetsToCreate,
                ParticlesPerTick = 1,
                OrbitRadius = 150,
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
                X = picDisplay.Width / 2f,
                Y = picDisplay.Height / 2f,
                Radius = 70,
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            var graphics = Graphics.FromImage(picDisplay.Image);
            graphics.Clear(Color.Black);

            _sunEmitter.UpdateState();
            _sunEmitter.RenderParticles(graphics);
            if (_isAttractionVisible)
            {
                _sunEmitter.RenderImpactPoints(graphics);
            }
            
            picDisplay.Invalidate();
        }

        //Переключение отображения орбит
        private void changeAttractionVision_Click(object sender, EventArgs e)
        {
            _isAttractionVisible = !_isAttractionVisible;
        }

        //Пересоздание системы
        private void generateBtn_Click(object sender, EventArgs e)
        {
            GenerateSytem();
            selectedParticleSpeed.Enabled = false;
            sunAttractionTrackBar.Value = 10;
        }
        
        //Изменение силы притяжения солнца
        private void sunAttractionTrackBar_Scroll(object sender, EventArgs e)
        {
            _sunEmitter.SunPoint.Power = sunAttractionTrackBar.Value / 10f;
        }

        //Выбор частицы нажатием кнопки мыши
        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (_selectedParticle != null)
            {
                _selectedParticle.Selected = false;
                _selectedParticle = null;
                selectedParticleSpeed.Enabled = false;
            }

            foreach (var particle in _sunEmitter.Particles.Where(particle => 
                         Math.Abs(particle.X - e.X) <= particle.Radius + 1 && 
                         Math.Abs(particle.Y - e.Y) <= particle.Radius + 1)
                     )
            {
                _selectedParticle = particle;
                particle.Selected = true;
                selectedParticleSpeed.Value = (int) particle.Speed * 10;
                selectedParticleSpeed.Enabled = true;
                break;
            }
        }

        //Изменение скорости выбранной частицы
        private void selectedParticleSpeed_Scroll(object sender, EventArgs e)
        {
            _selectedParticle!.Speed = selectedParticleSpeed.Value / 10f;
        }
    }
}
