using HeroesGame.Characters;
using System.Collections.Generic;

namespace HeroesGame.PackBuilding
{
    public interface IOpponentPackFormationBuilder
    {

        string GetOpponentCharacterIdOnPosition(TeamPosition position);
        void GenerateOpponentsBaseOnTemplate(string templateID);
        List<Character> GetOpponentCharacters();
    }
}
