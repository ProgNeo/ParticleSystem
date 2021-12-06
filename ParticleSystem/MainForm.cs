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

            /*
            _emitter = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.HotPink,
                ColorTo = Color.FromArgb(0, Color.White),
                ParticlesPerTick = 1,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };
            */
            _emitter = new TopEmitter()
            {
                SpeedMin = 10,
                SpeedMax = 10,
                ParticlesPerTick = 10,
                Width = picDisplay.Width
            };

            _emitters.Add(_emitter);
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

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            switch (cbColorPoint.Text)
            {
                case "Красный":
                    _emitter.ImpactPoints.Add(new RepaintingPoint()
                    {
                        X = e.X,
                        Y = e.Y,
                        RepaintTo = Color.Red
                    });
                    break;
                case "Ораньжевый":
                    _emitter.ImpactPoints.Add(new RepaintingPoint()
                    {
                        X = e.X,
                        Y = e.Y,
                        RepaintTo = Color.Orange
                    });
                    break;
                case "Жёлтый":
                    _emitter.ImpactPoints.Add(new RepaintingPoint()
                    {
                        X = e.X,
                        Y = e.Y,
                        RepaintTo = Color.Yellow
                    });
                    break;
                case "Зелёный":
                    _emitter.ImpactPoints.Add(new RepaintingPoint()
                    {
                        X = e.X,
                        Y = e.Y,
                        RepaintTo = Color.LimeGreen
                    });
                    break;
                case "Голубой":
                    _emitter.ImpactPoints.Add(new RepaintingPoint()
                    {
                        X = e.X,
                        Y = e.Y,
                        RepaintTo = Color.Cyan
                    });
                    break;
                case "Синий":
                    _emitter.ImpactPoints.Add(new RepaintingPoint()
                    {
                        X = e.X,
                        Y = e.Y,
                        RepaintTo = Color.Blue
                    });
                    break;
                case "Фиолетовый":
                    _emitter.ImpactPoints.Add(new RepaintingPoint()
                    {
                        X = e.X,
                        Y = e.Y,
                        RepaintTo = Color.MediumPurple
                    });
                    break;
            }
        }
    }
}
