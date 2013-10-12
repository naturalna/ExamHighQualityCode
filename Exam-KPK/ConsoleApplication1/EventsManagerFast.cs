namespace Calendar_System
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventsManagerFast : IEventsManager
    {
        private readonly MultiDictionary<string, Event> tableOfEvents = new MultiDictionary<string, Event>(true);
        private readonly OrderedMultiDictionary<DateTime, Event> orderedByDateTableOfEvents = new OrderedMultiDictionary<DateTime, Event>(true);

        public int Count
        {
            get
            {
                return this.orderedByDateTableOfEvents.KeyValuePairs.Count;
            }
        }

        public void AddEvent(Event eventForAdd)
        {
            string eventTitleToLowerCase = eventForAdd.EventTitle.ToLowerInvariant();
            this.tableOfEvents.Add(eventTitleToLowerCase, eventForAdd);
            this.orderedByDateTableOfEvents.Add(eventForAdd.DateOftheEvent, eventForAdd);
        }

        public int DeleteEventsByTitle(string title)
        {
            string titleToLowerCase = title.ToLowerInvariant();
            var eventsForDeleteHolder = this.tableOfEvents[titleToLowerCase];
            int deletedEventsNumber = eventsForDeleteHolder.Count;

            foreach (var eventForDelete in eventsForDeleteHolder)
            {
                this.orderedByDateTableOfEvents.Remove(eventForDelete.DateOftheEvent, eventForDelete);
            }

            this.tableOfEvents.Remove(titleToLowerCase);
            return deletedEventsNumber;
        }

        public IEnumerable<Event> ListEvents(DateTime fromDate, int numberOfSearchedEvents)
        {
            var eventsInDateRange =
                from selectedEvent in this.orderedByDateTableOfEvents.RangeFrom(fromDate, true).Values
                select selectedEvent;

            var events = eventsInDateRange.Take(numberOfSearchedEvents);
            return events;
        }
    }
}
