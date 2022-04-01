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

        public ReadableObject(Texture2D tex, Vector2 pos, Vector2 size, bool drawn)
            : base(tex, pos, size)
        {
            isDrawn = drawn;
        }
        public bool IsDrawn
        {
            get { return isDrawn; }
            set { isDrawn = value; }
        }
    }
}
