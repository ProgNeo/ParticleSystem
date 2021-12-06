﻿using System;
using System.Drawing;

namespace ParticleSystem.Points
{
    public class RepaintingPoint : ImpactPoint
    {
        public Color RepaintTo;
        public int Diametr = 50;
        public override void ImpactParticle(Particle particle)
        {
            var gX = X - particle.X;
            var gY = Y - particle.Y;
            var r = Math.Sqrt(gX * gX + gY * gY);

            if (!(r + particle.Radius / 2 <= Diametr / 2)) return;

            if (particle is not ParticleColorful colorful) return;
            
            colorful.FromColor = RepaintTo;
        }

        public override void Render(Graphics graphics)
        {
            graphics.DrawEllipse(
                new Pen(RepaintTo),
                X - Diametr / 2,
                Y - Diametr / 2,
                Diametr,
                Diametr
            );
        }
    }
}