using System;
using System.Collections.Generic;
using System.Text;

namespace HeroGame.Characters
{
    public enum TeamPosition { Front_1, Front_2, Front_3, Middle_1, Middle_2, Middle_3, Middle_4, Rear_1, Rear_2, Rear_3}
    public interface ICharacterInTeam
    {
        string GetTeam();
        void SetTeam(string team);
        void SetPosition(TeamPosition position);
        TeamPosition GetPosition();
        Character GetCharacter();
    }
}
