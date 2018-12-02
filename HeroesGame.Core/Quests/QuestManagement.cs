﻿using HeroesGame.Configuration;
using System.Collections.Generic;
using System;
using System.Linq;
using HeroesGame.RefresingMechanism;
using HeroesGame.Core.Randomizers;
using HeroesGame.Mercenaries;
using HeroesGame.PackBuilding;
using HeroesGame.Accounts;

namespace HeroesGame.Quests
{
    public class QuestManagement : IQuestManagement
    {
        private readonly IConfigRepository _configRepository;
        private readonly IRefreshingMechnism _refreshingMechnism;
        private readonly IValueRandomizer _randomizer;
        private readonly IFormationTemplateRepository _formationTemplateRepository;
        private readonly IAccountManagement _accountManagement;
        private readonly IQuestRepository _questRepository;
        private readonly IRewardTemplatesRepository _rewardTemplatesRepository;

        public QuestManagement(IConfigRepository configRepository, IRefreshingMechnism refreshingMechnism, 
            IValueRandomizer randomizer, IFormationTemplateRepository formationTemplateRepository,
            IAccountManagement accountManagement, IQuestRepository questRepository, IRewardTemplatesRepository rewardTemplatesRepository)
        {
            _configRepository = configRepository;
            _refreshingMechnism = refreshingMechnism;
            _randomizer = randomizer;
            _formationTemplateRepository = formationTemplateRepository;
            _accountManagement = accountManagement;
            _questRepository = questRepository;
            _rewardTemplatesRepository = rewardTemplatesRepository;
        }

        public bool GenerateQuests()
        {
            var now = DateTime.Now;
            var refreshResult = _refreshingMechnism.GetRefreshStatus(RefreshOption.Quests, now);
            if (refreshResult.Status == RefresStatus.Ready)
            {
                _questRepository.Clear(_accountManagement.GetLoggedAccount().ID);
                var numberOfQuests = Int32.Parse(_configRepository.GetParameterValue("NumberOfQuests"));
                var quests = new List<Quest>();
                var questLevelChanges = new Dictionary<int, ChanceRange>();
                questLevelChanges.Add(1, new ChanceRange(_configRepository.GetParameterValue("ChanceForLevel_1_quest")));
                questLevelChanges.Add(2, new ChanceRange(_configRepository.GetParameterValue("ChanceForLevel_2_quest")));
                questLevelChanges.Add(3, new ChanceRange(_configRepository.GetParameterValue("ChanceForLevel_3_quest")));
                questLevelChanges.Add(4, new ChanceRange(_configRepository.GetParameterValue("ChanceForLevel_4_quest")));

                for (int i = 1; i <= numberOfQuests; i++)
                {
                    var randomValue = _randomizer.GetRandomValueInRange(1, questLevelChanges[1].MaxValue, "Quest_level_chance");
                    int level = 1;
                    for (int j = 1; j <= 4; j++)
                    {
                        if (randomValue < questLevelChanges[j].Value) level = j;
                    }

                    var formationTemplates = _formationTemplateRepository.GetAll().Where(x => x.Level == level);
                    FormationTemplate choosenFormationTemplate = null;
                    var possibleFormations = formationTemplates.Where(x => x.Level == level);
                    var amountOfTemplates = possibleFormations.Count();
                    var counter = 1;
                    var formationDictionary = possibleFormations.ToDictionary(x => counter++, x => x);
                    if (amountOfTemplates > 0)
                    {
                        var choosen = _randomizer.GetRandomValueInRange(1, amountOfTemplates+1, "ChoosingFormation");
                        choosenFormationTemplate = formationDictionary[choosen];
                        RewardTemplate rewardTemplate = null;
                        var counterRewards = 1;
                        var allRewardTemplates = _rewardTemplatesRepository.GetAll().Where(x => x.Level == level.ToString());
                        var amountOfRewardTemplates = allRewardTemplates.Count();
                        var rewardsDictionary = allRewardTemplates.ToDictionary(x => counterRewards++, x => x);
                        if (amountOfRewardTemplates > 0)
                        {
                            var choosenReward = _randomizer.GetRandomValueInRange(1, amountOfRewardTemplates + 1, "ChoosingRewards");
                            rewardTemplate = rewardsDictionary[choosenReward];
                        }

                        quests.Add(new Quest {
                            ID = $"Q_{i}",
                            Level = level.ToString(),
                            FormationID = choosenFormationTemplate.ID,
                            Name = $"Defeat - {choosenFormationTemplate.Name}",
                            WinRewards = rewardTemplate == null ? "" : rewardTemplate.ID
                        });
                    }
                }
                foreach (var quest in quests)
                {
                    _questRepository.Add(quest, _accountManagement.GetLoggedAccount().ID);
                }

                _refreshingMechnism.AddRefreshFactForLoggedAccount(RefreshOption.Quests, now);
                return true;
            }
            else return false;
        }

        public List<Quest> GetAll()
        {
            return _questRepository.GetAll(_accountManagement.GetLoggedAccount().ID);
        }
    }
}
