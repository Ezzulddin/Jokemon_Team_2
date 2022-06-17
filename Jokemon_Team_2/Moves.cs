using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_2
{
    class Moves
    {
        public Moves()
        {

        }
        
        private static int Power, Acc, Damage, PP;
        private static string moveName;
        //Test Change

        #region Normal Type
        private static string growl;
        private static string tackle;
        private static string quickattack;
        #endregion

        #region Grass Type
        private static string vinewhip;
        private static string leechseed;
        private static string razorleaf;
        #endregion

        #region Fire Type
        private static string ember;
        private static string firefang;
        private static string flamethrower;
        #endregion

        #region Water Type
        private static string watergun;
        private static string waterpulse;
        private static string bubble;
        #endregion

        #region Lightning Type
        private static string nuzzle;
        private static string thundershock;
        private static string spark;
        #endregion

        #region Ground Type
        private static string rollout;
        private static string rockthrow;
        private static string smackdown;
        #endregion

        #region Poison Type
        private static string acid;
        private static string poisonsting;
        private static string smog;
        #endregion

        #region Flying Type
        private static string gust;
        private static string wingattack;
        private static string airslash;
        #endregion



    

        
        public static void MoveUsed(int inAtt, int Damage)
        {
            if (moveName == tackle.ToLower())
            {
                PP = 35;
                Power = 40;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == growl.ToLower())
            {
                PP = 40;
                Power = 0;
                Acc = 100;
                PP -= 1;
                
            }
            else if (moveName == quickattack.ToLower())
            {
                PP = 30;
                Power = 40;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == vinewhip.ToLower())
            {
                PP = 25;
                Power = 45;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == leechseed.ToLower())
            {
                PP = 10;
                Power = 0;
                Acc = 90;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == razorleaf.ToLower())
            {
                PP = 25;
                Power = 55;
                Acc = 95;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == ember.ToLower())
            {
                PP = 25;
                Power = 40;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == firefang.ToLower())
            {
                PP = 15;
                Power = 65;
                Acc = 95;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == flamethrower.ToLower())
            {
                PP = 15;
                Power = 90;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == watergun.ToLower())
            {
                PP = 25;
                Power = 40;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == waterpulse.ToLower())
            {
                PP = 20;
                Power = 60;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == bubble.ToLower())
            {
                PP = 30;
                Power = 40;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == nuzzle.ToLower())
            {
                PP = 20;
                Power = 20;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == thundershock.ToLower())
            {
                PP = 30;
                Power = 40;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == spark.ToLower())
            {
                PP = 20;
                Power = 65;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == rollout.ToLower())
            {
                PP = 20;
                Power = 30;
                Acc = 90;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == rockthrow.ToLower())
            {
                PP = 15;
                Power = 50;
                Acc = 90;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == smackdown.ToLower())
            {
                PP = 15;
                Power = 50;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == acid.ToLower())
            {
                PP = 30;
                Power = 40;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == poisonsting.ToLower())
            {
                PP = 35;
                Power = 15;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == smog.ToLower())
            {
                PP = 20;
                Power = 30;
                Acc = 70;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == gust.ToLower())
            {
                PP = 35;
                Power = 40;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == wingattack.ToLower())
            {
                PP = 35;
                Power = 60;
                Acc = 100;
                Damage = inAtt + Power;
                PP -= 1;
            }
            else if (moveName == airslash.ToLower())
            {
                PP = 15;
                Power = 75;
                Acc = 95;
                Damage = inAtt + Power;
                PP -= 1;
            }
        }
    }
}
