namespace Calendar_System
{
    using System;

    internal class RunCalendarSystem
    {
        internal static void Main()
        {
            EventsManagerFast eventManager = new EventsManagerFast();
            CommandExecutor commandExecutor = new CommandExecutor(eventManager);
            bool notEndCommand = true;

            while (notEndCommand)
            {
                string currenrCommandLine = Console.ReadLine();
                if (null == currenrCommandLine || currenrCommandLine == "End")
                {
                    notEndCommand = false;
                    break;
                }
                else
                {
                    try
                    {
                        Command currentCommand = Command.Parse(currenrCommandLine);
                        string outputText = commandExecutor.ProcessCommand(currentCommand);
                        Console.WriteLine(outputText);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
