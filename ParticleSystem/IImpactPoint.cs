using System.Drawing;

namespace ParticleSystem
{
    public abstract class IImpactPoint
    {
        public float X; 
        public float Y;
        
        public abstract void ImpactParticle(Particle particle);

        public void Render(Graphics g)
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