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

        public Dictionary<string, Character> GetFightResultsAfterTurn(int turnNumber)
        {
            var characters = new Dictionary<string, Character>();
            foreach(var character in _startCharacters)
            {
                characters.Add(character.GetCharacter().ID, character.GetCharacter());
            }

            for (int i = 1; i <= turnNumber; i++)
            {
                if (_startCharacters.Count(x => x.GetTeam() == _firstTeam) == 1 && _startCharacters.Count(x => x.GetTeam() == _secondTeam) == 1)
                {
                    var firstCharA = _startCharacters.First(x => x.GetTeam() == _firstTeam).GetCharacter().ID;
                    var firstCharB = _startCharacters.First(x => x.GetTeam() == _secondTeam).GetCharacter().ID;

                    var newHpB = CalculateNewHp(
                        _startCharacters.First(x => x.GetCharacter().ID == firstCharA).GetCharacter(),
                        _startCharacters.First(x => x.GetCharacter().ID == firstCharB).GetCharacter());
                    characters[firstCharB].Hp = newHpB;

                    if (newHpB > 0)
                    {
                        characters[firstCharA].Hp = CalculateNewHp(
                            _startCharacters.First(x => x.GetCharacter().ID == firstCharB).GetCharacter(),
                            _startCharacters.First(x => x.GetCharacter().ID == firstCharA).GetCharacter());
                    }
                }

            }
            return characters;
        }

        private static int CalculateNewHp(Character attacker, Character defender)
        {
            var damage = attacker.Att - defender.Def;
            return defender.Hp < damage ? 0 : defender.Hp - damage;
        }
    }
}
