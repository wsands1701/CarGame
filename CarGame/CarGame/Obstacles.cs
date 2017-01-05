using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGame
{
    abstract class Obstacles
    {
        private int x;
        private int y;
        private int speed;
        bool collide;
        Texture2D image;

        //arrays of x and y coordinates
        int[] yCoords = new int[] { 150, 310, 450, 620 };
        int[] xCoords = new int[] { -20, 1300 };


        //generates a random number
        Random rnd = new Random();

        //overloaded constructor method
        //If NotMoving
   
            /*    public Obstacles(int X, int Y, int Speed, Boolean Collision)
        {
            this.x = X;
            this.y = Y;
            this.speed = Speed;
            collide = Collision;
            
        }*/



        //if traffic(Moving)
      public Obstacles(int x,int y, int Speed, bool collision, Texture2D Image)
            {
           this.x = x;
           this.y = y;
           this.speed = Speed;
           this.image = Image;
           this.collide = collision;
           }
        //Sets
        public void setX(int X)
        {               //How do i make it so that it doesnt generate two random numbers, but instead compares to value of the same, randomly- generated, number?
            int rand = rnd.Next(0, 3);
            if (yCoords[rand] == 150) || yCoords[rand] == 310)
                {
                x = 1300;
            }
        }
                    
            
         public void setY(int Y)
            {
              y = Y;
            }
        
        public void setSpeed(int Speed)
            {
                speed = Speed;
           
            }
        public void setCollide(Boolean collision)
            {
                collide = collision;
            }
        //Gets
        public int getX()
            {
                 return x;
            }

        public int getY()
            {
                return y;
            }
        private int getSpeed()
            {
                return speed;
            }
        public Boolean getCollide()
            {
                return collide;
            }

       

       // new object car1(int xCoord, int yCoord, Boolean collison, int speed);


        
    }



    /* What we need to do:
    make an ArrayList of Obejcts that we can add/subtract from. Each object will need to have the following properties:
                -Spawning position
                -speed (tree vs. oncoming traffic)
                -collision (boolean)

    Make a Traffic Class
        -adds color


    */
}
