using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using HeroesGame.Characters;
using HeroesGame.FightMechanizm;
using HeroesGame.Core.Randomizers;
using BoDi;

namespace ConstructionYard
{
    [Binding]
    public class FightSimulationsSteps : HeroesGameTestsBase
    {
        private Dictionary<string, Character> characters = new Dictionary<string, Character>();
        private List<ICharacterInTeam> charactersInTeams = new List<ICharacterInTeam>();
        private List<Character> charactersAfterFight = new List<Character>();
        private string winningTeam = "";

        public FightSimulationsSteps(IObjectContainer objectContainer) : base(objectContainer) { }
        

        [Given(@"The following characters")]
        public void GivenTheFollowingCharacters(Table table)
        {
            characters = table.CreateSet<Character>().ToDictionary(x => x.ID, x =>x);
            Assert.Greater(characters.Count, 0);
        }

        [Given(@"Character '(.*)' is assigned to team '(.*)' on position '(.*)'")]
        public void GivenCharacterIsAssignedToTeamOnPositionF(string charID, string teamName, TeamPosition position)
        {
            int before = charactersInTeams.Count(x => x.GetTeam() == teamName);
            characters[charID].SetTeam(teamName);
            characters[charID].SetPosition(position);
            charactersInTeams.Add(characters[charID]);
            Assert.AreEqual(before + 1, charactersInTeams.Count(x => x.GetTeam() == teamName));

        }

        [When(@"Fight between '(.*)' and '(.*)' starts")]
        public void WhenFightBetweenAndStarts(string firstTeam, string secondTeam)
        {
            var fightMechnizm = objectContainer.Resolve<IFightMechanizm>();
            fightMechnizm.SetNewLogger( new FakeLogger());
            fightMechnizm.SetupFight(charactersInTeams, firstTeam, secondTeam);
            charactersAfterFight = fightMechnizm.StartFight();
        }

        [Then(@"Team '(.*)' won")]
        public void ThenTeamWon(string team)
        {
            var fightMechnizm = objectContainer.Resolve<IFightMechanizm>();
            Assert.AreEqual(team, fightMechnizm.GetWinningTeam());
        }


        [Then(@"The following characters status is")]
        public void ThenTheFollowingCharactersStatusIs(Table table)
        {
            var expectedCharactersAfterFight = table.CreateSet<Character>();
            foreach(var expectedChar in expectedCharactersAfterFight)
            {
                Assert.AreEqual(expectedChar, charactersAfterFight.First(x=>x.ID == expectedChar.ID));
            }
        }
    }
}
