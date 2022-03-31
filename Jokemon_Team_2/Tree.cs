using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_2
{
    class Tree : Sprite
    {
        private bool draw;
        public Tree(Texture2D tex, Vector2 pos, Vector2 size,bool isDraw) : base(tex, pos, size)
        {
            draw = isDraw;
        }

        public bool IsDraw
        {
            get { return draw; }
            set { draw = value; }
        }
    }
}
