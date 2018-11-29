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
                Assert.AreEqual(quest, expectedQuests.First(x => x.ID == quest.ID));
            }
            Assert.AreEqual(expectedQuests.Count, quests.Count);
        }

        [Given(@"Number of quest to be generated is '(.*)'")]
        public void GivenNumberOfQuestToBeGeneratedIs(int numberOfQuests)
        {
            var configRepo = objectContainer.Resolve<IConfigRepository>();
            configRepo.SetConfigParameter($"NumberOfQuests", numberOfQuests.ToString());
        }

    }
}
