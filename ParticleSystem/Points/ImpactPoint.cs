using System.Drawing;
using ParticleSystem.Emitters;
using ParticleSystem.Particles;

namespace ParticleSystem.Points
{
    public abstract class ImpactPoint
    {
        public float X; 
        public float Y;
        
        public abstract void ImpactParticle(Particle particle);
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                new SolidBrush(Color.Red),
                X - 5,
                Y - 5,
                10,
                10
            );
        }
    }
}