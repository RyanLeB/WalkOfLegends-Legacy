using System.Collections.Generic;
using TextRPG_V2.Shop_Quests;
using TextRPG_V2;
using System;
using System.Linq;

public class QuestManager
{
    private List<Quest> quests;
    private UIManager uiManager;

    public QuestManager(List<Quest> quests, UIManager uiManager)
    {
        this.quests = quests;
        this.uiManager = uiManager;
    }
    public void UpdateQuests()
    {
        foreach (var quest in quests)
        {
            quest.Update();
        }
        uiManager.UpdateQuestWindow(quests);
    }


    public void IncrementQuestTask(string questName)
    {
        var quest = quests.FirstOrDefault(q => q.Name == questName);
        if (quest != null)
        {
            quest.IncrementTask();
            uiManager.UpdateQuestWindow(quests);
        }
    }
}


