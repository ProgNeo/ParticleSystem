using System;
using System.Drawing;

namespace ParticleSystem.Particles
{
    public class Particle
    {
        public int Radius;
        public float X;
        public float Y;

        public float Speed;

        public float SpeedX;
        public float SpeedY;
        public float Life;

        public Color Color = Color.White;
        public static Random Random = new();
        public Action<Particle, Particle>? OnOverlap;

        public bool Selected = false;

        public Particle()
        {
            var direction = (double)Random.Next(360);
            var speed = 1 + Random.Next(10);
                
            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            Life = Random.Next(60, 160);
        }

        public virtual void Draw(Graphics g)
        {
            var k = Math.Min(1f, Life / 100);
            var alpha = (int)(k * 255);
            
            var color = Color.FromArgb(alpha, Color);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            if (Selected == true)
            {
                g.DrawEllipse(
                    new Pen(Color.Aqua, 3),
                    X - Radius,
                    Y - Radius,
                    Radius * 2 + 1,
                    Radius * 2 + 1
                );
            }

            b.Dispose();
        }

        public virtual bool Overlaps(Particle particle)
        {
            var distance = Math.Sqrt((particle.X - X) * (particle.X - X) + (particle.Y - Y) * (particle.Y - Y));

            return distance <= particle.Radius + Radius;
        }

        //Вызов делегата при пересечении
        public virtual void Overlap(Particle particle)
        {
            OnOverlap?.Invoke(this, particle);
        }
    }
}
