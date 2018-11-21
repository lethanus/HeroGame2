using HeroesGame.Characters;
using HeroesGame.Accounts;

namespace HeroesGame.PackBuilding
{
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
            var charactersPositions = _packFormationRepository.GetAll();
            foreach(var character in charactersPositions)
            {
                if(character.Character_ID == characterID)
                {
                    _packFormationRepository.SetCharacterToPosition("", character.Position, _accountManagement.GetLoggedAccount().ID);
                }
            }
            _packFormationRepository.SetCharacterToPosition(characterID, position, _accountManagement.GetLoggedAccount().ID);
        }
    }

}
