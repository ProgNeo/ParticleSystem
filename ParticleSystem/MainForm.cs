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
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            _emitters.Add(_emitter);
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            _emitter.UpdateState(); 

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                _emitter.Render(g);
            }

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
    }
}
