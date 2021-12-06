using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParticleSystem.Emitters;
using ParticleSystem.Points;

namespace ParticleSystem
{
    public partial class MainForm : Form
    {
        private readonly List<Emitter> _emitters = new();
        private readonly Emitter _emitter;
        public MainForm()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            _emitter = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.HotPink,
                ColorTo = Color.FromArgb(0, Color.White),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            _emitters.Add(_emitter);

            _emitter.ImpactPoints.Add(new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            });
            
            _emitter.ImpactPoints.Add(new GravityPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
            });
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            var g = Graphics.FromImage(picDisplay.Image);
            g.Clear(Color.Black);

            foreach (var emitter in _emitters)
            {
                emitter.UpdateState(); 
                emitter.Render(g); 
            }


            afuksahfk.Text = _emitter.Particles.Count.ToString();
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            _emitter.MousePositionX = e.X;
            _emitter.MousePositionY = e.Y;
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            _emitter.Direction = tbDirection.Value;
            lblDirection.Text = $@"{tbDirection.Value}°"; 
        }

        private void tbSpreading_Scroll(object sender, EventArgs e)
        {
            _emitter.Spreading = tbSpreading.Value;
            lblSpreading.Text = $@"{tbSpreading.Value}°";
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            foreach (var p in _emitter.ImpactPoints)
            {
                if (p is GravityPoint point) 
                {
                    point.Power = tbGraviton.Value;
                }
            }
        }
    }
}
