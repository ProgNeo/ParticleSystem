using System;
using System.Collections.Generic;
using System.Drawing;
using ParticleSystem.Particles;
using ParticleSystem.Points;

namespace ParticleSystem.Emitters
{
    public class Emitter
    {
        public List<Particle> Particles = new();
        public List<ImpactPoint> ImpactPoints = new();
        
        public float GravitationX = 0;
        public float GravitationY = 1;

        public int X;
        public int Y;
        public int Direction = 0;
        public int Spreading = 360;
        public int SpeedMin = 1;
        public int SpeedMax = 10;
        public int RadiusMin = 2;
        public int RadiusMax = 10;
        public int ParticlesPerTick = 1;

        public Color ColorFrom = Color.White;
        public Color ColorTo = Color.FromArgb(0, Color.Black);

        public virtual void ResetParticle(Particle particle)
        {
            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.Random.Next(Spreading) - Spreading / 2f;
            
            var speed = Particle.Random.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.Random.Next(RadiusMin, RadiusMax);
        }

        public virtual void UpdateState()
        {
            var particlesToCreate = ParticlesPerTick;

            foreach (var particle in Particles)
            {
                if (particle.Life <= 0)
                {
                    if (particlesToCreate <= 0) continue;
                    particlesToCreate -= 1;
                    ResetParticle(particle);
                }
                else
                {
                    particle.Life -= 1;
                    foreach (var point in ImpactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }

            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = new Particle();
                ResetParticle(particle);
                Particles.Add(particle);
            }
        }

        public void RenderParticles(Graphics graphics)
        {
            foreach (var particle in Particles)
            {
                particle.Draw(graphics);
            }
        }

        public void RenderImpactPoints(Graphics graphics)
        {
            foreach (var point in ImpactPoints)
            {
                point.Render(graphics);
            }
        }

        public void RenderRangeOfImpactPoints(Graphics graphics)
        {
            foreach (var point in ImpactPoints)
            {
                point.RenderRange(graphics);
            }
        }
    }
}