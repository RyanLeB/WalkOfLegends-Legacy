using System.Collections.Generic;
using TextRPG_V2.Shop_Quests;
using TextRPG_V2;
using System;

public class QuestManager
{
    private List<Quest> quests;
    private UIManager uiManager;

    public QuestManager(List<Quest> quests, UIManager uiManager)
    {
        this.quests = quests;
        this.uiManager = uiManager;
    }

    public void EnemyDefeated()
    {
        foreach (var quest in quests)
        {
            quest.EnemyDefeated();
        }
        uiManager.UpdateQuestWindow(quests);
    }

    public void ItemUsed()
    {
        foreach (var quest in quests)
        {
            quest.ItemUsed();
        }
        uiManager.UpdateQuestWindow(quests);
    }
}


