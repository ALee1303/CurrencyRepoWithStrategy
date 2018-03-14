using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    public class USCurrencyRepo : ICurrencyRepo
    {
        public List<ICoin> Coins { get; private set; }

        public List<ICoin> CurrencyList { get { return orderedCoins(); } }

        public USCurrencyRepo() : this(new List<ICoin>())
        {
        }
        public USCurrencyRepo(List<ICoin> Coins)
        {
            this.Coins = Coins;
        }

        public string About()
        {
            return "";
        }

        public void AddCoin(ICoin c)
        {
            Coins.Add(c);
        }

        public int GetCoinCount()
        {
            return Coins.Count();
        }

        public static List<ICoin> orderedCoins()
        {
            List<ICoin> coinList = new List<ICoin>
            {
                { new Penny() },
                { new Nickel() },
                { new Dime() },
                { new Quarter() },
                { new HalfDollar() },
                { new DollarCoin() }
            };

            return coinList.OrderByDescending(c => c.MonetaryValue).ToList();
        }


        public static ICurrencyRepo CreateChange(double Amount)
        {
            ICurrencyRepo returnedChagne = new USCurrencyRepo();
            for (double chng = Amount; chng > 0.00;)
            {
                if (chng >= 1.00)
                {
                    returnedChagne.AddCoin(new DollarCoin());
                    chng -= 1.00;
                }
                else if (chng >= 0.50)
                {
                    returnedChagne.AddCoin(new HalfDollar());
                    chng -= 0.50;
                }
                else if (chng >= 0.25)
                {
                    returnedChagne.AddCoin(new Quarter());
                    chng -= 0.25;
                }
                else if (chng >= 0.10)
                {
                    returnedChagne.AddCoin(new Dime());
                    chng -= 0.10;
                }
                else if (chng >= 0.05)
                {
                    returnedChagne.AddCoin(new Nickel());
                    chng -= 0.05;
                }
                else
                {
                    returnedChagne.AddCoin(new Penny());
                    chng -= 0.01;
                }
            }
            return returnedChagne;
        }

        public static ICurrencyRepo CreateChange(double AmountTendered, double TotalCOst)
        {
            return CreateChange(AmountTendered - TotalCOst);
        }

        public ICurrencyRepo MakeChange(double Amount)
        {
            ICurrencyRepo newChange = new USCurrencyRepo();

            Decimal amount = (Decimal)Amount;

            List<ICoin> changeReference = orderedCoins();

            foreach (ICoin c in changeReference)
                while (amount >= (Decimal)c.MonetaryValue)
                {
                    newChange.AddCoin(c);
                    amount -= (Decimal)c.MonetaryValue;
                }
            return newChange;
        }

        public ICurrencyRepo MakeChange(double AmountTendered, double TotalCOst)
        {
            ICurrencyRepo newChange = new USCurrencyRepo();

            double toChange = AmountTendered - TotalCOst;

            newChange = MakeChange(toChange);

            return newChange;
        }

        public ICurrencyRepo Reduce()
        {
            ICurrencyRepo reduced = this.MakeChange(this.TotalValue());
            return reduced;
        }

        public ICoin RemoveCoin(ICoin c)
        {
            Coins.Remove(c);
            return c;
        }

        public double TotalValue()
        {
            double value = new double();
            foreach(ICoin c in Coins)
            {
                value += c.MonetaryValue;
            }
            return value;
        }
    }
}
