using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class Particle
    {
        public float X;
        public float Y;
        public int Radius;

        public float Direction;
        public float Speed;
        public float Life;

        public static readonly Random Rand = new();

        public Particle()
        {
            Direction = Rand.Next(0, 360);
            Speed = Rand.Next(1, 5);
            Radius = Rand.Next(2, 10);
            Life = Rand.Next(20, 100);
        }
        public Particle(int x, int y) 
        {
            Direction = Rand.Next(0, 360);
            Speed = Rand.Next(1, 5);
            Radius = Rand.Next(2, 10);
            Life = Rand.Next(20, 100);
            X = x;
            Y = y;
        }
        public virtual void Draw(Graphics graphics)
        {
            var k = Math.Min(1f, Life / 100);
            var alpha = (int)(k * 255);
            
            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);

            graphics.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }

    public class ParticleColorful : Particle
    {
        public Color FromColor;
        public Color ToColor;
        
        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }
        
        public override void Draw(Graphics g)
        {
            var k = MathF.Min(1f, Life / 100);
            
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }
}
