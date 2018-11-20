using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Characters;
using HeroesGame.Loggers;
using HeroesGame.Core.Randomizers;

namespace HeroesGame.FightMechanizm
{
    public class FightMechanizm
    {
        private List<ICharacterInTeam> _characters = new List<ICharacterInTeam>();
        private string _firstTeam;
        private string _secondTeam;
        private string _winningTeam;
        private Logger _logger;
        private IValueRandomizer _randomizer;

        public FightMechanizm(List<ICharacterInTeam> startCharacters, string firstTeam, string secondTeam, Logger logger, IValueRandomizer randomizer)
        {
            _characters = startCharacters;
            _firstTeam = firstTeam;
            _secondTeam = secondTeam;
            _logger = logger;
            _randomizer = randomizer;
        }

        public List<Character> StartFight()
        {
            int i = 1;
            while (!AllCharactersAreDeadInTeam(_firstTeam) && !AllCharactersAreDeadInTeam(_secondTeam))
            {
                _logger.LogLine($"Turn {i++} started");
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
            }
            
            return _characters.Select(x => x.GetCharacter()).ToList();
        }

        private bool AllCharactersAreDeadInTeam(string teamName)
        {
            var liveSecondTeamCount = _characters.Count(x => x.GetTeam() != teamName && x.getHp() > 0);
            if (liveSecondTeamCount == 0)
            {
                _winningTeam = teamName;
                _logger.LogLine($"Team {_winningTeam} won");
                return true;
            }
            return false;
        }

        private int CalculateNewHp(ICharacterInTeam attacker, ICharacterInTeam defender)
        {
            var attack_value = _randomizer.GetRandomValueInRange(attacker.getMin_Att(), attacker.getMax_Att(), "Attack");
            var damage = attack_value > defender.getDef() ? attack_value - defender.getDef() : 0;
            var newHP = defender.getHp() < damage ? 0 : defender.getHp() - damage;

            var isKilled = newHP == 0 ? "[Killed]" : "";
            _logger.LogLine($"[{attacker.GetTeam()}] {attacker.getName()} dealed {damage} damage to {defender.getName()} and new HP is {newHP} {isKilled}");

            return newHP;
        }

        public string GetWinningTeam()
        {
            return _winningTeam;
        }
    }
}
