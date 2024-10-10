using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public abstract class Item
    {
        private string name; // Name of the item
        private ConsoleColor color; // Color of the Item representation
        private char symbol; // The graphical representation of the Item
        private int price; // Price of the item

         

        /// <summary>
        /// Constructor method for an abstract item object
        /// </summary>
        /// <param name="name">Name of the item</param>
        public Item(string name, int price)
        {
            this.name = name;
            this.price = price;
            color = ConsoleColor.Yellow;
            symbol = '?';
            
        }

        /// <summary>
        /// Empty Constructor for an Item object
        /// </summary>
        public Item()
        {
            name = null;
            price = 0;
            color = ConsoleColor.Yellow;
            symbol = '?';
            
        }

        /// <summary>
        /// Method for using an item
        /// </summary>
        /// <param name="target">The entity that is using the item</param>
        /// <returns>A string for the event log</returns>
        public abstract string Use(Entity target);


        /// <summary>
        /// Accessor method for the name of the item
        /// </summary>
        /// <returns>Name of the item</returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Mutator method for the name of the item
        /// </summary>
        /// <param name="name">Name of the item</param>
        public void SetName(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Accessor method for the price of the item
        /// </summary>
        /// <returns>Price of the item</returns>
        public int GetPrice()
        {
            return price;
        }

        /// <summary>
        /// Mutator method for the price of the item
        /// </summary>
        /// <param name="price">Price of the item</param>
        public void SetPrice(int price)
        {
            this.price = price;
        }

        /// <summary>
        /// Mutator method that sets the graphical representation of the Item
        /// </summary>
        /// <param name="symbol">The graphical representation of the Item</param>
        public void SetSymbol(char symbol)
        {
            this.symbol = symbol;
        }

        /// <summary>
        /// Accessor method that returns the graphical representation of the Item
        /// </summary>
        /// <returns>The graphical representation of the Item</returns>
        public char GetSymbol()
        {
            return symbol;
        }

        /// <summary>
        /// Mutator method that sets the color of the graphical representation of the Item
        /// </summary>
        /// <param name="color">The color of the graphical representation of the Item</param>
        public void SetColor(ConsoleColor color)
        {
            this.color = color;
        }

        /// <summary>
        /// Accessor method that returns the color of the graphical representation of the Item
        /// </summary>
        /// <returns>The color of the graphical representation of the Item</returns>
        public ConsoleColor GetColor()
        {
            return color;
        }
    }
}
