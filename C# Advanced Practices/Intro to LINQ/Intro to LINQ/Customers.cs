using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Intro_to_LINQ
{
    public static class Customers
    {
        private static string customersXml = System.IO.File.ReadAllText("Customers.xml");

        public static List<Customer> CustomerList { get; } =
            (from e in XDocument.Parse(customersXml).Root.Elements("customer")
             select new Customer
             {
                 CustomerID = (string)e.Element("id"),
                 CompanyName = (string)e.Element("name"),
                 Address = (string)e.Element("address"),
                 City = (string)e.Element("city"),
                 Region = (string)e.Element("region"),
                 PostalCode = (string)e.Element("postalcode"),
                 Country = (string)e.Element("country"),
                 Phone = (string)e.Element("phone"),
                 Orders = (
                    from o in e.Elements("orders").Elements("order")
                    select new Order
                    {
                        OrderID = (int)o.Element("id"),
                        OrderDate = (DateTime)o.Element("orderdate"),
                        Total = (decimal)o.Element("total")
                    }).ToArray()
             }).ToList();
    }
}