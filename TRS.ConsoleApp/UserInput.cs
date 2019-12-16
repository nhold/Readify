namespace TRS.ConsoleApp.Commands
{
    public class UserInput
    {
        private string input;
        private string command;
        private string[] arguments;

        public bool IsValid
        {
            get;
            private set;
        }

        public string InitialInput
        {
            get
            {
                return input;
            }
        }

        public string Command
        {
            get
            {
                return command;
            }
        }

        public string[] GetArguments()
        {
            return arguments;
        }

        public static UserInput ExtractUserInput(string input)
        {
            UserInput userInput = new UserInput
            {
                input = input
            };

            if (string.IsNullOrWhiteSpace(input))
            {
                userInput.IsValid = false;
                return userInput;
            }

            userInput.arguments = input.Split(',');

            // Pull out the command.
            var splitCommand = userInput.arguments[0].Split(' ');
            userInput.command = splitCommand[0].ToLower();

            // Remove the command from the first argument.
            int spaceIndex = userInput.arguments[0].IndexOf(' ');
            userInput.arguments[0] = userInput.arguments[0].Substring(spaceIndex + 1).Trim();

            userInput.IsValid = !string.IsNullOrWhiteSpace(userInput.command);

            return userInput;
        }
    }
}