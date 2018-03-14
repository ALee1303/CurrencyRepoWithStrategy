using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    [Serializable]
    public class Nickel : USCoin
    {
        public Nickel(USCoinMintMark mint)  : base(mint)
        {
            Name += "Nickel";
            MonetaryValue = 0.05;
        }
        public Nickel() : this(0)
        { }
        protected Nickel(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
