int[] input=Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
string command = string.Empty;
int exceptionCount = 0;
while (exceptionCount<3)
{
    command = Console.ReadLine();
    string[] cmdInfo=command.Split(" ");
    string cmdType = cmdInfo[0];
    if (cmdType=="Replace")
    {
        try
        {
            int givenIndex = int.Parse(cmdInfo[1]);
            int givenElement = int.Parse(cmdInfo[2]);
            if (givenIndex<0||givenIndex>=input.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            input[givenIndex] = givenElement;
        }
        catch (FormatException)
        {
            Console.WriteLine("The variable is not in the correct format!");
            exceptionCount++;
        }
        catch(ArgumentOutOfRangeException)
        {
            Console.WriteLine("The index does not exist!");
            exceptionCount++;
        }
        //catch(ArgumentException)
        //{
        //    exceptionCount++;
        //}
    }
    else if (cmdType=="Print")
    {
        try
        {
            int givenStart = int.Parse(cmdInfo[1]);
            int givenEnd = int.Parse(cmdInfo[2]);
            if (givenStart < 0 ||givenEnd>= input.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = givenStart; i <= givenEnd; i++)
            {
                if (i!=givenEnd)
                {
                    Console.Write($"{input[i]}, ");
                }
                else
                {
                    Console.Write(input[i]);
                }
            }
            Console.WriteLine();
        }
        catch (FormatException)
        {
            Console.WriteLine("The variable is not in the correct format!");
            exceptionCount++;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("The index does not exist!");
            exceptionCount++;
        }
        //catch (ArgumentException)
        //{
        //    exceptionCount++;
        //}
    }
    else if (cmdType=="Show")
    {
        try
        {
            int index = int.Parse(cmdInfo[1]);
            Console.WriteLine(input[index]);
        }
        catch (FormatException)
        {
            Console.WriteLine("The variable is not in the correct format!");
            exceptionCount++;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("The index does not exist!");
            exceptionCount++;
        }
        //catch (ArgumentException)
        //{
        //    exceptionCount++;
        //}
    }
}
Console.WriteLine(string.Join(", ", input));