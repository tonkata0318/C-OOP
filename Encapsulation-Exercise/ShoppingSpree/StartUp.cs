﻿using System.Security.Principal;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
			List<Person> people= new List<Person>();
			List<Product> products= new List<Product>();
			try
			{
				string[] nameMonetPair = Console.ReadLine()
					.Split(";", StringSplitOptions.RemoveEmptyEntries);
				foreach (var namemoneyPair in nameMonetPair)
				{
					string[] nameMoney = namemoneyPair.Split("=", StringSplitOptions.RemoveEmptyEntries);
					Person person = new(nameMoney[0], decimal.Parse(nameMoney[1]));
					people.Add(person);
				}
                string[] productCostPairs = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (var productCostPair in productCostPairs)
                {
                    string[] productCost = productCostPair.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    Product product = new(productCost[0], decimal.Parse(productCost[1]));
                    products.Add(product);
                }

            }
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}
			string input;
			while ((input=Console.ReadLine())!="END")
			{
				string[] personProduct = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
				string personName = personProduct[0];
				string productName = personProduct[1];
				Person person = people.FirstOrDefault(p => p.Name==personName);
				Product product=products.FirstOrDefault(p => p.Name==productName);

				if (person!=null && product!=null)
				{
					Console.WriteLine(person.Add(product));
				}
			}
			Console.WriteLine(string.Join(Environment.NewLine,people));
        }
    }
}