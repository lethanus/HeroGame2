using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesGame.Characters
{
    public interface ICharacterInTeam : ICharacter
    {
        string GetTeam();
        void SetTeam(string team);
        void SetPosition(TeamPosition position);
        TeamPosition GetPosition();
        Character GetCharacter();
    }
}
