using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking
{
    public class Office
    {
        public Office(string name, string country)
        {
            Name = name;
            Country = country;
            Currency = Currency.currencies.Find(x => x.Country == Country);
            //Currency = Currency.currencies[1];
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public Currency Currency { get; set; }

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