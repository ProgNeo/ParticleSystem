using System;
using System.Collections.Generic;
using System.Drawing;
using ParticleSystem.Points;

namespace ParticleSystem.Particles
{
    public class Planet : Particle
    {
        public List<SatteliteOrbitPoint> SattelitesOrbits = new();
        
        public void ChangeOrbitsPositions()
        {
            foreach (var orbit in SattelitesOrbits)
            {
                orbit.X = this.X;
                orbit.Y = this.Y;
            }
        }
    }
}
