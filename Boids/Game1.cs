using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Boids
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Random random = new Random();

        Texture2D circle;
        private int startingNumOfBoids = 10;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            if (GraphicsDevice == null)
            {
                _graphics.ApplyChanges();
            }

            _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            for (int i = 0; i < startingNumOfBoids; i++)
            {
                GroupFuncs.AddBoid();
            }
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            circle = Content.Load<Texture2D>("circle");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                GroupFuncs.AddBoid();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                SimulateNext.boids.Clear();
                for (int i = 0; i < startingNumOfBoids; i++)
                {
                    GroupFuncs.AddBoid();
                }
            }
            SimulateNext.Next();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            foreach (Boid boid in SimulateNext.boids)
            {
                _spriteBatch.Draw(circle, boid.position, Color.Cyan);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
