using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class QuestManager
    {
        // Quests
        public string slayEnemiesQuest;

        public string earnSouls;

        public string winGame;

        // Quests Completed
        private string questCompleted;


        // Player
        private Player player;


        // Defines the quests

        public QuestManager(Player player)
        {
            this.player = player;
            slayEnemiesQuest = "Slay 5 enemies";
            earnSouls = "Earn 300 souls";
            winGame = "Slay the Final Boss (Dragon)";
            questCompleted = "Quest Completed!";
        }

        // Updates the quests

        public void UpdateQuest()
        { 
            if (player.enemiesKilled == 5)
            {
                slayEnemiesQuest = questCompleted;
            }

            if (player.souls >= 300)
            {
                earnSouls = questCompleted;
            }

            if (player.dragonDefeated)
            {
                winGame = questCompleted;
            }

        }

        // Calls the UpdateQuest method

        public void Update()
        {
            UpdateQuest();
        }



    }
}
