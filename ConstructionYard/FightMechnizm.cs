using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionYard
{
    public class FightMechnizm
    {
        private List<ICharacterInTeam> _startCharacters = new List<ICharacterInTeam>();
        private string _firstTeam;
        private string _secondTeam;

        public FightMechnizm(List<ICharacterInTeam> startCharacters, string firstTeam, string secondTeam)
        {
            _startCharacters = startCharacters;
            _firstTeam = firstTeam;
            _secondTeam = secondTeam;
        }

        public List<Character> GetFightResultsAfterTurn(int turnNumber)
        {
            var characters = new List<ICharacterInTeam>();
            foreach(var character in _startCharacters)
            {
                characters.Add(character.GetCharacter());
            }

            for (int i = 1; i <= turnNumber; i++)
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

            }
            return characters.Select(x=>x.GetCharacter()).ToList();
        }

        private static int CalculateNewHp(Character attacker, Character defender)
        {
            var damage = attacker.Att - defender.Def;
            return defender.Hp < damage ? 0 : defender.Hp - damage;
        }
    }
}
