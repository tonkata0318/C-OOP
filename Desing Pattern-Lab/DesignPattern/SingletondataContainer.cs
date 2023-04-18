using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public class SingletondataContainer : ISingletonContainer
    {
        
        private Dictionary<string, int> capitals=new Dictionary<string, int>();
        public SingletondataContainer()
        {
            Console.WriteLine("Initializing singleton object");
            var elements = File.ReadAllLines(@"..\..\..\capitals.txt");
            for (int i = 0; i < elements.Length; i+=2)
            {
                capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }
        private static SingletondataContainer instance=new SingletondataContainer();
        public  SingletondataContainer Instance=>instance;
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
