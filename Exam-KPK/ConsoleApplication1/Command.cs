namespace Calendar_System
{
    using System;
    using System.Linq;

    public struct Command
    {   
        public Command(string commandName, string[] paramms)
            : this()
        {
            this.CommandName = commandName;
            this.Paramms = paramms;
        }

        public string CommandName { get; set; }

        public string[] Paramms { get; set; }

        public static Command Parse(string currentCommandLine)
        {
            int numberOfArguments = (currentCommandLine.Split(new char[]{'|'}, StringSplitOptions.RemoveEmptyEntries)).Length;

            int commandNameLastIndex = currentCommandLine.IndexOf(' ');
            if (commandNameLastIndex == -1)
            {
                throw new FormatException("Invalid command line !");
            }

            string commandName = currentCommandLine.Substring(0, commandNameLastIndex);
            string commandParameters = currentCommandLine.Substring(commandNameLastIndex + 1);
            string[] commandArguments = commandParameters.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            if (numberOfArguments != commandArguments.Length)
            {
                throw new FormatException("Invalid  command or spaces !");
            }

            if (commandName.Contains('|'))
            {
                throw new FormatException("Invalid command: " + currentCommandLine);
            }

            for (int i = 0; i < commandArguments.Length; i++)
            {
                commandArguments[i] = commandArguments[i].Trim();
            }

            Command command = new Command(commandName, commandArguments);
            return command;
        }
    }
}
