using System.Drawing;
using ParticleSystem.Particles;

namespace ParticleSystem.Points
{
    public abstract class ImpactPoint
    {
        public float X; 
        public float Y;
        public float Diametr;
        public Color Color = Color.White;

        public abstract void ImpactParticle(Particle particle);
        public virtual void Render(Graphics graphics)
        {
            graphics.DrawEllipse(
                new Pen(Color),
                X - Diametr / 2f,
                Y - Diametr / 2f,
                Diametr,
                Diametr
            );
        }
    }
}