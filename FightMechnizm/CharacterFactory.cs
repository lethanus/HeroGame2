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
                new Character("Goblin scout", 10, 10, 20, 0, 5, "Min_Dmg_Attack"),
                new Character("Elf hunter", 20, 10, 30, 5, 10, "Min_Dmg_Attack"),
                new Character("Human warrior", 40, 15, 30, 7, 4, "Min_Dmg_Attack"),
                new Character("Troll warrior", 200, 30, 50, 20, 2, "Min_Dmg_Attack"),
                new Character("Skeleton", 15, 8, 13, 3, 5, "Min_Dmg_Attack"),
                new Character("Human palladin", 100, 40, 45, 25, 9, "Min_Dmg_Attack")
            };



            return characters;
        }
    }
}
