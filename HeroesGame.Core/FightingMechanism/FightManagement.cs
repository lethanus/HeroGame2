using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.FightMechanizm
{
    public class FightManagement : IFightManagement
    {
        public string GetLastFightResult()
        {
            return "Player wins";
        }

        public void StartAfightAgainstTemplate(string opponentTemplateID)
        {
            
        }
    }
}
