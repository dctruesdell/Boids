using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Boids
{
    public class Boid
    {
        public Vector2 position;
        public Vector2 velocity;
        private float _protectedRange;
        private float _sightRange;

        public Boid(Vector2 position, Vector2 velocity, float protectedRange, float sightRange)
        {
            this.position = position;
            this.velocity = velocity;
            this._protectedRange = protectedRange;
            this._sightRange = sightRange;
        }

        public double ProtectedRange
        {
            get { return _protectedRange; }
        }

        public double SightRange
        {
            get { return _sightRange; }
        }

        public void Avoid()
        {
            for (int i = 0; i < SimulateNext.boids.Count; i++)
            {
                if (GroupFuncs.FindDistance(this.position, SimulateNext.boids[i].position) <= _protectedRange)
                {
                    Vector2 newVelocity = Vector2.Zero;
                    newVelocity += this.position - SimulateNext.boids[i].position;
                    this.velocity += newVelocity * SimulateNext.avoidFactor;
                }
            }
        }

        public void FollowCenter()
        {
            List<Vector2> nearbyBoids = new List<Vector2>();
            
            for (int i = 0; i < SimulateNext.boids.Count; i++)
            {
                if (GroupFuncs.FindDistance(this.position, SimulateNext.boids[i].position) <= _sightRange)
                {
                    nearbyBoids.Add(SimulateNext.boids[i].position);
                }
            }
            this.velocity += GroupFuncs.AveragePosition(nearbyBoids) * SimulateNext.groupingFactor;
        } 

        public void Move()
        {
            this.position += this.velocity;
        }
    }
}
