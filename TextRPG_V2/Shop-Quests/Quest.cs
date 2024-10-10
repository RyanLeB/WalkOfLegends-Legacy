using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2.Shop_Quests
{
    public class Quest
    {
        public string Name;
        public string Description;
        public bool IsCompleted;
        public int EnemiesToDefeat;
        public int EnemiesDefeated;

       

        public Quest(string name, string description)
        {
            Name = name;
            Description = description;
            
            
            IsCompleted = false;
        }

        private void CompleteQuest()
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                
            }
        }

        public void EnemyDefeated()
        {
            if (EnemiesToDefeat > 0)
            {
                EnemiesDefeated++;
                if (EnemiesDefeated >= EnemiesToDefeat)
                {
                    CompleteQuest();
                }
            }
        }

        public void ItemUsed()
        {
            if (Name == "Use an item" && !IsCompleted)
            {
                CompleteQuest();
            }
        }



    }
}
