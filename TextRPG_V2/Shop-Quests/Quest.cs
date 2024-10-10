using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2.Shop_Quests
{
    public class Quest
    {
        public string Name; // Name of the quest
        public string Description; // Description of the quest
        public bool isCompleted; // checks if the quest is completed

        

        public int totalTasks; // total tasks to complete
        public int currentTasks; // current tasks completed

        // Constructor for the Quest class, includes the name, description, quest goal, and total tasks to complete the quest
        public Quest(string name, string description, int totalTasks)
        {
            isCompleted = false;
            
            this.Name = name;
            this.Description = description;
            
            
            this.totalTasks = totalTasks;
            
            
            currentTasks = 0;
        }


        // Checks if the quest is completed
        public void Update()
        {
            if (currentTasks >= totalTasks)
            {
                isCompleted = true;
                Name = "Quest Complete";
            }
        }

        // Method to increment the current tasks
        public void IncrementTask()
        {
            if (currentTasks < totalTasks)
            {
                currentTasks++;
            }
            Update();
        }

        // Gets the progress of the quest
        public string GetProgress()
        {
            return $"{currentTasks}/{totalTasks}";
        }
    }
}






