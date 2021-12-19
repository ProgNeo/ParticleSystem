using System;
using ParticleSystem.Particles;

namespace ParticleSystem.Points
{
    public class SatteliteOrbitPoint : ImpactPoint
    {
        public Planet Planet;

        public SatteliteOrbitPoint(Planet planet)
        {
            Planet = planet;
        }

        public override void ImpactParticle(Particle particle)
        {
            if (particle is not Sattelite sattelite) return;

            var gX = X - particle.X;
            var gY = Y - particle.Y;
            var r = Math.Sqrt(gX * gX + gY * gY);

            if (r > Diametr / 2) return;

            var r2 = Math.Max(100, gX * gX + gY * gY);
                
            particle.SpeedX += gX / r2 * particle.Speed * particle.Speed;
            particle.SpeedY += gY / r2 * particle.Speed * particle.Speed;
            particle.X += Planet.SpeedX;
            particle.Y += Planet.SpeedY;
            sattelite.IsOnPlanetOrbit = true;
        }
    }
}