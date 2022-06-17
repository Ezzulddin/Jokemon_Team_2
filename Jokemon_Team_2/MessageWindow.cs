using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Jokemon_Team_2
{
    class MessageWindow : Sprite
    {


        public MessageWindow(Texture2D tex, Vector2 pos, Vector2 size)
        {
            this.spriteTexture = tex;
            this.spritePosition = pos;
            this.spriteSize = size;
        }
        public void DrawMessageWindow(SpriteBatch spriteBatch, Texture2D messageTexture)

        {
            spriteBatch.Begin();
            spriteBatch.Draw(messageTexture, new Rectangle((int)spritePosition.X, (int)spritePosition.Y, (int)spriteSize.X, (int)spriteSize.Y), Color.White);
            spriteBatch.End();
        
        }

    }
}