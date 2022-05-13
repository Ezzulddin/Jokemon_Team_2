using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_2
{
    class PhysicsManager
    {
        private float speed = 0.1f;
        private int collisionOffset = 3;
        private bool SignInitialize = false;

        public void CheckCollision(Player p, Tree t)
        {
            Rectangle treeRect = new Rectangle((int)t.spritePosition.X, (int)t.spritePosition.Y, (int)t.spriteSize.X, (int)t.spriteSize.Y);

            if (p.goingUp)
            {

                p.projectedPos = new Vector2((int)p.spritePosition.X, (int)p.spritePosition.Y - collisionOffset);
                Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(treeRect))
                {
                    p.hasCollidedTop = true;
                }
                if (p.hasCollidedTop == false)
                {
                    goUp(p);
                    p.hasCollidedBottom = false;
                    p.hasCollidedRight = false;
                    p.hasCollidedLeft = false;
                }
            }
            else if (p.goingDown)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X, (int)p.spritePosition.Y + collisionOffset);
                Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(treeRect))
                {
                    p.hasCollidedBottom = true;
                }
                if (p.hasCollidedBottom == false)
                {
                    goDown(p);
                    p.hasCollidedTop = false;
                    p.hasCollidedRight = false;
                    p.hasCollidedLeft = false;
                }
            }
            else if (p.goingLeft)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X - collisionOffset, (int)p.spritePosition.Y);
                Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(treeRect))
                {
                    p.hasCollidedLeft = true;
                    p.goingUp = false;
                    p.goingDown = false;
                }
                if (p.hasCollidedLeft == false)
                {
                    goLeft(p);
                    p.hasCollidedRight = false;
                    p.hasCollidedTop = false;
                    p.hasCollidedBottom = false;
                }
            }
            else if (p.goingRight)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X + collisionOffset, (int)p.spritePosition.Y);
                Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(treeRect))
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
        public bool CheckSignCollision(Player p, ReadableObject r)
        {
            Rectangle readableObjectRect = new Rectangle((int)r.spritePosition.X, (int)r.spritePosition.Y, (int)r.spriteSize.X, (int)r.spriteSize.Y);

            if (p.goingUp)
            {

                p.projectedPos = new Vector2((int)p.spritePosition.X, (int)p.spritePosition.Y - collisionOffset);
                Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(readableObjectRect))
                {
                    p.hasCollidedTop = true;
                    SignInitialize = true;

                }
                if (p.hasCollidedTop == false)
                { 
                    SignInitialize = false;
                    goUp(p);
                    p.hasCollidedBottom = false;
                    p.hasCollidedRight = false;
                    p.hasCollidedLeft = false;
                }
            }
            else if (p.goingDown)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X, (int)p.spritePosition.Y + collisionOffset);
                Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(readableObjectRect))
                {
                    p.hasCollidedBottom = true;
                }
                if (p.hasCollidedBottom == false)
                {

                    SignInitialize = false;
                    goDown(p);
                    p.hasCollidedTop = false;
                    p.hasCollidedRight = false;
                    p.hasCollidedLeft = false;
                }
            }
            else if (p.goingLeft)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X - collisionOffset, (int)p.spritePosition.Y);
                Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(readableObjectRect))
                {
                    p.hasCollidedLeft = true;
                }
                if (p.hasCollidedLeft == false)
                {
                    goLeft(p);
                    SignInitialize = false;
                    p.hasCollidedRight = false;
                    p.hasCollidedTop = false;
                    p.hasCollidedBottom = false;
                }
            }
            else if (p.goingRight)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X + collisionOffset, (int)p.spritePosition.Y);
                Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(readableObjectRect))
                {
                    p.hasCollidedRight = true;
                }
                if (p.hasCollidedRight == false)
                {
                    goRight(p);
                    SignInitialize = false;
                    p.hasCollidedLeft = false;
                    p.hasCollidedTop = false;
                    p.hasCollidedBottom = false;
                }
            }
            return SignInitialize;

        }
        //public void CheckCollision(Player p, Building b)
        //{
        //    Rectangle buildingRect = new Rectangle((int)b.spritePosition.X, (int)b.spritePosition.Y, (int)b.spriteSize.X, (int)b.spriteSize.Y);

        //    if (p.goingUp)
        //    {

        //        p.projectedPos = new Vector2((int)p.spritePosition.X, (int)p.spritePosition.Y - collisionOffset);
        //        Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

        //        if (projectedPlayerRect.Intersects(buildingRect))
        //        {
        //            p.hasCollidedTop = true;
        //        }
        //        if (p.hasCollidedTop == false)
        //        {
        //            goUp(p);
        //            p.hasCollidedBottom = false;
        //            p.hasCollidedRight = false;
        //            p.hasCollidedLeft = false;
        //        }
        //    }
        //    else if (p.goingDown)
        //    {
        //        p.projectedPos = new Vector2((int)p.spritePosition.X, (int)p.spritePosition.Y + collisionOffset);
        //        Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

        //        if (projectedPlayerRect.Intersects(buildingRect))
        //        {
        //            p.hasCollidedBottom = true;
        //        }
        //        if (p.hasCollidedBottom == false)
        //        {
        //            goDown(p);
        //            p.hasCollidedTop = false;
        //            p.hasCollidedRight = false;
        //            p.hasCollidedLeft = false;
        //        }
        //    }
        //    else if (p.goingLeft)
        //    {
        //        p.projectedPos = new Vector2((int)p.spritePosition.X - collisionOffset, (int)p.spritePosition.Y);
        //        Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

        //        if (projectedPlayerRect.Intersects(buildingRect))
        //        {
        //            p.hasCollidedLeft = true;
        //        }
        //        if (p.hasCollidedLeft == false)
        //        {
        //            goLeft(p);
        //            p.hasCollidedRight = false;
        //            p.hasCollidedTop = false;
        //            p.hasCollidedBottom = false;
        //        }
        //    }
        //    else if (p.goingRight)
        //    {
        //        p.projectedPos = new Vector2((int)p.spritePosition.X + collisionOffset, (int)p.spritePosition.Y);
        //        Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

        //        if (projectedPlayerRect.Intersects(buildingRect))
        //        {
        //            p.hasCollidedRight = true;
        //        }
        //        if (p.hasCollidedRight == false)
        //        {
        //            goRight(p);
        //            p.hasCollidedLeft = false;
        //            p.hasCollidedTop = false;
        //            p.hasCollidedBottom = false;
        //        }
        //    }
        //}
        public void goLeft(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X - speed, playerSprite.spritePosition.Y);
        }
        public void goRight(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X + speed, playerSprite.spritePosition.Y);
        }
        public void goUp(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X, playerSprite.spritePosition.Y - speed);
        }
        public void goDown(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X, playerSprite.spritePosition.Y + speed);
        }
    }
}
