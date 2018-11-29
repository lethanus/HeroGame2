using HeroesGame.Configuration;
using System.Collections.Generic;
using System;

namespace HeroesGame.Quests
{
    public class QuestManagement : IQuestManagement
    {
        private readonly IConfigRepository _configRepository;

        public QuestManagement(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        public bool GenerateQuests()
        {
            return true;
        }

        public List<Quest> GetAll()
        {
            var numberOfQuests = Int32.Parse( _configRepository.GetParameterValue("NumberOfQuests"));
            var quests = new List<Quest>();

            for (int i = 1; i <= numberOfQuests; i++)
            {
                quests.Add(new Quest { ID = $"Q_{1}", Level = "1", FormationID = "T_1", Name = "Defeat - Goblin pack", WinRewards = "" });
            }
            return quests;
        }
    }
}
