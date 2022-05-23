using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Jokemon_Team_2
{
    class InputManager
    {
        KeyboardState state;
        MouseState mouse;

        public void CheckKeys(Player playerSprite,GraphicsDeviceManager inGraphics)
        {
            state = Keyboard.GetState();

            playerSprite.goingLeft = false;
            playerSprite.goingRight = false;
            playerSprite.goingUp = false;
            playerSprite.goingDown = false;

            if (state.IsKeyDown(Keys.A))
            {
                playerSprite.goingLeft = true;
                if(playerSprite.spritePosition.X <= 0)
                {
                    playerSprite.goingLeft = false;
                }
            }

            if (state.IsKeyDown(Keys.D))
            {
                playerSprite.goingRight = true;
                if(playerSprite.spritePosition.X >= inGraphics.PreferredBackBufferWidth)
                {
                    playerSprite.goingRight = false;
                }
            }

            if (state.IsKeyDown(Keys.W))
            {
                playerSprite.goingUp = true;
                if(playerSprite.spritePosition.Y <= 0)
                {
                    playerSprite.goingUp = false;
                }
            }

            if (state.IsKeyDown(Keys.S))
            {
                playerSprite.goingDown = true;
                if(playerSprite.spritePosition.Y >= inGraphics.PreferredBackBufferHeight)
                {
                    playerSprite.goingDown = false;
                }
            }
        }

        
    }
}
