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

        // Item class
        private ItemInvincible itemInvincible;

        // Map and UI class
        private Map map;
        private UI ui;


        public ShopManager(Player player, Map map, UI ui)
        {
            this.player = player;
            this.map = map;
            this.ui = ui;
        }


        // Player Buffs 


        // Purchase Health Buff

        void IncreaseHealth()
        {
            if (player.souls >= 30)
            {
                player.healthSystem.Heal(30);
                player.souls -= 30;
            }
        }

        // Purchase Damage Buff

        void IncreaseDamage()
        {
            if (player.souls >= 100)
            {
                player.attack += 20;
                player.souls -= 100;
            }
        }

        // Purchase Invincibility

        void Invincibility()
        {
            if (player.souls >= 60)
            {
                player.souls -= 60;
                itemInvincible = new ItemInvincible(map, player, ui);
                itemInvincible.DoYourJob();
                itemInvincible = null;
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
                case ConsoleKey.D3:
                    Invincibility();
                    break;
                default:
                    break;
            }

        }





    }
}
