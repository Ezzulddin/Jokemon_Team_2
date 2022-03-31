using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace Jokemon_Team_2
{
    class BlackScreen
    {
        Color blackSCreen;
        public void LoadBlackSCreen(bool isBlack, GraphicsDevice GraphicsDevice)
        {
            blackSCreen = Color.Black;
            if (isBlack == true)
            {
                GraphicsDevice.Clear(blackSCreen);
            }
            
        }
    }
}
