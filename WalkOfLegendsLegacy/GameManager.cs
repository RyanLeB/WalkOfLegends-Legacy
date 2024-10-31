﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FirstPlayable_CalebWolthers_22012024
{
    internal class GameManager
    {

        public static Map map;
        public static Player player;
        public static EnemyManager enemyManager;
        public static ItemManager itemManager;
        public static UI ui;
        public static bool gameOver;
        
        // new additions
        private QuestManager questManager;
        private ShopManager shopManager;
        public bool shopDisplayed;

        private const string SettingsFilePath = "settings.json";


        public void Play()
        {
            //Init
            Settings.LoadSettings(SettingsFilePath);
            player = new Player(this);
            map = new Map(player, this);
            enemyManager = new EnemyManager(player, map);
            gameOver = false;
            map.StartMap();

            questManager = new QuestManager(player);
            ui = new UI(player, map, enemyManager, questManager);
            ui.LoadStartingScreen();
            itemManager = new ItemManager(player, map, ui);
            player.SetStuff(map, enemyManager, ui, itemManager);
            shopManager = new ShopManager(player, map, ui);
            map.LocateShop(shopManager);
            map.DisplayMap();
            
            shopDisplayed = false;

            enemyManager.PlaceGoblins(5);
            enemyManager.PlaceOrcs(10);
            enemyManager.PlaceMinotaurs(5);
            enemyManager.PlaceDragons(1);

            itemManager.PlaceHealthPotions(25);
            itemManager.PlaceInvincibility(10);
            itemManager.PlaceFreeze(10);


            while (gameOver == false)
            {
                if (player.healthSystem.health <= 0)
                {
                    gameOver = true;
                }

                GetInput();

                //Update
                itemManager.UpdateItems();
                player.Update(input);
                player.CheckShop();
                enemyManager.UpdateEnemies();

                // new additions
                questManager.UpdateQuest();
                if(shopDisplayed)
                {
                    map.DisplayShop();
                    shopManager.ShopDisplay();
                }



                //Draw
                itemManager.DrawItems();
                enemyManager.DrawEnemies();
                player.Draw();
                map.DisplayMap();
                map.DrawShop();
                ui.Draw();
            }
            if (gameOver == true && !player.dragonDefeated)
            {
                
                Console.Clear();
                Console.WriteLine("Game Over, try again");
            }
            else if (gameOver == true && player.dragonDefeated)
            {
                Settings.SaveSettings(SettingsFilePath);
                Console.Clear();
                Console.WriteLine("Congratulations, you have defeated the dragon and beat the game!"); // displayed victory screen
            }


        }

        public void GetInput()
        {
            input = Console.ReadKey(true);
        }

        private ConsoleKeyInfo input;
    }

}
