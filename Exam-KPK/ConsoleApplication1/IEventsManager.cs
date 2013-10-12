namespace Calendar_System
{
    using System;
    using System.Collections.Generic;

    public interface IEventsManager
    {
        /// <summary>
        /// Exposes the method, which supports a simple add over a Power Collections.
        /// </summary>
        /// <param name="eventForAdd"> new instance of class Event to be added </param>
        void AddEvent(Event eventForAdd);

        /// <summary>
        /// Exposes the method, which supports delete over a Power Collections.
        /// </summary>
        /// <param name="EventTitle">eventTitle is key for the proces of search in a Power Collections. It represents title of
        /// the event for delete</param>
        /// <returns>Returns the number of found and delete events</returns>
        int DeleteEventsByTitle(string eventTitle);

        /// <summary>
        /// Exposes the method, which supports a simple search over a Power Collections and returns all found instance of class Event 
        /// which satisfy the conditions.
        /// </summary>
        /// <param name="startDate">Start date condition. All found instance of class Event must be on or after start day.</param>
        /// <param name="numberOfSearchedEvents">Represents a INT32 value, which indicate the number of the searched elements which will be returnd .
        /// If the number is bigger than all find matches all matches are returned</param>
        /// <returns>Collection of all events from startDate and dates after start date.</returns>
        IEnumerable<Event> ListEvents(DateTime startDate, int numberOfSearchedEvents);
    } 
}
