using System;
using System.Collections.Generic;

namespace TextRPG_V2
{
    public class Shop
    {
        private List<Item> inventory;

        public Shop()
        {
            inventory = new List<Item>();
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            inventory.Remove(item);
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Shop Inventory:");
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.GetName()} - {item.GetPrice()} gold");
            }
        }

        public void BuyItem(Item item, Player player)
        {
            if (player.playerGold >= item.GetPrice())
            {
                player.playerGold -= item.GetPrice();
                
                RemoveItem(item);
                Console.WriteLine($"You bought {item.GetName()}.");
            }
            else
            {
                Console.WriteLine("Not enough gold.");
            }
        }

        public void SellItem(Item item, Player player)
        {
            player.playerGold += item.GetPrice();
            
            AddItem(item);
            Console.WriteLine($"You sold {item.GetName()}.");
        }
    }
}
