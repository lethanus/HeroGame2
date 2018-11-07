using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionYard
{
    public class FightMechnizm
    {
        private Dictionary<string, Character> _teamA = new Dictionary<string, Character>();
        private Dictionary<string, Character> _teamB = new Dictionary<string, Character>();

        public FightMechnizm(Dictionary<string, Character> teamA, Dictionary<string, Character> teamB)
        {
            _teamA = teamA;
            _teamB = teamB;
        }

        public Dictionary<string, Character> GetFightResultsAfterTurn(int turnNumber)
        {
            var characters = new Dictionary<string, Character>();
            foreach(var character in _teamA)
            {
                characters.Add(character.Key, character.Value);
            }
            foreach (var character in _teamB)
            {
                characters.Add(character.Key, character.Value);
            }

            for (int i = 1; i <= turnNumber; i++)
            {
                if (_teamA.Count == 1 && _teamB.Count == 1)
                {
                    var firstCharA = _teamA.Keys.First();
                    var firstCharB = _teamB.Keys.First();
                    var attackA = _teamA[firstCharA].Att - _teamB[firstCharB].Def;
                    var attackB = _teamB[firstCharB].Att - _teamA[firstCharA].Def;

                    var hpB = _teamB[firstCharB].Hp;
                    var newHpB = hpB < attackA ? 0 : hpB - attackA;
                    characters[firstCharB].Hp = newHpB;

                    if (newHpB > 0)
                    {
                        var hpA = _teamA[firstCharA].Hp;
                        var newHpA = hpA < attackB ? 0 : hpA - attackB;
                        characters[firstCharA].Hp = newHpA;
                    }
                }

            }
            return characters;
        }
    }
}
