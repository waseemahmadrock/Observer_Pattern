using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication55
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock pakola = new Pakola("Pakola", 120.00);
            pakola.Attach(new Investor("Raju"));
            pakola.Attach(new Investor("Shaam"));

            pakola.Price = 120.10;
            pakola.Price = 121.00;
            pakola.Price = 120.50;
            pakola.Price = 120.75;
        }

        abstract class Stock
        {
            private string _symbol;
            private double _price;
            private List<IInvestor> _investors = new List<IInvestor>();

            public Stock(string symbol, double price)
            {
                this._symbol = symbol;
                this._price = price;
            }

            public void Attach(IInvestor investor)
            {
                _investors.Add(investor);
            }

            public void Detach(IInvestor investor)
            {
                _investors.Remove(investor);
            }

            public void Notify()
            {
                foreach (IInvestor investor in _investors)
                {
                    investor.Update(this);
                }

                Console.WriteLine("");
            }

            public double Price
            {
                get { return _price; }
                set
                {
                    if (_price != value)
                    {
                        _price = value;
                        Notify();
                    }
                }
            }

            public string Symbol
            {
                get { return _symbol; }
            }
        }


        class Pakola : Stock
        {
            public Pakola(string symbol, double price)
                : base(symbol, price)
            {
            }
        }

        interface IInvestor
        {
            void Update(Stock stock);
        }


        class Investor : IInvestor
        {
            private string _name;
            private Stock _stock;

            public Investor(string name)
            {
                this._name = name;
            }

            public void Update(Stock stock)
            {
                Console.WriteLine("Notified {0} of {1}'s " +
                  "change to Rs. {2}", _name, stock.Symbol, stock.Price);
            }

            public Stock Stock
            {
                get { return _stock; }
                set { _stock = value; }
            }
        }
    }
}
