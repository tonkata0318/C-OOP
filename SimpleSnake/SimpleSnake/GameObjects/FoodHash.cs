using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class FoodHash : Food
    {
        private const char foodSymbol = '#';
        private const int pointsGiven = 3;
        public FoodHash(Wall wall) : base(wall, foodSymbol, pointsGiven)
        {
        }
    }
}
