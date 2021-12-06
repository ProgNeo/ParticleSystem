using System;
using System.Collections.Generic;
using System.Drawing;

namespace ParticleSystem
{
    public class Emitter
    {
        private readonly List<Particle> _particles = new();
        public List<IImpactPoint> ImpactPoints = new();

        public int MousePositionX = 0;
        public int MousePositionY = 0;

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
        public int LifeMin = 20;
        public int LifeMax = 100;

        public int ParticlesPerTick = 1;

        public Color ColorFrom = Color.White; 
        public Color ColorTo = Color.FromArgb(0, Color.Black);

        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful
            {
                FromColor = ColorFrom,
                ToColor = ColorTo
            };

            return particle;
        }
        public void UpdateState()
        {
            var particlesToCreate = ParticlesPerTick;

            foreach (var particle in _particles)
            {
                if (particle.Life <= 0)
                {
                    if (particlesToCreate <= 0) continue;
                    particlesToCreate -= 1;
                    ResetParticle(particle);
                }
                else
                {
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
                var particle = CreateParticle();
                ResetParticle(particle);
                _particles.Add(particle);
            }
        }
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.Rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.Rand.Next(Spreading) - Spreading / 2;

            var speed = Particle.Rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.Rand.Next(RadiusMin, RadiusMax);
        }

        public void Render(Graphics graphics)
        {
            foreach (var particle in _particles)
            {
                particle.Draw(graphics);
            }

            foreach (var point in ImpactPoints)
            {
                point.Render(graphics);
            }
        }
    }
}