﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_V2.Items;
using TextRPG_V2.Shop_Quests;

namespace TextRPG_V2
{
    public class GameManager
    {
        // ---- singleton for easy access ----
        private static GameManager instance;
        public static GameManager Instance => instance ?? (instance = new GameManager());


        Map map; //The map on which the game takes place
        UIManager uiManager; //The Object that manages UI elements (Camera, action log, controls, etc...) 
        EntityManager entityManager; //The object that managed entities
        ItemManager itemManager; //object that manages items


        private Shop shop;
        private List<Quest> quests;

        private bool gameWin; //bool tracking if the game was won
        private bool gameLose; //bool tracking if the game was lost



        /// <summary>
        /// Constructor method for a GameManager object
        /// </summary>
        public GameManager() 
        {
            gameLose = false;
            gameWin = false;
            shop = new Shop();
            quests = new List<Quest>();
        }

        /// <summary>
        /// Method that starts the game by instantiating all the aspects and starting the game loop.
        /// </summary>
        public void StartGame()
        {
            //reading in path for the map file.
            string path = Path.Combine(Environment.CurrentDirectory, GlobalVariables.directory, GlobalVariables.filename);

            //initializing the entity and item managers
            entityManager = new EntityManager();
            itemManager = new ItemManager();

            //loading in map from the file path
            map = new Map(path, entityManager, itemManager);

            //initializing UI
            uiManager = new UIManager(entityManager, quests);

            // Initialize shop and quests
            InitializeShop();
            InitializeQuests();

            //title screen
            TitleScreen();

            //drawing world
            uiManager.DrawUI(map);

            //starting game loop
            GameLoop();
        }

        /// <summary>
        /// Method that starts the game loop of the game
        /// </summary>

        private void InitializeShop()
        {
            shop.AddItem(new HealingPotion());
            shop.AddItem(new Sword());
        }

        private void InitializeQuests()
        {
            quests.Add(new Quest("Escape the Dungeon", "Find the exit to escape the dungeon."));
            uiManager.UpdateQuestWindow(quests);
        }

        public Shop GetShop()
        {
            return shop;
        }

        public List<Quest> GetQuests()
        {
            return quests;
        }

        public void EnterShop()
        {
            shop.DisplayInventory();
            // Add logic for buying/selling items
        }

        public void CheckQuests()
        {
            foreach (var quest in quests)
            {
                if (!quest.IsCompleted)
                {
                    Console.WriteLine($"Quest: {quest.Name} - {quest.Description}");
                }
            }
        }

        public void GameLoop()
        {
            //game loop
            while (!gameLose && !gameWin)
            {
                //updates the entities and checks if the game was won
                gameWin = entityManager.UpdateEntities(map, uiManager, itemManager);
                
                //updates the items
                itemManager.UpdateItems();

                //check if the player has been killed
                if(entityManager.GetPlayer() == null)
                {
                    //initiates game loss
                    gameLose=true;
                }
                
            }

            //calls method to end the game
            FinishGame();
        }

        /// <summary>
        /// Method that wraps up the game by clearing the screen and giving an end message.
        /// </summary>
        public void FinishGame()
        {
            Console.Clear();

            if (gameWin)
            {
                Console.WriteLine("You managed to escpate the dungeon.");
                Console.WriteLine("Congratulations on beating the game!");
            }
            else if (gameLose)
            {
                Console.WriteLine("You were defeated by the perils of the");
                Console.WriteLine("ancient dungeon.");
                Console.WriteLine("\nRestart the program to try again...");
            }

            Console.ReadKey(true);
        }

        /// <summary>
        /// Method that sets the title screen
        /// </summary>
        private void TitleScreen()
        {
            //Title
            Console.WriteLine("          Welcome To:          \n");

            Console.WriteLine("  ___   _____   ____           ");
            Console.WriteLine(" / _ \\  \\   /  /  _ \\  |\\    /|");
            Console.WriteLine("/./ \\.\\  \\./  /../ \\.\\ |.\\  /.|");
            Console.WriteLine("|.|  |.| |.|  \\..\\  |/ |.|__|.|");
            Console.WriteLine("|:|  |/  |:|   \\::\\    |::::::|");
            Console.WriteLine("|:| ___  |:|    \\::\\   |:|  |:|");
            Console.WriteLine("|x| \\x/  |x|     \\xx\\  |x|  |x|");
            Console.WriteLine("|x| |x|  |x|      |xx| |x|  |x|");
            Console.WriteLine("\\X\\_/X|  /X\\  |\\_/XX/  |X|  |X|");
            Console.WriteLine(" \\XXXX| /XXX\\ |XXXX/   |X|  |X|");
            Console.WriteLine("___ |X| _____ |X| ____ |X|  |X|");
            Console.WriteLine("|XX |X| |XXXX |X| |XXX |X/  \\X|");
            Console.WriteLine("    |/        |/       |/    \\|");

            //Description
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("You are a Gish warrior; practitioner of");
            Console.WriteLine("both might and magic. You have been trapped");
            Console.WriteLine("in an ancient dungeon. Can you use your wits");
            Console.WriteLine("to escape?");

            //user prompt
            Console.WriteLine("\nPress any key to start the game...");

            //start sequence
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
