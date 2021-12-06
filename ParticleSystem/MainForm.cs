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
        public List<Particle> Particles = new List<Particle>();
        public MainForm()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            for(var i = 0; i < 500; i++)
            {
                Particles.Add(new Particle(
                    picDisplay.Image.Width / 2, 
                    picDisplay.Image.Height / 2)
                );
            }
        }

    }
}
