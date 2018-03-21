using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
       
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Dice dieSet = new Dice();
        KeyboardState prevStatekeyboard, curStatekeyboard;

        enum GameState 
        {
            MainMenu,
            Options,
            Playing,
        }
        // Makes the current gamestate go to the menu
        GameState CurrentGameState = GameState.MainMenu;

        //Screensize adjustments (this is the standard resolution of my screen)
        int screenWidth = 1366, screenHeight = 768;

        CButton btnPlay;
        

        Map map; 

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            curStatekeyboard = prevStatekeyboard = Keyboard.GetState();
            Tiles.Content = Content;
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
            map = new Map();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            spriteBatch = new SpriteBatch(GraphicsDevice);

            //screen stuff
            map.Generate(new int[,]{
                {6,6,6,6,6,6,6},
                {6,1,3,4,2,1,6},
                {6,2,3,2,4,5,6},
                {6,3,4,1,3,2,6},
                {6,2,3,5,2,4,6},
                {6,1,5,5,3,5,6},
                {6,6,6,6,6,6,6},
            }, 64);
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();
            IsMouseVisible = true;

            btnPlay = new CButton(Content.Load<Texture2D>("Button"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(600, 375));

            Tiles.Content = Content;



            dieSet.LoadContent(Content);
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
            MouseState mouse = Mouse.GetState();
            curStatekeyboard = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.isClicked) CurrentGameState = GameState.Playing;
                    btnPlay.Update(mouse);
                    break;

                case GameState.Playing:
                    // If space bar is pressed in the current state and the previous state the space bar was not pressed then the dice are rolled.
                    if (curStatekeyboard.IsKeyDown(Keys.Space) && prevStatekeyboard.IsKeyUp(Keys.Space))
                        dieSet.Roll();
                    break;
            }


            
            // TODO: Add your update logic here


            prevStatekeyboard = curStatekeyboard;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    btnPlay.Draw(spriteBatch);
                    break;

                case GameState.Playing:
                    map.Draw(spriteBatch);
                    dieSet.Draw(spriteBatch);
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
