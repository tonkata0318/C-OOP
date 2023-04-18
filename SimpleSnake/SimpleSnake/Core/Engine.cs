using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Wall wall;
        private Snake snake;
        private SimpleSnake.GameObjects.Point[] pointsOfDirection;
        private Direction direction;
        private double sleepTime;
        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            sleepTime = 100;
            pointsOfDirection=new GameObjects.Point[4];
        }
        public void Run()
        {
            this.CreateDirections();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }
                bool isMoving = snake.IsMoving(pointsOfDirection[(int)direction]);
                if (!isMoving)
                {
                    AskUserForRestart();
                }
                sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);
            }
        }

        private void CreateDirections()
        {
            this.pointsOfDirection[0]=new SimpleSnake.GameObjects.Point(1,0);
            this.pointsOfDirection[1]=new SimpleSnake.GameObjects.Point(-1,0);
            this.pointsOfDirection[2]=new SimpleSnake.GameObjects.Point(0,1);
            this.pointsOfDirection[3]=new SimpleSnake.GameObjects.Point(0,-1);
        }
        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput=Console.ReadKey();
            if (userInput.Key==ConsoleKey.LeftArrow)
            {
                if (direction!=Direction.Right)
                {
                    direction= Direction.Left;
                }
            }
            else if (userInput.Key==ConsoleKey.RightArrow)
            {
                if (direction!=Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key==ConsoleKey.UpArrow)
            {
                if (direction!=Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key==ConsoleKey.DownArrow)
            {
                if (direction!=Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
            Console.CursorVisible= false;
            bool isMoving = snake.IsMoving(pointsOfDirection[(int)direction]);
            if (!isMoving)
            {
                AskUserForRestart();
            }
        }

        private void AskUserForRestart()
        {
            int leftX = wall.LeftX + 1;
            int topY = 3;
            Console.SetCursorPosition(leftX, topY);
            Console.WriteLine();
            Console.WriteLine($"Player points: {snake.Points}");
            Console.WriteLine($"Player level: {snake.PlayerLevel}");
            Console.Write("Would you like to continue? y/n");
            string input=Console.ReadLine();
            if (input=="y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }
    }
}
