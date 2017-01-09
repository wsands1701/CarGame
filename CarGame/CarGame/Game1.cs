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
        Rectangle treeRectangle1;
        Rectangle treeRectangle2;
        Rectangle treeRectangle3;
        Rectangle treeRectangle4;
        Rectangle treeRectangle5;
        
        Scrollingbackground road1;
        Scrollingbackground road2;

        bool mousePressed = false;
      
        //time variables
        int h = 0;
        int m = 0;
        int s = 0;
        TimeSpan t1 = new TimeSpan(0, 0, 0);

        int r=250;
        int g=250;
        int b=250;
        Color plCl;

        int speedoflines = 7;

        Point mousePointer;

        //vectors
        Vector2 stationaryObjSpeed;
        Vector2 enemyCarObjSpeed;
        Vector2 playerCarObjSpeed;
        Vector2 playerRectcord;
        Random rnd1 = new Random();
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

        //

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

            //Road Lines
            line1Rectangle = new Rectangle(GraphicsDevice.Viewport.Width/4, 260, 100, 15);
            line1Rectangle2 = new Rectangle(GraphicsDevice.Viewport.Width/2, 260, 100, 15);
            line1Rectangle3 = new Rectangle((GraphicsDevice.Viewport.Width / 4)*3, 260, 100, 15);
            line1Rectangle4 = new Rectangle(GraphicsDevice.Viewport.Width, 260, 100, 15);
            line2Rectangle = new Rectangle(GraphicsDevice.Viewport.Width / 4, 520, 100, 15);
            line2Rectangle2 = new Rectangle(GraphicsDevice.Viewport.Width / 2, 520, 100, 15);
            line2Rectangle3 = new Rectangle((GraphicsDevice.Viewport.Width / 4) * 3, 520, 100, 15);
            line2Rectangle4 = new Rectangle(GraphicsDevice.Viewport.Width, 520, 100, 15);
            //Trees
            treeRectangle1 = new Rectangle(GraphicsDevice.Viewport.Width/5, 700, 110, 90);
            treeRectangle2 = new Rectangle(GraphicsDevice.Viewport.Width/4, 700, 110, 90);
            treeRectangle3 = new Rectangle(GraphicsDevice.Viewport.Width/2, 700, 110, 90);
            treeRectangle4 = new Rectangle((GraphicsDevice.Viewport.Width/3)*4, 700, 110, 90);
            treeRectangle5 = new Rectangle(GraphicsDevice.Viewport.Width, 700, 110, 90);


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

            //background
            road1 = new Scrollingbackground(Content.Load<Texture2D>("Road"), new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            road2 = new Scrollingbackground(Content.Load<Texture2D>("Road"), new Rectangle(GraphicsDevice.Viewport.Width ,0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));

           

            //button textures
            play = Content.Load<Texture2D>("play");
            end = Content.Load<Texture2D>("end");
            back = Content.Load<Texture2D>("back");
            help = Content.Load<Texture2D>("help");
            ChooseColor = Content.Load<Texture2D>("ChooseColor.jpg");
          
            //music


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
            road1.Update();
            road2.Update();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (road1.rectangle.X + road1.texture.Width <= 0)
                road1.rectangle.X = road2.rectangle.X + road2.texture.Width;

            if (road2.rectangle.X + road2.texture.Width <= 0)
                road2.rectangle.X = road1.rectangle.X + road1.texture.Width;
            

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
                        state = GameState.MainMenu;
                    }
                    if (pinkRectangle.Contains(mousePointer))
                    {
                        r = 255; g = 192; b = 210;
                        state = GameState.MainMenu;
                    }
                    if (redRectangle.Contains(mousePointer))
                    {
                        r = 255; g = 0; b = 0;
                        state = GameState.MainMenu;
                        
                    }
                    if (orangeRectangle.Contains(mousePointer))
                    {
                        r = 255; g = 102; b = 0;
                        state = GameState.MainMenu;
                        
                    }
                    if (greenRectangle.Contains(mousePointer))
                    {
                        g = 255; r = 0; b = 0;
                        state = GameState.MainMenu;
   
                    }
                    if (blueRectangle.Contains(mousePointer))
                    {
                        b = 255; r = 0; g = 0;
                        state = GameState.MainMenu;
                       
                    }
                    if (whiteRectangle.Contains(mousePointer))
                    {
                        b = 255; r = 255; g = 255;
                        state = GameState.MainMenu;
                       
                    }
                    if (backRectangle.Contains(mousePointer))
                        state = GameState.MainMenu;


                    break;

                case GameState.PlayGame:
                    t1 += gameTime.ElapsedGameTime;

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
                        if (playerRectangle.X >= GraphicsDevice.Viewport.Width-150)
                        {
                            playerRectangle.X = GraphicsDevice.Viewport.Width - 150;
                            Console.WriteLine("USe CODE KEEM");
                        }
                        if (playerRectangle.X < 0)
                        {
                            playerRectangle.X = 0;
                        }
                        if (playerRectangle.Y >= GraphicsDevice.Viewport.Height - 75)
                        {
                            playerRectangle.Y = GraphicsDevice.Viewport.Height - 75;
                            Console.WriteLine("Use CODE KEEMSTAR");
                        }
                        if (playerRectangle.Y < 0)
                        {
                            playerRectangle.Y = 0;
                        }



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
            //set location of top lines
            line1Rectangle.X -= speedoflines;
            line1Rectangle2.X -= speedoflines;
            line1Rectangle3.X -= speedoflines;
            line1Rectangle4.X -= speedoflines;

            if (line1Rectangle.X < -50)
            {
                line1Rectangle.X = GraphicsDevice.Viewport.Width-50;
            }
            if (line1Rectangle2.X < -50)
            {
                line1Rectangle2.X = GraphicsDevice.Viewport.Width-50;
            }
            if (line1Rectangle3.X < -50)
            {
                line1Rectangle3.X = GraphicsDevice.Viewport.Width-50;
            }
            if (line1Rectangle4.X < -50)
            {
                line1Rectangle4.X = GraphicsDevice.Viewport.Width-50;
            }
            //set location of bottom lines
            line2Rectangle.X -= speedoflines;
            line2Rectangle2.X -= speedoflines;
            line2Rectangle3.X -= speedoflines;
            line2Rectangle4.X -= speedoflines;

            
            if (line2Rectangle2.X < -50)
            {
                line2Rectangle2.X = GraphicsDevice.Viewport.Width-50;
            }
            if (line2Rectangle.X < -50)
            {
                line2Rectangle.X = GraphicsDevice.Viewport.Width-50;
            }
            if (line2Rectangle3.X < -50)
            {
                line2Rectangle3.X = GraphicsDevice.Viewport.Width-50;
            }
            if (line2Rectangle4.X < -50)
            {
                line2Rectangle4.X = GraphicsDevice.Viewport.Width-50;
            }
            
            //move the trees
            treeRectangle1.X -= speedoflines;
            treeRectangle2.X -= speedoflines;
            treeRectangle3.X -= speedoflines;
            treeRectangle4.X -= speedoflines;
            treeRectangle5.X -= speedoflines;

            //reset the trees
            if(treeRectangle1.X < 0)
            {
                int test = rnd1.Next() % GraphicsDevice.Viewport.Width;
                treeRectangle1.X = GraphicsDevice.Viewport.Width+test;
            }
            if(treeRectangle2.X < 0)
            {
                int test = rnd1.Next() % GraphicsDevice.Viewport.Width;
                treeRectangle2.X = GraphicsDevice.Viewport.Width + test;
            }
            if(treeRectangle3.X < 0)
            {
                int test = rnd1.Next() % GraphicsDevice.Viewport.Width;
                treeRectangle3.X = GraphicsDevice.Viewport.Width + test;
            }
            if (treeRectangle4.X < 0)
            {
                int test = rnd1.Next() % GraphicsDevice.Viewport.Width;
                treeRectangle4.X = GraphicsDevice.Viewport.Width + test;
            }
            if (treeRectangle5.X < 0)
            {
                int test = rnd1.Next() % GraphicsDevice.Viewport.Width;
                treeRectangle5.X = GraphicsDevice.Viewport.Width + test;
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

            road1.Draw(spriteBatch);
            road2.Draw(spriteBatch);

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
            spriteBatch.Draw(road, GraphicsDevice.Viewport.Bounds, Color.White);
            spriteBatch.DrawString(font, "Welcome to the Car Game!", new Vector2(50, 50), Color.White);
            spriteBatch.DrawString(font, "You should choose a car color before pressing Play", new Vector2(250, 500), Color.White);
            spriteBatch.Draw(play, playRectangle, Color.White);
            spriteBatch.Draw(help, helpRectangle, Color.White);
            spriteBatch.Draw(end, endRectangle, Color.White);
          
            spriteBatch.Draw(ChooseColor, choose_colorRectangle, Color.White);
        }

        public void PlayTheGame() {
            GraphicsDevice.Clear(Color.Black);
            //draws the road
         
            //lines
            spriteBatch.Draw(line, line1Rectangle, Color.White);
            spriteBatch.Draw(line, line1Rectangle2, Color.White);
            spriteBatch.Draw(line, line1Rectangle3, Color.White);
            spriteBatch.Draw(line, line1Rectangle4, Color.White);
            spriteBatch.Draw(line, line2Rectangle, Color.White);
            spriteBatch.Draw(line, line2Rectangle2, Color.White);
            spriteBatch.Draw(line, line2Rectangle3, Color.White);
            spriteBatch.Draw(line, line2Rectangle4, Color.White);
            //trees
            spriteBatch.Draw(tree, treeRectangle1, Color.White);
            spriteBatch.Draw(tree, treeRectangle2, Color.White);
            spriteBatch.Draw(tree, treeRectangle3, Color.White);
            spriteBatch.Draw(tree, treeRectangle4, Color.White);
            spriteBatch.Draw(tree, treeRectangle5, Color.White);
            spriteBatch.Draw(whiteCar, playerRectangle, plCl);
            spriteBatch.DrawString(font, "Points: " + t1.Seconds, new Vector2(100, 100),Color.White);
        }
        public void DisplayHelpScreen()
        {
            spriteBatch.DrawString(font, "Welcome to The Car Game!\n-To move your car, click and hold the left mouse button and drag the \n wherever you want it to go.\n-Avoid obsticles traveling towards your car for the longest time to win!", new Vector2(50, 50), Color.White);
            spriteBatch.Draw(back, backRectangle, Color.White);
            spriteBatch.DrawString(font, "Click the 'Play' button in to start game", new Vector2(50, 50), Color.White);
            spriteBatch.DrawString(font, "To quit, click the 'End' button", new Vector2(100, 50), Color.White);
            spriteBatch.DrawString(font, "To change the color of the car, click the 'Choose Color' button to select one of the colors", new Vector2(150, 50), Color.White);
            
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
