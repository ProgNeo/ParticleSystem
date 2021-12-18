using System.Drawing;

namespace ParticleSystem.Particles
{
    public class Sun : Particle
    {
        public override void Draw(Graphics g)
        {
            g.FillEllipse(
                new SolidBrush(Color.FromArgb(100, Color)),
                X - Radius, 
                Y - Radius, 
                Radius * 2, 
                Radius * 2
            );
            g.FillEllipse(
                new SolidBrush(Color.FromArgb(155, Color)),
                X - Radius + 5, 
                Y - Radius + 5, 
                (Radius * 2) - 10,
                (Radius * 2) - 10
            );
            g.FillEllipse(
                new SolidBrush(Color.FromArgb(255, Color)),
                X - Radius + 10,
                Y - Radius + 10,
                (Radius * 2) - 20,
                (Radius * 2) - 20
            );
        }
    }
}
