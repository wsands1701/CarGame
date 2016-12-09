using System;
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
        Rectangle playerRectangle;

        Point mousePointer;

        //vectors
        Vector2 stationaryObjSpeed;
        Vector2 enemyCarObjSpeed;
        Vector2 playerCarObjSpeed;
        
        //textures
        Texture2D road;
        Texture2D tree;
        Texture2D flower;

        //car textures
        Texture2D greenCar;
        Texture2D redCar;
        Texture2D blueCar;
        Texture2D orangeCar;
        Texture2D whiteCar;
        Texture2D greyCar;
        Texture2D play;
        Texture2D end;
        Texture2D help;
        Texture2D back;

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

            


            playRectangle = new Rectangle(50, 200, 300, 150);
            endRectangle = new Rectangle(350, 200, 300, 150);
            helpRectangle = new Rectangle(650, 200, 300, 150);
            backRectangle = new Rectangle(900, 0, 300, 300);
           

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

            // TODO: use this.Content to load your game content here

            //vegetation / background textures
            road = Content.Load<Texture2D>("Road");
            tree = Content.Load<Texture2D>("tree");
            //can we use a gif in MVS? we could line the road with this
            //flower = Content.Load<Texture2D>("");

            //car textures
            blueCar = Content.Load<Texture2D>("BlueCar");
            greenCar = Content.Load<Texture2D>("GreenCar");
            greyCar = Content.Load<Texture2D>("GreyCar");
            orangeCar = Content.Load<Texture2D>("OrangeCar");
            redCar = Content.Load<Texture2D>("RedCar");
            whiteCar = Content.Load<Texture2D>("WhiteCar");

            //button textures
            play = Content.Load<Texture2D>("play");
            end = Content.Load<Texture2D>("end");
            back = Content.Load<Texture2D>("back");
            help = Content.Load<Texture2D>("help");


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
                  
                    break;

                case GameState.HelpScreen:
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        mousePointer = new Point(Mouse.GetState().X, Mouse.GetState().Y);
                    
                    if (backRectangle.Contains(mousePointer))
                        state = GameState.MainMenu;
                    break;

                case GameState.ChooseColor:

                    break;
                
                case GameState.PlayGame:
                    //if left mouse is pressed/collect mouse location data, then make and draw playerrectangle with said pointer data
                    if(Mouse.GetState().LeftButton==ButtonState.Pressed)
                    {
                        mousePointer= new Point(Mouse.GetState().X, Mouse.GetState().Y);
                        playerRectangle = new Rectangle(mousePointer.X,mousePointer.Y, 600, 297);
                        spriteBatch.Draw(redCar, playerRectangle, Color.White);
                    }

                    break;

                case GameState.EndGame:
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        mousePointer = new Point(Mouse.GetState().X, Mouse.GetState().Y);

                    if (backRectangle.Contains(mousePointer))
                        state = GameState.MainMenu;
                    break;
            }
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
                    PlayTheGame();
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
            spriteBatch.Draw(play, playRectangle, Color.White);
            spriteBatch.Draw(help, helpRectangle, Color.White);
            spriteBatch.Draw(end, endRectangle, Color.White);
        }

        public void PlayTheGame() { 
            spriteBatch.DrawString(font, "Welcome to the Car Game!", new Vector2(50, 50), Color.White);
            spriteBatch.Draw(play, playRectangle, Color.White);
            spriteBatch.Draw(help, helpRectangle, Color.White);
            spriteBatch.Draw(end, endRectangle, Color.White);
        }
        public void DisplayHelpScreen()
        {
            spriteBatch.DrawString(font, "Help", new Vector2(50, 50), Color.White);
            spriteBatch.Draw(back, backRectangle, Color.White);
        }
        public void DisplayChooseColor()
        {

            spriteBatch.DrawString(font, "Help", new Vector2(50, 50), Color.White);
            spriteBatch.Draw(back, backRectangle, Color.White);
        }

        public void showHelp()
        {

        }
        
        public void PlayGame()
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(road, new Vector2(0,0), Color.White);
        
            spriteBatch.DrawString(font, "Please choose a car color listed below.", new Vector2(50, 50), Color.White);
        }

        public void EndTheGame()
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.DrawString(font, "GAME OVER", new Vector2(50, 50), Color.White);
            spriteBatch.Draw(back, backRectangle, Color.White);
        }
        public void EndGame()
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.DrawString(font, "GAME OVER", new Vector2(50, 50), Color.White);
            spriteBatch.Draw(back, backRectangle, Color.White);
        }

        }
    }
