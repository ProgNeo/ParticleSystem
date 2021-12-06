using System;

namespace ParticleSystem.Points
{
    public class AntiGravityPoint : ImpactPoint
    {
        public int Power = 100;
        public override void ImpactParticle(Particle particle)
        {
            var gX = X - particle.X;
            var gY = Y - particle.Y;
            var r2 = Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX -= gX * Power / r2;
            particle.SpeedY -= gY * Power / r2;
        }
    }
}