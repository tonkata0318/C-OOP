using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Animal
    {
        string Name { get; set; }
        string favoriteFood { get; set; }
        public Animal(string name, string favoriteFood)
        {
            Name = name;
            this.favoriteFood = favoriteFood;
        }
        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my favourite food is {favoriteFood}";
        }
    }
}
