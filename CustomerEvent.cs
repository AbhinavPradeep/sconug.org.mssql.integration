using System;
using System.Collections.Generic;

namespace sconug.org.mssql.integration
{
    public class CustomerEvent
    {
        public string CustomerID {get;set;}
        public Customer Customer {get;set;}
        public string EventID {get;set;}
        public Event Event {get;set;}
    }
}