namespace Calendar_System
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class CommandExecutor
    {
        private readonly IEventsManager eventsManager;

        public CommandExecutor(IEventsManager currentEventsManager)
        {
            this.eventsManager = currentEventsManager;
        }

        public IEventsManager EventsManager
        {
            get
            {
                return this.eventsManager;
            }
        }

        public string ProcessCommand(Command currentCommand)
        {
            switch (currentCommand.CommandName)
            {
                case "AddEvent": return this.AddEvent(currentCommand);
                case "DeleteEvents": return this.DeleteEvent(currentCommand);
                case "ListEvents": return this.GetListEvents(currentCommand);
                default:
                    throw new FormatException("WTF " + currentCommand.CommandName + " is?");
            }
        }

        private string GetListEvents(Command currentCommand)
        {
            if (currentCommand.Paramms.Length == 2)
            {
                DateTime date = DateTime.ParseExact(currentCommand.Paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                int commandNumber = int.Parse(currentCommand.Paramms[1]);
                List<Event> events = this.eventsManager.ListEvents(date, commandNumber).ToList();
                StringBuilder outputText = new StringBuilder();

                if (!events.Any())
                {
                    return "No events found";
                }

                foreach (var e in events)
                {
                    outputText.AppendLine(e.ToString());
                }

                return outputText.ToString().Trim();
            }

            throw new FormatException("Invalid params!");
        }

        private string DeleteEvent(Command currentCommand)
        {
            if (currentCommand.Paramms.Length == 1)
            {
                int numberOfDeletedEvents = this.eventsManager.DeleteEventsByTitle(currentCommand.Paramms[0]);

                if (numberOfDeletedEvents == 0)
                {
                    return "No events found.";///1
                }

                return numberOfDeletedEvents + " events deleted";
            }

            throw new FormatException("Invalid params");
        }

        private string AddEvent(Command currentCommand)
        {
            if (currentCommand.Paramms.Length == 2)
            {
                var date = DateTime.ParseExact(currentCommand.Paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                Event createdEventFromCommand = new Event(date, currentCommand.Paramms[1]);
                this.eventsManager.AddEvent(createdEventFromCommand);
                return "Event added";
            }

            if (currentCommand.Paramms.Length == 3)
            {
                var date = DateTime.ParseExact(currentCommand.Paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var createdEventFromCommand = new Event(date, currentCommand.Paramms[1], currentCommand.Paramms[2]);
                this.eventsManager.AddEvent(createdEventFromCommand);
                return "Event added";
            }

            throw new FormatException("Invalid params");
        }
    }
}
