using System;
using System.Collections.Generic;
using System.Drawing;
using ParticleSystem.Particles;
using ParticleSystem.Points;

namespace ParticleSystem.Emitters
{
    public class SunEmitter : Emitter
    {
        public List<Emitter> Emmiters = new List<Emitter>();
        public int ParticlesToCreate;
        public float OrbitDiametr;
        public Random Rand = new();

        public override void ResetParticle(Particle particle)
        {
            particle.Life = 100;

            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.Rand.Next(Spreading) - Spreading / 2f;

            if (particle is ParticleColorful colorful)
            {
                colorful.FromColor = ColorFrom;
                colorful.ToColor = ColorTo;
            }

            var speed = Particle.Rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.Rand.Next(RadiusMin, RadiusMax);
        }

        public override void UpdateState()
        {
            for (var i = 0; i < Particles.Count; i++)
            {
                ImpactPoints[i].ImpactParticle(Particles[i]);

                Particles[i].X += Particles[i].SpeedX;
                Particles[i].Y += Particles[i].SpeedY;
            }

            while (ParticlesToCreate >= 1)
            {
                ParticlesToCreate -= 1;
                var particle = CreateParticle();
                var orbit = new OrbitPoint()
                {
                    X = this.X,
                    Y = this.Y,
                    Diametr = OrbitDiametr * 2,
                };

                var particlesToCreate = Rand.Next(0, 5);
                var orbitDiametr = Rand.Next(150, 170);

                var emitter = new PlanetEmitter()
                {
                    Direction = 0,
                    Spreading = 1,
                    RadiusMin = 2,
                    RadiusMax = 4,
                    GravitationX = 0,
                    GravitationY = 0,
                    SpeedMin = 1,
                    SpeedMax = 1,
                    ParticlesToCreate = particlesToCreate,
                    OrbitDiametr = orbitDiametr,
                    X = this.X,
                    Y = this.Y
                };

                Emmiters.Add(emitter);

                ResetParticle(particle);
                particle.Y -= OrbitDiametr;
                Particles.Add(particle);
                ImpactPoints.Add(orbit);
                OrbitDiametr += Rand.Next(90, 110);
            }
        }
    }
}