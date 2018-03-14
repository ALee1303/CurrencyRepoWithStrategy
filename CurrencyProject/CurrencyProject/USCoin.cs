using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    public enum USCoinMintMark { D, P, S, W };

    [Serializable]
    public abstract class USCoin : Coin
    {
        public USCoinMintMark MintMark { get; }

        public USCoin() : base()
        {
            Name = "US ";
        }
        public USCoin(USCoinMintMark mint) : this()
        {
            MintMark = mint;
        }
        protected USCoin(SerializationInfo info, StreamingContext context) : base(info, context)
        { }

        public override string About()
        {
            return string.Format($"{Name} is from {Year}. It is worth ${MonetaryValue}. It was made in {GetMintNameFromMark(MintMark)}");
        }

        public static string GetMintNameFromMark(USCoinMintMark mintMark)
        {
            switch (mintMark)
            {
                case USCoinMintMark.P:
                    return string.Format("Philadephia");
                case USCoinMintMark.D:
                    return string.Format("Denver");
                case USCoinMintMark.S:
                    return string.Format("San Francisco");
                case USCoinMintMark.W:
                    return string.Format("West Point");
                default:
                    return string.Format("Unknown");
            }
        }
    }
}