using System;
using System.Drawing;
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
            var gX = X - particle.X;
            var gY = Y - particle.Y;
            var r = Math.Sqrt(gX * gX + gY * gY);
            
            if (r > (Diametr + Range) / 2 || r < (Diametr - Range) / 2) return;

            var r2 = Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX += gX / r2;
            particle.SpeedY += gY / r2;

            particle.X += Planet.SpeedX;
            particle.Y += Planet.SpeedY;

            if (particle is Sattelite sattelite)
            {
                sattelite.IsOnPlanetOrbit = true;
            }
        }
    }
}