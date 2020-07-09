using System;
using System.Collections.Generic;

namespace sconug.org.mssql.integration
{
    public class Address
    {
        public Address()
        {
            Customers = new List<Customer>();
        }
        public string AddressID { get; set; }
        public int HouseNum { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public List<Customer> Customers{get;set;}
    }
}
