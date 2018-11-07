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
            var characters = new Dictionary<string, ICharacterInTeam>();
            foreach(var character in _startCharacters)
            {
                characters.Add(character.GetCharacter().ID, character.GetCharacter());
            }

            for (int i = 1; i <= turnNumber; i++)
            {
                foreach (var character in characters.OrderByDescending(x => x.Value.GetCharacter().Speed))
                {
                    var firstLiveCharForOtherTeam = characters.First(x => x.Value.GetTeam() != character.Value.GetTeam() && x.Value.GetCharacter().Hp > 0).Value.GetCharacter();

                    characters[firstLiveCharForOtherTeam.ID].GetCharacter().Hp = CalculateNewHp(
                            character.Value.GetCharacter(),
                            firstLiveCharForOtherTeam); 
                }

            }
            return characters.ToDictionary(x=>x.Key, x=>x.Value.GetCharacter());
        }

        private static int CalculateNewHp(Character attacker, Character defender)
        {
            var damage = attacker.Att - defender.Def;
            return defender.Hp < damage ? 0 : defender.Hp - damage;
        }
    }
}
