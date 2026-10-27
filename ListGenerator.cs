
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Day_01_G03
{
    class Product : IComparable<Product>
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public int CompareTo(Product? other)
        {
            return UnitPrice.CompareTo(other?.UnitPrice);
        }

        public override string ToString()
        {
            return $"ProductID: {ProductID}, ProductName: {ProductName}, Category: {Category}, UnitPrice: {UnitPrice}, UnitsInStock: {UnitsInStock}";
        }
    }

    class Customer
    {
        public string CustomerID { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public Order[] Orders { get; set; } = Array.Empty<Order>();

        public Customer()
        {
        }

        public Customer(string customerID, string customerName)
        {
            CustomerID = customerID;
            CustomerName = customerName;
        }

        public override string ToString()
        {
            return $"{CustomerID}, {CustomerName}, {Address}, {City}, {Region}, {PostalCode}, {Country}, {Phone}, {Fax}";
        }
    }

    class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }

        public Order()
        {
        }

        public Order(int orderID, DateTime orderDate, decimal total)
        {
            OrderID = orderID;
            OrderDate = orderDate;
            Total = total;
        }

        public override string ToString()
        {
            return $"Order Id: {OrderID}, Date: {OrderDate.ToShortDateString()}, Total: {Total}";
        }
    }

    internal static class ListGenerator
    {
        public static List<Product> ProductsList { get; set; } = new List<Product>();

        public static List<Customer> CustomersList { get; set; } = new List<Customer>();

        static ListGenerator()
        {
            ProductsList = new List<Product>()
            {
                new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100 },
                new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.00M, UnitsInStock = 17 },
                new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.00M, UnitsInStock = 13 },
                new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.00M, UnitsInStock = 53 },
                new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", UnitPrice = 21.35M, UnitsInStock = 0 },
                new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25.00M, UnitsInStock = 120 },
                new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", UnitPrice = 30.00M, UnitsInStock = 15 },
                new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", UnitPrice = 40.00M, UnitsInStock = 6 },
                new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97.00M, UnitsInStock = 29 },
                new Product { ProductID = 10, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.00M, UnitsInStock = 31 },
                new Product { ProductID = 11, ProductName = "Queso Cabrales", Category = "Dairy Products", UnitPrice = 21.00M, UnitsInStock = 22 },
                new Product { ProductID = 12, ProductName = "Queso Manchego La Pastora", Category = "Dairy Products", UnitPrice = 38.00M, UnitsInStock = 86 },
                new Product { ProductID = 13, ProductName = "Konbu", Category = "Seafood", UnitPrice = 6.00M, UnitsInStock = 24 },
                new Product { ProductID = 14, ProductName = "Tofu", Category = "Produce", UnitPrice = 23.25M, UnitsInStock = 35 },
                new Product { ProductID = 15, ProductName = "Genen Shouyu", Category = "Condiments", UnitPrice = 15.50M, UnitsInStock = 39 },
                new Product { ProductID = 16, ProductName = "Pavlova", Category = "Confections", UnitPrice = 17.45M, UnitsInStock = 29 },
                new Product { ProductID = 17, ProductName = "Alice Mutton", Category = "Meat/Poultry", UnitPrice = 39.00M, UnitsInStock = 0 },
                new Product { ProductID = 18, ProductName = "Carnarvon Tigers", Category = "Seafood", UnitPrice = 62.50M, UnitsInStock = 42 },
                new Product { ProductID = 19, ProductName = "Teatime Chocolate Biscuits", Category = "Confections", UnitPrice = 9.20M, UnitsInStock = 25 },
                new Product { ProductID = 20, ProductName = "Sir Rodney's Marmalade", Category = "Confections", UnitPrice = 81.00M, UnitsInStock = 40 },
                new Product { ProductID = 21, ProductName = "Sir Rodney's Scones", Category = "Confections", UnitPrice = 10.00M, UnitsInStock = 3 },
                new Product { ProductID = 22, ProductName = "Gustaf's Knäckebröd", Category = "Grains/Cereals", UnitPrice = 21.00M, UnitsInStock = 104 },
                new Product { ProductID = 23, ProductName = "Tunnbröd", Category = "Grains/Cereals", UnitPrice = 9.00M, UnitsInStock = 61 },
                new Product { ProductID = 24, ProductName = "Guaraná Fantástica", Category = "Beverages", UnitPrice = 4.50M, UnitsInStock = 20 },
                new Product { ProductID = 25, ProductName = "NuNuCa Nuß-Nougat-Creme", Category = "Confections", UnitPrice = 14.00M, UnitsInStock = 76 },
                new Product { ProductID = 26, ProductName = "Gumbär Gummibärchen", Category = "Confections", UnitPrice = 31.23M, UnitsInStock = 15 },
                new Product { ProductID = 27, ProductName = "Schoggi Schokolade", Category = "Confections", UnitPrice = 43.90M, UnitsInStock = 49 },
                new Product { ProductID = 28, ProductName = "Rössle Sauerkraut", Category = "Produce", UnitPrice = 45.60M, UnitsInStock = 26 },
                new Product { ProductID = 29, ProductName = "Thüringer Rostbratwurst", Category = "Meat/Poultry", UnitPrice = 123.79M, UnitsInStock = 0 },
                new Product { ProductID = 30, ProductName = "Nord-Ost Matjeshering", Category = "Seafood", UnitPrice = 25.89M, UnitsInStock = 10 },
                new Product { ProductID = 31, ProductName = "Gorgonzola Telino", Category = "Dairy Products", UnitPrice = 12.50M, UnitsInStock = 0 },
                new Product { ProductID = 32, ProductName = "Mascarpone Fabioli", Category = "Dairy Products", UnitPrice = 32.00M, UnitsInStock = 9 },
                new Product { ProductID = 33, ProductName = "Geitost", Category = "Dairy Products", UnitPrice = 2.50M, UnitsInStock = 112 },
                new Product { ProductID = 34, ProductName = "Sasquatch Ale", Category = "Beverages", UnitPrice = 14.00M, UnitsInStock = 111 },
                new Product { ProductID = 35, ProductName = "Steeleye Stout", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 20 },
                new Product { ProductID = 36, ProductName = "Inlagd Sill", Category = "Seafood", UnitPrice = 19.00M, UnitsInStock = 112 },
                new Product { ProductID = 37, ProductName = "Gravad lax", Category = "Seafood", UnitPrice = 26.00M, UnitsInStock = 11 },
                new Product { ProductID = 38, ProductName = "Côte de Blaye", Category = "Beverages", UnitPrice = 263.50M, UnitsInStock = 17 },
                new Product { ProductID = 39, ProductName = "Chartreuse verte", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 69 },
                new Product { ProductID = 40, ProductName = "Boston Crab Meat", Category = "Seafood", UnitPrice = 18.40M, UnitsInStock = 123 },
                new Product { ProductID = 41, ProductName = "Jack's New England Clam Chowder", Category = "Seafood", UnitPrice = 9.65M, UnitsInStock = 85 },
                new Product { ProductID = 42, ProductName = "Singaporean Hokkien Fried Mee", Category = "Grains/Cereals", UnitPrice = 14.00M, UnitsInStock = 26 },
                new Product { ProductID = 43, ProductName = "Ipoh Coffee", Category = "Beverages", UnitPrice = 46.00M, UnitsInStock = 17 },
                new Product { ProductID = 44, ProductName = "Gula Malacca", Category = "Condiments", UnitPrice = 19.45M, UnitsInStock = 27 },
                new Product { ProductID = 45, ProductName = "Rogede sild", Category = "Seafood", UnitPrice = 9.50M, UnitsInStock = 5 },
                new Product { ProductID = 46, ProductName = "Spegesild", Category = "Seafood", UnitPrice = 12.00M, UnitsInStock = 95 },
                new Product { ProductID = 47, ProductName = "Zaanse koeken", Category = "Confections", UnitPrice = 9.50M, UnitsInStock = 36 },
                new Product { ProductID = 48, ProductName = "Chocolade", Category = "Confections", UnitPrice = 12.75M, UnitsInStock = 15 },
                new Product { ProductID = 49, ProductName = "Maxilaku", Category = "Confections", UnitPrice = 20.00M, UnitsInStock = 10 },
                new Product { ProductID = 50, ProductName = "Valkoinen suklaa", Category = "Confections", UnitPrice = 16.25M, UnitsInStock = 65 },
                new Product { ProductID = 51, ProductName = "Manjimup Dried Apples", Category = "Produce", UnitPrice = 53.00M, UnitsInStock = 20 },
                new Product { ProductID = 52, ProductName = "Filo Mix", Category = "Grains/Cereals", UnitPrice = 7.00M, UnitsInStock = 38 },
                new Product { ProductID = 53, ProductName = "Perth Pasties", Category = "Meat/Poultry", UnitPrice = 32.80M, UnitsInStock = 0 },
                new Product { ProductID = 54, ProductName = "Tourtière", Category = "Meat/Poultry", UnitPrice = 7.45M, UnitsInStock = 21 },
                new Product { ProductID = 55, ProductName = "Pâté chinois", Category = "Meat/Poultry", UnitPrice = 24.00M, UnitsInStock = 115 },
                new Product { ProductID = 56, ProductName = "Gnocchi di nonna Alice", Category = "Grains/Cereals", UnitPrice = 38.00M, UnitsInStock = 21 },
                new Product { ProductID = 57, ProductName = "Ravioli Angelo", Category = "Grains/Cereals", UnitPrice = 19.50M, UnitsInStock = 36 },
                new Product { ProductID = 58, ProductName = "Escargots de Bourgogne", Category = "Seafood", UnitPrice = 13.25M, UnitsInStock = 62 },
                new Product { ProductID = 59, ProductName = "Raclette Courdavault", Category = "Dairy Products", UnitPrice = 55.00M, UnitsInStock = 79 },
                new Product { ProductID = 60, ProductName = "Camembert Pierrot", Category = "Dairy Products", UnitPrice = 34.00M, UnitsInStock = 19 },
                new Product { ProductID = 61, ProductName = "Sirop d'érable", Category = "Condiments", UnitPrice = 28.50M, UnitsInStock = 113 },
                new Product { ProductID = 62, ProductName = "Tarte au sucre", Category = "Confections", UnitPrice = 49.30M, UnitsInStock = 17 },
                new Product { ProductID = 63, ProductName = "Vegie-spread", Category = "Condiments", UnitPrice = 43.90M, UnitsInStock = 24 },
                new Product { ProductID = 64, ProductName = "Wimmers gute Semmelknödel", Category = "Grains/Cereals", UnitPrice = 33.25M, UnitsInStock = 22 },
                new Product { ProductID = 65, ProductName = "Louisiana Fiery Hot Pepper Sauce", Category = "Condiments", UnitPrice = 21.05M, UnitsInStock = 76 },
                new Product { ProductID = 66, ProductName = "Louisiana Hot Spiced Okra", Category = "Condiments", UnitPrice = 17.00M, UnitsInStock = 4 },
                new Product { ProductID = 67, ProductName = "Laughing Lumberjack Lager", Category = "Beverages", UnitPrice = 14.00M, UnitsInStock = 52 },
                new Product { ProductID = 68, ProductName = "Scottish Longbreads", Category = "Confections", UnitPrice = 12.50M, UnitsInStock = 6 },
                new Product { ProductID = 69, ProductName = "Gudbrandsdalsost", Category = "Dairy Products", UnitPrice = 36.00M, UnitsInStock = 26 },
                new Product { ProductID = 70, ProductName = "Outback Lager", Category = "Beverages", UnitPrice = 15.00M, UnitsInStock = 15 },
                new Product { ProductID = 71, ProductName = "Flotemysost", Category = "Dairy Products", UnitPrice = 21.50M, UnitsInStock = 26 },
                new Product { ProductID = 72, ProductName = "Mozzarella di Giovanni", Category = "Dairy Products", UnitPrice = 34.80M, UnitsInStock = 14 },
                new Product { ProductID = 73, ProductName = "Röd Kaviar", Category = "Seafood", UnitPrice = 15.00M, UnitsInStock = 101 },
                new Product { ProductID = 74, ProductName = "Longlife Tofu", Category = "Produce", UnitPrice = 10.00M, UnitsInStock = 4 },
                new Product { ProductID = 75, ProductName = "Rhönbräu Klosterbier", Category = "Beverages", UnitPrice = 7.75M, UnitsInStock = 125 },
                new Product { ProductID = 76, ProductName = "Lakkalikööri", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 57 },
                new Product { ProductID = 77, ProductName = "Original Frankfurter grüne Soße", Category = "Condiments", UnitPrice = 13.00M, UnitsInStock = 32 }
            };

            string xmlPath = Path.Combine(AppContext.BaseDirectory, "Customers.xml");

            if (!File.Exists(xmlPath))
            {
                throw new FileNotFoundException(
                    "Customers.xml was not found. Add the file to the project and set Copy to Output Directory to Copy if newer.",
                    xmlPath);
            }

            try
            {
                XDocument document = XDocument.Load(xmlPath);

                if (document.Root == null)
                {
                    throw new XmlException("Customers.xml has no root element.");
                }

                CustomersList = (
                    from e in document.Root.Elements("customer")
                    select new Customer()
                    {
                        CustomerID = (string?)e.Element("id") ?? string.Empty,
                        CustomerName = (string?)e.Element("name") ?? string.Empty,
                        Address = (string?)e.Element("address") ?? string.Empty,
                        City = (string?)e.Element("city") ?? string.Empty,
                        Region = (string?)e.Element("region") ?? string.Empty,
                        PostalCode = (string?)e.Element("postalcode") ?? string.Empty,
                        Country = (string?)e.Element("country") ?? string.Empty,
                        Phone = (string?)e.Element("phone") ?? string.Empty,
                        Fax = (string?)e.Element("fax") ?? string.Empty,
                        Orders = (
                            from o in e.Elements("orders").Elements("order")
                            select new Order()
                            {
                                OrderID = (int?)o.Element("id") ?? 0,
                                OrderDate = (DateTime?)o.Element("orderdate") ?? DateTime.MinValue,
                                Total = (decimal?)o.Element("total") ?? 0
                            }).ToArray()
                    }).ToList();
            }
            catch (XmlException ex)
            {
                throw new InvalidOperationException(
                    $"Customers.xml is not valid XML. Check the file contents. Details: {ex.Message}", ex);
            }
        }
    }
}
