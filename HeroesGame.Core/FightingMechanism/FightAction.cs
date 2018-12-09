using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.FightMechanizm
{
    public class FightAction
    {
        public int Action_Order { get; set; }
        public int Attacker_ID { get; set; }
        public int Attacker_Position { get; set; }
        public int Defender_ID { get; set; }
        public int Defender_Position { get; set; }
        public int Defender_New_Hp { get; set; }
        public int Attacker_DMG_dealt { get; set; }

    }
}
