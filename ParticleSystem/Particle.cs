using System;
using System.Collections.Generic;
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

        private static readonly Random _random = new();

        public int Radius => _radius;
        public float X => _x;
        public float Y => _y;
        public float Direction => _direction;
        public float Speed => _speed;

        /*public int Radius
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
        }*/
        public Particle()
        {
            _direction = _random.Next(360);
            _speed = 2 + _random.Next(10);
            _radius = 2 + _random.Next(10);
        }
        public Particle(int x, int y) 
        {
            _direction = _random.Next(360);
            _speed = 2 + _random.Next(10);
            _radius = 2 + _random.Next(10);
            _x = x;
            _y = y;
        }
    }
}
