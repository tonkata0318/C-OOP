using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private const char snakeSymbol = '\u25CF';
        private int foodIndex;
        public int Points { get; private set; }
        public int PlayerLevel { get { return snakeElements.Count; } }
        public Snake(Wall wall)
        {
            this.wall = wall;
            snakeElements= new Queue<Point>();
            foods= new Food[3];
            foodIndex= RandomFoodNumber;
            this.GetFoods();
            this.CreateSnake();
        }
        private int RandomFoodNumber=>new Random().Next(0,this.foods.Length);
        private void CreateSnake()
        {
            for (int i = 1; i <= 6; i++)
            {
                this.snakeElements.Enqueue(new Point(2, i));
            }
        }
        private void GetFoods()
        {
            foods[0] = new FoodHash(wall);
            foods[1] = new FoodDollar(wall);
            foods[2]=new FoodAsterisk(wall);
            this.foods[foodIndex].SetRandomPosition(snakeElements);
        }
        public bool IsMoving(Point point)
        {
            Point snakeHead=snakeElements.Last();
            GetNextPoint(point, snakeHead);
            bool isPointOfSnake = this.snakeElements.Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);
            if (isPointOfSnake)
            {
                return false;
            }
            Point snakeNewHead=new Point(nextLeftX, nextTopY);
            if (wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }
            snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);
            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(point, snakeHead);
            }
            Point snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(' ');
            return true;
        }

        private void Eat(Point point, Point snakeHead)
        {
            int length = foods[foodIndex].FoodPoints;
            for (int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(point, snakeHead);
            }
            foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(snakeElements);
            Points+=foods[foodIndex].FoodPoints;
        }

        private void GetNextPoint(Point direction,Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY=snakeHead.TopY + direction.TopY;
        }
    }
}
