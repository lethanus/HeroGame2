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
        private Dictionary<string, Character> teamA = new Dictionary<string, Character>();
        private Dictionary<string, Character> teamB = new Dictionary<string, Character>();
        private Dictionary<string, Character> charactersAfterFight = new Dictionary<string, Character>();


        [Given(@"The following characters")]
        public void GivenTheFollowingCharacters(Table table)
        {
            characters = table.CreateSet<Character>().ToDictionary(x => x.ID, x => x);
            Assert.Greater(characters.Count, 0);
        }
        
        [Given(@"Character '(.*)' is assigned to team A")]
        public void GivenCharacterIsAssignedToTeamA(string charID)
        {
            int before = teamA.Count;
            teamA.Add(charID, characters[charID]);
            Assert.AreEqual(before + 1, teamA.Count);
        }

        [Given(@"Character '(.*)' is assigned to team B")]
        public void GivenCharacterIsAssignedToTeamB(string charID)
        {
            int before = teamB.Count;
            teamB.Add(charID, characters[charID]);
            Assert.AreEqual(before + 1, teamB.Count);
        }


        [When(@"Fight turn (.*) ends")]
        public void WhenFightTurnEnds(int turnNumber)
        {
            if (turnNumber == 1)
            {
                if (teamA.Count == 1 && teamB.Count == 1)
                {
                    var firstCharA = teamA.Keys.First();
                    var firstCharB = teamB.Keys.First();
                    var attackA = teamA[firstCharA].Att;
                    var attackB = teamB[firstCharB].Att;

                    
                    var hpB = teamB[firstCharB].Hp;
                    var newHpB = hpB < attackA ? 0 : hpB - attackA;
                    characters[firstCharB].Hp = newHpB;

                    if (newHpB > 0)
                    {
                        var hpA = teamA[firstCharA].Hp;
                        var newHpA = hpA < attackB ? 0 : hpA - attackB;
                        characters[firstCharA].Hp = newHpA;
                    }
                }
                
            }
        }
        
        [Then(@"The following characters status is")]
        public void ThenTheFollowingCharactersStatusIs(Table table)
        {
            charactersAfterFight = table.CreateSet<Character>().ToDictionary(x => x.ID, x => x);
            foreach(var expectedChar in charactersAfterFight)
            {
                Assert.AreEqual(expectedChar.Value, characters[expectedChar.Key]);
            }
        }
    }
}
