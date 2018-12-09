using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Characters;

namespace HeroesGame.FightMechanizm
{
    public class FightAction
    {
        public int Action_Order { get; set; }
        public string Attacker_ID { get; set; }
        public TeamPosition Attacker_Position { get; set; }
        public string Defender_ID { get; set; }
        public TeamPosition Defender_Position { get; set; }
        public int Defender_New_Hp { get; set; }
        public int Attacker_DMG_dealt { get; set; }

        public override bool Equals(object obj)
        {
            var toCompare = obj as FightAction;
            if (Action_Order == toCompare.Action_Order &&
               Attacker_ID == toCompare.Attacker_ID &&
               Attacker_Position == toCompare.Attacker_Position &&
               Defender_ID == toCompare.Defender_ID &&
               Defender_Position == toCompare.Defender_Position &&
               Defender_New_Hp == toCompare.Defender_New_Hp &&
               Attacker_DMG_dealt == toCompare.Attacker_DMG_dealt 
               )
                return true;
            return false;
        }
    }

    
}
