using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    public interface ICurrency
    {
        double MonetaryValue { get; }
        string Name { get; }

        string About();
    }
    
    public interface ICoin : ICurrency
    {
        int Year { get; }
    }

    public interface IBankNote : ICurrency
    {
        int Year { get; }
    }
}
