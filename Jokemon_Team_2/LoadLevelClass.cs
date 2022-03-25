using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_2
{
    class LoadLevelClass
    {
        private bool blackScreen = false;
        public void LoadLevel(Player p,GraphicsDeviceManager inGraphics)
        {
            if(p.spritePosition.Y <= 5)
            {
                inGraphics.GraphicsDevice.Clear(Color.Black);
            }
        }
    }
}
