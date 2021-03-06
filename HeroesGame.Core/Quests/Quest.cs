﻿using System.Collections.Generic;
using HeroesGame.Common;

namespace HeroesGame.Quests
{
    public class Quest : ObjectWithID
    {
        public string Level { get; set; }
        public string Name { get; set; }
        public string FormationID { get; set; }
        public string RewardsID { get; set; }
        public string WinRewards { get; set; }

        public override bool Equals(object obj)
        {
            var toCompare = obj as Quest;
            if (toCompare == null) return false;
            if (toCompare.Name == Name && toCompare.Level == Level && toCompare.FormationID == FormationID && toCompare.RewardsID == RewardsID)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = -1319351149;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Level);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FormationID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RewardsID);
            return hashCode;
        }
    }
}
