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
        private readonly Emitter _emitter = new();
        public MainForm()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            _emitter.GravityPoints.Add(new Point(
                picDisplay.Width / 2, picDisplay.Height / 2
            ));
       
            _emitter.GravityPoints.Add(new Point(
                (int)(picDisplay.Width * 0.75), picDisplay.Height / 2
            ));

            _emitter.GravityPoints.Add(new Point(
                (int)(picDisplay.Width * 0.25), picDisplay.Height / 2
            ));
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
    }
}
