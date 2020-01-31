using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Polygame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        public static GameTime GetGameTime { get => myGameTime; }
        static GameTime myGameTime;
        SpriteBatch spriteBatch;
        GameObject gameObject;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            SceneManager.Initialize(1);

            base.Initialize();
        }

        //ur mom gae

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferHeight = 1024;
            graphics.PreferredBackBufferWidth = 1024;
            graphics.ApplyChanges();
            gameObject = new GameObject(new Vector2(487, 0));
            gameObject.AddComponent(new RigidBody(50, 1));
            gameObject.AddComponent(new BoxCollider2D(64, 64));
            gameObject.AddComponent(new SpriteRenderer(Content.Load<Texture2D>("Tree")));
            //mySprite = Content.Load<Texture2D>("whitePixel");
            //myRectangle = new Rectangle(487, 487, 50, 50);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here



        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            myGameTime = gameTime;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState tempKS = Keyboard.GetState();
            gameObject.GetComponent(typeof(RigidBody)).Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //// TODO: Add your drawing code here
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            SceneManager.DrawScene(spriteBatch);
            gameObject.GetComponent(typeof(SpriteRenderer)).Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

//Texture2D whitePixel;
//Texture2D background;
//Texture2D[] shadow;
//Vector2[] shadowPositions;
//Color[] shadowTransparency;
//Vector2 position;
//Random rng;
//float ligthShift = 0;
//int frame = 0;
//int width;
//int height;

//width = graphics.PreferredBackBufferWidth;
//height = graphics.PreferredBackBufferHeight;

//whitePixel = Content.Load<Texture2D>("whitePixel");
//background = Content.Load<Texture2D>("Skärmbild (1)");
//shadow = new Texture2D[]
//{
//    Content.Load<Texture2D>("Shadow_Black"),
//    Content.Load<Texture2D>("Shadow_Ring_Outer"),
//    Content.Load<Texture2D>("Shadow_Ring_Middle"),
//    Content.Load<Texture2D>("Shadow_Ring_Inner")
//};
//shadowPositions = new Vector2[shadow.Length];
//for (int i = 0; i < shadowPositions.Length; i++)
//{
//    shadowPositions[i] = new Vector2((width - shadow[i].Width) / 2 - width / 2, (height - shadow[i].Height) / 2 - height / 2);
//}
//shadowTransparency = new Color[]
//{
//    Color.White,
//    new Color(0f, 0f, 0f, 0.75f),
//    new Color(0f, 0f, 0f, 0.50f),
//    new Color(0f, 0f, 0f, 0.25f)
//};

//spriteBatch.Begin();
//spriteBatch.Draw(background, Vector2.Zero, Color.White);
//for(int i = 0; i < shadow.Length; i++)
//{
//    spriteBatch.Draw(shadow[i], shadowPositions[i] + position, shadowTransparency[i]);
//}
//spriteBatch.End();
