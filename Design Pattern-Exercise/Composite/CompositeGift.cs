﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class CompositeGift:GiftBase,IGiftOperations
    {
        private List<GiftBase> gifts;
        public CompositeGift(string name,int price):base(name,price) 
        {
            gifts= new List<GiftBase>();
        }
        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }

        public override int CalculateTotalPrice()
        {
            int price = 0;
            Console.WriteLine($"{name} contains the following products with prices:");
            foreach (var item in gifts)
            {
                price += item.CalculateTotalPrice();
            }
            return price;
        }

        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }
    }
}
