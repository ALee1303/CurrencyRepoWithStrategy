using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    [Serializable]
    public class Quarter : USCoin
    {
        public Quarter(USCoinMintMark mint)  : base(mint)
        {
            Name += "Quarter";
            MonetaryValue = 0.25;
        }
        public Quarter() : this(0)
        { }
        protected Quarter(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
