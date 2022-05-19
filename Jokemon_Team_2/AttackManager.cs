using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_2
{
    class AttackManager
    {
        public int HP, Att, Def, SpAtt, SpDef, Spd;
        //public bool Physical;
        public AttackManager(int inHP ,int inAtt, int inDeff, int inSpAtt, int inSpDef, int inSpd)
        {
            inAtt = Att;
            inDeff = Def;
            inSpAtt = SpAtt;
            inSpDef = SpDef;
            inSpd = Spd;
            inHP = HP;
            //I still don't have a proper system in mind so I'm just attempting to figure one out 
        }

        public static void PhysicalAtt(int inAtt)
        {
            
        }
        public static void SpecialAtt(int inSpAtt)
        {

        }
        public static void StatusMoves(int inSpAtt)
        {

        }
        public static void DamageReduction(int inDef, int inSpDef)
        {

        }
        public static bool Physical()
        {
            return true;
        }

    }
}
