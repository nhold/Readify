namespace TRS.ConsoleApp.Commands
{
    public interface ICommand
    {
        public abstract string CommandName();

        public abstract bool Process(string[] arguments);
    }
}