using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroGame.Characters
{
    public class CharacterFactory
    {
        public List<Character> BuildStandardCharacters()
        {
            var characters = new List<Character>
            {
                new Character("Goblin", 10, 10, 0, 5),
                new Character("Elf", 20, 10, 5, 10)
            };



            return characters;
        }
    }
}
