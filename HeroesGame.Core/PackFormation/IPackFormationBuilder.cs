using HeroesGame.Characters;
using System.Collections.Generic;

namespace HeroesGame.PackBuilding
{
    public interface IPackFormationBuilder
    {
        string GetCharacterIdOnPosition(TeamPosition position);
        void SetCharacterToPosition(string characterID, TeamPosition position);
        List<CharacterInThePack> GetAll();
    }

}
