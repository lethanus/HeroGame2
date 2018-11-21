﻿using HeroesGame.Characters;
using System.Collections.Generic;

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
    }


}
