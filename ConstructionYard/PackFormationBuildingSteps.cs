using System;
using TechTalk.SpecFlow;
using BoDi;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using HeroesGame.Characters;

namespace ConstructionYard
{
    [Binding]
    public class PackFormationBuildingSteps
    {
        private readonly IObjectContainer objectContainer;

        public PackFormationBuildingSteps(IObjectContainer objectContainer)
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

        [When(@"Player will set character with ID '(.*)' to position '(.*)'")]
        public void WhenPlayerWillSetCharacterWithIDToPosition(string characterID, TeamPosition position)
        {
            
        }
        
        [Then(@"Pack formation should look like this")]
        public void ThenPackFormationShouldLookLikeThis(Table table)
        {
            Assert.AreEqual(true, false);
        }
    }
}
