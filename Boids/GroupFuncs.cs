using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Boids
{
    public static class GroupFuncs
    {
        public static Vector2 AveragePosition(List<Vector2> vectors)
        {
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
    }
}
