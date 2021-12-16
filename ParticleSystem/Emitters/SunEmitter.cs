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
        
        public bool IsRingExist = false;

        public Random Random = new();

        public override void ResetParticle(Particle particle)
        {
            particle.Life = 100;

            particle.X = this.X;
            particle.Y = this.Y;

            var direction = Direction + (double)Particle.Rand.Next(Spreading) - Spreading / 2f;

            if (particle is ParticleColorful colorful)
            {
                colorful.FromColor = ColorFrom;
                colorful.ToColor = ColorTo;
            }

            var speed = Particle.Rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);
        }

        public override void UpdateState()
        {
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
        }

        //Создаются планеты и их орбиты
        public void CreatePlanets()
        {
            while (PlanetsToCreate > 0)
            {
                var randomColor = Color.FromArgb(Random.Next(256),
                    Random.Next(256), Random.Next(256));

                var particle = new Planet
                {
                    Color = randomColor,
                    Radius = Random.Next(5, 10)
                };

                var orbit = new PlanetOrbitPoint
                {
                    Color = randomColor,
                    X = this.X,
                    Y = this.Y,
                    Diametr = OrbitRadius * 2,
                };

                ResetParticle(particle);
                particle.Y -= OrbitRadius;

                CreateSattelitesOfPlanet(particle);
                Particles.Add(particle);
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