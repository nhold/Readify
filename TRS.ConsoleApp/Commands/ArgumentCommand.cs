using System;

namespace TRS.ConsoleApp.Commands
{
    public class ArgumentCommand<T1, T2> : ICommand where T1 : struct, IConvertible where T2 : struct, IConvertible
    {
        private readonly string commandName;
        private readonly Action<T1, T2> action;

        public ArgumentCommand(string commandName, Action<T1, T2> action)
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
            var args = ArgumentHelper.GetArguments<T1, T2>(arguments);

            if (args == null)
            {
                return false;
            }

            action(args.Item1, args.Item2);

            return true;
        }
    }

    internal class ArgumentCommand<T1, T2, T3> : ICommand
         where T1 : struct, IConvertible
         where T2 : struct, IConvertible
         where T3 : struct, IConvertible
    {
        private readonly string commandName;
        private readonly Action<T1, T2, T3> action;

        public ArgumentCommand(string commandName, Action<T1, T2, T3> action)
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
            var args = ArgumentHelper.GetArguments<T1, T2, T3>(arguments);

            if (args == null)
            {
                return false;
            }

            action(args.Item1, args.Item2, args.Item3);

            return true;
        }
    }
}