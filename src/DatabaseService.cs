using Bogus;

namespace DotnetWorkshop
{
    internal class DatabaseService
    {

        private IEnumerable<Customer> customers;
        IEnumerable<Customer> AllCustomers
        {
            get
            {
                if (customers == null)
                {
                    var customerFaker = new Faker<Customer>()
                      .RuleFor(c => c.CompanyName, f => f.Company.CompanyName())
                      .RuleFor(c => c.ContactName, f => f.Name.FullName())
                      .RuleFor(c => c.Phone, f => f.Phone.PhoneNumberFormat())
                      .RuleFor(c => c.Email, f => f.Internet.Email())
                      .RuleFor(c => c.Country, f => f.Address.Country())
                      .RuleFor(c => c.Id, f => f.IndexFaker + 1) // Ensure unique IDs starting from 1
                      .RuleFor(c => c.Revenue, f => f.Finance.Amount(10, 2000));
                    customers = customerFaker.Generate(1000);
                }
                return customers;
            }
        }

        internal IEnumerable<Customer> GetAllCustomers()
        {
            return AllCustomers;
        }

        internal IEnumerable<int> GetAllIds()
        {
            return AllCustomers.Select(c => c.Id);
        }
        internal Customer GetCustomer(int id)
        {
            // Simulate fetching data from a database
            Thread.Sleep(5); // Simulate delay
            return AllCustomers.FirstOrDefault(c => c.Id == id);
        }

        internal class Customer
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string Phone { get; set; }
            public string Country { get; set; }
            public decimal Revenue { get; set; }
        }
    }


}
