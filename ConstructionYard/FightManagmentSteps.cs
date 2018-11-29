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
    public class FightManagmentSteps : HeroesGameTestsBase
    {
        public FightManagmentSteps(IObjectContainer objectContainer) : base(objectContainer) { }


        [When(@"Fight will be vs generated team from template '(.*)'")]
        public void WhenFightWillBeVsGeneratedTeamFromTemplate(string opponentTemplateID)
        {
            var fightManagement = objectContainer.Resolve<IFightManagement>();
            fightManagement.PrepareFightAgainstTemplate(opponentTemplateID);
            fightManagement.StartFight();
        }
        
        [Then(@"Fight result should be '(.*)'")]
        public void ThenFightResultShouldBe(FightResult expectedResult)
        {
            var fightManagement = objectContainer.Resolve<IFightManagement>();
            FightResult result = fightManagement.GetLastFightResult();
            Assert.AreEqual(expectedResult, result);
        }
    }


}
