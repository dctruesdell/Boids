using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boids
{
    public static class SimulateNext
    {
        public static float avoidFactor = 3;
        public static float groupingFactor = 3;
        public static List<Boid> boids = new List<Boid>();


        public static void Next()
        {
            // two loops so that things don't move around while we calculate the next velocity.
            for (int i = 0; i < boids.Count; i++)
            {
                boids[i].Avoid();
                boids[i].FollowCenter();
            }
            for (int i = 0; i < boids.Count; i++)
            {
                boids[i].Move();
            }

        }
    }
}
