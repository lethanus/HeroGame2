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

        public FightMechnizm(List<ICharacterInTeam> startCharacters)
        {
            _startCharacters = startCharacters;
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
                if (_startCharacters.Count(x => x.GetTeam() == "A") == 1 && _startCharacters.Count(x => x.GetTeam() == "B") == 1)
                {
                    var firstCharA = _startCharacters.First(x => x.GetTeam() == "A").GetCharacter().ID;
                    var firstCharB = _startCharacters.First(x => x.GetTeam() == "B").GetCharacter().ID;

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
