using System.Collections.Generic;

namespace HeroesGame.Quests
{
    public class QuestManagement : IQuestManagement
    {
        public bool GenerateQuests()
        {
            return true;
        }

        public List<Quest> GetAll()
        {
            var quests = new List<Quest>();

            quests.Add(new Quest { ID = "Q1", Level = "1", FormationID = "T_1", Name = "Defeat - Goblin pack", WinRewards = "" });

            return quests;
        }
    }
}
