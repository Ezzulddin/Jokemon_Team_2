using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_2
{
    class Sprite
    {
        public Texture2D SpriteTexture { get; set; }
        public Vector2 SpritePosition { get; set; }
        public Vector2 SpriteSize { get; set; }

        public Sprite()
        {

        }

        public Sprite(Texture2D tex, Vector2 pos, Vector2 size)
        {
            this.SpriteTexture = tex;
            this.SpritePosition = pos;
            this.SpriteSize = size;

        }

        public void drawSprite(SpriteBatch spriteBatch, Texture2D texture)
        {
            SpriteTexture = texture;
            spriteBatch.Begin();
            spriteBatch.Draw(SpriteTexture, new Rectangle((int)SpritePosition.X, (int)SpritePosition.Y, (int)SpriteSize.X, (int)SpriteSize.Y), Color.White);
            spriteBatch.End();

        }


    }
}
