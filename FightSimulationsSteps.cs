﻿using System;
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
            charactersAfterFight = fightMechnizm.StartFight(charactersInTeams, firstTeam, secondTeam);
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
                Assert.IsTrue(expectedChar.Equals( charactersAfterFight.First(x=>x.ID == expectedChar.ID)));
            }
            Assert.AreEqual(expectedCharactersAfterFight.Count(), charactersAfterFight.Count);
        }

        [Then(@"Replay acctions are")]
        public void ThenReplayAcctionsAre(Table table)
        {
            var fightMechnizm = objectContainer.Resolve<IFightMechanizm>();
            var expectedFightActions = table.CreateSet<FightAction>();
            var fightActions = fightMechnizm.GetFightActions();
            foreach (var expectedAction in expectedFightActions)
            {
                Assert.IsTrue(fightActions.Contains(expectedAction));
            }
            Assert.AreEqual(expectedFightActions.Count(), fightActions.Count);
        }

    }


}
