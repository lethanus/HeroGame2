using HeroesGame.Configuration;
using System.Collections.Generic;
using System;
using System.Linq;
using HeroesGame.RefresingMechanism;
using HeroesGame.Core.Randomizers;
using HeroesGame.Mercenaries;
using HeroesGame.PackBuilding;
using HeroesGame.Accounts;
using HeroesGame.Inventory;

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

        public QuestManagement(IConfigRepository configRepository, IRefreshingMechnism refreshingMechnism, 
            IValueRandomizer randomizer, IFormationTemplateRepository formationTemplateRepository,
            IAccountManagement accountManagement, IQuestRepository questRepository, 
            IRewardTemplatesRepository rewardTemplatesRepository, IInventoryManagement inventoryManagement)
        {
            _configRepository = configRepository;
            _refreshingMechnism = refreshingMechnism;
            _randomizer = randomizer;
            _formationTemplateRepository = formationTemplateRepository;
            _accountManagement = accountManagement;
            _questRepository = questRepository;
            _rewardTemplatesRepository = rewardTemplatesRepository;
            _inventoryManagement = inventoryManagement;
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
                var questLevelChances = new Dictionary<int, ChanceRange>();
                questLevelChances.Add(1, new ChanceRange(_configRepository.GetParameterValue("ChanceForLevel_1_quest")));
                questLevelChances.Add(2, new ChanceRange(_configRepository.GetParameterValue("ChanceForLevel_2_quest")));
                questLevelChances.Add(3, new ChanceRange(_configRepository.GetParameterValue("ChanceForLevel_3_quest")));
                questLevelChances.Add(4, new ChanceRange(_configRepository.GetParameterValue("ChanceForLevel_4_quest")));

                for (int i = 1; i <= numberOfQuests; i++)
                {
                    var level = GetRandomLevel(questLevelChances);

                    FormationTemplate choosenFormationTemplate = GetRandomFormationTemplateForLevel(level);
                    RewardTemplate rewardTemplate = GetRandomRewardTemplateForLevel(level);

                    if (choosenFormationTemplate != null)
                    {
                        quests.Add(new Quest
                        {
                            ID = $"Q_{i}",
                            Level = level.ToString(),
                            FormationID = choosenFormationTemplate.ID,
                            Name = $"Defeat - {choosenFormationTemplate.Name}",
                            RewardsID = rewardTemplate == null ? "" : rewardTemplate.ID,
                            WinRewards = rewardTemplate == null ? "" : rewardTemplate.Rewards
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

        public void ComplateQuest(string questID, string result)
        {
            var quest = _questRepository.GetAll(_accountManagement.GetLoggedAccount().ID).First(x => x.ID == questID);
            _inventoryManagement.AddItems("TR_2", 1);
            _questRepository.Remove(quest, _accountManagement.GetLoggedAccount().ID);
        }
    }
}
