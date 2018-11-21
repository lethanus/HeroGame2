using System;
using TechTalk.SpecFlow;
using BoDi;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using HeroesGame.Characters;
using HeroesGame.Accounts;

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
    }

    public interface IPackFormationBuilder
    {
        string GetCharacterIdOnPosition(TeamPosition position);
        void SetCharacterToPosition(string characterID, TeamPosition position);
    }

    public class PackFormationBuilder : IPackFormationBuilder
    {
        private readonly IPackFormationRepository _packFormationRepository;
        private IAccountManagement _accountManagement;

        public PackFormationBuilder(IPackFormationRepository packFormationRepository, IAccountManagement accountManagement)
        {
            _packFormationRepository = packFormationRepository;
            _accountManagement = accountManagement;
        }

        public string GetCharacterIdOnPosition(TeamPosition position)
        {
            return _packFormationRepository.GetCharacterIdOnPosition(position, _accountManagement.GetLoggedAccount().ID);
        }

        public void SetCharacterToPosition(string characterID, TeamPosition position)
        {
            _packFormationRepository.SetCharacterToPosition(characterID, position, _accountManagement.GetLoggedAccount().ID);
        }
    }

    public interface IPackFormationRepository
    {
        string GetCharacterIdOnPosition(TeamPosition position, string accountID);
        void SetCharacterToPosition(string characterID, TeamPosition position, string iD);
    }

    public class PackFormationJsonFileRepository : IPackFormationRepository
    {
        private string _directoryPath;
        private Dictionary<TeamPosition, string> _packFormation = new Dictionary<TeamPosition, string>();

        public PackFormationJsonFileRepository(string directoryPath)
        {
            _directoryPath = directoryPath;
            _packFormation.Add(TeamPosition.Front_1, "");
            _packFormation.Add(TeamPosition.Front_2, "");
            _packFormation.Add(TeamPosition.Front_3, "");
            _packFormation.Add(TeamPosition.Middle_1, "");
            _packFormation.Add(TeamPosition.Middle_2, "");
            _packFormation.Add(TeamPosition.Middle_3, "");
            _packFormation.Add(TeamPosition.Middle_4, "");
            _packFormation.Add(TeamPosition.Rear_1, "");
            _packFormation.Add(TeamPosition.Rear_2, "");
            _packFormation.Add(TeamPosition.Rear_3, "");
            _packFormation.Add(TeamPosition.None, "");
        }

        public string GetCharacterIdOnPosition(TeamPosition position, string accountID)
        {
            return _packFormation[position];
        }

        public void SetCharacterToPosition(string characterID, TeamPosition position, string iD)
        {
            _packFormation[position] = characterID;
        }
    }

        public class CharacterInThePack
        {
            public TeamPosition Position { get; set; }
            public string Character_ID { get; set; }

        }

}
