using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGame
{
    class Player
    {
        Texture2D player;

        public Point GetMousePosition()
        {
            return new Point(Mouse.GetState().X, Mouse.GetState().Y); 
        }

        

        
    }

    

}
