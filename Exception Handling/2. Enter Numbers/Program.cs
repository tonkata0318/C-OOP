List<int> list = new List<int>();
for (int i = 1; i <= 10; i++)
{

	int num=ReadNumber(i,100);
	if (num!=0)
	{
        list.Add(num);
    }
	else
	{
		i--;
	}
}
Console.WriteLine(string.Join(", ",list));



int ReadNumber(int start,int end)
{
	int number = 0;
	try
	{
		number = int.Parse(Console.ReadLine());
		if (number<=start||number>=end)
		{
			throw new ArithmeticException($"Your number is not in range {start} - {end}!");
		}
	}
	catch (FormatException)
	{
		Console.WriteLine("Invalid Number!");
	}
	catch(ArithmeticException ex)
	{
        number = 0;
        Console.WriteLine(ex.Message);
	}
	return number;
}