using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Boids
{
    public static class SimulateNext
    {
        public static float avoidFactor = 500f;
        public static float groupingFactor = 650f;
        public static float alignFactor = 400f;

        private static int maxSpeed = 10;

        public static List<Boid> boids = new List<Boid>();


        public static void Next()
        {
            // two loops so that things don't move around while we calculate the next velocity.
            for (int i = 0; i < boids.Count; i++)
            {
                boids[i].Avoid();
                boids[i].FollowCenter();
                boids[i].Align();

            }
            for (int i = 0; i < boids.Count; i++)
            {
                if (boids[i].velocity.Length() > maxSpeed)
                {
                    boids[i].velocity.Normalize();
                    boids[i].velocity *= maxSpeed;
                }

                boids[i].Move();
                boids[i].velocity = Vector2.Zero;

            }

        }
    }
}
