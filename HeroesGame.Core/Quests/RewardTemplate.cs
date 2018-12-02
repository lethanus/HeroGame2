using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using HeroesGame.Common;

namespace HeroesGame.Quests
{
    public class RewardTemplate : ObjectWithID
    {
        public string Level { get; set; }
        public string Rewards { get; set; }
    }
}
