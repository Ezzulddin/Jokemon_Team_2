using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_2
{
    class Player : Sprite
    {
        public Vector2 projectedPos;
        public bool hasCollidedTop = false;
        public bool hasCollidedBottom = false;
        public bool hasCollidedLeft = false;
        public bool hasCollidedRight = false;

        public bool goingLeft;
        public bool goingRight;
        public bool goingUp;
        public bool goingDown;

        private bool isDrawn;

        public Player(Texture2D tex, Vector2 pos, Vector2 size,bool draw) : base(tex, pos, size)
        {
            isDrawn = draw;
        }
        public bool IsDrawn
        {
            get { return isDrawn; }
            set { isDrawn = value; }
        }
    }
}

