using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Boids
{
    public class Boid
    {
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 nextVelocity;
        private float _protectedRange;
        private float _sightRange;

        public Boid(Vector2 position, Vector2 velocity, float protectedRange, float sightRange)
        {
            this.position = position;
            this.velocity = velocity;
            this._protectedRange = protectedRange;
            this._sightRange = sightRange;
            this.nextVelocity = this.velocity;
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
            Vector2 newVelocity = Vector2.Zero;
            for (int i = 0; i < SimulateNext.boids.Count; i++)
            {
                float distance = GroupFuncs.FindDistance(position, SimulateNext.boids[i].position);
                if (distance <= _protectedRange)
                {
                    newVelocity += SimulateNext.boids[i].position;
                }
            }
             nextVelocity += (newVelocity - position) * SimulateNext.avoidFactor;
            
        }

        public void FollowCenter()
        {
            List<Vector2> nearby = new List<Vector2>();
            for (int i = 0; i < SimulateNext.boids.Count; i++)
            {
                float distance = GroupFuncs.FindDistance(position, SimulateNext.boids[i].position);
                if (distance <= _sightRange)
                {
                    nearby.Add(SimulateNext.boids[i].position);
                }
            }
            if (nearby.Count != 0)
            {
                nextVelocity += (position - GroupFuncs.AverageVectors(nearby)) * SimulateNext.groupingFactor;
            }

        } 

        public void Align()
        {
            List<Vector2> nearbyBoids = new List<Vector2>();

            for (int i = 0; i < SimulateNext.boids.Count; i++)
            {
                float distance = GroupFuncs.FindDistance(position, SimulateNext.boids[i].position);
                if (distance <= _sightRange && distance > _protectedRange)
                {
                    nearbyBoids.Add(SimulateNext.boids[i].velocity);
                }
            }
            if ( nearbyBoids.Count > 0 )
            {
                nextVelocity += (GroupFuncs.AverageVectors(nearbyBoids) - position ) * SimulateNext.alignFactor;
            }
            
        }

        public void Move()
        {
            position += velocity;
        }
    }
}
