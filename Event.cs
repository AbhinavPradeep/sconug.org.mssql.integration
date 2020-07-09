using System;
using System.Collections.Generic;

namespace sconug.org.mssql.integration
{
    public class Event
    {
        public Event()
        {
            address = new Address();
            EventEventTags = new List <EventEventTag> ();
            CustomerEvents = new List <CustomerEvent> ();
        }
        public string EventID { get; set; }
        public string Description { get; set; }
        public Address address { get; set; }
        public List<EventEventTag> EventEventTags {get;set;}
        public List<CustomerEvent> CustomerEvents {get;set;}
    }
}
