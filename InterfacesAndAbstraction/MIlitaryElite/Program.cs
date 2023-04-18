using MIlitaryElite.Models;
using MIlitaryElite.Models.Interfaces;

string command = string.Empty;
List<ISoldier> list = new List<ISoldier>();
while ((command=Console.ReadLine())!="End")
{
	try
	{
		string[] cmdInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
		if (cmdInfo[0] =="Private")
		{
			list.Add(new Private(int.Parse(cmdInfo[1]), cmdInfo[2], cmdInfo[3], decimal.Parse(cmdInfo[4])));
		}
		else if (cmdInfo[0]== "LeutenantGeneral")
		{
			LieutenantGeneral leitenant=new LieutenantGeneral(int.Parse(cmdInfo[1]), cmdInfo[2], cmdInfo[3], decimal.Parse(cmdInfo[4]))
			list.Add(new LieutenantGeneral(int.Parse())
		}
	}
	catch (Exception)
	{

	}
}