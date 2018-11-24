using HeroesGame.Characters;
using System.Collections.Generic;
using HeroesGame.Inventory;

namespace HeroesGame.Mercenaries
{
    public interface IMercenaryManagement
    {
        void AddNewMercenary(Character mercenary);
        List<Character> GetAllMercenariesForLoggedUser();
        Mercenary GetMercenaryBaseOnTemplate(string mercenaryName, int mercenaryLevel);
        void GenerateMercenaries();
        List<Mercenary> GetRecruits();
        bool ConvinceRecruit(Mercenary recruit);
        double GetConvinceChance(int level);
        List<PositionInInventory> GetAvailableGiftItems();
        void AddGifts(string itemID, int amount);
        void RemoveGifts(string itemID, int amount);
        List<PositionInInventory> GetCurrentGifts();
    }


}
