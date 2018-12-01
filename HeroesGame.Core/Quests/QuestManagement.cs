using HeroesGame.Configuration;
using System.Collections.Generic;
using System;
using System.Linq;
using HeroesGame.RefresingMechanism;
using HeroesGame.Core.Randomizers;
using HeroesGame.Mercenaries;
using HeroesGame.PackBuilding;

namespace HeroesGame.Quests
{
    public class QuestManagement : IQuestManagement
    {
        private readonly IConfigRepository _configRepository;
        private readonly IRefreshingMechnism _refreshingMechnism;
        private readonly IValueRandomizer _randomizer;
        private readonly IFormationTemplateRepository _formationTemplateRepository;
        private List<Quest> _quests = new List<Quest>();

        public QuestManagement(IConfigRepository configRepository, IRefreshingMechnism refreshingMechnism, IValueRandomizer randomizer, IFormationTemplateRepository formationTemplateRepository)
        {
            _configRepository = configRepository;
            _refreshingMechnism = refreshingMechnism;
            _randomizer = randomizer;
            _formationTemplateRepository = formationTemplateRepository;
        }

        public bool GenerateQuests()
        {
            var now = DateTime.Now;
            var refreshResult = _refreshingMechnism.GetRefreshStatus(RefreshOption.Quests, now);
            if (refreshResult.Status == RefresStatus.Ready)
            {

                _refreshingMechnism.AddRefreshFactForLoggedAccount(RefreshOption.Quests, now);
                var numberOfQuests = Int32.Parse(_configRepository.GetParameterValue("NumberOfQuests"));
                _quests.Clear();

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
                    if (formationTemplates.Count() == 1)
                        choosenFormationTemplate = formationTemplates.First();

                    _quests.Add(new Quest { ID = $"Q_{i}", Level = level.ToString(), FormationID = choosenFormationTemplate.ID, Name = "Defeat - Goblin pack", WinRewards = "" });
                }
                return true;
            }
            else return false;
        }

        public List<Quest> GetAll()
        {
            return _quests;
        }
    }
}
