using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ParticleSystem.Particles;
using ParticleSystem.Points;

namespace ParticleSystem.Emitters
{
    public class SunEmitter : Emitter
    {
        public List<Emitter> Emmiters = new List<Emitter>();
        public Emitter? RingEmitter = null;
        public int ParticlesToCreate;
        public float OrbitRadius;
        public Random Rand = new();
        public bool IsRingExist = false;

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

                if (Emmiters[i] is not PlanetEmitter planetEmmiter) continue;
                planetEmmiter.SpeedX = Particles[i].SpeedX;
                planetEmmiter.SpeedY = Particles[i].SpeedY;

                planetEmmiter.X += planetEmmiter.SpeedX;
                planetEmmiter.Y += planetEmmiter.SpeedY;
            }
            
            while (ParticlesToCreate >= 1)
            {
                if (IsRingExist == false && Rand.Next(10) % 5 == 2)
                {
                    IsRingExist = true;
                    var emitter = new Emitter
                    {
                        GravitationY = 0,
                        Direction = 0,
                        Spreading = 10,
                        SpeedMin = (int)Math.Sqrt(OrbitRadius * 2),
                        SpeedMax = (int)Math.Sqrt(OrbitRadius * 2),
                        LifeMin = 100,
                        LifeMax = 300,
                        ColorFrom = Color.White,
                        ColorTo = Color.FromArgb(0, Color.Gray),
                        ParticlesPerTick = 3,
                        X = this.X, 
                        Y = this.Y - OrbitRadius
                    };
                    emitter.ImpactPoints.Add(new RingPoint
                    {
                        Diametr = OrbitRadius * 2,
                        X = this.X,
                        Y = this.Y,
                    });
                    RingEmitter = emitter;
                }

                else
                {
                    var randomColor = Color.FromArgb(Rand.Next(256),
                        Rand.Next(256), Rand.Next(256));
                    ColorFrom = randomColor;
                    ColorTo = randomColor;

                    var particle = CreateParticle();
                    var orbit = new OrbitPoint()
                    {
                        mColor = randomColor,
                        X = this.X,
                        Y = this.Y,
                        Diametr = OrbitRadius * 2,
                    };

                    var particlesToCreate = Rand.Next(0, 5);
                    var orbitDiametr = Rand.Next(25, 30);

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
                        OrbitRadius = orbitDiametr,
                        X = this.X,
                        Y = this.Y - OrbitRadius
                    };

                    Emmiters.Add(emitter);

                    ResetParticle(particle);
                    particle.Y -= OrbitRadius;
                    Particles.Add(particle);
                    ImpactPoints.Add(orbit);
                }

                ParticlesToCreate -= 1;
                OrbitRadius += Rand.Next(120, 150);
            }
        }
    }
}