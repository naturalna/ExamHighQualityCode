namespace Calendar_System
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Obsolete("Not used anymore", true)]
    internal class EventManager : IEventsManager
    {
        private readonly List<Event> listOfEvents = new List<Event>();

        public void AddEvent(Event eventForAdd)
        {
            this.listOfEvents.Add(eventForAdd);
        }

        public int DeleteEventsByTitle(string title)
        {
            return this.listOfEvents.RemoveAll(
                ev => ev.EventTitle.ToLowerInvariant() == title.ToLowerInvariant());
        }

        public IEnumerable<Event> ListEvents(DateTime eventDate, int numberOfSearchedEvents)
        {
            return (from evn in this.listOfEvents
                    where evn.DateOftheEvent >= eventDate
                    orderby evn.DateOftheEvent, evn.EventTitle, evn.Location
                    select evn).Take(numberOfSearchedEvents);
        }
    }
}
