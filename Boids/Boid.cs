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
            List<Vector2> velocities = new List<Vector2>();
            for (int i = 0; i < SimulateNext.boids.Count; i++)
            {
               
                float distance = GroupFuncs.FindDistance(position, SimulateNext.boids[i].position);
                if (distance <= _protectedRange && distance <= _sightRange)
                {
                    Vector2 newVelocity = SimulateNext.boids[i].position;
                    velocities.Add(newVelocity);
                }
            }
            if (velocities.Count > 0)
            {
                nextVelocity += -1 * ((position - GroupFuncs.AverageVectors(velocities)) * SimulateNext.avoidFactor);
            }
            
        }

        public void FollowCenter()
        {
            Vector2 center = GroupFuncs.CenterOfMass();

            nextVelocity += (center) * SimulateNext.groupingFactor;
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
