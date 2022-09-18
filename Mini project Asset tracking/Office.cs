using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking
{
    public class Office
    {
        // The office class handles officies and their countries
        public Office(string name, string country)
        {
            Name = name;
            Country = country;
            // The currency is determined from the country
            Currency = Currency.currencies.Find(x => x.Country == Country);
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public Currency Currency { get; set; }

        // A list of all available offices
        public static List<Office> OfficeList = new List<Office>
        {
            new Office("Malmö", "Sweden"),
            new Office("Copenhagen", "Denmark"),
            new Office("New York", "USA"),
            new Office("London", "England"),
            new Office("Paris", "EU"),
            new Office("Berlin", "EU")
        };
}
}

// By Ole Victor