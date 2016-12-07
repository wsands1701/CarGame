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

        public int getX()
        {
            return x;
        }

        public int getY()
    {
            return y;
        }


        new object car1(int xCoord, int yCoord, Boolean collison, int speed);


        
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
