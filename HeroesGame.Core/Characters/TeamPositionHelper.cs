using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Characters
{
    public enum TeamPosition { Front_1, Front_2, Front_3, Middle_1, Middle_2, Middle_3, Middle_4, Rear_1, Rear_2, Rear_3, None }

    public class TeamPositionHelper
    {
        public static List<TeamPosition> GetTeamPositions()
        {
            return Enum.GetValues(typeof(TeamPosition)).Cast<TeamPosition>().Where(x=>x != TeamPosition.None).ToList();
        }

        public static TeamPosition GetFirstAvailablePositionInTeam(List<ICharacterInTeam> team)
        {
            var allPositions = GetTeamPositions();
            var positionsInTheTeam = team.Select(y => y.GetPosition());
            return allPositions.Where(x => !positionsInTheTeam.Contains(x)).First();
        }
    }
}
