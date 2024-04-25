using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Boids
{
    public static class SimulateNext
    {
        public static float avoidFactor = +5f;
        public static float groupingFactor = 2f;
        public static float alignFactor = 4f;

        private static int maxSpeed = 10;

        public static List<Boid> boids = new List<Boid>();


        public static void Next()
        { 
            // two loops so that things don't move around while we calculate the next velocity.
            for (int i = 0; i < boids.Count; i++)
            {
                boids[i].nextVelocity = Vector2.Zero;
                boids[i].Avoid();
                boids[i].FollowCenter();
                boids[i].Align();;
            }
            for (int i = 0; i < boids.Count; i++)
            {
                if (boids[i].nextVelocity.Length() > maxSpeed)
                {
                    boids[i].nextVelocity.Normalize();
                    boids[i].nextVelocity *= maxSpeed;
                }
                boids[i].velocity = boids[i].nextVelocity;
                boids[i].Move();
            }

        }
    }
}
