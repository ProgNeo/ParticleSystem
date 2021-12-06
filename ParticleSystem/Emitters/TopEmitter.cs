using System.Windows.Forms;

namespace ParticleSystem.Emitters
{
    public class TopEmitter : Emitter
    {
        public int Width;

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);
            
            particle.X = Particle.Rand.Next(Width);
            particle.Y = 0; 

            particle.SpeedY = 1;
            particle.SpeedX = Particle.Rand.Next(-2, 2);
        }
    }
}