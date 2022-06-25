using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_3___Animation_Part_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tribbleBrownTexture;
        Texture2D tribbleCreamTexture;
        Texture2D tribbleGreyTexture;
        Texture2D tribbleOrangeTexture;
        
        Tribble tribble1;
        Tribble tribble2;
        Tribble tribble3;
        Tribble tribble4;

        Random generator = new Random();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Lesson 3 - Animation Part 1";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 500;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            tribble1 = new Tribble(tribbleGreyTexture, new Rectangle(10, 10, generator.Next(1, 500), 100), new Vector2(2, 0));
            tribble2 = new Tribble(tribbleBrownTexture, new Rectangle(10, 10, 100, 100), new Vector2(0, 5));
            tribble3 = new Tribble(tribbleOrangeTexture, new Rectangle(10, 10, 100, 100), new Vector2(2, 2));
            tribble4 = new Tribble(tribbleCreamTexture, new Rectangle(10, 10, 100, 100), new Vector2(generator.Next(1, 100), generator.Next(1, 100)));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            tribble1.Move();
            tribble2.Move();
            tribble3.Move();
            tribble4.Move();

            if (tribble1.Bounds.Left < 0)
                tribble1 = new Tribble(tribbleGreyTexture, new Rectangle(10, 10, generator.Next(1, 500), 100), new Vector2(2, 0));
            if (tribble1.Bounds.Right > 800)
                tribble1.BounceLeftRight();

            if (tribble2.Bounds.Bottom > 500 || tribble2.Bounds.Top < 0)
            {
                tribble2.BounceTopBottom();
                tribble2 = new Tribble(tribbleBrownTexture, new Rectangle(10, 10, 100, 100), new Vector2(0, generator.Next(1, 50)));
            }

            if (tribble3.Bounds.Right > 800 || tribble3.Bounds.Left < 0)
                tribble3.BounceLeftRight();
            if (tribble3.Bounds.Bottom > 500 || tribble3.Bounds.Top < 0)
                tribble3.BounceTopBottom();

            if (tribble4.Bounds.Right > 800 || tribble4.Bounds.Left < 0)
                tribble4.BounceLeftRight();
            if (tribble4.Bounds.Bottom > 500 || tribble4.Bounds.Top < 0)
                tribble4.BounceTopBottom();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(tribble1.Texture, tribble1.Bounds, Color.White);
            _spriteBatch.Draw(tribble2.Texture, tribble2.Bounds, Color.White);
            _spriteBatch.Draw(tribble3.Texture, tribble3.Bounds, Color.White);
            _spriteBatch.Draw(tribble4.Texture, tribble4.Bounds, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
