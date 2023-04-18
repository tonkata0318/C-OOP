using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class FoodAsterisk : Food
    {
        private const char foodSymbol = '*';
        private const int pointsGiven = 1;
        public FoodAsterisk(Wall wall) : base(wall, foodSymbol, pointsGiven)
        {
        }
    }
}
