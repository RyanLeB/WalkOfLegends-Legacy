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

        void IncreaseHealth()
        {
            if (player.souls >= 30)
            {
                player.healthSystem.Heal(30);
                player.souls -= 30;
            }
        }

        void IncreaseDamage()
        {
            if (player.souls >= 100)
            {
                player.attack += 20;
                player.souls -= 100;
            }
        }




        // Shop Display

        public void ShopDisplay()
        {

            shopNav = Console.ReadKey(true);
            switch (shopNav.Key)
            {
                case ConsoleKey.D1:
                    IncreaseHealth();
                    break;
                case ConsoleKey.D2:
                    IncreaseDamage();
                    break;
                default:
                    break;
            }

        }





    }
}
