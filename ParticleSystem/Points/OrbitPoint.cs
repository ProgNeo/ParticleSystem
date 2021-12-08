using System;
using System.Drawing;
using ParticleSystem.Particles;

namespace ParticleSystem.Points
{
    public class OrbitPoint : ImpactPoint
    {
        public float Diametr;
        public override void ImpactParticle(Particle particle)
        {
            var gX = X - particle.X;
            var gY = Y - particle.Y;
            var r = Math.Sqrt(gX * gX + gY * gY);

            if (!(r + particle.Radius < Diametr)) return;

            var r2 = Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX += gX / r2;
            particle.SpeedY += gY / r2;
        }

        public override void Render(Graphics graphics)
        {
            graphics.DrawEllipse(
                new Pen(Color.White),
                X - Diametr / 2f,
                Y - Diametr / 2f,
                Diametr,
                Diametr
            );
        }
    }
}