using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            const int healthCost = 30;
            if (player.souls >= healthCost)
            {
                player.healthSystem.Heal(30);
                player.souls -= healthCost;
                
            }
        }

        // Purchase Damage Buff

        void IncreaseDamage()
        {

            const int damageCost = 100;
            if (player.souls >= damageCost)
            {
                player.attack += 20;
                player.souls -= damageCost;
                
            }
        }

        // Purchase Invincibility

        void Invincibility()
        {

            const int invincibilityCost = 60;
            if (player.souls >= invincibilityCost)
            {
                player.souls -= invincibilityCost;
                
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
