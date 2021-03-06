﻿using HeroesGame.Configuration;
using System.Collections.Generic;
using System;
using System.Linq;
using HeroesGame.RefresingMechanism;
using HeroesGame.Core.Randomizers;
using HeroesGame.Mercenaries;
using HeroesGame.PackBuilding;
using HeroesGame.Accounts;
using HeroesGame.Inventory;
using HeroesGame.FightMechanizm;
using HeroesGame.Loggers;

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
        private readonly IInventoryManagement _inventoryManagement;
        private readonly IItemTemplateRepository _itemTemplateRepository;
        private readonly IFightManagement _fightManagement;
        private ConfigurationAdapter configurationAdapter = new ConfigurationAdapter();

        public QuestManagement(IConfigRepository configRepository, IRefreshingMechnism refreshingMechnism, 
            IValueRandomizer randomizer, IFormationTemplateRepository formationTemplateRepository,
            IAccountManagement accountManagement, IQuestRepository questRepository, 
            IRewardTemplatesRepository rewardTemplatesRepository, IInventoryManagement inventoryManagement,
            IItemTemplateRepository itemTemplateRepository, IFightManagement fightManagement)
        {
            _configRepository = configRepository;
            _refreshingMechnism = refreshingMechnism;
            _randomizer = randomizer;
            _formationTemplateRepository = formationTemplateRepository;
            _accountManagement = accountManagement;
            _questRepository = questRepository;
            _rewardTemplatesRepository = rewardTemplatesRepository;
            _inventoryManagement = inventoryManagement;
            _itemTemplateRepository = itemTemplateRepository;
             _fightManagement = fightManagement;
        }

        public bool GenerateQuests()
        {
            configurationAdapter.LoadConfigs(_configRepository);
            var now = DateTime.Now;
            var refreshResult = _refreshingMechnism.GetRefreshStatus(RefreshOption.Quests, now);
            if (refreshResult.Status == RefresStatus.Ready)
            {
                _questRepository.Clear(_accountManagement.GetLoggedAccount().ID);
                List<Quest> quests = new List<Quest>();
                for (int i = 1; i <= configurationAdapter.NumberOfQuests; i++)
                    quests.Add(GenerateFightQuest(GetRandomLevel(configurationAdapter.QuestGenerateChances), i));

                _questRepository.AddMany(quests, _accountManagement.GetLoggedAccount().ID);

                _refreshingMechnism.AddRefreshFactForLoggedAccount(RefreshOption.Quests, now);
                return true;
            }
            else return false;
        }

        private Quest GenerateFightQuest(int level, int counter)
        {
            FormationTemplate choosenFormationTemplate = GetRandomFormationTemplateForLevel(level);
            RewardTemplate rewardTemplate = GetRandomRewardTemplateForLevel(level);
            if (choosenFormationTemplate != null)
            {
                return new Quest
                {
                    ID = $"Q_{counter}",
                    Level = level.ToString(),
                    FormationID = choosenFormationTemplate.ID,
                    Name = $"Defeat - {choosenFormationTemplate.Name}",
                    RewardsID = rewardTemplate == null ? "" : rewardTemplate.ID,
                    WinRewards = rewardTemplate == null ? "" : rewardTemplate.Rewards
                };
            }
            return null;
        }


        private int GetRandomLevel(Dictionary<int, ChanceRange> questLevelChances)
        {
            var randomValue = _randomizer.GetRandomValueInRange(1, questLevelChances[1].MaxValue, "Quest_level_chance");
            int level = 1;
            for (int j = 1; j <= 4; j++)
            {
                if (randomValue < questLevelChances[j].Value) level = j;
            }
            return level;
        }

        private FormationTemplate GetRandomFormationTemplateForLevel(int level)
        {
            FormationTemplate choosenFormationTemplate = null;
            var formationTemplates = _formationTemplateRepository.GetAll().Where(x => x.Level == level);
            var possibleFormations = formationTemplates.Where(x => x.Level == level);
            var amountOfTemplates = possibleFormations.Count();
            var counter = 1;
            var formationDictionary = possibleFormations.ToDictionary(x => counter++, x => x);
            if (amountOfTemplates > 0)
            {
                var choosen = _randomizer.GetRandomValueInRange(1, amountOfTemplates + 1, "ChoosingFormation");
                choosenFormationTemplate = formationDictionary[choosen];
            }
            return choosenFormationTemplate;
        }

        private RewardTemplate GetRandomRewardTemplateForLevel(int level)
        {
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
            return rewardTemplate;
        }

        public List<Quest> GetAll()
        {
            return _questRepository.GetAll(_accountManagement.GetLoggedAccount().ID);
        }

        private void AddReward(string rewardString)
        {
            var splited = rewardString.Split('_');
            int amount = Int32.Parse(splited[0]);
            string itemName = splited[1];
            string itemID = _itemTemplateRepository.GetAll().First(x => x.Name == itemName).ID;
            _inventoryManagement.AddItems(itemID, amount);
        }

        public string StartQuest(string questID)
        {
            var selectedQuest = GetAll().First(x => x.ID == questID);

            _fightManagement.PrepareFightAgainstTemplate(selectedQuest.FormationID);
            _fightManagement.StartFight();
            var questResult = _fightManagement.GetLastFightResult();
            var quest = _questRepository.GetAll(_accountManagement.GetLoggedAccount().ID).First(x => x.ID == questID);
            if (questResult == FightResult.PlayerWins && !string.IsNullOrEmpty(quest.RewardsID))
            {
                var rewardTemaplate = _rewardTemplatesRepository.GetAll().First(x => x.ID == quest.RewardsID);
                foreach (var reward in rewardTemaplate.Rewards.Split(':'))
                {
                    AddReward(reward);
                }
            }
            _questRepository.Remove(quest, _accountManagement.GetLoggedAccount().ID);
            return questResult == FightResult.PlayerWins ? "Completed" : "NotCompleted";
        }

        public FightReplay GetLastFightReplay()
        {
            return _fightManagement.GetFightReplay();
        }
    }
}
