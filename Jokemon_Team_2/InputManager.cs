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

        public void CheckKeys(Player playerSprite, GraphicsDeviceManager inGraphics)
        {
            state = Keyboard.GetState();

            playerSprite.goingLeft = false;
            playerSprite.goingRight = false;
            playerSprite.goingUp = false;
            playerSprite.goingDown = false;

            if (state.IsKeyDown(Keys.A))
            {
                playerSprite.goingLeft = true;
                
            }

            if (state.IsKeyDown(Keys.D))
            {
                playerSprite.goingRight = true;
                
            }

            if (state.IsKeyDown(Keys.W))
            {
                playerSprite.goingUp = true;
                
            }

            if (state.IsKeyDown(Keys.S))
            {
                playerSprite.goingDown = true;
                
            }
        }


    }
}
