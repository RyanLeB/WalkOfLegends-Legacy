using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class ShopManager
    {
        // shop navigation
        private ConsoleKeyInfo shopNav;        
            
        // Player class
        private Player player;


        public ShopManager(Player player)
        {
            this.player = player;
        }


        // Player Buffs

        public void Buffs()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Shop!");
            Console.WriteLine("You have " + player.souls + " souls");
            Console.WriteLine("1. Health Potion - 50 souls");
            Console.WriteLine("2. Damage Buff - 100 souls");
            Console.WriteLine("3. Exit Shop");
            shopNav = Console.ReadKey();
            switch (shopNav.Key)
            {
                case ConsoleKey.D1:
                    if (player.souls >= 50)
                    {
                        player.souls -= 50;
                        player.health += 50;
                        Console.WriteLine("You have bought a Health Potion!");
                        Console.WriteLine("You now have " + player.souls + " souls");
                        Console.WriteLine("You now have " + player.health + " health");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough souls!");
                        Console.ReadKey();
                    }
                    break;
                case ConsoleKey.D2:
                    if (player.souls >= 100)
                    {
                        player.souls -= 100;
                        player.attack += 10;
                        Console.WriteLine("You have bought a Damage Buff!");
                        Console.WriteLine("You now have " + player.souls + " souls");
                        Console.WriteLine("You now have " + player.attack + " damage");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough souls!");
                        Console.ReadKey();
                    }
                    break;
                case ConsoleKey.D3:
                    break;
            }
        }



    }
}
