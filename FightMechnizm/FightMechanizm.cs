using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroGame.Characters;


namespace HeroGame.FightMechanizm
{
    public class FightMechanizm
    {
        private List<ICharacterInTeam> _startCharacters = new List<ICharacterInTeam>();
        private string _firstTeam;
        private string _secondTeam;
        private string _winningTeam;

        public FightMechanizm(List<ICharacterInTeam> startCharacters, string firstTeam, string secondTeam)
        {
            _startCharacters = startCharacters;
            _firstTeam = firstTeam;
            _secondTeam = secondTeam;
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
                foreach (var attacker in characters.OrderByDescending(x => x.GetCharacter().Speed))
                {
                    if (attacker.GetCharacter().Hp > 0)
                    {
                        var firstLiveCharFromOtherTeam = characters.First(x => x.GetTeam() != attacker.GetTeam() && x.GetCharacter().Hp > 0).GetCharacter();

                        firstLiveCharFromOtherTeam.Hp = CalculateNewHp(
                                attacker.GetCharacter(),
                                firstLiveCharFromOtherTeam);
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
