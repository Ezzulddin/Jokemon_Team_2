using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_2
{

    class Building : Sprite
    {
        bool isCollidable = true;
        bool isInteractable = true;
        public Building(Texture2D tex, Vector2 pos, Vector2 size, bool draw) : base(tex, pos, size)
        {

        }

    }

}
