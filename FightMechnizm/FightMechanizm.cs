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
        private List<ICharacterInTeam> _startCharacters = new List<ICharacterInTeam>();
        private string _firstTeam;
        private string _secondTeam;
        private string _winningTeam;
        private Logger _looger;

        public FightMechanizm(List<ICharacterInTeam> startCharacters, string firstTeam, string secondTeam, Logger logger)
        {
            _startCharacters = startCharacters;
            _firstTeam = firstTeam;
            _secondTeam = secondTeam;
            _looger = logger;
        }

        public List<Character> GetFightResults()
        {
            var characters = new List<ICharacterInTeam>();
            foreach (var character in _startCharacters)
            {
                characters.Add(character.GetCharacter());
            }

            for (int i = 1; i <= 15; i++)
            {
                _looger.LogLine($"Turn {i} started");
                foreach (var attacker in characters.OrderByDescending(x => x.GetCharacter().Speed))
                {
                    if (attacker.GetCharacter().Hp > 0)
                    {
                        var firstLiveCharFromOtherTeam = characters.FirstOrDefault(x => x.GetTeam() != attacker.GetTeam() && x.GetCharacter().Hp > 0);

                        if (firstLiveCharFromOtherTeam != null)
                        {
                            var defender = firstLiveCharFromOtherTeam.GetCharacter();
                            defender.Hp = CalculateNewHp(attacker.GetCharacter(), defender);
                            var isKilled = defender.Hp == 0 ? "[Killed]" : "";
                            _looger.LogLine($"[{attacker.GetTeam()}]{attacker.GetCharacter().Name} reduced {defender.Name} HP to {defender.Hp} {isKilled}");
                        }
                    }
                }
                var liveFirstTeamCount = characters.Count(x => x.GetTeam() == _firstTeam && x.GetCharacter().Hp > 0);
                var liveSecondTeamCount = characters.Count(x => x.GetTeam() == _secondTeam && x.GetCharacter().Hp > 0);
                if (liveFirstTeamCount == 0)
                {
                    _winningTeam = _secondTeam;
                    break;
                }
                if (liveSecondTeamCount == 0)
                {
                    _winningTeam = _firstTeam;
                    break;
                }
            }
            _looger.LogLine($"Team {_winningTeam} won");
            return characters.Select(x => x.GetCharacter()).ToList();
        }

        private static int CalculateNewHp(Character attacker, Character defender)
        {
            var damage = attacker.Att - defender.Def;
            return defender.Hp < damage ? 0 : defender.Hp - damage;
        }

        public string GetWinningTeam()
        {
            return _winningTeam;
        }
    }
}
