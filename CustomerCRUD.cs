using System.Linq;

namespace sconug.org.mssql.integration
{
    public class CustomerCRUD
    {
        public void CreateCustomer(Customer customer)
        {
            using( var context = new CustomerContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }
        public void DeleteCustomer(string CustomerID)
        {
            var context = new CustomerContext();
            var customer = context.Customers.Where(customer => customer.CustomerID == CustomerID).SingleOrDefault();
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
        public Customer ReadCustomer(string CustomerID)
        {
            using (var context = new CustomerContext())
            {
                var customer = context.Customers.Where(customer => customer.CustomerID == CustomerID).SingleOrDefault();
                context.SaveChanges();
                return customer;
            }
        }
        public void UpdateCustomer(Customer customer)
        {
            var context = new CustomerContext();
            string CustomerID = customer.CustomerID;
            Customer ToBeUpdated = context.Customers.Where(customer => customer.CustomerID == CustomerID).SingleOrDefault();
            ToBeUpdated = customer;
            context.Customers.Update(ToBeUpdated);
            context.SaveChanges();
        }
    }
}