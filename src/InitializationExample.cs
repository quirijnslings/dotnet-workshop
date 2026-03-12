using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop;

public class InitializationExample : ICodingExample
{

    public string Name => "Initialization";

    public bool IsAsync => false;

    public void Run()
    {
        Console.WriteLine("Please view the code (InitializationExample)");
        var customer = new Customer
        {
            Name = "John Doe",
            CreationDate = DateTime.Now,
            Address = new Address
            {
                Street = "123 Main St",
                City = "Anytown",
                State = "CA",
                ZipCode = "12345",
                Country = "USA"
            },
            Purchases = new List<Purchase>
            {
                new Purchase { ProductName = "Laptop", Price = 999.99m, PurchaseDate = DateTime.Now.AddDays(-10) },
                new Purchase { ProductName = "Mouse", Price = 25.50m, PurchaseDate = DateTime.Now.AddDays(-5) }
            }
        };

        var customer2 = new Customer
        {
            Name = "Jane Doe",
            CreationDate = DateTime.Now,
            Address = new Address
            {
                Street = "123 Main St",
                City = "Anytown",
                State = "CA",
                ZipCode = "12345",
                Country = "USA"
            },
            Purchases = [
                new Purchase { ProductName = "Laptop", Price = 999.99m, PurchaseDate = DateTime.Now.AddDays(-10) },
                new Purchase { ProductName = "Mouse", Price = 25.50m, PurchaseDate = DateTime.Now.AddDays(-5) }
            ]
        };

        IDictionary<int, Product> catalog = new Dictionary<int, Product>
        {
            [1] = new Product { Id = 1, Name = "Laptop", Price = 999.99m, Stock = 10 },
            [2] = new Product { Id = 2, Name = "Mouse", Price = 25.50m, Stock = 100 }
        };


    }

    public Task RunAsync()
    {
        throw new NotImplementedException();
    }

    public class Customer
    {
        public string? Name { get; set; }
        public decimal Revenue => Purchases?.Sum(p => p.Price) ?? 0m;
        public DateTime CreationDate { get; set; }
        public Address? Address { get; set; }
        public IEnumerable<Purchase>? Purchases { get; set; }
    }

    public class Purchase
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
