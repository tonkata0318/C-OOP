string[] input = Console.ReadLine().Split(" ");
int sum = 0;
foreach (var el in input)
{
	int element = 0;
	try
	{
	    element=int.Parse(el);
		sum += element;
	}
	catch (FormatException)
	{
		Console.WriteLine($"The element '{el}' is in wrong format!");
	}
	catch(OverflowException)
	{
		Console.WriteLine($"The element '{el}' is out of range!");
	}
	finally 
	{
		Console.WriteLine($"Element '{el}' processed - current sum: {sum}");
    }
}
Console.WriteLine($"The total sum of all integers is: {sum}");
