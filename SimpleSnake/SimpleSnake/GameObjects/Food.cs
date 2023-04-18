using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private Wall wall;
        private Random random;
        private char foodSymbol;
        protected Food(Wall wall,char foodSymbol,int points) : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;
            this.random = new Random();
        }
        public int FoodPoints { get; private set; }
        public void SetRandomPosition(Queue<Point> points)
        {
            LeftX = random.Next(2, wall.LeftX-2);
            TopY=random.Next(2,wall.TopY-2);
            bool isPointOfSnake=points.Any(x=>x.LeftX==this.LeftX&&x.TopY==this.TopY);
            while (isPointOfSnake)
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY=random.Next(2,wall.TopY-2);
                isPointOfSnake = points.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }
            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor= ConsoleColor.White;
        }
        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY==this.TopY&&snake.LeftX==this.LeftX;
        }
    }
}
