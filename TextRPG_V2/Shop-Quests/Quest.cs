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

        public Quest(string name, string description)
        {
            Name = name;
            Description = description;
            IsCompleted = false;
        }

        public void CompleteQuest()
        {
            IsCompleted = true;
            Console.WriteLine($"Quest '{Name}' completed!");
        }
    }
}
