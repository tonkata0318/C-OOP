﻿try
{
	int number = int.Parse(Console.ReadLine());
	if (number<0)
	{
		throw new Exception();
    }
	Console.WriteLine(Math.Sqrt(number));
}
catch (Exception)
{
	Console.WriteLine("Invalid number.");
}
finally
{
	Console.WriteLine("Goodbye.");
}