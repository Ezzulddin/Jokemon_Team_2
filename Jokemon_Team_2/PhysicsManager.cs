using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Jokemon_Team_2
{
    internal class PhysicsManager
    {

        private float speed = 0.35f;
        private int collisionOffset = 3;


        public void checkCollision(Player p, Rectangle r)
        {
            if (p.goingUp)
            {
                p.projectedPos = new Vector2(p.spritePosition.X, p.spritePosition.Y - collisionOffset); //check if we are about to collide
                Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(r)) //check if projection has collided
                {
                    p.hasCollidedTop = true;
                }
                if (p.hasCollidedTop == false) //if we're not at the top, let the player go up
                {
                    goUp(p);
                    p.hasCollidedBottom = false; //if we've gone up, can't be colliding with bottom
                    p.hasCollidedLeft = false;
                    p.hasCollidedRight = false;
                }
            }
            else if (p.goingDown)
            {

                p.projectedPos = new Vector2(p.spritePosition.X, p.spritePosition.Y + collisionOffset); //check if we are about to collide
                Rectangle projectedPlayerSprite = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerSprite.Intersects(r)) //check if projection has collided
                {
                    p.hasCollidedBottom = true;
                }


                if (p.hasCollidedBottom == false)
                {
                    goDown(p);
                    p.hasCollidedTop = false;
                    p.hasCollidedLeft = false;
                    p.hasCollidedRight = false;
                }


            }
            else if (p.goingLeft)
            {

                p.projectedPos = new Vector2(p.spritePosition.X - collisionOffset, p.spritePosition.Y); //check if we are about to collide
                Rectangle projectedPlayerSprite = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerSprite.Intersects(r)) //check if projection has collided
                {
                    p.hasCollidedLeft = true;
                }


                if (p.hasCollidedLeft == false)
                {
                    goLeft(p);
                    p.hasCollidedRight = false;
                    p.hasCollidedBottom = false;
                    p.hasCollidedTop = false;
                }

            }
            else if (p.goingRight)
            {

                p.projectedPos = new Vector2(p.spritePosition.X + collisionOffset, p.spritePosition.Y); //check if we are about to collide
                Rectangle projectedPlayerSprite = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerSprite.Intersects(r)) //check if projection has collided
                {
                    p.hasCollidedRight = true;
                }


                if (p.hasCollidedRight == false)
                {
                    goRight(p);
                    p.hasCollidedLeft = false;
                    p.hasCollidedTop = false;
                    p.hasCollidedBottom = false;
                }
            }
        }


        public void goLeft(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X - speed, playerSprite.spritePosition.Y);
        }

        public void goRight(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X + speed, playerSprite.spritePosition.Y);
        }

        public void goDown(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X, playerSprite.spritePosition.Y + speed);
        }

        public void goUp(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X, playerSprite.spritePosition.Y - speed);
        }


    }
}
