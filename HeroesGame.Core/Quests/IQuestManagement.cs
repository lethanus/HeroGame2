using System.Collections.Generic;

namespace HeroesGame.Quests
{
    public interface IQuestManagement
    {
        List<Quest> GetAll();
        bool GenerateQuests();
        void ComplateQuest(string questID, string result);
    }
}
