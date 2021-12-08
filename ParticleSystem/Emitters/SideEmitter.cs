using ParticleSystem.Particles;

namespace ParticleSystem.Emitters
{
    public class SideEmitter : Emitter
    {
        public int Height;
        public int Width;

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);

            particle.Life = Particle.Rand.Next(250, 250);

            particle.X = Width;
            particle.Y = Particle.Rand.Next(Height);

            particle.SpeedY = 0;
            particle.SpeedX = Particle.Rand.Next(-2, 2);
        }
    }
}