using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_V2.Shop_Quests;
using TextRPG_V2.UIElements;

namespace TextRPG_V2
{
    public class UIManager
    {
        private Camera gameplayWindow; //Camera that projects the game world
        private StatWindow playerStatWindow; //Window that shows the player's stats
        private StatWindow enemyStatWindow; //Window that shows the stats of the enemy that was last hit
        private ControlsWindow controlsWindow; //Window that shows the game controls
        private EventLog eventLogWindow; //Window that shows the event log
        private QuestWindow questWindow; //Window that displays quests

        private int[] gameplayPos; //The position on the screen of the gameplay
        private int[] playerWinPos; //The position on the screen of the player stat window
        private int[] enemyWinPos; //The position on the screen of the enemy stat window
        private int[] controlsPos; //The position on the screen of the controls window
        private int[] eventLogPos; //The position on the screen of the event log
        private int[] questWinPos; //The position on the screen of the quest window

        /// <summary>
        /// Constructor method for a UIManager object which manages the User Interface
        /// </summary>
        /// <param name="entityManager">The entity manager for the game</param>
        public UIManager(EntityManager entityManager, List<Quest> quests)
        {
            // Instantiate all windows
            gameplayWindow = new Camera(entityManager.GetPlayer());
            playerStatWindow = new StatWindow(entityManager.GetPlayer());
            enemyStatWindow = new StatWindow(null);
            controlsWindow = new ControlsWindow();
            eventLogWindow = new EventLog();
            questWindow = new QuestWindow(70, 10, quests);

            // Set initial positions of windows
            gameplayPos = new int[2] { 0, 0 };
            playerWinPos = new int[2] { 0, gameplayWindow.GetWidth() + GlobalVariables.windowPadding };
            enemyWinPos = new int[2] { playerStatWindow.GetHeight() + GlobalVariables.windowPadding, gameplayWindow.GetWidth() + GlobalVariables.windowPadding };
            controlsPos = new int[2] { 0, gameplayWindow.GetWidth() + playerStatWindow.GetWidth() + 2 * GlobalVariables.windowPadding };
            eventLogPos = new int[2] { gameplayWindow.GetHeight(), 0 };

            // Calculate the total width and height of the UI windows
            int totalWidth = gameplayWindow.GetWidth() + playerStatWindow.GetWidth() + controlsWindow.GetWidth() + questWindow.GetWidth() + GlobalVariables.windowPadding * 3;
            int totalHeight = gameplayWindow.GetHeight() + eventLogWindow.GetHeight() + GlobalVariables.windowPadding * 2;

            // Set the quest window position to the right edge
            questWinPos = new int[2] { 0, totalWidth - questWindow.GetWidth() - GlobalVariables.windowPadding };

            // Setting console window size and settings
            Console.SetWindowSize(totalWidth, totalHeight);
            Console.SetBufferSize(totalWidth, totalHeight);
            Console.CursorVisible = false;
        }


        /// <summary>
        /// Function which draws the UI on to the screen
        /// </summary>
        /// <param name="map">The map on which the game takes place</param>
        public void DrawUI(Map map)
        {
            playerStatWindow.SetTargetInfo();
            enemyStatWindow.SetTargetInfo();

            gameplayWindow.DrawGamePlay(map, gameplayPos[0], gameplayPos[1]);
            playerStatWindow.printWindow(playerWinPos);
            enemyStatWindow.printWindow(enemyWinPos);
            controlsWindow.printWindow(controlsPos);
            eventLogWindow.printWindow(eventLogPos);
            questWindow.printWindow(questWinPos);
        }

        public void DisplayShop(Shop shop)
        {
            shop.DisplayInventory();
        }

        public void UpdateQuestWindow(List<Quest> quests)
        {
            questWindow.UpdateQuests(quests);
        }

        
        /// <summary>
        /// Method which adds an event message to the event log
        /// </summary>
        /// <param name="eventMessage">The message to be added to the event log</param>
        public void AddEventToLog(string eventMessage)
        {
            eventLogWindow.AddEvent(eventMessage);
        }

        /// <summary>
        /// Method that sets the enemy stat window to the currently targeted enemy
        /// </summary>
        /// <param name="target">the target of the enemy stat window</param>
        public void SetEnemyStats(Entity target)
        {
            enemyStatWindow.ChangeTarget(target);
        }


    }
}
