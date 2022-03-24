using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_2
{
    class InputManager
    {

        KeyboardState state;
        private int speed = 1;
        public void CheckKeys()
        {
            state = Keyboard.GetState();
            
        }

        public void goLeft()
        {

        }
    }
}
