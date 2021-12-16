using System;
using System.Drawing;
using ParticleSystem.Particles;

namespace ParticleSystem.Points
{
    public class PlanetOrbitPoint : ImpactPoint
    {
        public float Diametr;
        public float Range = 10;
        // ReSharper disable once InconsistentNaming
        public Color Color = Color.White;
        
        public override void ImpactParticle(Particle particle)
        {
            var gX = X - particle.X;
            var gY = Y - particle.Y;
            var r = Math.Sqrt(gX * gX + gY * gY);
            
            if (r > (Diametr + Range) / 2 || r < (Diametr - Range) / 2) return;

            var r2 = Math.Max(100, gX * gX + gY * gY);
            
            switch (particle)
            {
                case Sattelite:
                    particle.SpeedX += gX / r2 / 3;
                    particle.SpeedY += gY / r2 / 3;
                    break;
                case Asteroid:
                    particle.SpeedX += gX * Diametr / r2;
                    particle.SpeedY += gY * Diametr / r2;
                    break;
                default:
                    particle.SpeedX += gX / r2;
                    particle.SpeedY += gY / r2;
                    break;
            }
        }

        public override void Render(Graphics graphics)
        {
            graphics.DrawEllipse(
                new Pen(Color),
                X - Diametr / 2f,
                Y - Diametr / 2f,
                Diametr,
                Diametr
            );
            graphics.DrawEllipse(
                new Pen(Color),
                X - (Diametr + Range) / 2f,
                Y - (Diametr + Range) / 2f,
                (Diametr + Range),
                (Diametr + Range)
            );
            graphics.DrawEllipse(
                new Pen(Color),
                X - (Diametr - Range) / 2f,
                Y - (Diametr - Range) / 2f,
                (Diametr - Range),
                (Diametr - Range)
            );
        }
    }
}