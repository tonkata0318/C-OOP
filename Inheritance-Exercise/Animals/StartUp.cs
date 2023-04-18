using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string anymalType=Console.ReadLine();
                if (anymalType == "Beast!")
                {
                    break;
                }
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(anymalType);
                switch (anymalType)
                {
                    case "Cat":
                        Cat cat = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Console.WriteLine(cat);
                        break;
                    case "Dog":
                        Dog dog = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Console.WriteLine(dog);
                        break;
                    case "Frog":
                        Frog frog = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Console.WriteLine(frog);
                        break;
                    case "Kitten":
                        Kitten kittens = new Kitten(tokens[0], int.Parse(tokens[1]));
                        Console.WriteLine(kittens);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(tokens[0], int.Parse(tokens[1]));
                        Console.WriteLine(tomcat);
                        break;
                }
            }
            
        }
    }
}
