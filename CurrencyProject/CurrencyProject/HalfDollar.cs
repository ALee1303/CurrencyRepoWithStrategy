using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    [Serializable]
    public class HalfDollar : USCoin
    {
        public HalfDollar(USCoinMintMark mint)  : base(mint)
        {
            Name += "HalfDollar";
            MonetaryValue = 0.50;
        }
        public HalfDollar() : this(0)
        { }
        protected HalfDollar(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
