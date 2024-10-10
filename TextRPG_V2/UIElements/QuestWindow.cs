using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_V2.Shop_Quests;

namespace TextRPG_V2.UIElements
{
    public class QuestWindow : UIWindow
    {
        private List<Quest> quests;

        public QuestWindow(int width, int height, List<Quest> quests) : base(width, height)
        {
            this.quests = quests;
        }

        public void UpdateQuests(List<Quest> quests)
        {
            this.quests = quests;
            ClearContents();
            int linePos = 1;
            foreach (var quest in quests)
            {
                if (!quest.IsCompleted)
                {
                    AddLine(linePos++, $"Quest: {quest.Name}");
                    AddLine(linePos++, $"Desc: {quest.Description}");
                    if (quest.EnemiesToDefeat > 0)
                    {
                        AddLine(linePos++, $"Progress: {quest.EnemiesDefeated}/{quest.EnemiesToDefeat} enemies defeated");
                    }
                }
            }
        }

    }
}
