using System;
using System.Collections.Generic;
using System.Drawing;

namespace ParticleSystem
{
    public class Emitter
    {
        private readonly List<Particle> _particles = new();
        public List<Point> GravityPoints = new();

        public int MousePositionX = 0;
        public int MousePositionY = 0;

        public float GravitationX = 0;
        public float GravitationY = 0;
        public void UpdateState()
        {
            foreach (var particle in _particles)
            {
                particle.Life -= 1;
                if (particle.Life < 0)
                {
                    particle.Life = 20 + Particle.Rand.Next(100);
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;

                    var direction = (double)Particle.Rand.Next(360);
                    var speed = Particle.Rand.Next(1, 10);

                    particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                    particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

                    particle.Radius = 2 + Particle.Rand.Next(10);
                }
                else
                {
                    const float m = 100f;
                    foreach (var point in GravityPoints)
                    {
                        var gX = GravityPoints[0].X - particle.X;
                        var gY = GravityPoints[0].Y - particle.Y;

                        var r2 = MathF.Max(100, gX * gX + gY * gY);

                        particle.SpeedX += gX * m / r2;
                        particle.SpeedY += gY * m / r2;
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }

            for (var i = 0; i < 10; i++)
            {
                if (_particles.Count < 500)
                {
                    var particle = new ParticleColorful
                    {
                        FromColor = Color.Yellow,
                        ToColor = Color.FromArgb(0, Color.Magenta),
                        X = MousePositionX,
                        Y = MousePositionY
                    };

                    _particles.Add(particle);
                }
                else
                {
                    break;
                }
            }
        }

        public void Render(Graphics g)
        {
            foreach (var particle in _particles)
            {
                particle.Draw(g);
            }

            foreach (var point in GravityPoints)
            {
                g.FillEllipse(
                    new SolidBrush(Color.Red),
                    point.X - 5,
                    point.Y - 5,
                    10,
                    10
                );
            }
        }
    }
}