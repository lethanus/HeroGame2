using System;
using TechTalk.SpecFlow;
using BoDi;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using HeroesGame.Characters;
using HeroesGame.FightMechanizm;

namespace ConstructionYard
{
    [Binding]
    public class FightManagmentSteps
    {
        private readonly IObjectContainer objectContainer;

        public FightManagmentSteps(IObjectContainer objectContainer)
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

        [When(@"Fight will be vs generated team from template '(.*)'")]
        public void WhenFightWillBeVsGeneratedTeamFromTemplate(string opponentTemplateID)
        {
            var fightManagement = objectContainer.Resolve<IFightManagement>();
            fightManagement.StartAfightAgainstTemplate(opponentTemplateID);
        }
        
        [Then(@"Fight result should be '(.*)'")]
        public void ThenFightResultShouldBe(string expectedResult)
        {
            var fightManagement = objectContainer.Resolve<IFightManagement>();
            string result = fightManagement.GetLastFightResult();
            Assert.AreEqual(expectedResult, result);
        }
    }


}
