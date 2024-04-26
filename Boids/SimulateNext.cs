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

        public static float avoidFactor = 0.5f;
        public static float groupingFactor = .01f;
        public static float alignFactor = .09f;

        public static List<Boid> boids = new List<Boid>();


        public static void Next()
        {
            // two loops so that things don't move around while we calculate the next velocity.
            for (int i = 0; i < boids.Count; i++)
            {
                boids[i].FollowCenter();
                boids[i].Align();
                boids[i].Avoid();
                boids[i].Move();
                boids[i].velocity.Normalize();
            }


        }

    }

}
