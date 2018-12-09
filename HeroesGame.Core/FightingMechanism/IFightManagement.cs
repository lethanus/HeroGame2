using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Characters;

namespace HeroesGame.FightMechanizm
{
    public interface IFightManagement
    {
        void PrepareFightAgainstTemplate(string opponentTemplateID);
        FightResult GetLastFightResult();
        void StartFight();
        List<ICharacterInTeam> GetPlayerCharacters();
        List<ICharacterInTeam> GetOpponentCharacters();
        FightReplay GetFightReplay();
    }
}
