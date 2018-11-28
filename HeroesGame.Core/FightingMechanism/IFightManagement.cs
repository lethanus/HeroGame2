using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.FightMechanizm
{
    public interface IFightManagement
    {
        void StartAfightAgainstTemplate(string opponentTemplateID);
        string GetLastFightResult();
    }
}
