using System;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using ParticleSystem.Particles;
using ParticleSystem.Points;

namespace ParticleSystem.Emitters
{
    public class SunEmitter : Emitter
    {
        public int PlanetsToCreate;
        public float OrbitRadius;

        public Point RingPoint = new(0, 0);
        public int RingSpeed;

        public Random Random = new();

        public override void ResetParticle(Particle particle)
        {
            particle.X = this.X;
            particle.Y = this.Y;
                
            var direction = particle is Asteroid ? Random.Next(Spreading) : (Random.Next(2) == 1 ? 0 : 180);
            var speed = particle is Asteroid ? RingSpeed : SpeedMin;

            particle.SpeedX = (float)(Math.Cos(direction / 180f * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180f * Math.PI) * speed);

            particle.OnOverlap += (particle1, particle2) =>
            {
                if (particle1.Radius > particle2.Radius)
                {
                    particle2.SpeedY += particle1.SpeedY * particle1.Radius / particle2.Radius;
                    particle2.SpeedX += particle1.SpeedX * particle1.Radius / particle2.Radius;

                    particle1.SpeedY -= particle2.SpeedY * particle2.Radius / particle1.Radius;
                    particle1.SpeedX -= particle2.SpeedX * particle2.Radius / particle1.Radius;
                }
                else
                {
                    particle1.SpeedY += particle2.SpeedY * particle2.Radius / particle1.Radius;
                    particle1.SpeedX += particle2.SpeedX * particle2.Radius / particle1.Radius;

                    particle2.SpeedY -= particle1.SpeedY * particle1.Radius / particle2.Radius;
                    particle2.SpeedX -= particle1.SpeedX * particle1.Radius / particle2.Radius;
                }
            };
        }

        public override void UpdateState()
        {
            var particlesToCreate = ParticlesPerTick;

            for (var i = 0; i < Particles.Count; i++)
            {
                for (var j = i + 1; j < Particles.Count; j++)
                {
                    if (Particles[i] is not Asteroid && Particles[i].Overlaps(Particles[j]))
                    {
                        Particles[i].Overlap(Particles[j]);
                    }
                }

                if (Particles[i] is Sattelite sattelite)
                {
                    sattelite.IsOnPlanetOrbit = false;
                }

                foreach (var point in ImpactPoints)
                {
                    point.ImpactParticle(Particles[i]);
                }

                Particles[i].X += Particles[i].SpeedX;
                Particles[i].Y += Particles[i].SpeedY;


                if (Particles[i] is Planet planet)
                {
                    planet.ChangeOrbitsPositions();
                }
            }

            while (RingPoint.X != 0 && Particles.Count < 175 && particlesToCreate > 0)
            {
                particlesToCreate -= 1;
                var particle = new Asteroid
                {
                    FromColor = Color.White,
                    ToColor = Color.Gray,
                    Radius = Random.Next(5, 9)
                };
                ResetParticle(particle);
                particle.X = RingPoint.X;
                particle.Y = RingPoint.Y;
                Particles.Add(particle);
            }
        }

        //Создаются планеты и их орбиты
        public void CreatePlanets()
        {
            while (PlanetsToCreate > 0)
            {
                var randomColor = Color.FromArgb(Random.Next(256),
                    Random.Next(256), Random.Next(256));

                ImpactPoint orbit = new PlanetOrbitPoint
                {
                    Color = randomColor,
                    X = this.X,
                    Y = this.Y,
                    Diametr = OrbitRadius * 2,
                    Range = 10
                };

                if (RingPoint.X == 0 && Random.Next(10) % 4 == 2)
                {
                    RingPoint = new Point(this.X, (int) (this.Y - OrbitRadius));
                    RingSpeed = (int) Math.Sqrt(OrbitRadius * 2);
                    orbit = new RingOrbitPoint
                    {
                        X = this.X,
                        Y = this.Y,
                        Diametr = OrbitRadius * 2,
                        Color = Color.White,
                        Range = 70,
                    };
                }

                else
                {
                    var particle = new Planet
                    {
                        Color = randomColor,
                        Radius = Random.Next(9, 16)
                    };

                    ResetParticle(particle);
                    particle.Y -= OrbitRadius;

                    CreateSattelitesOfPlanet(particle);
                    Particles.Add(particle);
                }

                ImpactPoints.Add(orbit);
                PlanetsToCreate -= 1;
                OrbitRadius += Random.Next(120, 150);
            }
        }

        //Создаются спутники планеты
        private void CreateSattelitesOfPlanet(Planet planet)
        {
            var sattelitesToCreate = Random.Next(2, 5);
            var orbitRadius = Random.Next(25, 30);

            while (sattelitesToCreate > 0)
            {
                var randomColor = Color.FromArgb(Random.Next(256),
                    Random.Next(256), Random.Next(256));
                sattelitesToCreate -= 1;

                var satellite = new Sattelite
                {
                    Color = randomColor,
                    Radius = Random.Next(3, 5)
                };

                var orbit = new SatteliteOrbitPoint(planet)
                {
                    Color = randomColor,
                    X = planet.X,
                    Y = planet.Y,
                    Diametr = orbitRadius * 2,
                    Range = 5
                };

                ResetParticle(satellite);

                satellite.X = planet.X;
                satellite.Y = planet.Y - orbitRadius;

                Particles.Add(satellite);
                planet.SattelitesOrbits.Add(orbit);
                ImpactPoints.Add(orbit);

                orbitRadius += Random.Next(12, 15);
            }
        }
    }
}