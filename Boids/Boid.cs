using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Boids
{
    internal class Boid
    {
        public Vector2 position;
        public Vector2 velocity;
        private double _protectedRange;
        private double _sightRange;

        public Boid()
        {
            // construct
        }

        public double ProtectedRange
        {
            get { return _protectedRange; }
        }

        public double SightRange
        {
            get { return _sightRange; }
        }

        public void avoid(Boid other)
        {
            if (GroupFuncs.FindDistance(this.position, other.position)  <= _protectedRange)
            {
                for 
            }
        }

    }
}
