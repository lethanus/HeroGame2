using System;
using TechTalk.SpecFlow;
using BoDi;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using HeroesGame.Characters;
using HeroesGame.FightMechanizm;
using HeroesGame.Quests;
using HeroesGame.Configuration;
using HeroesGame.Core.Randomizers;
using HeroesGame.Accounts;

namespace ConstructionYard
{
    [Binding]
    public class QuestsManagementSteps : HeroesGameTestsBase
    {
        public QuestsManagementSteps(IObjectContainer objectContainer) : base(objectContainer) {}

        [When(@"Player will refresh and regenerate quests")]
        public void WhenPlayerWillRefreshAndRegenerateQuests()
        {
            var questManagement = objectContainer.Resolve<IQuestManagement>();
            questManagement.GenerateQuests();
        }
        
        [Then(@"List of quests should contain")]
        public void ThenListOfQuestsShouldConTain(Table table)
        {
            var questManagement = objectContainer.Resolve<IQuestManagement>();
            var quests = questManagement.GetAll();

            var expectedQuests = table.CreateSet<Quest>().ToList();
            foreach (var quest in expectedQuests)
            {
                Assert.IsTrue( quests.First(x=>x.ID == quest.ID).Equals(quest));
            }
            Assert.AreEqual(expectedQuests.Count, quests.Count);
        }

        [Given(@"Number of quest to be generated is '(.*)'")]
        public void GivenNumberOfQuestToBeGeneratedIs(int numberOfQuests)
        {
            var configRepo = objectContainer.Resolve<IConfigRepository>();
            configRepo.SetConfigParameter($"NumberOfQuests", numberOfQuests.ToString());
        }

        [Given(@"The chance of getting level '(.*)' quests is set to '(.*)' of '(.*)'")]
        public void GivenTheChanceOfGettingLevelQuestsIsSetToOf(int level, int chanceValue, int chanceMax)
        {
            var configRepo = objectContainer.Resolve<IConfigRepository>();
            configRepo.SetConfigParameter($"ChanceForLevel_{level}_quest", $"{chanceValue}_{chanceMax}");
        }

        [Given(@"Randomzer for quests level will always return '(.*)'")]
        public void GivenRandomzerForQuestsLevelWillAlwaysReturn(int randomizerResult)
        {
            var randomizer = objectContainer.Resolve<IValueRandomizer>();
            randomizer.SetReturnValue($"Quest_level_chance", randomizerResult);
        }

        [Then(@"List of quests should contain at least '(.*)' quests with FormationID '(.*)' and Level '(.*)'")]
        public void ThenListOfQuestsShouldContainAtLeastQuestsWithFormationID(int minimumAmount, string formationID, string level)
        {
            var questManagement = objectContainer.Resolve<IQuestManagement>();
            var quests = questManagement.GetAll();
            Assert.Greater(quests.Count(x => x.FormationID == formationID && x.Level == level), minimumAmount);
        }

        [Then(@"List of quests should contain at least '(.*)' quests with Rewards using template '(.*)'")]
        public void ThenListOfQuestsShouldContainAtLeastQuestsWithRewardsUsingTemplate(int minimumAmount, string rewardTemplateID)
        {
            var questManagement = objectContainer.Resolve<IQuestManagement>();
            var quests = questManagement.GetAll();
            Assert.Greater(quests.Count(x => x.RewardsID == rewardTemplateID), minimumAmount);
        }


        [Given(@"Reward templates have")]
        public void GivenRewardTemplatesHave(Table table)
        {
            var rewardTemplatesRepository = objectContainer.Resolve<IRewardTemplatesRepository>();
            var rewardTemplates = table.CreateSet<RewardTemplate>().ToList();
            foreach (var template in rewardTemplates)
            {
                rewardTemplatesRepository.Add(template);
            }
        }

        [Given(@"List of quests contains")]
        public void GivenListOfQuestsContains(Table table)
        {
            var questRepository = objectContainer.Resolve<IQuestRepository>();
            var accountManagement = objectContainer.Resolve<IAccountManagement>();
            var quests = table.CreateSet<Quest>().ToList();
            foreach (var quest in quests)
            {
                questRepository.Add(quest, accountManagement.GetLoggedAccount().ID);
            }
        }

        [When(@"Player will complete quest with ID '(.*)' with result '(.*)'")]
        public void WhenPlayerWillCompleteQuestWithID(string questID, string result)
        {
            var questManagement = objectContainer.Resolve<IQuestManagement>();
            questManagement.ComplateQuest(questID, result);
        }

        [When(@"Player will start quest with ID '(.*)'")]
        public void WhenPlayerWillStartQuestWithID(string questID)
        {
            var questManagement = objectContainer.Resolve<IQuestManagement>();
            questManagement.StartQuest(questID);
        }

        [Then(@"Quest '(.*)' should be completed")]
        public void ThenQuestShouldBeComplated(string questID)
        {
            var questManagement = objectContainer.Resolve<IQuestManagement>();
            var result = questManagement.GetQuestResult(questID);
            Assert.AreEqual("Completed", result);
        }


    }
}
