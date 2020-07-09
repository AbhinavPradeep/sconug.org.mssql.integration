using System;
using System.Collections.Generic;

namespace sconug.org.mssql.integration
{
    public class EventEventTag
    {
        public string EventID {get;set;}
        public Event Event {get;set;}
        public string EventTagID {get;set;}
        public EventTag EventTag {get;set;}
    }
}