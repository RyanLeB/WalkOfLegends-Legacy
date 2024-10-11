using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Player
    {
        public char playerChar;
        public int moves;
        public int health;
        public int attack;
        public int posX;
        public int posY;
        public int nextPosX;
        public int nextPosY;
        public int lastPosX;
        public int lastPosY;
        public bool freezeEnemies;
        private Map map;
        private EnemyManager enemyManager;
        private ItemManager itemManager;
        public HealthSystem healthSystem;
        private UI ui;

        // new additions
        public int enemiesKilled;
        public bool dragonDefeated;
        public int souls;
        
       

        private GameManager gameManager;
        public int shopPositionY;
        public int shopPositionX;

        public Player(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }


        public void SetStuff(Map map, EnemyManager enemyManager, UI ui, ItemManager itemManager)
        {
            this.map = map;
            this.enemyManager = enemyManager;
            this.itemManager = itemManager;
            this.ui = ui;
            health = Settings.playerHealth;
            healthSystem = new HealthSystem(health);

            enemiesKilled = 0;
            
            
            moves = 0;
            attack = Settings.playerAttack;
            playerChar = Settings.playerChar;
            posX = Settings.playerStartPosX;
            posY = Settings.playerStartPosY;
            freezeEnemies = false;
            
            // new additions
            dragonDefeated = false;
            souls = 0;


        }


        public void Update(ConsoleKeyInfo input)
        {
            // checks for shop
            CheckShop();
            
            if (input.Key == ConsoleKey.W)
            {
                Move(0, -1);
                gameManager.shopDisplayed = false;
                

            }
            else if (input.Key == ConsoleKey.A)
            {
                Move(-1, 0);
                gameManager.shopDisplayed = false;
                

            }
            else if (input.Key == ConsoleKey.S)
            {
                Move(0, 1);
                gameManager.shopDisplayed = false;
                
            }
            else if (input.Key == ConsoleKey.D)
            {
                Move(1, 0);
                gameManager.shopDisplayed = false;
                
            }

           
            
        }


        //Moves the player
        public void Move(int nextX, int nextY)
        {
            moves++;

            nextPosX = posX + nextX; 
            nextPosY = posY + nextY;

            lastPosY = posY;
            lastPosX = posX;

            CheckNextMove();

            posY = nextPosY;
            posX = nextPosX;

            //EnemyManager.UpdateEnemies();
        }

        public void Draw()
        {
            map.map[lastPosY, lastPosX] = '`';

            if (shopPositionX != posX || shopPositionY != posY)
            {
                map.map[shopPositionY, shopPositionX] = '&';
            }
            
            map.map[posY, posX] = playerChar;
        }



        //Makes sure the player doesnt move
        public void CantMove()
        {
            nextPosY = lastPosY;
            nextPosX = lastPosX;
        }


        //Checks the tile in front of the player to see whats there
        public void CheckNextMove()
        {

            if (posX != map.width - 1 && posY != map.height - 1 && posX != 0 && posY != 0)
            {

                if (map.map[posY, nextPosX] == '^' || map.map[nextPosY, posX] == '^')
                {
                    CantMove();
                }
                else if (map.map[posY, nextPosX] == '~' || map.map[nextPosY, posX] == '~')
                {
                    CantMove();
                }
                else if (map.map[posY, nextPosX] == '#' || map.map[nextPosY, posX] == '#')
                {
                    CantMove();
                }

                CheckForEnemies();
                CheckForItems();

            }
        }

        public void CheckShop()
        {
            if (map.map[posY, posX] == '&')
            {

                shopPositionY = posY; shopPositionX = posX;
                
                gameManager.shopDisplayed = true;
            }
        }

        public void CheckForEnemies()
        {
            foreach (var enemy in enemyManager.enemies)
            {
                if ((posY == enemy.posY && nextPosX == enemy.posX) || (nextPosY == enemy.posY && posX == enemy.posX))
                {
                    if (enemy.health > 0)
                    {
                        CantMove();
                        enemy.healthSystem.health = 0;
                        enemy.healthSystem.TakeDamage(attack);
                        enemy.health += enemy.healthSystem.health;
                        Console.SetCursorPosition(0, map.cameraHeight + 22);
                        ui.UpdateHUD(enemy);
                        
                    }
                }
            }
        }

        public void CheckForItems()
        {
            foreach (var item in itemManager.items)
            {
                if ((posY == item.posY && nextPosX == item.posX) || (nextPosY == item.posY && posX == item.posX))
                {
                    item.DoYourJob();
                }
            }
        }



    }
}