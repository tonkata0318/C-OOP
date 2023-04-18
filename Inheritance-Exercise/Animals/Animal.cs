using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {

        private int age;
        private string name;
        private string gender;
        public string Name { get { return name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    name = value;
                }
            } }
        public int Age {get { return age; }
            set
            {
                if (value>0)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
        public string Gender
        {
            get => gender; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    gender = value;
                }
            }
        }

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public abstract string ProduceSound();
        public override string ToString()
        {
            return $"{Name} {Age} {Gender}{Environment.NewLine}{ProduceSound()}";
        }
    }
}
