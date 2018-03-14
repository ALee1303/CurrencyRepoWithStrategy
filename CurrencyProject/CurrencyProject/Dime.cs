using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    [Serializable]
    public class Dime : USCoin
    {
        public Dime(USCoinMintMark mint)  : base(mint)
        {
            Name += "Dime";
            MonetaryValue = 0.10;
        }
        public Dime() : this(0)
        { }
        protected Dime(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
