using Telephony;

string[] phones = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] urls= Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
foreach (var phone in phones)
{
	ICallable pHone;

    if (phone.Length==10)
	{
		 pHone = new Smarthpone();
		try
		{
			Console.WriteLine(pHone.Call(phone));
		}
		catch (ArgumentException ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
	else
	{
		pHone= new StationaryPhone();
        try
        {
            Console.WriteLine(pHone.Call(phone));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
foreach (var url in urls)
{
	Smarthpone smarthpone= new Smarthpone();
	try
	{
		Console.WriteLine(smarthpone.Browse(url));
	}
	catch (ArgumentException ex)
	{
		Console.WriteLine(ex.Message);
	}
}