using System;
using TechTalk.SpecFlow;
using BoDi;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using HeroesGame.Characters;
using HeroesGame.FightMechanizm;
using HeroesGame.Common;

namespace ConstructionYard
{
    [Binding]
    public class QuestsManagementSteps
    {
        private readonly IObjectContainer objectContainer;

        public QuestsManagementSteps(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeRepository()
        {
            TestInstaler.InitializeRepository(objectContainer);
        }

        [AfterScenario]
        public void CleanupRepository()
        {
            TestInstaler.CleanupRepository();
        }

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
    }

    public interface IQuestManagement
    {
        List<Quest> GetAll();
        bool GenerateQuests();
    }

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

    public class Quest : ObjectWithID
    {
        public string Level { get; set; }
        public string Name { get; set; }
        public string FormationID { get; set; }
        public string WinRewards { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            var hashCode = -1319351149;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Level);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FormationID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(WinRewards);
            return hashCode;
        }
    }
}
