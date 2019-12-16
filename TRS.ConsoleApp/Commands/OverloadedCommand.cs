using System.Collections.Generic;

namespace TRS.ConsoleApp.Commands
{
    public class OverloadedCommand : ICommand
    {
        private readonly string commandName;
        private readonly List<ICommand> commands;

        public OverloadedCommand(string commandName, List<ICommand> commands)
        {
            this.commandName = commandName;
            this.commands = commands;
        }

        public string CommandName()
        {
            return commandName;
        }

        public bool Process(string[] arguments)
        {
            foreach (var command in commands)
            {
                if (command.Process(arguments))
                    return true;
            }

            return false;
        }
    }
}