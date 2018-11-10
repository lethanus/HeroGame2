using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroGame.Characters;
using HeroGame.Loggers;

namespace HeroGame.FightMechanizm
{
    public class FightMechanizm
    {
        private List<ICharacterInTeam> _characters = new List<ICharacterInTeam>();
        private string _firstTeam;
        private string _secondTeam;
        private string _winningTeam;
        private Logger _logger;

        public FightMechanizm(List<ICharacterInTeam> startCharacters, string firstTeam, string secondTeam, Logger logger)
        {
            _characters = startCharacters;
            _firstTeam = firstTeam;
            _secondTeam = secondTeam;
            _logger = logger;
        }

        public List<Character> StartFight()
        {
            for (int i = 1; i <= 100; i++)
            {
                _logger.LogLine($"Turn {i} started");
                foreach (var attacker in _characters.OrderByDescending(x => x.getSpeed()))
                {
                    if (attacker.getHp() > 0)
                    {
                        var defender = _characters.FirstOrDefault(x => x.GetTeam() != attacker.GetTeam() && x.getHp() > 0);

                        if (defender != null)
                        {
                            var newHp = CalculateNewHp(attacker, defender);
                            defender.setNewHP(newHp);
                        }
                    }
                }
                if (CheckFigthEndForTeam(_characters, _firstTeam)) break;
                if (CheckFigthEndForTeam(_characters, _secondTeam)) break;
            }
            
            return _characters.Select(x => x.GetCharacter()).ToList();
        }

        private bool CheckFigthEndForTeam(List<ICharacterInTeam> characterInTeams, string teamNameToCheck)
        {
            var liveSecondTeamCount = characterInTeams.Count(x => x.GetTeam() != teamNameToCheck && x.getHp() > 0);
            if (liveSecondTeamCount == 0)
            {
                _winningTeam = teamNameToCheck;
                _logger.LogLine($"Team {_winningTeam} won");
                return true;
            }
            return false;
        }

        private int CalculateNewHp(ICharacterInTeam attacker, ICharacterInTeam defender)
        {
            var damage = attacker.getAtt() > defender.getDef() ? attacker.getAtt() - defender.getDef() : 0;
            var newHP = defender.getHp() < damage ? 0 : defender.getHp() - damage;

            var isKilled = newHP == 0 ? "[Killed]" : "";
            _logger.LogLine($"[{attacker.GetTeam()}]{attacker.getName()} dealed {damage} damage to {defender.getName()} and new HP is {newHP} {isKilled}");

            return newHP;
        }

        public string GetWinningTeam()
        {
            return _winningTeam;
        }
    }
}
