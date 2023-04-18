using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;
        public Cocktail(string name, string size, double price)
        {
            Name = name;
            this.size = size;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size => size;

        public double Price
        {
            get { return price; }
            private set
            {
                if (Size=="Large")
                {
                    price= value;
                }
                else if (size=="Middle")
                {
                    value = value / 3;
                    value = value * 2;
                    price = value;
                }
                else if (size=="Small")
                {
                    price = value / 3;
                }
            }
        }
        public override string ToString()
        {
            return $"{Name} ({size}) - {Price:f2} lv";
        }
    }
}
