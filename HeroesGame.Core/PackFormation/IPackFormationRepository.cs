using HeroesGame.Characters;
using System.Collections.Generic;

namespace HeroesGame.PackBuilding
{
    public interface IPackFormationRepository
    {
        string GetCharacterIdOnPosition(TeamPosition position, string accountID);
        void SetCharacterToPosition(string characterID, TeamPosition position, string iD);
        List<CharacterInThePack> GetAll(string accountID);
    }

}
