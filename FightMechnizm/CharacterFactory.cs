using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroGame.Characters
{
    public class CharacterFactory
    {
        public List<ICharacterInTeam> BuildStandardCharacters()
        {
            var characters = new List<ICharacterInTeam>
            {
                new Character("Goblin scout", 10, 10, 0, 5),
                new Character("Elf hunter", 20, 10, 5, 10),
                new Character("Human warrior", 40, 15, 7, 4),
                new Character("Troll warrior", 200, 30, 20, 2),
                new Character("Skeleton", 15, 8, 3, 5),
                new Character("Human palladin", 100, 40, 25, 9)
            };



            return characters;
        }
    }
}
