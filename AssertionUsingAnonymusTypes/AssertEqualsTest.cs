using System;
using System.Collections.Generic;
using System.Linq;
using AssertionUsingAnonymousTypes.TestClasses;
using NUnit.Framework;

namespace AssertionUsingAnonymousTypes
{
    [TestFixture]
    public class AssertEqualsTest
    {
        [Test]
        public void GetAllCustomers_CustomersNameAndCountryAsExpectedSimple()
        {
            var result = GetAllCustomers();

            var resultAsAnonymous = result.Select(customer =>
                new {
                    customer.Name, 
                    Address = new
                    {
                        customer.Address.Country
                    }
                }); 
            
            var expected = new[]
            {
                new {Name = "Nathan Salazar", Address = new {Country = "US"}},
                new {Name = "Lani Decker", Address = new {Country = "UK"}},
                new {Name = "Wade wrong", Address = new {Country = "France"}},
                new {Name = "Sonia Page", Address = new {Country = "US"}},
            };

            CollectionAssert.AreEqual(expected, resultAsAnonymous);
        }

        
        [Test]
        public void GetAllCustomers_CustomersNameAndCountryAsExpected()
        {
            var result = GetAllCustomers();
            
            var expected = new[]
            {
                new {Name = "Nathan Salazar", Address = new {Country = "US"}},
                new {Name = "Lani Decker", Address = new {Country = "UK"}},
                new {Name = "Wade wrong", Address = new {Country = "France"}},
                new {Name = "Sonia Page", Address = new {Country = "US"}},
            };

            result.AssertEqualTo(expected);
        }

        private static IEnumerable<Customer> GetAllCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Nathan Salazar",
                    Address = new Address
                    {
                        StreetAddress = "43 Compare Valley",
                        City = "Chambersburg",
                        State = "PA",
                        ZipCode = 17201,
                        Country = "US",
                    },
                    EmailAddress = "arcu.Aliquam@ipsumleoelementum.com",
                    TelephoneNumber = "717-261-7855",
                    Birthday = Convert.ToDateTime("1-May-84"),
                    Occupation = "Traffic technician",
                    Domain = "ScottsdaleSkincare.com",
                },
                new Customer
                {
                    Id = 2,
                    Name = "Lani Decker",
                    Address = new Address
                    {
                        StreetAddress = "2493 Chapmans Lane",
                        City = "Albuquerque",
                        State = "NM",
                        ZipCode = 87109,
                        Country = "UK",
                    },
                    EmailAddress = "nisi@laoreet.com",
                    TelephoneNumber = "505-823-9031",
                    Birthday = Convert.ToDateTime("10-Oct-69"),
                    Occupation = "Lobby attendant",
                    Domain = "DigitClub.com",
                },
                new Customer
                {
                    Id = 3,
                    Name = "Wade Guerr",
                    Address = new Address
                    {
                        StreetAddress = "4612 Lakewood Drive",
                        City = "Rochelle Park",
                        State = "NJ",
                        ZipCode = 7662,
                        Country = "France",
                    },
                    EmailAddress = "euismod@utaliquam.co.uk",
                    TelephoneNumber = "201-881-8239",
                    Birthday = Convert.ToDateTime("2-Jun-73"),
                    Occupation = "Dermatologist",
                    Domain = "BuyingTVs.com",
                },
                new Customer
                {
                    Id = 4,
                    Name = "Sonia Page",
                    Address = new Address
                    {
                        StreetAddress = "4652 Sardis Sta",
                        City = "Reno (Parker)",
                        State = "TX",
                        ZipCode = 76020,
                        Country = "US",
                    },
                    EmailAddress = "dignissim.tempor@Donecdignissim.org",
                    TelephoneNumber = "817-677-2247",
                    Birthday = Convert.ToDateTime("29-Feb-72"),
                    Occupation = "Clinical laboratory technician",
                    Domain = "BetLimit.com",
                }
            };
        }
    }
}