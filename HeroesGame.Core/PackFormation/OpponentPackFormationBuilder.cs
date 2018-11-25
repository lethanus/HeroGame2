using HeroesGame.Characters;
using HeroesGame.PackBuilding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.PackBuilding
{
    public class OpponentPackFormationBuilder : IOpponentPackFormationBuilder
    {
        public void GenerateOpponentsBaseOnTemplate(string templateID)
        {
            
        }

        public string GetOpponentCharacterIdOnPosition(TeamPosition position)
        {
            return "";
        }

        public List<Character> GetOpponentCharacters()
        {
            return null;
        }
    }
}
