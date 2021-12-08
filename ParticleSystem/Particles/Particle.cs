using System;
using System.Drawing;

namespace ParticleSystem.Particles
{
    public class Particle
    {
        public int Radius; 
        public float X;
        public float Y; 

        public float SpeedX; 
        public float SpeedY; 
        public float Life;

        public static Random Rand = new Random();
        
        public Particle()
        {
            var direction = (double)Rand.Next(360);
            var speed = 1 + Rand.Next(10);
                
            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            Life = Rand.Next(60, 160);
        }

        public virtual void Draw(Graphics g)
        {
            var k = Math.Min(1f, Life / 100);
            var alpha = (int)(k * 255);
            
            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }
}
