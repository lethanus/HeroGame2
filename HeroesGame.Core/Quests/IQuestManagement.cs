using System.Collections.Generic;

namespace HeroesGame.Quests
{
    public interface IQuestManagement
    {
        List<Quest> GetAll();
        bool GenerateQuests();
        string StartQuest(string questID);
    }
}
