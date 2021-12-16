using System;
using System.Collections.Generic;
using System.Drawing;
using ParticleSystem.Particles;
using ParticleSystem.Points;

namespace ParticleSystem.Emitters
{
    public class PlanetEmitter : Emitter
    {
        public int ParticlesToCreate;
        public float OrbitRadius;
        public Random Rand = new();
        public float SpeedX;
        public float SpeedY;

        public override void ResetParticle(Particle particle)
        {
            particle.Life = 100;

            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.Random.Next(Spreading) - Spreading / 2f;

            if (particle is ParticleColorful colorful)
            {
                colorful.FromColor = ColorFrom;
                colorful.ToColor = ColorTo;
            }

            var speed = Particle.Random.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.Random.Next(RadiusMin, RadiusMax);
        }

        public override void UpdateState()
        {
            for (var i = 0; i < Particles.Count; i++)
            {
                ImpactPoints[i].ImpactParticle(Particles[i]);

                Particles[i].X += Particles[i].SpeedX + this.SpeedX;
                Particles[i].Y += Particles[i].SpeedY + this.SpeedY;
                ImpactPoints[i].X = this.X;
                ImpactPoints[i].Y = this.Y;
            }

            while (ParticlesToCreate >= 1)
            {
                var rnd = new Random();

                var randomColor = Color.FromArgb(rnd.Next(256), 
                    rnd.Next(256), rnd.Next(256));
                ParticlesToCreate -= 1;
                ColorFrom = randomColor;
                ColorTo = randomColor;
                var particle = CreateParticle();
                var orbit = new PlanetOrbitPoint()
                {
                    Color = randomColor,
                    X = this.X,
                    Y = this.Y,
                    Diametr = OrbitRadius * 2,
                };
                ResetParticle(particle);
                particle.Y -= OrbitRadius;
                Particles.Add(particle);
                ImpactPoints.Add(orbit);
                OrbitRadius += Rand.Next(7, 10);
            }
        }
    }
}