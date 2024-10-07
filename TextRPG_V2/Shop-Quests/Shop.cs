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
                Console.WriteLine(item.GetName());
            }
        }

        public void BuyItem(Item item, Player player)
        {
            if (player.gold >= item.Price)
            {
                player.gold -= item.Price;
                player.AddItem(item);
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
            player.Gold += item.Price;
            player.RemoveItem(item);
            AddItem(item);
            Console.WriteLine($"You sold {item.GetName()}.");
        }
    }
}
s
