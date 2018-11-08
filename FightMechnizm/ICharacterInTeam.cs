using System;
using System.Collections.Generic;
using System.Text;

namespace HeroGame.Characters
{
    public interface ICharacterInTeam
    {
        string GetTeam();
        void SetTeam(string team);
        void SetPosition(TeamPosition position);
        TeamPosition GetPosition();
        Character GetCharacter();
    }
}
