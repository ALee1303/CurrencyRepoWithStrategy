using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    [Serializable]
    public class DollarCoin : USCoin
    {
        public DollarCoin(USCoinMintMark mint)  : base(mint)
        {
            Name += "DollarCoin";
            MonetaryValue = 1.00;
        }
        public DollarCoin() : this(0)
        { }
        protected DollarCoin(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
