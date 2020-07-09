using System;
using System.Linq;

namespace sconug.org.mssql.integration
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressCRUD addressCRUD = new AddressCRUD();
            CustomerCRUD customerCRUD = new CustomerCRUD();
            CustomerContext context = new CustomerContext();
            context.Database.EnsureCreated();

            customerCRUD.DeleteCustomer("WEFDR");
            addressCRUD.DeleteAddress("JFBBVMD");

            Address AbhiAddress = CreateAddress();
            Customer Abhi = CreateCustomer();
            Abhi.Address = AbhiAddress;


            customerCRUD.CreateCustomer(Abhi);

            Customer ReturnedAbhi = customerCRUD.ReadCustomer("WEFDR");
            System.Console.WriteLine(ReturnedAbhi.Password);
            System.Console.WriteLine(ReturnedAbhi.EmailID);
            System.Console.WriteLine(ReturnedAbhi.UserName);



            // Customer UpdatedAbhi = new Customer();
            // UpdatedAbhi.CustomerID = "WESDR";
            // UpdatedAbhi.EmailID = "abhinav.pradeep@gmail.com";
            // UpdatedAbhi.IsVerified = false;
            // UpdatedAbhi.Password = "D1@m0nds";
            // UpdatedAbhi.UserName = "Abhi";
            // crud.UpdateCustomer(UpdatedAbhi);
            // Customer ToPrintAbhi = crud.ReadCustomer("WESDR");
            // System.Console.WriteLine($"Updated Password = {ToPrintAbhi.Password}");
            // crud.DeleteCustomer("WESDR");
        }

        private static Customer CreateCustomer()
        {
            Customer Abhi = new Customer()
            {
                CustomerID = "WEFDR",
                EmailID = "abhinav.pradeep@gmail.com",
                IsVerified = false,
                Password = "QWERTY",
                UserName = "Abhi"
            };

            return Abhi;
        }

        private static Address CreateAddress()
        {
            Address AbhiAddress = new Address()
            {
                AddressID = "JFBBVMD",
                HouseNum = 91,
                StreetName = "Bendall Way",
                State = "QLD",
                Suburb = "Harmony"
            };

            return AbhiAddress;
        }
    }
}
