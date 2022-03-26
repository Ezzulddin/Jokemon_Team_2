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
        public string message { get; set; }
        public Vector2 messagePosition { get; set; }
        public MessageWindow(Texture2D tex, Vector2 pos, Vector2 size, String mes, Vector2 mesPos)
        {
            this.spriteTexture = tex;
            this.spritePosition = pos;
            this.spriteSize = size;
            this.message = mes;
            this.messagePosition = mesPos;

        }
    }
}
