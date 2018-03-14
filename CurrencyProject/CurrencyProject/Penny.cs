using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    [Serializable]
    public class Penny : USCoin
    {
        public Penny(USCoinMintMark mint)  : base(mint)
        {
            Name += "Penny";
            MonetaryValue = 0.01;
        }
        public Penny() : this(0)
        { }
        protected Penny(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
