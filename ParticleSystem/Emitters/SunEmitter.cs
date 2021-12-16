using System;
using System.Drawing;
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
            particle.Life = Random.Next(LifeMin, LifeMax);

            particle.X = this.X;
            particle.Y = this.Y;

            var direction = Direction + (double)Particle.Random.Next(Spreading) - Spreading / 2f;
            
            var speed = particle is Asteroid ? RingSpeed : SpeedMin;

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);
        }

        public override void UpdateState()
        {
            var particlesToCreate = ParticlesPerTick;

            foreach (var particle in Particles)
            {
                foreach (var point in ImpactPoints)
                {
                    point.ImpactParticle(particle);
                }

                particle.X += particle.SpeedX;
                particle.Y += particle.SpeedY;


                if (particle is Planet planet)
                {
                    planet.ChangeOrbitsPositions();
                }
            }

            while (Particles.Count < 300 && particlesToCreate > 0)
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

                var orbit = new PlanetOrbitPoint
                {
                    Color = randomColor,
                    X = this.X,
                    Y = this.Y,
                    Diametr = OrbitRadius * 2,
                };

                if (RingPoint.X == 0 && Random.Next(10) % 4 == 2)
                {
                    RingPoint = new Point(this.X, (int) (this.Y - OrbitRadius));
                    RingSpeed = (int) Math.Sqrt(OrbitRadius * 2);
                    orbit.Color = Color.White;
                    orbit.Range = 70;
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
                    Diametr = orbitRadius * 2
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