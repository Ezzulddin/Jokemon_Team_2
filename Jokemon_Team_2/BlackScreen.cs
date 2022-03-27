using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Jokemon_Team_2
{
    class BlackScreen
    {

        public void FadeScreen(Player p,GraphicsDevice inGraphics,int timer)
        {
            p.projectedPos = new Vector2(360, 380);
            
            if(p.spritePosition.Y <= 5)
            {
                inGraphics.Clear(Color.Black);
                timer--;
                
                if(timer == 0)
                {
                    Rectangle playerNewPos = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
                }
            }
        }
    }
}
