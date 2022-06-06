using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics; 

namespace Jokemon_Team_2
{
    class AttackManager
    {
        public int HP { get; set; }
        public int Att { get; set; }
        public int Def { get; set; }
        public int SpAtt { get; set; }
        public int SpDef { get; set; }
        public int Spd { get; set; }
        public int Damage { get; set; }
        public string move1 { get; set; }
        public string move2 { get; set; }
        public string move3 { get; set; }
        public string move4 { get; set; }

        
        //public bool Physical;
        public AttackManager(int inHP ,int inAtt, int inDeff, int inSpAtt, int inSpDef, int inSpd, int inDamage)
        {
            inAtt = Att;
            inDeff = Def;
            inSpAtt = SpAtt;
            inSpDef = SpDef;
            inSpd = Spd;
            inHP = HP;
            inDamage = Damage;
            
            //I still don't have a proper system in mind so I'm just attempting to figure one out 
            
        }
        public static void CheckDamage(int inAtt, int inDamage)
        {
            Moves.MoveUsed(inAtt, inDamage);
            Debug.WriteLine("IT WORKS HAHAHAHAHAHHA");

        }
        



    }
}
