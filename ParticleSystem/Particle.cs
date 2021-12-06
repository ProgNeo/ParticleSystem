using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class Particle
    {
        private int _radius;
        private float _x; 
        private float _y;

        private float _direction;
        private float _speed;

        private float _life;

        public static readonly Random Rand = new();

        public int Radius
        {
            get => _radius;
            set => _radius = value;
        }
        public float X
        {
            get => _x;
            set => _x = value;
        }
        public float Y
        {
            get => _y;
            set => _y = value;
        }
        public float Direction
        {
            get => _direction;
            set => _direction = value;
        }
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
        public float Life
        {
            get => _life;
            set => _life = value;
        }

        public Particle()
        {
            _direction = Rand.Next(360);
            _speed = 2 + Rand.Next(10);
            _radius = 2 + Rand.Next(10);
            _life = 20 + Rand.Next(100);
        }
        public Particle(int x, int y) 
        {
            _direction = Rand.Next(360);
            _speed = 2 + Rand.Next(10);
            _radius = 2 + Rand.Next(10);
            _life = 20 + Rand.Next(100);
            _x = x;
            _y = y;
        }
        public void Draw(Graphics graphics)
        {
            var k = Math.Min(1f, Life / 100);
            var alpha = (int)(k * 255);
            
            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);

            graphics.FillEllipse(b, _x - _radius, _y - _radius, 
                _radius * 2, _radius * 2);

            b.Dispose();
        }
    }
}
