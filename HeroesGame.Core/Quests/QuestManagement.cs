using HeroesGame.Configuration;
using System.Collections.Generic;
using System;
using HeroesGame.RefresingMechanism;

namespace HeroesGame.Quests
{
    public class QuestManagement : IQuestManagement
    {
        private readonly IConfigRepository _configRepository;
        private readonly IRefreshingMechnism _refreshingMechnism;

        public QuestManagement(IConfigRepository configRepository, IRefreshingMechnism refreshingMechnism)
        {
            _configRepository = configRepository;
            _refreshingMechnism = refreshingMechnism;
        }

        public bool GenerateQuests()
        {
            var now = DateTime.Now;
            var refreshResult = _refreshingMechnism.GetRefreshStatus(RefreshOption.Quests, now);
            if (refreshResult.Status == RefresStatus.Ready)
            {

                _refreshingMechnism.AddRefreshFactForLoggedAccount(RefreshOption.Quests, now);
                return true;
            }
            else return false;
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
