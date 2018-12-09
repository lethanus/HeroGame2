using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Characters;
using HeroesGame.Loggers;

namespace HeroesGame.FightMechanizm
{
    public interface IFightMechanizm
    {

        List<Character> StartFight(List<ICharacterInTeam> startCharacters, string firstTeam, string secondTeam);
        string GetWinningTeam();
        void SetNewLogger(Logger logger);
        List<FightAction> GetFightActions();
    }
}
