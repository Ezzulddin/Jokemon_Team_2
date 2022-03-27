using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Jokemon_Team_2
{
    class BlackScreen : Sprite
    {
        //public BlackScreen(Texture2D tex, Vector2 pos, Vector2 size)
        //{
        //    this.spriteTexture = tex;
        //    this.spritePosition = pos;
        //    this.spriteSize = size;

        //}


        public void Undraw(List<Tree> treeObjects,SpriteBatch spriteBatch,int timer)
        {
            foreach(Tree tr in treeObjects)
            {
                if(tr.IsDraw)
                {
                    tr.DrawSprite(spriteBatch,tr.spriteTexture);
                    if(timer == 0)
                    {
                        tr.IsDraw = false;
                    }
                }
            }
        }
        
        public void NewLevelDraw(SpriteBatch spriteBatch,Building b)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(b.spriteTexture, new Rectangle((int)spritePosition.X, (int)spritePosition.Y, (int)spriteSize.X, (int)spriteSize.Y), Color.White);
            spriteBatch.End();
        }

    }
}
