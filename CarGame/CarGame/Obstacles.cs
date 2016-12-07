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


    }
}
