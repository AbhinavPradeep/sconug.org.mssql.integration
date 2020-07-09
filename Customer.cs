using System;
using System.Collections.Generic;

namespace sconug.org.mssql.integration
{
    public class Customer
    {
        public Customer()
        {
            Address = new Address();
            CustomerEventTags = new List<CustomerEventTag>();
            CustomerEvents = new List<CustomerEvent>();
        }
        public string CustomerID { get; set; }
        public string EmailID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ProfileImageUrl { get; set; }
        public Address Address { get; set; }
        public bool IsVerified { get; set; }
        public List<CustomerEventTag> CustomerEventTags {get;set;}
        public List<CustomerEvent> CustomerEvents {get;set;}
    }
}