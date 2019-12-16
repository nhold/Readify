using System.Collections.Generic;

namespace TRS.ConsoleApp.Commands
{
    public class CommandLibrary : Dictionary<string, ICommand>
    {
        private readonly Dictionary<string, ICommand> commands;

        public CommandLibrary()
        {
            commands = new Dictionary<string, ICommand>();
        }

        public void Register(ICommand command)
        {
            commands.Add(command.CommandName(), command);
        }

        public void Unregister(ICommand command)
        {
            commands.Remove(command.CommandName());
        }

        public void Execute(UserInput userInput)
        {
            if (commands.ContainsKey(userInput.Command))
            {
                commands[userInput.Command].Process(userInput.GetArguments());
            }
        }
    }
}