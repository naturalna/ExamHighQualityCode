namespace Calendar_System
{
    using System;
    using System.Linq;

    public class Event : IComparable<Event>
    {
        internal Event(DateTime dateOftheEvent, string eventTitle, string location)
        {
            this.DateOftheEvent = dateOftheEvent;
            this.EventTitle = eventTitle;
            this.Location = location;
        }

        public Event(DateTime dateOftheEvent, string eventTitle)
            : this(dateOftheEvent, eventTitle, null)
        {
        }

        internal DateTime DateOftheEvent { get; private set; }

        internal string EventTitle { get; private set; }

        internal string Location { get; private set; }

        public int CompareTo(Event otherEvent)
        {
            int dateCompareResult = DateTime.Compare(this.DateOftheEvent, otherEvent.DateOftheEvent);

            foreach (char c in this.EventTitle)
            {
                int titleCompareResult = 0;
                if (dateCompareResult == 0)
                {
                    titleCompareResult = string.Compare(this.EventTitle, otherEvent.EventTitle, StringComparison.Ordinal);
                    if (titleCompareResult != 0)
                    {
                        return titleCompareResult;
                    }
                }

                int locationCompareResult = 0;
                if (titleCompareResult == 0)
                {
                    locationCompareResult = string.Compare(this.Location, otherEvent.Location, StringComparison.Ordinal);
                    if (locationCompareResult != 0)
                    {
                        return locationCompareResult;
                    }
                }
            }

            return dateCompareResult;
        }

        public override string ToString()
        {
            string form = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";

            if (this.Location != null)
            {
                form += " | {2}";
            }

            string eventAsString = string.Format(form, this.DateOftheEvent, this.EventTitle, this.Location);
            return eventAsString;
        }
    }
}
