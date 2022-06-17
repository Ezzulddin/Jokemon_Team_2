using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_2
{
    class CameraManager
    {
        public Matrix Transform { get; private set; }
        public void Follow(Player Target)
        {


            Matrix Position = Matrix.CreateTranslation
                 (-Target.spritePosition.X - (Target.spriteSize.X / 2),
                 -Target.spritePosition.Y - (Target.spriteSize.Y / 2)
                 , 0);
            Matrix offset = Matrix.CreateTranslation(
            Game1.screenWidth / 2,
            Game1.screenHeight / 2,
            0);





            Transform = Position * offset;
        }
    }
}
