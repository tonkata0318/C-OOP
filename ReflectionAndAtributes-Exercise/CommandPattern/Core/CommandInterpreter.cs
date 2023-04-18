using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens=args.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];
            string[] commandArgs=tokens.Skip(1).ToArray();
            Type commandType = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t=>t.Name==$"{command}Command");
            if (commandType==null)
            {
                throw new InvalidOperationException("Command not found!");

            }
            ICommand commandInstance=Activator.CreateInstance(commandType) as ICommand;
            string result=commandInstance.Execute(commandArgs);
            return result;
        }
    }
}
