using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

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
        Rectangle picRectangle;
        Rectangle Lane4;
        Rectangle Lane3;
        Rectangle Lane2;
        Rectangle Lane1;
        
        /*
    greenCar = Content.Load<Texture2D>("GreenCar");
        greyCar = Content.Load<Texture2D>("GreyCar");
        orangeCar = Content.Load<Texture2D>("OrangeCar");
        redCar = Content.Load<Texture2D>("RedCar");
        whiteCar = Content.Load<Texture2D>("WhiteCar");
        pinkCar = this.Content.Load<Texture2D>("PinkCar");
        aquaCar = Content.Load<Texture2D>("AquaCar");
        yellowCar
        */

        Scrollingbackground road1;
        Scrollingbackground road2;

        bool startMenuMusic = true;
        bool mousePressed = false;
        bool colorSelected = false;
      
        //time variables
        TimeSpan t1 = new TimeSpan(0, 0, 0);
        int points = 0;

        int r=250;
        int g=250;
        int b=250;
        Color plCl;

        int speedoflines = 7;

        Point newMousePoint;
        Point oldMousePoint = new Point();

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
        Texture2D carStartImage;

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
        SpriteFont yung;

        //sounds
        SoundEffect menu;
        SoundEffect carStart;
        SoundEffect losingSound;
        SoundEffect crash;
       SoundEffectInstance menuSound;

        //arraylist for car types
        ArrayList TrafficOptions = new ArrayList();



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


            playRectangle = new Rectangle(50, 630, 300, 150);
            endRectangle = new Rectangle(350, 630, 300, 150);
            picRectangle = new Rectangle(100, 100, 1100, 500);
            helpRectangle = new Rectangle(650, 630, 300, 150);
            backRectangle = new Rectangle(1050, 50, 80, 80);
            redRectangle = new Rectangle(300, 200, 200, 100);
            blueRectangle = new Rectangle(500, 200, 200, 100);
            greenRectangle = new Rectangle(100, 200, 200, 100);
            whiteRectangle = new Rectangle(900, 200, 200, 100);
            orangeRectangle = new Rectangle(700, 200, 200, 100);
            pinkRectangle = new Rectangle(700, 300, 200, 100);
            aquaRectangle = new Rectangle(500, 300, 200, 100);
            yellowRectangle = new Rectangle(300, 300, 200, 100); 
            choose_colorRectangle = new Rectangle(950, 630, 300, 150);
           

            // cars
            Lane4 = new Rectangle(-100 , 570, 150, 75);
            Lane3 = new Rectangle(-100, 470, 150, 75);
            Lane2 = new Rectangle(2000, 150, 150, 75);
            Lane1 = new Rectangle(2000, 250, 150, 75);
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
            line = Content.Load<Texture2D>("line");
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
            pinkCar = this.Content.Load<Texture2D>("PinkCar");
            aquaCar = Content.Load<Texture2D>("AquaCar");
            yellowCar = Content.Load<Texture2D>("YellowCar");
            //lines.get(lines.go(dank));

            //background
            road1 = new Scrollingbackground(Content.Load<Texture2D>("Road"), new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            road2 = new Scrollingbackground(Content.Load<Texture2D>("Road"), new Rectangle(GraphicsDevice.Viewport.Width ,0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));

           

            //button textures
            play = Content.Load<Texture2D>("play.png");
            end = Content.Load<Texture2D>("end.png");
            back = Content.Load<Texture2D>("back");
            help = Content.Load<Texture2D>("help.png");
            ChooseColor = Content.Load<Texture2D>("ChooseColor.png");
            carStartImage = Content.Load<Texture2D>("CarStartImage");
          
            //music - sounds
            menu = Content.Load<SoundEffect>("menuMusic");
            menuSound = menu.CreateInstance();
            carStart = Content.Load<SoundEffect>("car_start");
            losingSound = Content.Load<SoundEffect>("losing_sound");
            crash = Content.Load<SoundEffect>("crash");

            //font
            font = Content.Load<SpriteFont>("fastFont");


            //car spawning array and stuff that may or may not work
            /*
            //add cars (x, y, speed, collisions, image)
            Obstacles redTraffic = new Moving(50, 50, 150, false, redCar);
            Obstacles blueTraffic = new Moving(50, 50, 150, false, blueCar);
            Obstacles greenTraffic = new Moving(50, 50, 150, false, greenCar);
            Obstacles greyTraffic = new Moving(50, 50, 150, false, greyCar);
            Obstacles orangeTraffic = new Moving(50, 50, 150, false, orangeCar);
            Obstacles whiteTraffic = new Moving(50, 50, 150, false, whiteCar);
            



            //add car to arraylist
            TrafficOptions.Add(redTraffic);
            TrafficOptions.Add(blueTraffic);
            TrafficOptions.Add(greenTraffic);
            TrafficOptions.Add(greyTraffic);
            TrafficOptions.Add(orangeTraffic);
            TrafficOptions.Add(whiteTraffic);
            */



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

            newMousePoint = oldMousePoint;

            // TODO: Add your update logic here
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                newMousePoint = new Point(Mouse.GetState().X, Mouse.GetState().Y);
            }

           
            
            Console.WriteLine(newMousePoint);

            switch (state)
            {
                case GameState.MainMenu:

                    //set state of the game based on button selected
                    if (playRectangle.Contains(newMousePoint))
                        state = GameState.PlayGame;

                    if (endRectangle.Contains(newMousePoint))
                        state = GameState.EndGame;

                    if (helpRectangle.Contains(newMousePoint))
                        state = GameState.HelpScreen;

                    if (choose_colorRectangle.Contains(newMousePoint))
                        state = GameState.ChooseColor;

                    break;

                case GameState.HelpScreen:

                    //go back to main menu if back button is clicked on 
                    if (backRectangle.Contains(newMousePoint))
                        state = GameState.MainMenu;

                    break;

                case GameState.ChooseColor:
                   
                    if (yellowRectangle.Contains(newMousePoint))
                    {
                        r = 255; g = 255; b = 0;
                        colorSelected = true;
                    }
                    if (pinkRectangle.Contains(newMousePoint))
                    {
                        r = 252; g = 142; b = 172;
                        colorSelected = true;
                    }
                    if (redRectangle.Contains(newMousePoint))
                    {
                        r = 255; g = 0; b = 0;
                        colorSelected = true;
                        
                    }
                    if (orangeRectangle.Contains(newMousePoint))
                    {
                        r = 255; g = 102; b = 0;
                        colorSelected = true;
                        
                    }
                    if (greenRectangle.Contains(newMousePoint))
                    {
                        g = 255; r = 0; b = 0;
                        colorSelected = true;
   
                    }
                    if (aquaRectangle.Contains(newMousePoint))
                    {
                        g = 255; r = 0; b = 255;
                        colorSelected = true;

                    }
                    if (blueRectangle.Contains(newMousePoint))
                    {
                        b = 255; r = 0; g = 0;
                        colorSelected = true;
                       
                    }
                    if (whiteRectangle.Contains(newMousePoint))
                    {
                        b = 255; r = 255; g = 255;
                        colorSelected = true;
                    }

                    if (colorSelected && (newMousePoint.X > 0 && newMousePoint.Y > 0))
                    {
                        state = GameState.MainMenu;
                    }

                    break;

                case GameState.PlayGame:
                    road1.Update();
                    road2.Update();
                    t1 += gameTime.ElapsedGameTime;
                 if (road1.rectangle.X<(-1)*GraphicsDevice.Viewport.Width)
                        road1.rectangle.X = GraphicsDevice.Viewport.Width;

                 if (road2.rectangle.X <(-1)* GraphicsDevice.Viewport.Width)
                      road2.rectangle.X = GraphicsDevice.Viewport.Width;
                    playerRectangle = new Rectangle(playerRectangle.X, playerRectangle.Y, 150, 75);

                    if (playerRectangle.Contains(newMousePoint))
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
                        }
                        if (playerRectangle.X < 0)
                        {
                            playerRectangle.X = 0;
                        }
                        if (playerRectangle.Y >= GraphicsDevice.Viewport.Height - 75)
                        {
                            playerRectangle.Y = GraphicsDevice.Viewport.Height - 75;
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

                    if (backRectangle.Contains(newMousePoint))
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
            // make the cars move
            Lane4.X += speedoflines + 10;
            Lane3.X += speedoflines + 5;
            Lane2.X -= speedoflines + 7;
            Lane1.X -= speedoflines + 3;


            // Reset Cars
            if (Lane4.X > 2000)
                Lane4.X = -200;
            if (Lane3.X > 2000)
                Lane3.X = -200;
            if (Lane2.X < 0)
                Lane2.X = 2000;
            if (Lane1.X < 0)
                Lane1.X = 2000;
            
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
            GraphicsDevice.Clear(Color.Black);
            if (startMenuMusic)
            {
                menuSound.Play();  
               

               
                startMenuMusic = false;
            }

            spriteBatch.DrawString(font, "Welcome to the Car Game!", new Vector2(500, 30), Color.White);
            spriteBatch.DrawString(font, "You should choose a car color before pressing Play", new Vector2(383, 60), Color.White);
            spriteBatch.Draw(play, playRectangle, Color.White);
            spriteBatch.Draw(help, helpRectangle, Color.White);
            spriteBatch.Draw(end, endRectangle, Color.White);
            spriteBatch.Draw(carStartImage, picRectangle,Color.White);
          
            spriteBatch.Draw(ChooseColor, choose_colorRectangle, Color.White);
        }

        public void PlayTheGame() {
            spriteBatch.Draw(road, GraphicsDevice.Viewport.Bounds, Color.White);
            road1.Draw(spriteBatch);
            road2.Draw(spriteBatch);

            menuSound.Stop();
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
            
            spriteBatch.DrawString(font, "Points: " +  t1.TotalSeconds.ToString("####.##"), new Vector2(1000, 25),Color.White);
        }
        public void DisplayHelpScreen()
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(font, "\n-To move your car, click and hold the left mouse button and drag the \n wherever you want it to go.\n-Avoid obsticles traveling towards your car for the longest time to win!\n-Click the 'Play' button in to start game.\n-To quit, click the 'End' button. \n-To change the color of the car, click the 'Choose Color' button \n to select one of the colors.", new Vector2(50, 100), Color.White);
            spriteBatch.Draw(back, backRectangle, Color.White);
            
        }
        public void DisplayChooseColor()
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(font, "Please choose a car color listed below.", new Vector2(50, 50), Color.White);

            spriteBatch.Draw(redCar, redRectangle, Color.White);
            spriteBatch.Draw(greenCar, greenRectangle, Color.White);
            spriteBatch.Draw(blueCar, blueRectangle, Color.White);
            spriteBatch.Draw(orangeCar, orangeRectangle, Color.White);
            spriteBatch.Draw(whiteCar, whiteRectangle, Color.White);
            spriteBatch.Draw(pinkCar, pinkRectangle, Color.White);
            spriteBatch.Draw(aquaCar, aquaRectangle, Color.White);
            spriteBatch.Draw(yellowCar, yellowRectangle, Color.White);
            


        }

        public void EndTheGame()
        {
            GraphicsDevice.Clear(Color.Gray);
            Exit();
        }
        }
    }
