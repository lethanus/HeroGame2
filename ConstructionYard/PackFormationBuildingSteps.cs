using System;
using TechTalk.SpecFlow;
using BoDi;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using HeroesGame.Characters;
using HeroesGame.PackBuilding;

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
            var packFormationBuilder = objectContainer.Resolve<IPackFormationBuilder>();

            packFormationBuilder.SetCharacterToPosition(characterID, position);
        }
        
        [Then(@"Pack formation should look like this")]
        public void ThenPackFormationShouldLookLikeThis(Table table)
        {
            var packFormationBuilder = objectContainer.Resolve<IPackFormationBuilder>();
            var charactersInThePack = table.CreateSet<CharacterInThePack>().ToList();
            foreach (var character in charactersInThePack)
            {
                Assert.AreEqual(character.Character_ID, packFormationBuilder.GetCharacterIdOnPosition(character.Position));
            }
        }

        [Given(@"Have some formation templates")]
        public void GivenHaveSomeFormationTemplates(Table table)
        {
            var formationTemplateRepository = objectContainer.Resolve<IFormationTemplateRepository>();
            var templates = table.CreateSet<FormationTemplate>().ToList();
            foreach (var template in templates)
            {
                formationTemplateRepository.Add(template);
            }
            Assert.AreEqual(templates.Count, formationTemplateRepository.GetAll().Count);
        }

        [When(@"System want to build opponent pack base on template '(.*)'")]
        public void WhenSystemWantToBuildOpponentPackBaseOnTemplate(string templateID)
        {
            var opponentPackFormationBuilder = objectContainer.Resolve<IOpponentPackFormationBuilder>();
            opponentPackFormationBuilder.GenerateOpponentsBaseOnTemplate(templateID);
        }

        [Then(@"Generated opponents collection should have characters below")]
        public void ThenGeneratedOpponentsCollectionShouldHaveCharactersBelow(Table table)
        {
            var opponentPackFormationBuilder = objectContainer.Resolve<IOpponentPackFormationBuilder>();
            var expected = table.CreateSet<Character>().ToList();
            List<Character> characters = opponentPackFormationBuilder.GetOpponentCharacters();
            foreach (var expectedcharacter in expected)
            {
                Assert.AreEqual(expectedcharacter, characters.First(x => x.ID == expectedcharacter.ID));
            }
            Assert.AreEqual(expected.Count, characters.Count);
        }

        [Then(@"Opponent pack formation should look like this")]
        public void ThenOpponentPackFormationShouldLookLikeThis(Table table)
        {
            var opponentPackFormationBuilder = objectContainer.Resolve<IOpponentPackFormationBuilder>();
            var charactersInThePack = table.CreateSet<CharacterInThePack>().ToList();
            foreach (var character in charactersInThePack)
            {
                Assert.AreEqual(character.Character_ID, opponentPackFormationBuilder.GetOpponentCharacterIdOnPosition(character.Position));
            }
        }

    }

}
