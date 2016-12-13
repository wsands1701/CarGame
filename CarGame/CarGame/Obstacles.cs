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
        Boolean collide;
        Texture2D image;
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
      public Obstacles(int x,int y, int Speed, Boolean collision, Texture2D Image)
            {
           this.x = x;
           this.y = y;
           this.speed = Speed;
           image = Image;
           collide = collision;
           } 
         //Sets
        public void setX(int X)
            {
                 x = X;
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
