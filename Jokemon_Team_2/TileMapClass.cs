using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Jokemon_Team_2
{
    class TileMapClass
    {
        public void CreateMap(Tile[,] tileArray, char[,] tileValuesArray, int TILE_SIZE,
            Texture2D big_tree, Texture2D building, Texture2D Tile_sign, Tree trees, Building house, ReadableObject Wood_sign, SpriteFont loadFont,
            GraphicsDevice GraphicsDevice)
        {
            Vector2 temPosition;
            Vector2 bSize = new Vector2(150, 150);
            Vector2 tSize = new Vector2(80, 100);
            Vector2 sSize = new Vector2(30, 30);
            for (int i = 0; i <= tileArray.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= tileArray.GetUpperBound(1); j++)
                {
                    if (tileValuesArray[i, j].ToString().Contains("1"))
                    {
                        temPosition = new Vector2(i * TILE_SIZE, j * TILE_SIZE);
                        tileArray[i, j] = new Tile(big_tree, temPosition, tSize);
                        trees = new Tree(big_tree, temPosition, tSize, true);

                        

                    }
                    if (tileValuesArray[i, j].ToString().Contains("2"))
                    {
                        temPosition = new Vector2(i * TILE_SIZE, j * TILE_SIZE);
                        tileArray[i, j] = new Tile(building, temPosition, bSize);
                        house = new Building(building, temPosition, bSize, true);
                        Debug.WriteLine("X: {0} Y:{1}", house.spritePosition.X, house.spritePosition.Y);

                    }
                    if (tileValuesArray[i, j].ToString().Contains("3"))
                    {
                        temPosition = new Vector2(i * TILE_SIZE, j * TILE_SIZE);
                        tileArray[i, j] = new Tile(Tile_sign, temPosition, sSize);
                        Wood_sign = new ReadableObject(Tile_sign, temPosition, sSize, loadFont, ("default"), new Vector2(80, 670), true);
                        Debug.WriteLine("X: {0} Y: {1}", Wood_sign.spritePosition.X, Wood_sign.spritePosition.Y);

                        
                    }
                    else if (tileValuesArray[i, j].ToString().Contains("0"))
                    {
                        tileArray[i, j] = new Tile(new Texture2D(GraphicsDevice, 10, 10), new Vector2(0, 0), new Vector2(0, 0));
                    }
                }
            }
        }
    }
}
