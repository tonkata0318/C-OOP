using System.Diagnostics;

Dictionary<int,double> accounts=new Dictionary<int,double>();
string[] input = Console.ReadLine().Split(",");
foreach (string account in input)
{
    string[] accInfo= account.Split("-");
    int accountNumber = int.Parse(accInfo[0]);
    double accountBalace = double.Parse(accInfo[1]);
    if (!accounts.ContainsKey(accountNumber))
    {
        accounts.Add(accountNumber, accountBalace);
    }
}
string command = string.Empty;
while ((command=Console.ReadLine())!="End")
{
    string[] cmdInfo = command.Split(" ");
    string commandType= cmdInfo[0];
    if (commandType=="Deposit")
    {
        try
        {
            int accountNumber = int.Parse(cmdInfo[1]);
            double accountDeposit = int.Parse(cmdInfo[2]);
            bool accountDoesNotExist = false;
            foreach (var item in accounts)
            {
                if (accountNumber == item.Key)
                {
                    accountDoesNotExist = true;
                }
            }
            if (!accountDoesNotExist)
            {
                throw new FormatException("Invalid account!");
            }
            accounts[accountNumber] += accountDeposit;
            Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
    else if (commandType=="Withdraw")
    {
        try
        {
            int accountNumber = int.Parse(cmdInfo[1]);
            double accountWithdraw = double.Parse(cmdInfo[2]);
            bool accountDoesNotExist = false;
            foreach (var item in accounts)
            {
                if (accountNumber == item.Key)
                {
                    accountDoesNotExist = true;
                }
            }
            if (!accountDoesNotExist)
            {
                throw new FormatException("Invalid account!");
            }
            if (accounts[accountNumber]<accountWithdraw)
            {
                throw new OverflowException("Insufficient balance!");
            }
            accounts[accountNumber] -= accountWithdraw;
            Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    else 
    {
        Console.WriteLine("Invalid command!");
    }
    Console.WriteLine("Enter another command");
}