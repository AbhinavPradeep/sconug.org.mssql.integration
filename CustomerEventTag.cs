using System;
using System.Collections.Generic;

namespace sconug.org.mssql.integration
{
    public class CustomerEventTag
    {
        public string CustomerID {get;set;}
        public Customer Customer {get;set;}
        public string EventTagID {get;set;}
        public EventTag EventTag {get;set;}
    }
}