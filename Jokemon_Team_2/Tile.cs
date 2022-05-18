using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
namespace Jokemon_Team_2
{
    class Tile : Sprite
    {
        public Tile()
        {

        }
        public Tile(Texture2D inTexture,Vector2 inPosition,Vector2 inSize)
            : base(inTexture,inPosition,inSize)
        {

        }
        public Vector2 GetTilePosition { get; set; }
        public string TileType { get; set; }
    }
}
