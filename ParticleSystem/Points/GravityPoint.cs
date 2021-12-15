﻿using System;
using System.Drawing;
using ParticleSystem.Particles;

namespace ParticleSystem.Points
{
    public class GravityPoint : ImpactPoint
    {
        public float Power = 100;
        // ReSharper disable once InconsistentNaming
        public Color mColor = Color.White;

        public override void ImpactParticle(Particle particle)
        {
            var gX = X - particle.X;
            var gY = Y - particle.Y;
            var r = Math.Sqrt(gX * gX + gY * gY);

            if (!(r + particle.Radius < Power)) return;

            var r2 = Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX += gX * Power / r2;
            particle.SpeedY += gY * Power / r2;
        }

        public override void Render(Graphics graphics)
        {
            graphics.DrawEllipse(
                new Pen(mColor),
                X - Power / 2f,
                Y - Power / 2f,
                Power,
                Power
            );
        }
    }
}