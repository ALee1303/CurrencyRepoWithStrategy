using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    public interface ICurrencyRepo
    {
        List<ICoin> Coins { get; }

        string About();
        void AddCoin(ICoin c);
        int GetCoinCount();
        ICurrencyRepo MakeChange(double Amount);
        ICurrencyRepo MakeChange(double AmountTendered, double TotalCOst);
        ICurrencyRepo Reduce();
        ICoin RemoveCoin(ICoin c);
        double TotalValue();
    }
}
