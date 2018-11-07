using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ConstructionYard
{
    [Binding]
    public class FightSimulationsSteps
    {
        private Dictionary<string, Character> characters = new Dictionary<string, Character>();
        private List<ICharacterInTeam> charactersInTeams = new List<ICharacterInTeam>();
        private Dictionary<string, Character> charactersAfterFight = new Dictionary<string, Character>();

        [Given(@"The following characters")]
        public void GivenTheFollowingCharacters(Table table)
        {
            characters = table.CreateSet<Character>().ToDictionary(x => x.ID, x =>x);
            Assert.Greater(characters.Count, 0);
        }

        [Given(@"Character '(.*)' is assigned to team '(.*)'")]
        public void GivenCharacterIsAssignedToTeam(string charID, string teamName)
        {
            int before = charactersInTeams.Count(x => x.GetTeam() == teamName);
            characters[charID].SetTeam(teamName);
            charactersInTeams.Add(characters[charID]);
            Assert.AreEqual(before + 1, charactersInTeams.Count(x => x.GetTeam() == teamName));
        }

        [When(@"Fight between '(.*)' and '(.*)' turn (.*) ends")]
        public void WhenFightBetweenAndTurnEnds(string firstTeam, string secondTeam, int turnNumber)
        {
            var fightMechnizm = new FightMechnizm(charactersInTeams, firstTeam, secondTeam);
            charactersAfterFight = fightMechnizm.GetFightResultsAfterTurn(turnNumber);
        }


        [Then(@"The following characters status is")]
        public void ThenTheFollowingCharactersStatusIs(Table table)
        {
            var expectedCharactersAfterFight = table.CreateSet<Character>().ToDictionary(x => x.ID, x => x);
            foreach(var expectedChar in expectedCharactersAfterFight)
            {
                Assert.AreEqual(expectedChar.Value, charactersAfterFight[expectedChar.Key]);
            }
        }
    }
}
