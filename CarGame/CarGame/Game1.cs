﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CarGame
{
    //I'm watching you all ~ McCloskey
    //nice
      
        //create image to follow mouse when pressed. Can use this, our branch
   
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle playRectangle;
        Rectangle endRectangle;
        Rectangle helpRectangle;
        Rectangle backRectangle;
        Rectangle choose_colorRectangle;
        Rectangle playerRectangle;
        Rectangle redRectangle;
        Rectangle blueRectangle;
        Rectangle greenRectangle;
        Rectangle orangeRectangle;
        Rectangle whiteRectangle;
        Rectangle pinkRectangle;
        Rectangle aquaRectangle;
        Rectangle yellowRectangle;
        Rectangle line1Rectangle;
        Rectangle line1Rectangle2;
        Rectangle line1Rectangle3;
        Rectangle line1Rectangle4;
        Rectangle line2Rectangle;
        Rectangle line2Rectangle2;
        Rectangle line2Rectangle3;
        Rectangle line2Rectangle4;
        bool mousePressed = false;
      
        int r=250;
        int g=250;
        int b=250;
        Color plCl;
      
        

        Point mousePointer;

        //vectors
        Vector2 stationaryObjSpeed;
        Vector2 enemyCarObjSpeed;
        Vector2 playerCarObjSpeed;
        Vector2 playerRectcord;
        
        //textures
        Texture2D road;
        Texture2D line;
        Texture2D tree;
        Texture2D flower;

        //car textures
        Texture2D greenCar;
        Texture2D redCar;
        Texture2D blueCar;
        Texture2D orangeCar;
        Texture2D whiteCar;
        Texture2D greyCar;
        Texture2D pinkCar;
        Texture2D aquaCar;
        Texture2D yellowCar;

        //button textures
        Texture2D play;
        Texture2D end;
        Texture2D help;
        Texture2D back;
        Texture2D ChooseColor;

        //font
        SpriteFont font;

        enum GameState
        {
            MainMenu,
            HelpScreen,
            ChooseColor,
            PlayGame,
            EndGame
        }
        GameState state = GameState.MainMenu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
      
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1280;

            //graphics.IsFullScreen = true;
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
            IsMouseVisible = true;
            line1Rectangle = new Rectangle(GraphicsDevice.Viewport.Width/4, 270, 100, 15);
            line1Rectangle2 = new Rectangle(GraphicsDevice.Viewport.Width/2, 270, 100, 15);
            line1Rectangle3 = new Rectangle((GraphicsDevice.Viewport.Width / 4)*3, 270, 100, 15);
            line1Rectangle4 = new Rectangle(GraphicsDevice.Viewport.Width, 270, 100, 15);
            line2Rectangle = new Rectangle(GraphicsDevice.Viewport.Width / 4, 500, 100, 15);
            line2Rectangle2 = new Rectangle(GraphicsDevice.Viewport.Width / 2, 500, 100, 15);
            line2Rectangle3 = new Rectangle((GraphicsDevice.Viewport.Width / 4) * 3, 500, 100, 15);
            line2Rectangle4 = new Rectangle(GraphicsDevice.Viewport.Width, 500, 100, 15);
            playRectangle = new Rectangle(50, 200, 300, 150);
            endRectangle = new Rectangle(350, 200, 300, 150);
            helpRectangle = new Rectangle(650, 200, 300, 150);
            backRectangle = new Rectangle(950, 500, 300, 300);
            redRectangle = new Rectangle(300, 200, 200, 100);
            blueRectangle = new Rectangle(500, 200, 200, 100);
            greenRectangle = new Rectangle(100, 200, 200, 100);
            whiteRectangle = new Rectangle(900, 200, 200, 100);
            orangeRectangle = new Rectangle(700, 200, 200, 100);
            pinkRectangle = new Rectangle(700, 300, 200, 100);
            aquaRectangle = new Rectangle(500, 300, 200, 100);
            yellowRectangle = new Rectangle(300, 300, 200, 100); 
            choose_colorRectangle = new Rectangle(950, 200, 300, 150);
           
            base.Initialize();
        }

        /// <summary>

        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //vegetation / background textures
            road = Content.Load<Texture2D>("Road");
            tree = Content.Load<Texture2D>("tree");
            line = Content.Load<Texture2D>("line");
            //can we use a gif in MVS? we could line the road with this
            //flower = Content.Load<Texture2D>("");

            //car textures
            blueCar = Content.Load<Texture2D>("BlueCar");
            greenCar = Content.Load<Texture2D>("GreenCar");
            greyCar = Content.Load<Texture2D>("GreyCar");
            orangeCar = Content.Load<Texture2D>("OrangeCar");
            redCar = Content.Load<Texture2D>("RedCar");
            whiteCar = Content.Load<Texture2D>("WhiteCar");
            pinkCar = this.Content.Load<Texture2D>("PinkCar");
            aquaCar = Content.Load<Texture2D>("AquaCar");
            yellowCar = Content.Load<Texture2D>("YellowCar");
            //lines.get(lines.go(dank));

            //button textures
            play = Content.Load<Texture2D>("play");
            end = Content.Load<Texture2D>("end");
            back = Content.Load<Texture2D>("back");
            help = Content.Load<Texture2D>("help");
            ChooseColor = Content.Load<Texture2D>("ChooseColor.jpg");
          

            //font
            font = Content.Load<SpriteFont>("fastFont");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            switch (state)
            {
                case GameState.MainMenu:
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        mousePointer = new Point(Mouse.GetState().X, Mouse.GetState().Y);

                    if (playRectangle.Contains(mousePointer))
                        state = GameState.PlayGame;

                    if (endRectangle.Contains(mousePointer))
                        state = GameState.EndGame;

                    if (helpRectangle.Contains(mousePointer))
                        state = GameState.HelpScreen;

                    if (choose_colorRectangle.Contains(mousePointer))
                        state = GameState.ChooseColor;

                    break;

                case GameState.HelpScreen:
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        mousePointer = new Point(Mouse.GetState().X, Mouse.GetState().Y);

                    if (backRectangle.Contains(mousePointer))
                        state = GameState.MainMenu;
                    break;

                case GameState.ChooseColor:
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        mousePointer = new Point(Mouse.GetState().X, Mouse.GetState().Y);

                    if (yellowRectangle.Contains(mousePointer))
                    {
                        r = 255; g = 255; b = 0;
                    }
                    if (pinkRectangle.Contains(mousePointer))
                    {
                        r = 255; g = 192; b = 210;
                    }
                    if (redRectangle.Contains(mousePointer))
                    {
                        r = 255; g = 0; b = 0;
                    }
                    if (orangeRectangle.Contains(mousePointer))
                    {
                        r = 255; g = 102; b = 0;
                    }
                    if (greenRectangle.Contains(mousePointer))
                    {
                        g = 255; r = 0; b = 0;
                    }
                    if (blueRectangle.Contains(mousePointer))
                    {
                        b = 255; r = 0; g = 0;
                    }
                    if (whiteRectangle.Contains(mousePointer))
                    {
                        b = 255; r = 255; g = 255;
                    }
                    if (backRectangle.Contains(mousePointer))
                        state = GameState.MainMenu;
                    break;

                case GameState.PlayGame:
                    //if left mouse is pressed/collect mouse location data, then make and draw playerrectangle with said pointer data
                    mousePointer = new Point(Mouse.GetState().X, Mouse.GetState().Y);
                    //     Console.WriteLine(mousePointer);
                    playerRectangle = new Rectangle(playerRectangle.X, playerRectangle.Y, 150, 75);
                    if (playerRectangle.Contains(mousePointer))
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)//new feature - hard mode day one dlc
                        {
                            mousePressed = true;
                        }

                    }
                    if (mousePressed)
                    {
                        playerRectangle.X = Mouse.GetState().X - 90;
                        playerRectangle.Y = Mouse.GetState().Y - 35;
                        if (Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            mousePressed = false;
                        }
                    }

                    break;

                case GameState.EndGame:

                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        mousePointer = new Point(Mouse.GetState().X, Mouse.GetState().Y);

                    if (backRectangle.Contains(mousePointer))
                        state = GameState.MainMenu;
                    break;
            }

            line1Rectangle.X -= 10;
            line1Rectangle2.X -= 10;
            line1Rectangle3.X -= 10;
            line1Rectangle4.X -= 10;

            if (line1Rectangle2.X < 0)
            {
                line1Rectangle2.X = GraphicsDevice.Viewport.Width;
            }
            if (line1Rectangle.X == -(line1Rectangle.X))
            {
                line1Rectangle.X = GraphicsDevice.Viewport.Width;
            }
            if (line1Rectangle3.X < 0)
            {
                line1Rectangle3.X = GraphicsDevice.Viewport.Width;
            }
            if (line1Rectangle4.X < 0)
            {
                line1Rectangle4.X = GraphicsDevice.Viewport.Width;
            }

            line2Rectangle.X += 10;
            line2Rectangle2.X += 10;
            line2Rectangle3.X += 10;
            line2Rectangle4.X += 10;

            /*
            if (line2Rectangle2.X > GraphicsDevice.Viewport.Width)
            {
                line2Rectangle2.X = 0;
            }
            if (line2Rectangle.X > GraphicsDevice.Viewport.Width)
            {
                line2Rectangle.X = 0;
            }
            if (line2Rectangle3.X > GraphicsDevice.Viewport.Width)
            {
                line2Rectangle3.X = 0;
            }
            if (line2Rectangle4.X > GraphicsDevice.Viewport.Width)
            {
                line2Rectangle4.X = 0;
            }
            */
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            switch (state) { 
            
                case GameState.MainMenu:
                    DisplayMainMenu();
            break;

                case GameState.HelpScreen:
                    DisplayHelpScreen();
            break;
                    
                case GameState.PlayGame:
                     plCl = new Color(r, g, b);
                     PlayTheGame();
            break;

                case GameState.EndGame:
                    EndTheGame();

            break;
                    
                case GameState.ChooseColor:
                   
                    DisplayChooseColor();

            break;
        }

            spriteBatch.End();


            


          
            base.Draw(gameTime);
        }


        public void DisplayMainMenu()
        {
            spriteBatch.DrawString(font, "Welcome to the Car Game!", new Vector2(50, 50), Color.White);
            spriteBatch.DrawString(font, "You should choose a car color before pressing Play", new Vector2(250, 500), Color.White);
            spriteBatch.Draw(play, playRectangle, Color.White);
            spriteBatch.Draw(help, helpRectangle, Color.White);
            spriteBatch.Draw(end, endRectangle, Color.White);
          
            spriteBatch.Draw(ChooseColor, choose_colorRectangle, Color.White);
        }

        public void PlayTheGame() {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(road, GraphicsDevice.Viewport.Bounds, Color.White);
            spriteBatch.Draw(line,line1Rectangle, Color.White);
            spriteBatch.Draw(line, line1Rectangle2, Color.White);
            spriteBatch.Draw(line, line1Rectangle3, Color.White);
            spriteBatch.Draw(line, line1Rectangle4, Color.White);
            spriteBatch.Draw(whiteCar, playerRectangle, plCl);
        }
        public void DisplayHelpScreen()
        {
            spriteBatch.DrawString(font, "Welcome to The Car Game!\n-To move your car, click and hold the left mouse button and drag the \n wherever you want it to go.\n-Avoid obsticles traveling towards your car for the longest time to win!", new Vector2(50, 50), Color.White);
            spriteBatch.Draw(back, backRectangle, Color.White);
        }
        public void DisplayChooseColor()
        {
            spriteBatch.DrawString(font, "Please choose a car color listed below.", new Vector2(50, 50), Color.White);

            spriteBatch.Draw(redCar, redRectangle, Color.White);
            spriteBatch.Draw(greenCar, greenRectangle, Color.White);
            spriteBatch.Draw(blueCar, blueRectangle, Color.White);
            spriteBatch.Draw(orangeCar, orangeRectangle, Color.White);
            spriteBatch.Draw(whiteCar, whiteRectangle, Color.White);
            spriteBatch.Draw(pinkCar, pinkRectangle, Color.White);
            spriteBatch.Draw(aquaCar, aquaRectangle, Color.White);
            spriteBatch.Draw(yellowCar, yellowRectangle, Color.White);
            spriteBatch.Draw(back, backRectangle, Color.White);
            
        }

        public void EndTheGame()
        {
            GraphicsDevice.Clear(Color.Gray);
            Exit();
        }

        }
    }
