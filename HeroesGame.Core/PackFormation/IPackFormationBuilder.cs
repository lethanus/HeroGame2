using HeroesGame.Characters;

namespace HeroesGame.PackBuilding
{
    public interface IPackFormationBuilder
    {
        string GetCharacterIdOnPosition(TeamPosition position);
        void SetCharacterToPosition(string characterID, TeamPosition position);
    }

}
