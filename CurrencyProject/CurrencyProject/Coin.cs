using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    [Serializable]
    public abstract class Coin : ICoin, ISerializable
    {
        public double MonetaryValue { get; protected set; }
        public string Name { get; protected set; }
        public int Year { get; protected set; }

        public Coin()
        { Year = 2017; }

        protected Coin(SerializationInfo info, StreamingContext context)
        {
            MonetaryValue = info.GetDouble("MonetaryValue");
            Name = info.GetString("Name");
            Year = info.GetInt32("Year");
        }

        public virtual string About()
        {
            return "";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MonetaryValue", MonetaryValue);
            info.AddValue("Name", Name);
            info.AddValue("Year", Year);
        }

        public override bool Equals(object other)
        {
            var toCompareWith = other as Coin;
            if (toCompareWith == null)
                return false;
            return this.MonetaryValue == toCompareWith.MonetaryValue &&
                this.Name == toCompareWith.Name &&
                this.Year == toCompareWith.Year;
        }

        //public override int GetHashCode()
        //{
        //    return this.GetHashCode();
        //}
    }
}
