using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    public class WindowUSCurrencyRepo : USCurrencyRepo
    {
        public string Path { get; private set; }

        public WindowUSCurrencyRepo(List<ICoin> Coins) : base(Coins)
        {
            Path = "MyFile.bin";
        }

        public bool Save()
        {
            if (Path == null)
                return false;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(this.Path,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Coins);
            stream.Close();
            return true;

        }

        public ICollection<ICoin> Load()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Path,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            List<ICoin> coins = (List<ICoin>)formatter.Deserialize(stream);
            stream.Close();
            return coins;
        }
    }
}
