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
        public static float avoidFactor = 0.03f;
        public static float groupingFactor = 0.03f;
        public static List<Boid> boids = new List<Boid>();


        public static void Next()
        {
            // two loops so that things don't move around while we calculate the next velocity.
            for (int i = 0; i < boids.Count; i++)
            {
                boids[i].Avoid();
                boids[i].FollowCenter();
                if ( 
                    (0 >= boids[i].position.X || 1080 > boids[i].position.X)
                    || 
                    (0 > boids[i].position.Y || boids[i].position.Y > 1920))
                {
                    boids[i].velocity *= -1;
                }

                {

                }
            }
            for (int i = 0; i < boids.Count; i++)
            {
                boids[i].Move();

            }

        }
    }
}
