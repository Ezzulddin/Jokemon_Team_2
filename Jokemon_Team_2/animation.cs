using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Jokemon_Team_2
{
    class animation
    {
        private Texture2D sSheet;

        private float timer;

        private int threshold;

        Rectangle[] sourceRectangles;

        byte previousAnimationIndex;
        byte currentAnimationIndex;
        //sourceRectangles[0] = new Rectangle(0, 0, sSheet.Width / 3, sSheet.Height / 4);
        //sourceRectangles[1] = new Rectangle(sSheet.Width / 3, 0, (sSheet.Width / 3), sSheet.Height / 4); ;
        //sourceRectangles[2] = new Rectangle(sSheet.Width / 3 * 2, 0, (sSheet.Width / 3), sSheet.Height / 4);

        //    previousAnimationIndex = 2;
        //    currentAnimationIndex = 1;

        public animation()
        {

 



        }
        private void updateAnimationFrame()
        {
            if (timer > threshold) //time to change frames
            {
                // 0 is left sprite, 1 middle, 2 right

                if (currentAnimationIndex == 1)  // if we're on the middle sprite
                {
                    if (previousAnimationIndex == 0)  //if our last frame was the left frame
                    {
                        currentAnimationIndex = 2;  //show right frame
                    }
                    else                         // else show left frame
                    {
                        currentAnimationIndex = 0;
                    }

                    previousAnimationIndex = currentAnimationIndex;
                }

                else //return to middle sprite
                {
                    currentAnimationIndex = 1;
                }

                timer = 0; //reset timer
            }

            else
            {
                timer += 1;
            }
        }

    }
}
