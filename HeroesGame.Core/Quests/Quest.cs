using System.Collections.Generic;
using HeroesGame.Common;

namespace HeroesGame.Quests
{
    public class Quest : ObjectWithID
    {
        public string Level { get; set; }
        public string Name { get; set; }
        public string FormationID { get; set; }
        public string WinRewards { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            var hashCode = -1319351149;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Level);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FormationID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(WinRewards);
            return hashCode;
        }
    }
}
