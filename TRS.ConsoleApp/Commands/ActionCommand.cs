using System;

namespace TRS.ConsoleApp.Commands
{
    /// <summary>
    /// An action command represents a string to no argument action.
    /// </summary>
    public class ActionCommand : ICommand
    {
        private readonly string commandName;
        private readonly Action action;

        public ActionCommand(string commandName, Action action)
        {
            this.commandName = commandName;
            this.action = action;
        }

        public string CommandName()
        {
            return commandName;
        }

        public bool Process(string[] arguments)
        {
            // Action command doesn't care about arguments.
            action?.Invoke();

            return true;
        }
    }
}