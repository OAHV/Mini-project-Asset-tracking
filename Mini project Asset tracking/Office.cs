using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking
{
    internal class Office
    {
        public Office(string name, string country, Currency currency)
        {
            Name = name;
            Country = country;
            Currency = currency;
        }

        string Name { get; set; }
        string Country { get; set; }
        Currency Currency { get; set; }
    }
}

// By Ole Victor