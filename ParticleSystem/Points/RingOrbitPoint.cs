using System;
using ParticleSystem.Particles;

namespace ParticleSystem.Points
{
    public class RingOrbitPoint : ImpactPoint
    {
        public override void ImpactParticle(Particle particle)
        {
            var gX = X - particle.X;
            var gY = Y - particle.Y;
            var r = Math.Sqrt(gX * gX + gY * gY);

            if (r > (Diametr + Range) / 2 || r < (Diametr - Range) / 2) return;

            var r2 = Math.Max(100, gX * gX + gY * gY);

            switch (particle)
            {
                case Sattelite sattelite:
                    if (sattelite.IsOnPlanetOrbit == false)
                    {
                        particle.SpeedX += gX / r2;
                        particle.SpeedY += gY / r2;
                    }
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
    }
}