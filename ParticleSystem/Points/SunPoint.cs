using System;
using ParticleSystem.Particles;

namespace ParticleSystem.Points
{
    public class SunPoint : ImpactPoint
    {
        public float Power = 1f;

        public override void ImpactParticle(Particle particle)
        {
            var gX = X - particle.X;
            var gY = Y - particle.Y;
            var r = Math.Sqrt(gX * gX + gY * gY);

            if (r > Diametr / 2) return;

            var r2 = Math.Max(100, gX * gX + gY * gY);

            switch (particle)
            {
                case Sattelite sattelite:
                    if (sattelite.IsOnPlanetOrbit == false)
                    {
                        particle.SpeedX += gX / r2 * particle.Speed * particle.Speed * Power;
                        particle.SpeedY += gY / r2 * particle.Speed * particle.Speed * Power;
                    }
                    break;
                default:
                    particle.SpeedX += gX / r2 * particle.Speed * particle.Speed * Power;
                    particle.SpeedY += gY / r2 * particle.Speed * particle.Speed * Power;
                    break;
            }
        }
    }
}