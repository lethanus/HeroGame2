using HeroesGame.Characters;
using System.Collections.Generic;

namespace HeroesGame.Mercenaries
{
    public interface IMercenaryManagement
    {
        void AddNewMercenary(Character mercenary);
        List<Character> GetAllMercenariesForLoggedUser();
        Mercenary GetMercenaryBaseOnTemplate(string mercenaryName, int mercenaryLevel);
        List<Mercenary> GenerateMercenaries(string accountID);
    }


}
