using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedcapacity;
        private double pricePerNight;
        
        public Room(int bedcapacity)
        {
            this.bedcapacity = bedcapacity;
            PricePerNight = 0;
        }

        public int BedCapacity => bedcapacity;

        public double PricePerNight
        {
            get { return pricePerNight; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                pricePerNight= value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight= price;
        }
    }
}
