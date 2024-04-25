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
        public static float avoidFactor = .05f;
        public static float groupingFactor = .07f;
        public static float alignFactor = .09f;

        private static int maxSpeed = 5;

        public static List<Boid> boids = new List<Boid>();


        public static void Next()
        { 
            // two loops so that things don't move around while we calculate the next velocity.
            for (int i = 0; i < boids.Count; i++)
            {
                //boids[i].nextVelocity = Vector2.Zero;

                boids[i].FollowCenter();
                boids[i].Align();
                boids[i].Avoid();
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
