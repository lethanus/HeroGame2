using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionYard
{
    public interface ICharacterInTeam 
    {
        string GetTeam();
        void SetTeam(string team);
        Character GetCharacter();
    }
}
