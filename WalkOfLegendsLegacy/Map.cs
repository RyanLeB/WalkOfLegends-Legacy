﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Reflection.Emit;
using System.Security.Policy;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Map
    {
        static string[] mapFile;
        public char[,] map;
        public int cameraWidth = Settings.cameraWidth;
        public int cameraHeight = Settings.cameraHeight;
        public int width;
        public int height;
        private Player player;

        // new additions
        static string[] shopFile;
        public char[,] shop;
        private ShopManager shopManager;
        private GameManager gameManager;


        // assigns player and gameManager

        public Map(Player player, GameManager gameManager)
        {
            this.player = player;
            this.gameManager = gameManager;
        }

        // assigns shopManager

        public void LocateShop(ShopManager shopManager)
        {
            this.shopManager = shopManager;
        }

        // Draws Shop if shopDisplayed, otherwise draws map

        public void DrawShop()
        {
            if (gameManager.shopDisplayed)
            {
                DisplayShop();
                shopManager.ShopDisplay();
            }
            else
            {
                DisplayMap();
            }
        }        
            public void StartMap()
        {
            mapFile = File.ReadAllLines(@"Map1.txt");

            // new additions
            shopFile = File.ReadAllLines(@"Shop.txt");

            map = new char[mapFile.Length, mapFile[0].Length];

            // new additions
            shop = new char[shopFile.Length, shopFile[0].Length];


            width = map.GetLength(1);
            height = map.GetLength(0);

            if (cameraWidth > width)
            {
                cameraWidth = width;
            }
            if (cameraHeight > height)
            {
                cameraHeight = height;
            }

            MakeMap();

            // new additions
            MakeShop();



            map[player.posX, player.posY] = player.playerChar;

            Console.SetCursorPosition(0, 0);
            Console.Clear();
        }


        public void MakeMap()
        {
            for (int i = 0; i < mapFile.Length; i++)
            {
                for (int j = 0; j < mapFile[0].Length; j++)
                {
                    map[i, j] = mapFile[i][j];
                }
            }
        }

        // makes shop
        public void MakeShop()
        {
            for (int i = 0; i < shopFile.Length; i++)
            {
                for (int j = 0; j < shopFile[0].Length; j++)
                {
                    shop[i, j] = shopFile[i][j];
                }
            }
        }


        //Draws map, and creates a temporary, smaller map that displays based on the players position
        public void DisplayMap()
        {
            Console.CursorVisible = false;

            int startX = Math.Max(0, player.posX - cameraWidth / 2);
            int startY = Math.Max(0, player.posY - cameraHeight / 2);

            ConsoleColor[,] colors = new ConsoleColor[cameraHeight, cameraWidth];
            char[,] tempMap = new char[cameraHeight, cameraWidth];

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("+");
            Console.WriteLine(new string('-', cameraWidth) + "+");

            for (int row = 0; row < cameraHeight; row++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|");

                for (int col = 0; col < cameraWidth; col++)
                {
                    int mapRow = startY + row;
                    int mapCol = startX + col;

                    if (mapRow >= 0 && mapRow < height && mapCol >= 0 && mapCol < width)
                    {
                        tempMap[row, col] = map[mapRow, mapCol];
                        colors[row, col] = GetTileColor(map[mapRow, mapCol]);
                    }
                    else
                    {
                        tempMap[row, col] = '^';
                        colors[row, col] = ConsoleColor.White;
                    }

                    Console.ForegroundColor = colors[row, col];
                    Console.Write(tempMap[row, col]);
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|");
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("+");
            Console.WriteLine(new string('-', cameraWidth) + "+");

            //UI.ShowHUD();
        }



        // new addition - DisplayShop
        public void DisplayShop()
        {
            Console.CursorVisible = false;
            ConsoleColor[,] colors = new ConsoleColor[cameraHeight, cameraWidth];
            char[,] newMap = new char[cameraHeight, cameraWidth];


            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("+");
            Console.WriteLine(new string('-', cameraWidth) + "+");

            for (int row = 0; row < cameraHeight; row++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("|");

                for (int col = 0; col < cameraWidth; col++)
                {
                    if (row < shop.GetLength(0) && col < shop.GetLength(1))
                    {
                        newMap[row, col] = shop[row, col];
                        colors[row, col] = GetTileColor(shop[row, col]);
                    }
                    else
                    {
                        newMap[row, col] = '^';
                        colors[row, col] = ConsoleColor.White;
                    }

                    Console.ForegroundColor = colors[row, col];
                    Console.Write(newMap[row, col]);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("|");
                Console.WriteLine();
            }

        }

        public ConsoleColor GetTileColor(char tile)
        {
            switch (tile)
            {
                case '`': return ConsoleColor.Black;
                case '~': return ConsoleColor.Cyan;
                case 'P': return ConsoleColor.Blue;
                case '#': return ConsoleColor.Green;
                case 'G': return ConsoleColor.Yellow;
                case 'D': return ConsoleColor.Red;
                case '!': return ConsoleColor.DarkRed;
                case '$': return ConsoleColor.Gray;
                case '§': return ConsoleColor.DarkRed;
                case '*': return ConsoleColor.Gray;
                case 'M': return ConsoleColor.Magenta;
                case '7': return ConsoleColor.White;
                case 'O': return ConsoleColor.DarkYellow;
                case '^': return ConsoleColor.DarkGray;
                case '@': return ConsoleColor.Blue;
                case '&': return ConsoleColor.Magenta;
                default: return ConsoleColor.White; 
            }
        }


    }
}
