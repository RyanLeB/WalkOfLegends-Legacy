using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2.Shop_Quests
{
    public class Quest
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public int EnemiesToDefeat { get; set; }
        public int EnemiesDefeated { get; private set; }

        public Quest(string name, string description, int enemiesToDefeat = 0)
        {
            Name = name;
            Description = description;
            EnemiesToDefeat = enemiesToDefeat;
            EnemiesDefeated = 0;
            IsCompleted = false;
        }

        public void CompleteQuest()
        {
            IsCompleted = true;
            Console.WriteLine($"Quest '{Name}' completed!");
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


    }
}
