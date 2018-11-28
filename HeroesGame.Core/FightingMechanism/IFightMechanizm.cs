using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Characters;

namespace HeroesGame.FightMechanizm
{
    public interface IFightMechanizm
    {

        List<Character> StartFight();
        string GetWinningTeam();
        void SetupFight(List<ICharacterInTeam> startCharacters, string firstTeam, string secondTeam);

    }
}
