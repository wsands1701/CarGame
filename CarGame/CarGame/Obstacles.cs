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
        private int wastfilly;
        Boolean Collide;

        //Gets
        public int getX()
        {
            return x;
        }

        public int getY()
    {
            return y;
        }
        private int getWastFilly()
        {
            return wastfilly;
        }
        public Boolean getCollide()
        {
            return Collide;
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
        
        public void setWastFilly(int WastFilly)
        {
            wastfilly = WastFilly;
           
        }
        public void setCollide(Boolean collide)
        {
            Collide = collide;
        }

        new object car1(int xCoord, int yCoord, Boolean collison, int speed);

        public int getX()
        {
            return x;
        }
        
        public int getY()
        {
            return y;
    }


    }
}
