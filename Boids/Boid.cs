using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
            Vector2 all = Vector2.Zero;
            for (int i = 0; i < SimulateNext.boids.Count; ++i)
            {
                if (SimulateNext.boids[0] != this
                    &&
                    GroupFuncs.FindDistance(position, SimulateNext.boids[i].position) <= _protectedRange)
                {
                    all += SimulateNext.boids[0].position;
                }
            }
            Vector2 average = all / (SimulateNext.boids.Count - 1);
            velocity += -1 * average * SimulateNext.avoidFactor;

        }

        public void FollowCenter()
        {
            Vector2 all = Vector2.Zero;
            for (int i = 0; i < SimulateNext.boids.Count; ++i)
            {
                if (SimulateNext.boids[0] != this)
                {
                    all += SimulateNext.boids[0].position;
                }
            }
            Vector2 average = all / (SimulateNext.boids.Count - 1);
            velocity += average * SimulateNext.groupingFactor;
        }

        public void Align()
        {
            Vector2 all = Vector2.Zero;
            for (int i = 0; i < SimulateNext.boids.Count; ++i)
            {
                if (SimulateNext.boids[0] != this
                    &&
                    GroupFuncs.FindDistance(this.position, SimulateNext.boids[i].position) <= _sightRange)
                {
                    all += SimulateNext.boids[0].velocity;
                }
            }
            Vector2 average = all / (SimulateNext.boids.Count - 1);
            velocity += average * SimulateNext.alignFactor;
        }

        public void Move()
        {
            position += velocity;

            int width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            int margin = 40;
            if (position.X > width - margin)
            {
                position.X = 0 + margin;
            }
            else if (position.X < 0 + margin)
            {
                position.X = width - margin;
            }

            if (position.Y > height - margin)
            {
                position.Y = 0 + margin;
            }
            else if (position.Y < 0)
            {
                position.Y = height - margin;
            }
        }
    }
}
