using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CarGame
{
    //I'm watching you all ~ McCloskey
    //nice
    
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
            PlayGame,
            HelpScreen,
            EndGame
        }
        GameState state = GameState.MainMenu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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

            playRectangle = new Rectangle(100, 200, 200, 200);
            endRectangle = new Rectangle(300, 200, 200, 200);
            helpRectangle = new Rectangle(500, 200, 200, 200);
            backRectangle = new Rectangle(600, 0, 200, 200);

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
            road = Content.Load<Texture2D>("road");
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

                case GameState.PlayGame:

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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            switch (state)
            {
                case GameState.MainMenu:
                    DisplayMainMenu();
                    break;

                case GameState.HelpScreen:
                    DisplayHelpScreen();
                    break;

                case GameState.PlayGame:
                    PlayTheGame();
                    break;

                case GameState.EndGame:
                    EndGame();
                    
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void DisplayMainMenu()
        {
            
        }
        public void DisplayHelpScreen()
        {
            

        }

        public void PlayTheGame()
        {

        }
        
        public void showHelp()
        {

        }
        public void EndGame()
        {

        }
    }
}
