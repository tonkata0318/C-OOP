using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private DelicacyRepository delicacies;
        private CocktailRepository cocktails;
        private double currentbill;
        private double turnover;
        private bool isReversed;
        public Booth(int boothId, int capacity)
        {
            this.boothId = boothId;
            this.capacity = capacity;
            delicacies=new DelicacyRepository();
            cocktails=new CocktailRepository();
            currentbill=0;
            turnover=0;
            isReversed=false;
        }

        public int BoothId => boothId;

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
            }
        }

        public IRepository<IDelicacy> DelicacyMenu =>delicacies;

        public IRepository<ICocktail> CocktailMenu => cocktails;

        public double CurrentBill => currentbill;
        
        public double Turnover => turnover;

        public bool IsReserved => isReversed;

        public void ChangeStatus()
        {
            if (isReversed==true)
            {
                isReversed= false;
            }
            else
            {
                isReversed = true;
            }
        }

        public void Charge()
        {
            turnover += currentbill;
            currentbill=0;
        }

        public void UpdateCurrentBill(double amount)
        {
            currentbill+=amount;
        }
        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"Booth: {boothId}");
            sb.AppendLine($"Capacity: {capacity}");
            sb.AppendLine($"Turnover: {turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");
            foreach (var item in cocktails.Models)
            {
                sb.AppendLine($"{item.ToString()}");
            }
            sb.AppendLine($"-Delicacy menu:");
            foreach (var item in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
