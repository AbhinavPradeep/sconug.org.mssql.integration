using System;
using System.Collections.Generic;

namespace sconug.org.mssql.integration
{
    public class EventTag
    {
        public EventTag()
        {
            CustomerEventTags = new List<CustomerEventTag>();
            EventEventTags = new List<EventEventTag>();
        }
        public string EventTagID { get; set; }
        public string Description { get; set; }
        public List<CustomerEventTag> CustomerEventTags{get;set;}
        public List<EventEventTag> EventEventTags {get;set;}
    }
}
