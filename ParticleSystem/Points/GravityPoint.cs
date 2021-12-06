using System;
using System.Drawing;

namespace ParticleSystem.Points
{
    public class GravityPoint : IImpactPoint
    {
        public int Power = 100;

        public override void ImpactParticle(Particle particle)
        {
            var gX = X - particle.X;
            var gY = Y - particle.Y;
            var r = Math.Sqrt(gX * gX + gY * gY);

            if (!(r + particle.Radius < Power / 2)) return;

            var r2 = Math.Max(100, gX * gX + gY * gY);
            particle.SpeedX += gX * Power / r2;
            particle.SpeedY += gY * Power / r2;
        }

        public override void Render(Graphics graphics)
        {
            graphics.DrawEllipse(
                new Pen(Color.Red),
                X - Power / 2,
                Y - Power / 2,
                Power,
                Power
            );
        }
    }
}