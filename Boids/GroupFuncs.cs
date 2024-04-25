using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Boids
{
    public static class GroupFuncs
    {
        public static Vector2 AverageVectors(List<Vector2> vectors)
        {
            if (vectors.Count == 0)
            {
            } 
            float x = 0;
            float y = 0;
            for (int i = 0; i < vectors.Count; i++)
            {
                x += vectors[i].X;
                y += vectors[i].Y;
            }

            float avgX = x / vectors.Count;
            float avgY = y / vectors.Count;

            return new Vector2(avgX, avgY);
        }

        public static Vector2 CenterOfMass()
        {
            List<Vector2> positions = new List<Vector2>();
            for (int i = 0; i < SimulateNext.boids.Count; i++)
            {
                positions.Add(SimulateNext.boids[i].position);
            }
            return AverageVectors(positions);
        }

        public static float FindDistance(Vector2 pos1, Vector2 pos2)
        {
            float x = pos1.X - pos2.X;
            float y = pos1.Y - pos2.Y;

            x *= x;
            y *= y;

            return (float)Math.Sqrt(x + y);
        }

        public static void AddBoid()
        {
            Random r = new Random();
            SimulateNext.boids.Add(new Boid(new Vector2(r.Next(50, 1000), r.Next(50, 1000)),
                new Vector2(r.Next(-10, 10), r.Next(-10, 10)),
                50,
                200));
        }
    }
}
