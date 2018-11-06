using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ConstructionYard
{
    [Binding]
    public class FightSimulationsSteps
    {
        [Given(@"The following characters")]
        public void GivenTheFollowingCharacters(Table table)
        {
            Assert.IsFalse(true);
        }
        
        [Given(@"Character '(.*)' is assigned to team '(.*)'")]
        public void GivenCharacterIsAssignedToTeam(string p0, string p1)
        {
            Assert.IsFalse(true);
        }
        
        [When(@"Fight turn (.*) ends")]
        public void WhenFightTurnEnds(int p0)
        {
            Assert.IsFalse(true);
        }
        
        [Then(@"The following characters status is")]
        public void ThenTheFollowingCharactersStatusIs(Table table)
        {
            Assert.IsFalse(true);
        }
    }
}
