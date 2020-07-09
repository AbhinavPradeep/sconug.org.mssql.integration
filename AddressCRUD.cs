using System.Linq;

namespace sconug.org.mssql.integration
{
    public class AddressCRUD
    {
        public void CreateAddress(Address Address)
        {
            var context = new CustomerContext();
            context.Addresses.Add(Address);
            context.SaveChanges();
        }
        public void DeleteAddress(string AddressID)
        {
            var context = new CustomerContext();
            var Address = context.Addresses.Where(Address => Address.AddressID == AddressID).SingleOrDefault();
            context.Addresses.Remove(Address);
            context.SaveChanges();
        }
        public Address ReadAddress(string AddressID)
        {
            var context = new CustomerContext();
            var Address = context.Addresses.Where(Address => Address.AddressID == AddressID).SingleOrDefault();
            context.SaveChanges();
            return Address;
        }
        public void UpdateAddress(Address Address)
        {
            var context = new CustomerContext();
            string AddressID = Address.AddressID;
            Address ToBeUpdated = context.Addresses.Where(Address => Address.AddressID == AddressID).SingleOrDefault();
            ToBeUpdated = Address;
            context.Addresses.Update(ToBeUpdated);
            context.SaveChanges();
        }
    }
}