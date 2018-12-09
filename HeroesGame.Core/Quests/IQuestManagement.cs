using System.Collections.Generic;
using HeroesGame.FightMechanizm;

namespace HeroesGame.Quests
{
    public interface IQuestManagement
    {
        List<Quest> GetAll();
        bool GenerateQuests();
        string StartQuest(string questID);
        FightReplay GetLastFightReplay();
    }
}
