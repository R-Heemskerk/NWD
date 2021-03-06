﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

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
        pawn stad = new pawn();
        KeyboardState prevStatekeyboard, curStatekeyboard;
        Process Console;
        Texture2D pix;

        enum GameState 
        {
            MainMenu,
            Options,
            Playing,
            Question,
            Waiting,
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

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();
            IsMouseVisible = true;

            btnPlay = new CButton(Content.Load<Texture2D>("Button"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(600, 375));

            Tiles.Content = Content;

            pix = new Texture2D(GraphicsDevice, 1, 1);
            pix.SetData(new Color[] { Color.White });

            map.Generate(new int[,]{
                {6,6,6,6,6,6,6},
                {6,1,3,4,2,1,6},
                {6,2,3,5,4,5,6},
                {6,3,4,1,3,2,6},
                {6,2,3,5,2,4,6},
                {6,1,4,5,3,5,6},
                {6,6,6,6,6,6,6},
            },64);

            dieSet.LoadContent(Content);
            stad.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            pix.Dispose();
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            mymouse.update();

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
                    {
                        dieSet.Roll();
                        CurrentGameState = GameState.Question;
                    }
                    break;

                case GameState.Question:
                    if (prevStatekeyboard.GetPressedKeys().Length <= 0 && curStatekeyboard.GetPressedKeys().Length > 0)
                    {
                        Console = Process.Start("QuestionConsole.exe");
                        CurrentGameState = GameState.Waiting;
                    }
                    break;
                case GameState.Waiting:
                    if(Console.HasExited)
                    {
                        if (Console.ExitCode == 2)
                        {}
                        //yeey gewonnen
                        else if (Console.ExitCode == 3)
                        { }
                            CurrentGameState = GameState.Playing;
                    }
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
            for (int x = 1; x < 7; x++)
            {
                for (int y = 1; y < 7; y++)
                {
                    Rectangle r = new Rectangle((x * 64) - 8, (y * 64) - 8, 16, 16);
                    if (mymouse.GetRectangle().Intersects(r))
                        spriteBatch.Draw(pix, r, new Color(0, 0, 50, 100));
                }
            }

                spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
