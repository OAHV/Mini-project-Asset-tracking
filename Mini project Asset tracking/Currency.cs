using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking
{
    internal class Currency
    {
        public Currency(string name, string symbol, string country, double exchangeFactor)
        {
            Name = name;
            Symbol = symbol;
            Country = country;
            ExchangeFactor = exchangeFactor;
        }

        string Name { get; set; }
        string Symbol { get; set; }
        string Country { get; set; }
        double ExchangeFactor { get; set; }

        double toDollar(double amount)
        {
            return ExchangeFactor * amount;
        }

        double fromDollar(double dollarAmount)
        {
            return dollarAmount / ExchangeFactor;
        }

    }
}
