using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_2
{
    class ReadableObject : Sprite
    {
        private bool isDrawn;
        public SpriteFont Fontfile { get; set; }
        public string message { get; set; }
        public Vector2 messagePosition { get; set; }

        public ReadableObject(Texture2D tex, Vector2 pos, Vector2 size, SpriteFont sFont, String mes, Vector2 mesPos, bool Drawn) : base(tex, pos, size)
        {
            this.spriteTexture = tex;
            this.spritePosition = pos;
            this.spriteSize = size;
            this.Fontfile = sFont;
            this.message = mes;
            this.messagePosition = mesPos;
            this.isDrawn = Drawn;
        }
        public void DrawMessage(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            Vector2 textLeftPoint = Fontfile.MeasureString(message) - Fontfile.MeasureString(message);
            spriteBatch.DrawString(Fontfile, message, messagePosition, Color.DarkBlue, 0, textLeftPoint, 2.5f, SpriteEffects.None, 0.5f);
            spriteBatch.End();

        }

        public bool IsDrawn
        {
            get { return isDrawn; }
            set { isDrawn = value; }
        }
    }
}