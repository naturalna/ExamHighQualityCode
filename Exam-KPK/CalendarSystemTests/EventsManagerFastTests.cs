using System;
using System.Collections.Generic;
using Calendar_System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarSystemTests
{
    [TestClass]
    public class EventsManagerFastTests
    {
        [TestMethod]
        public void AddEvent_AddOneEventCorrect()
        {
            EventsManagerFast manager = new EventsManagerFast();
            DateTime dateOfTheEvent = new DateTime(2013,05,25);
            Event testEvent = new Event(dateOfTheEvent,"MyTestEventTitle");
            manager.AddEvent(testEvent);
            int eventsCount = manager.Count;
            Assert.IsTrue(1 == eventsCount);
        }

        [TestMethod]
        public void AddEvent_AddOneEventTwice()
        {
            EventsManagerFast manager = new EventsManagerFast();
            DateTime dateOfTheEvent = new DateTime(2013, 05, 25);
            Event testEvent = new Event(dateOfTheEvent, "MyTestEventTitle");
            manager.AddEvent(testEvent);
            manager.AddEvent(testEvent);
            int eventsCount = manager.Count;
            Assert.IsTrue(2 == eventsCount);
        }

        [TestMethod]
        public void ListEvents_AddOneEventCorrectListOfEventsCheck()
        {
            EventsManagerFast manager = new EventsManagerFast();
            DateTime dateOfTheEvent = new DateTime(2013, 05, 25);
            Event testEvent = new Event(dateOfTheEvent, "MyTestEventTitle");
            Event testEventTwo = new Event(dateOfTheEvent, "MyTestEventTitleTwo");
            manager.AddEvent(testEvent);
            manager.AddEvent(testEventTwo);
            DateTime startDateOfSearch = new DateTime(2012, 01, 01);
            var allFindEventsInRange = (manager.ListEvents(startDateOfSearch, 100));
            int eventCount = 0;
            foreach (var ev in allFindEventsInRange)
            {
                eventCount++;
            }

            Assert.AreEqual(2, eventCount);
            Assert.IsTrue(2 == manager.Count);
        }

        [TestMethod]
        public void ListEvents_NoMachingDateTime()
        {
            EventsManagerFast manager = new EventsManagerFast();
            DateTime dateOfTheEvent = new DateTime(2013, 05, 25);
            Event testEvent = new Event(dateOfTheEvent, "MyTestEventTitle");
            Event testEventTwo = new Event(dateOfTheEvent, "MyTestEventTitleTwo");
            manager.AddEvent(testEvent);
            manager.AddEvent(testEventTwo);
            DateTime startDateOfSearch = new DateTime(2014, 01, 01);
            var allFindEventsInRange = (manager.ListEvents(startDateOfSearch, 100));
            int eventCount = 0;
            foreach (var ev in allFindEventsInRange)
            {
                eventCount++;
            }

            Assert.AreEqual(0, eventCount);
        }

        [TestMethod]
        public void ListEvents_EmptyList()
        {
            EventsManagerFast manager = new EventsManagerFast();
            DateTime startDateOfSearch = new DateTime(2014, 01, 01);
            var allFindEventsInRange = (manager.ListEvents(startDateOfSearch, 100));
            int eventCount = 0;
            foreach (var ev in allFindEventsInRange)
            {
                eventCount++;
            }

            Assert.AreEqual(0, eventCount);
        }

        [TestMethod]
        public void DeleteEventsByTitle_CorrectDelete()
        {
            EventsManagerFast manager = new EventsManagerFast();
            DateTime dateOfTheEvent = new DateTime(2013, 05, 25);
            Event testEvent = new Event(dateOfTheEvent, "MyTestEventTitle");
            Event testEventTwo = new Event(dateOfTheEvent, "MyTestEventTitleTwo");
            manager.AddEvent(testEvent);
            manager.AddEvent(testEventTwo);
            manager.DeleteEventsByTitle("MyTestEventTitle");

            Assert.IsTrue(1 == manager.Count);
        }

        [TestMethod]
        public void DeleteEventsByTitle_NotExistingEvent()
        {
            EventsManagerFast manager = new EventsManagerFast();
            DateTime dateOfTheEvent = new DateTime(2013, 05, 25);
            Event testEvent = new Event(dateOfTheEvent, "MyTestEventTitle");
            Event testEventTwo = new Event(dateOfTheEvent, "MyTestEventTitleTwo");
            manager.AddEvent(testEvent);
            manager.AddEvent(testEventTwo);
            int numberOfDeletedEvents = manager.DeleteEventsByTitle("NotExistingEventName");

            Assert.IsTrue(2 == manager.Count);
            Assert.IsTrue(0 == numberOfDeletedEvents);
        }
    }
}
