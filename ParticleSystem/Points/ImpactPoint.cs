using System.Drawing;
using ParticleSystem.Emitters;
using ParticleSystem.Particles;

namespace ParticleSystem.Points
{
    public abstract class ImpactPoint
    {
        public float X; 
        public float Y;
        public float Diametr;
        public float Range;
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

        public virtual void RenderRange(Graphics graphics)
        {
            graphics.DrawEllipse(
                new Pen(Color),
                X - (Diametr + Range) / 2f,
                Y - (Diametr + Range) / 2f,
                Diametr + Range,
                Diametr + Range
            );
            graphics.DrawEllipse(
                new Pen(Color),
                X - (Diametr - Range) / 2f,
                Y - (Diametr - Range) / 2f,
                Diametr - Range,
                Diametr - Range
            );
        }
    }
}