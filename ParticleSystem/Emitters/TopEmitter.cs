using System;
using System.Windows.Forms;

namespace ParticleSystem.Emitters
{
    public class TopEmitter : Emitter
    {
        public int Width;
        
        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);

            particle.Life = Particle.Rand.Next(80, 100);

            particle.X = Particle.Rand.Next(Width);
            particle.Y = 0; 

            particle.SpeedY = 1;
            particle.SpeedX = Particle.Rand.Next(-2, 2);
        }
    }
}