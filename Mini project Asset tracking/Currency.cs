using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking
{
    public class Currency
    {
        public Currency(string name, string symbol, string country, double exchangeFactor)
        {
            Name = name;
            Symbol = symbol;
            Country = country;
            ExchangeFactor = exchangeFactor;

            //currencies.Add(this);
        }

        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Country { get; set; }
        public double ExchangeFactor { get; set; }

        public double toDollar(double amount)
        {
            return amount / ExchangeFactor;
        }

        public double fromDollar(double dollarAmount)
        {
            return dollarAmount * ExchangeFactor;
        }

        public static List<Currency> currencies = new List<Currency>
        {
            new Currency("Danish Crown", "DKK", "Denmark", 6.5),
            new Currency("Swedish Crown", "SEK", "Sweden", 9.5),
            new Currency("US Dollar", "$", "USA", 1.2),
            new Currency("UK Pound", "£", "England", 0.8),
            new Currency("Euro", "EUR", "EU", 0.9)
        };
    }
}

// By Ole Victor